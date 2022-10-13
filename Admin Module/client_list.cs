using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loan_system.Admin_Module
{
    public partial class client_list : Form
    {
        public String mycon = connection.ipconnection;
        public client_list()
        {
            InitializeComponent();
        }
        void showallData()
        {


            try
            {

                string query = "SELECT client.client_id,client.name AS 'Client Name',client.contact AS 'Contact No.',client.total_payment AS 'Total Loan',client.Legend AS 'Paid/Unpaid',SUM(transactions.amount) AS 'Balance 'FROM `client` INNER JOIN transactions ON client.client_id=transactions.client_id where concat(client.name,client.client_id,client.Legend)  LIKE '%" + txt_srch.Text + "%' and client.legend='" + comboBox1.Text + "'GROUP BY transactions.client_id;";
                MySqlConnection conn = new MySqlConnection(mycon);
                MySqlCommand mycommand = new MySqlCommand(query, conn);

                MySqlDataAdapter myadapter = new MySqlDataAdapter();
                myadapter.SelectCommand = mycommand;
                DataTable table = new DataTable();
                dtable.DataSource = table;
                myadapter.Fill(table);




            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

        }

        private void client_list_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 1;
            showallData();
            
        }

        private void txt_srch_TextChanged(object sender, EventArgs e)
        {
            showallData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            showallData();
        }

        private void btn_pay_Click(object sender, EventArgs e)
        {
            if (dtable.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Daily-Report.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(dtable.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in dtable.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dtable.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    pdfTable.AddCell(cell.Value.ToString());
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                // title
                                Paragraph title = new Paragraph();
                                title.Alignment = Element.ALIGN_CENTER;
                                title.Font = FontFactory.GetFont("Arial", 25);
                                title.Add("\nDaily-Report\n\n");


                                Paragraph legend = new Paragraph();
                                legend.Alignment = Element.ALIGN_RIGHT;
                                legend.Font = FontFactory.GetFont("Arial", 12);
                                legend.Add("\n" + comboBox1.Text + "Record\n\n");

                                pdfDoc.Open();
                                pdfDoc.Add(title);
                                pdfDoc.Add(legend);

                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Data Exported Successfully !!!", "3RCJ LENDING CORPORATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
        }
    }
    }

