using Loan_system.components;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loan_system.Employee_Module
{
    public partial class Monthly_Report : Form
    {
        public String unpaid;
        public String name;
        public String unpaidAmount;
        public Double sum = 0;
   
        public string mycon = connection.ipconnection;
        public Monthly_Report()
        {
            InitializeComponent();
        }
        public void getData()
        {
            try
            {

                string query = "SELECT client.name AS 'Client Name', COUNT(*) AS 'Unpaid Days',MONTH(transactions.payment_date) AS 'MONTH',(client.daily_payment*COUNT(*)) AS 'Unpaid Amount' from transactions INNER JOIN client ON transactions.client_id=client.client_id WHERE transactions.amount=0  and client.record='bad record' AND MONTHNAME(transactions.payment_date)='" + comboBox1.Text + "' AND year(payment_date)='"+cbm_year.Text+ "' and client.name   LIKE '%" + txt_srch.Text + "%'GROUP BY transactions.client_id  ASC;";
             
                MySqlConnection conn = new MySqlConnection(mycon);
                MySqlCommand mycommand = new MySqlCommand(query, conn);

                MySqlDataAdapter myadapter = new MySqlDataAdapter();
                myadapter.SelectCommand = mycommand;
                //DataTable table = new DataTable();
                // dtable.DataSource = table;
                // myadapter.Fill(table);

                MySqlDataReader myreader1;
                conn.Open();
                myreader1 = mycommand.ExecuteReader();

                while (myreader1.Read())
                {

                    String name = myreader1.GetString("Client Name");

                    String days = myreader1.GetString("Unpaid Days");
                    String amount = myreader1.GetString("Unpaid Amount");
                    sum += double.Parse(amount);
                    AddMerchant_List(name, days, "₱" + amount);
                 
                }
                

                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void monthly() {

            try
            {
                string query = "SELECT SUM(client.daily_payment)AS Total FROM `transactions` INNER JOIN client ON transactions.client_id=client.client_id WHERE amount=0 AND MONTHNAME(transactions.payment_date)='" + comboBox1.Text + "' AND year(payment_date)='" + cbm_year.Text + "' ";

               
                MySqlConnection conn = new MySqlConnection(mycon);
                MySqlCommand mycommand = new MySqlCommand(query, conn);

                MySqlDataAdapter myadapter = new MySqlDataAdapter();
                myadapter.SelectCommand = mycommand;
                //DataTable table = new DataTable();
                // dtable.DataSource = table;
                // myadapter.Fill(table);

                MySqlDataReader myreader1;
                conn.Open();
                myreader1 = mycommand.ExecuteReader();
               
                if (myreader1.Read())
                {

                    string total = myreader1.GetString("Total");

                    lbl_sum.Text = "₱ " + total;

                }
               


                conn.Close();


            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }




        }
        public void AddMerchant_List(String Name, String Days, String Amount)
        {



            var w = new bad_records()
            {

                name = Name,
                days = Days,
                amount = Amount



            };
            pn1.Controls.Add(w);
        }
        static string getFullName(int month)
        {
            return CultureInfo.CurrentCulture.
                DateTimeFormat.GetMonthName
                (month);
        }
        private void Monthly_Report_Load(object sender, EventArgs e)
        {
            
            string month = DateTime.Now.Month.ToString("#");
            string year = DateTime.Now.Year.ToString("####");
            comboBox1.Text = getFullName(int.Parse(month)).ToString();
        
            
            //getData();
            // lbl_sum.Text = "₱" + sum.ToString();
            cbm_year.Text = year;
            monthly();






        }
      
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            pn1.Controls.Clear();
            lbl_sum.Text = "₱ 0.00 ";
            getData();
            monthly();
           
        }

        private void cbm_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            pn1.Controls.Clear();
            lbl_sum.Text = "₱ 0.00 ";
            getData();
            monthly();

        }

 
        private void txt_srch_TextChanged(object sender, EventArgs e)
        {
            pn1.Controls.Clear();
         
            getData();
            monthly();
        }
    }
        }

