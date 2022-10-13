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
   
    public partial class Daily_report : Form
    {
        public string mycon = connection.ipconnection;
        string uName = Loginform.name;
        public Daily_report()
        {
            InitializeComponent();
        }
        public void getExpectedCollection() {
            try
            {
                string query = "SELECT SUM(client.daily_payment) as payment FROM client where Legend='Unpaid'";
                MySqlConnection con = new MySqlConnection(mycon);
                MySqlCommand mycommand = new MySqlCommand(query, con);
                MySqlDataReader myreader1;
                con.Open();
                myreader1 = mycommand.ExecuteReader();
                if (myreader1.Read())
                {

                    string expectedCollection = myreader1.GetString("payment");
                   
                        lbl_expectedPayment.Text = "₱ " + expectedCollection;
                    }
                  
                
                
                else {
                
                }


            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }


        }
        public void getTotalCollection()
        {
            try
            {
                string query = "SELECT SUM(transactions.amount)as Total_Daily_Transaction FROM `transactions` WHERE transactions.payment_date=CURRENT_DATE ";
                MySqlConnection con = new MySqlConnection(mycon);
                MySqlCommand mycommand = new MySqlCommand(query, con);
                MySqlDataReader myreader1;
                con.Open();
                myreader1 = mycommand.ExecuteReader();
                if (myreader1.Read())
                {

                    string totalDailyTransaction = myreader1.GetString("Total_Daily_Transaction");
                    lbl_Collection.Text = "₱ " + totalDailyTransaction;
                }
                else { 
                
                }
            }
            catch (Exception ex)
            {
              
            }
        }
        public void getDataTable() {
          

                try
                {

                    string query = "SELECT transactions.recipt_no as 'Recipt No.',client.name as 'Clients',client.daily_payment as 'Unpaid amount',transactions.payment_date as 'Date of Payment',transactions.added_by as 'Added by' FROM `transactions` INNER JOIN client ON transactions.client_id=client.client_id WHERE payment_date=CURRENT_DATE and amount=0";

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
                   // MessageBox.Show(ex.Message);
                }

            












        }
        public void getPaid() {


            try
            {

                string query = "SELECT transactions.recipt_no as 'Recipt No.',client.name as 'Clients',transactions.amount ,transactions.payment_date as 'Date of Payment',transactions.added_by as 'Added by' FROM `transactions` INNER JOIN client ON transactions.client_id=client.client_id WHERE payment_date=CURRENT_DATE and amount>0";

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
        private void Daily_report_Load(object sender, EventArgs e)
        {
            lbl_expectedPayment.Text = "";
            lbl_Collection.Text = "";
            comboBox1.SelectedIndex = 1;
            getExpectedCollection();
            getTotalCollection();

            if (lbl_Collection.Text == "")
            {

            }
            else
            {
                double expected = double.Parse(lbl_expectedPayment.Text.Remove(0, 1));
                double collected = double.Parse(lbl_Collection.Text.Remove(0, 1));
                double total = expected - collected;
                if (total > 0)
                {
                    lbl_uncollected.Text = "₱ " + total.ToString();
                }
                else {
                    lbl_uncollected.Text = "₱ 0.00";
                }

            }

getDataTable();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                getPaid();
            }
            else if (comboBox1.SelectedIndex == 1) {
                getDataTable();
            }
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
                             
                                legend.Font = FontFactory.GetFont("Arial", 12);

                                legend.Add("\n"+comboBox1.Text+"Record");
                                legend.Alignment = Element.ALIGN_LEFT;
                                legend.Add("\n Printed by: " + uName + "\n\n");

                           
                                pdfDoc.Open();
                                pdfDoc.Add(title);
                                pdfDoc.Add(legend);
                               
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Data Exported Successfully !!!", "3RCJ LENDING CORPORATION",MessageBoxButtons.OK,MessageBoxIcon.Information);
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
