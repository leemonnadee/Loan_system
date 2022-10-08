using MySql.Data.MySqlClient;


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loan_system.Employee_Module
{
    public partial class Daily_payment : Form
    {
        public string mycon = connection.ipconnection;

        public Daily_payment()
        {
            InitializeComponent();
        }
        public void paid()
        {
            try
            {



                string query = "UPDATE `client` SET `Legend`='Paid' WHERE client_id='" + lbl_id.Text + "';";
                MySqlConnection con = new MySqlConnection(mycon);
                MySqlCommand mycommand = new MySqlCommand(query, con);
                MySqlDataReader myreader1;
                con.Open();
                myreader1 = mycommand.ExecuteReader();
                con.Close();
                
              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    public void Getremaining_Balance()
        {
            try
            {
                

                    string query = "select (client.total_payment-(sum(transactions.amount))) AS Remaining_Balance,sum(transactions.amount) as total_amount from transactions INNER JOIN client " +
                        "ON transactions.client_id=client.client_id WHERE transactions.client_id='" + lbl_id.Text + "';";
                    MySqlConnection con = new MySqlConnection(mycon);
                    MySqlCommand mycommand = new MySqlCommand(query, con);
                    MySqlDataReader myreader1;
                    con.Open();
                    myreader1 = mycommand.ExecuteReader();
                if (myreader1.Read())
                {

                    string totalAmount = myreader1.GetString("total_amount");
                    string remainingbalance = myreader1.GetString("Remaining_Balance");
                    lbl_remainingBalance.Text = "₱ " + remainingbalance;
               
                    
                    
                    if (double.Parse(totalAmount) >= Double.Parse(lbl_loanAmount.Text.Remove(0, 1)))
                    {
                        paid();
                        btn_pay.Enabled = false;
                    }
                    else
                    {

                    }

                    con.Close();


                }
               
            }
            catch (Exception ex)
            {
                lbl_remainingBalance.Text = "";
            }        
            }


        public void dailyPayment() {
            try
            {
                string query = "INSERT INTO `transactions`(`recipt_no`, `client_id`, `amount`, `payment_date`) " +
                    "VALUES ('','" + this.lbl_id.Text + "','" + this.txt_amount.Text + "','" + this.txt_date.Text + "')";

                MySqlConnection conn = new MySqlConnection(mycon);
                MySqlCommand mycommand = new MySqlCommand(query, conn);

                MySqlDataReader myreader1;

                //opening connection
                conn.Open();
                //execute the query
                myreader1 = mycommand.ExecuteReader();
                MessageBox.Show("Payment Added", "3RCJ LENDING System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Getremaining_Balance();
                conn.Close();
             
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        public string filter(string str)
        {

            return str.Replace("'", "''");

        }
        public void srch()
        {
            try
            {
                string query = "SELECT `client_id`,`name`,`loan_amount`,`total_payment`,`daily_payment`,`total_interest`,`days` ,`Legend` FROM `client`where name='" + filter(txt_srch.Text.ToLower()) + "'";

                MySqlConnection conn = new MySqlConnection(mycon);
                MySqlCommand mycommand = new MySqlCommand(query, conn);

                MySqlDataReader myreader1;

                //opening connection
                conn.Open();
                //execute the query
                myreader1 = mycommand.ExecuteReader();
               

                    if (myreader1.Read())
                {
                    btn_pay.Visible = true;
                    txt_amount.Enabled = true;
                    txt_amount.Text = "";

                    string role = myreader1.GetString("name");
                    string payment = myreader1.GetString("Legend");
                    if (txt_srch.Text.ToLower() == role)
                    {
                        DataPanel.Visible = true;
                        string dp = myreader1.GetString("daily_payment");
                        lbl_dailyPayment.Text = "₱ " + dp;
                        string tp = myreader1.GetString("total_payment");
                        lbl_loanAmount.Text = "₱ " + tp;
                        lbl_idtext.Visible = true;
                        lbl_id.Visible = true;
                        string id = myreader1.GetString("client_id");
                        lbl_id.Text = id;
                       
                        Getremaining_Balance();
                        displayDays();
                        btn_pay.Enabled = true;
                    }
                    if (payment.ToLower() == "paid") {

                        btn_pay.Visible = false;
                        txt_amount.Text = "Client Paid";
                        txt_amount.Enabled = false;

                    }



                    conn.Close();
               
                  

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

   
    
    private void uName_TextChanged(object sender, EventArgs e)
        {
            if (txt_srch.Text == String.Empty)
            {
                DataPanel.Visible = false;
                lbl_idtext.Visible = true;
                lbl_idtext.Visible = false;
                lbl_id.Visible = false;
                        btn_pay.Enabled = true;

            }
            else { 
            srch();
        
            }
        }
        public void record() {
            try
            {
                string query = "UPDATE `client` SET `record`='bad record' WHERE client_id='" + lbl_id.Text + "'";
                MySqlConnection conn = new MySqlConnection(mycon);
                MySqlCommand mycommand = new MySqlCommand(query, conn);

                MySqlDataReader myreader1;

                //opening connection
                conn.Open();
                //execute the query
                myreader1 = mycommand.ExecuteReader();
            
           
                conn.Close();

          


            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
        }
        public void displayDays() {
            try
            {
                string query = "SELECT client.name AS 'Client Name',client.contact AS 'Contact No.',client.total_payment AS 'Loan Amount', COUNT(transactions.amount) AS 'Unpaid Days' from transactions INNER JOIN client ON transactions.client_id=client.client_id WHERE transactions.amount=0 AND client.name='" + txt_srch.Text + "'  GROUP BY transactions.client_id  ASC";
                MySqlConnection conn = new MySqlConnection(mycon);
                MySqlCommand mycommand = new MySqlCommand(query, conn);

                MySqlDataReader myreader1;

                //opening connection
                conn.Open();
                //execute the query
                myreader1 = mycommand.ExecuteReader();


                if (myreader1.Read())
                {

                    string role = myreader1.GetString("Unpaid Days");
                    lbl_Unpaid.Text = role;
                    if (int.Parse(role) >= 7)
                        {
                            record();
                        }
                     



                }
                else { 
                }
                showdata();
                conn.Close();

               

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            }
                private void Daily_payment_Load(object sender, EventArgs e)
        {
            DataPanel.Visible=false;
            this.txt_date.Value = DateTime.Now;
            lbl_idtext.Visible = false;
            lbl_id.Visible = false;
       
          lbl_txt.Visible = true;
           lbl_Unpaid.Visible = true;
            btn_pay.Enabled = true;
            
                srch();



        }
        public void showdata() {
            try
            {

                string query = "SELECT c.name,c.email,c.contact as 'Contact No.', t.payment_date AS 'Unpaid Date' FROM `client` as c INNER JOIN transactions t ON c.client_id=t.client_id where amount=0 and c.client_id='"+ lbl_id.Text+ "'";

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
                MessageBox.Show(ex.Message);
            }


        }
      

        private void btn_pay_Click(object sender, EventArgs e)
        {
            if (txt_amount.Text == String.Empty)
            {
                MessageBox.Show("Amount not Found", "3RCJ LENDING System", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else {
                dailyPayment();
                displayDays();
            }
            
        }

        private void txt_amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            paid();
        }
    }
}
