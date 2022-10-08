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
    public partial class MonthlyReport : Form
    {
        public String mycon = connection.ipconnection;
        public double total_expenses = 0;
        public double total_net = 0;
        public double release=0;
        public double collected=0;
        public double interest = 0;
     
        public MonthlyReport()
        {
            InitializeComponent();
        }
        public void Display_Monthly() {
            try { 

            string query = "SELECT SUM(amount) AS 'Monthly Amount' FROM `transactions` WHERE MONTH(payment_date)=Month(CURRENT_DATE) AND YEAR(payment_date)=year(CURRENT_DATE)";
            MySqlConnection con = new MySqlConnection(mycon);
            MySqlCommand mycommand = new MySqlCommand(query, con);
            MySqlDataReader myreader1;
            con.Open();
            myreader1 = mycommand.ExecuteReader();
            if (myreader1.Read()) {
                        
                    collected=double.Parse(myreader1.GetString("Monthly Amount"));
                    double toBeCollected = release - collected;
                    lbl_monthly.Text = "Php" + toBeCollected.ToString();
            }
            else { 
            
            }
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
        }
        public void Display_expenses()
        {
            try
            {

                string query = "SELECT SUM(amount)  as 'Expenses' FROM `expenses` WHERE 1";
                MySqlConnection con = new MySqlConnection(mycon);
                MySqlCommand mycommand = new MySqlCommand(query, con);
                MySqlDataReader myreader1;
                con.Open();
                myreader1 = mycommand.ExecuteReader();
                if (myreader1.Read())
                {
                    lbl_editableExpenses.Text = "Php" + myreader1.GetString("Expenses");
                    total_expenses = double.Parse(myreader1.GetString("Expenses"));
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
        }
        public void Display_InterestRate() {
            try {
            string query = "SELECT SUM(total_interest)AS total FROM `client` WHERE MONTHNAME(loan_date)=MONTHNAME(CURRENT_DATE) AND year(loan_date)=year(CURRENT_DATE)";
            MySqlConnection con = new MySqlConnection(mycon);
            MySqlCommand mycommand = new MySqlCommand(query, con);
            MySqlDataReader myreader1;
            con.Open();
            myreader1 = mycommand.ExecuteReader();
            if (myreader1.Read())
            {
                lbl_InterestRate.Text = "Php" + myreader1.GetString("total");
                    interest = double.Parse(myreader1.GetString("total"));
            }
            else
            {

            }
        } catch (Exception ex) {
               // MessageBox.Show(ex.Message);
            }
}
        public void Loan_amount()
        {
            try { 
            string query = "SELECT SUM(loan_amount) AS 'Loan' FROM `client` WHERE MONTHNAME(loan_date)=MONTHNAME(CURRENT_DATE) AND year(loan_date)=year(CURRENT_DATE)";
            MySqlConnection con = new MySqlConnection(mycon);
            MySqlCommand mycommand = new MySqlCommand(query, con);
            MySqlDataReader myreader1;
            con.Open();
            myreader1 = mycommand.ExecuteReader();
            if (myreader1.Read())
            {
                lbl_ReleaseAmount.Text = "Php" + myreader1.GetString("loan");

                    release= double.Parse(myreader1.GetString("loan"));

                }
                else
            {

            }
                con.Close();
            }
           
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            
        }




       public void showallData()
        {


            try
            {

                string query = "SELECT `expenses_id` AS 'ID',`description`AS 'Expenses',amount,`date_transac`AS 'Date' FROM `expenses` WHERE MONTHNAME(date_transac)=MONTHNAME(CURRENT_DATE) AND year(date_transac)=year(CURRENT_DATE)";

                MySqlConnection conn = new MySqlConnection(mycon);
                MySqlCommand mycommand = new MySqlCommand(query, conn);

                MySqlDataAdapter myadapter = new MySqlDataAdapter();
                myadapter.SelectCommand = mycommand;
                DataTable table = new DataTable();
                dtable.DataSource = table;
                myadapter.Fill(table);
             



            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }

        }









        private void MonthlyReport_Load(object sender, EventArgs e)
        {
            Loan_amount();
            Display_Monthly();
            
            Display_InterestRate();
            Display_expenses();
            showallData();
            double Net=interest - total_expenses;
            lbl_netprofit.Text ="Php" +Net.ToString();
            refresh.Visible = false;
      
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            editable_expenses ee = new editable_expenses();
            ee.Show();
            refresh.Visible = true;
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            showallData();
                Loan_amount();
            Loan_amount();
            Display_expenses();
            double Net = interest - total_expenses;
            lbl_netprofit.Text = "Php" + Net.ToString();


            refresh.Visible = false;
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
                                title.Add("\n Expenses-Report\n\n");


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

