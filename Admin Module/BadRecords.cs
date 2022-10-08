using Loan_system.components;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Loan_system.Admin_Module
{
   
    public partial class BadRecords : Form
    {
        public String unpaid;
        public String name;
        public String unpaidAmount;
        public Double sum = 0;
        public string mycon = connection.ipconnection;
        public BadRecords()
        {
            InitializeComponent();
        }
        public void getData()
        {
            try
            {

                string query = "SELECT client.name AS 'Client Name', COUNT(*) AS 'Unpaid Days' ,(client.daily_payment*COUNT(*)) AS 'Unpaid Amount' from transactions INNER JOIN client ON transactions.client_id=client.client_id WHERE transactions.amount=0 AND client.Legend='Unpaid' and client.record='bad record' GROUP BY transactions.client_id  ASC";
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
                   AddMerchant_List(name,days, "₱"+ amount);


                }


                conn.Close();


            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

        }
      
        private void BadRecords_Load(object sender, EventArgs e)
        {

            getData();
            lbl_sum.Text= "₱" + sum.ToString();
        }










        public void AddMerchant_List(String Name,String Days,String Amount)
        {



            var w = new bad_records()
            {

                name = Name,
                days = Days,
                amount = Amount


              
            };
            pn1.Controls.Add(w);
            /**
            w.OnSelect += (ss, ee) =>
            {

                var merch = (merchant_widget)ss;
                merchant_list.merchantDisplay.merch_id = id;
                merchant_list.merchantDisplay.merch_store = merch.StoreName;
                merchant_list.merchantDisplay.merch_name = merch.Merchant_Name;






            };*/
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
    }
