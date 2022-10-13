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

namespace Loan_system.Employee_Module
{
    public partial class dash_transaction : Form
    {
        public string mycon = connection.ipconnection;
        public dash_transaction()
        {
            InitializeComponent();
        }
        public void showTransactions() {
            try
            {

                string query = "SELECT transactions.recipt_no AS 'Recipt No.',client.name AS 'Client Name',transactions.amount AS'Amount Paid',transactions.payment_date AS 'Day of Payment',transactions.added_by AS 'Added By' from transactions INNER JOIN client ON transactions.client_id=client.client_id " +
                    "where  concat(client.name,transactions.added_by,transactions.recipt_no)  LIKE '%" + textBox1.Text+"%' ORDER BY payment_date DESC ;";
                MySqlConnection conn = new MySqlConnection(mycon);
                MySqlCommand mycommand = new MySqlCommand(query, conn);

                MySqlDataAdapter myadapter = new MySqlDataAdapter();
                myadapter.SelectCommand = mycommand;
                DataTable table = new DataTable();
                dtable.DataSource = table;
                myadapter.Fill(table);







            }
            catch (Exception ex) {
                //MessageBox.Show(ex.Message);
            }
          


        }

       

        private void dash_transaction_Load(object sender, EventArgs e)
        {
            showTransactions();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            showTransactions();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_pay_Click(object sender, EventArgs e)
        {
            if (dtable.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "transaction-Report.pdf";
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
                                title.Add("\n Transaction-Report\n\n");


                                pdfDoc.Open();
                                pdfDoc.Add(title);
                            

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

