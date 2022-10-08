using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loan_system.Employee_Module
{
    public partial class client_acc : Form
    {
        public string mycon = connection.ipconnection;
        public client_acc()
        {
            InitializeComponent();
        }
        public string filter(string str) {

            return str.Replace("'", "''");
        
        }
        public void auth() {

            try
            {


                //connection query you can try on  workbench first 
                string query = "SELECT * FROM `client` WHERE name='"+filter(txt_uName.Text)+"' and Legend='Unpaid'";
                MySqlConnection conn = new MySqlConnection(mycon);
                MySqlCommand mycommand = new MySqlCommand(query, conn);

                MySqlDataReader myreader1;

                //opening connection
                conn.Open();
                //execute the query
                myreader1 = mycommand.ExecuteReader();


                if (myreader1.Read())
                {

                    MessageBox.Show("Client Already Exist ", "3RCJ LENDING System", MessageBoxButtons.OK, MessageBoxIcon.Error);



                }
                else
                {
                    Insert();
                }

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            }
        public void clear() {

            this.txt_uName.Text = String.Empty;
            this.txt_email.Text= String.Empty;
            this.txt_bday.Text = String.Empty;
            this.txt_contact.Text = String.Empty;
            this.txt_address.Text = String.Empty;
            txt_loan_amount.Text = String.Empty;
            lbl_totalDays.Text = "₱ 0.00";
            lbl_totalInterest.Text = "₱ 0.00";
            lbl_totalPayment.Text = "₱ 0.00";
        }
        
        public void Insert() {
            string email = txt_email.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success) {
                string query = "INSERT INTO " +
                    "`client`(`client_id`," +
                    " `name`," +
                    " `email`," +
                    " `bday`, " +
                    "`contact`," +
                    " `address`, " +
                    "`loan_amount`," +
                    " `total_payment`," +
                    " `daily_payment`, " +
                    "`total_interest`," +
                    " `days`," +
                    "`Legend`) " +
                    "VALUES (''," +
                    "'"+filter(this.txt_uName.Text.ToLower())+"'," +
                    "'"+filter(this.txt_email.Text.ToLower())+"'," +
                    "'"+this.txt_bday.Text+"'," +
                    "'"+this.txt_contact.Text+"'," +
                    "'"+filter(this.txt_address.Text)+"'," +
                    "'"+txt_loan_amount.Text+"'," +
                    "'"+this.lbl_totalPayment.Text.Remove(0, 1) + "'," +
                    "'"+this.lbl_totalDays.Text.Remove(0, 1) + "'," +
                    "'"+this.lbl_totalInterest.Text.Remove(0, 1) + "'," +
                    "'"+this.days_payment.Text+"','Unpaid')";
                MySqlConnection conn = new MySqlConnection(mycon);
                MySqlCommand mycommand = new MySqlCommand(query, conn);



                MySqlDataReader myreader1;



                conn.Open();


                myreader1 = mycommand.ExecuteReader();
               
                
                MessageBox.Show("Insert Successfully", "3RCJ LENDING System", MessageBoxButtons.OK, MessageBoxIcon.Information);
             
                
                clear();
                conn.Close();
            }

            else { 
                MessageBox.Show((email + "@ is incorrect"));
            }
        }
        public void loanComputation() {
       
            string interest = interest_rate.SelectedItem.ToString().Remove(2);
            string days = days_payment.SelectedItem.ToString().Remove(2);
            double loan_amount = Double.Parse(txt_loan_amount.Text);
            double total_interest_rate = (Double.Parse(interest) / 100) * loan_amount;
            double daily_payment = (loan_amount + total_interest_rate) / Double.Parse(days);
            double total_amount = loan_amount + total_interest_rate;
            lbl_totalInterest.Text = "₱"+ Math.Round((Double)total_interest_rate, 2).ToString();
            lbl_totalDays.Text = "₱"+Math.Round((Double)daily_payment, 2).ToString();
            lbl_totalPayment.Text = "₱"+Math.Round((Double)total_amount, 2).ToString();
            //MessageBox.Show(lbl_totalPayment.Text.Remove(0, 1));

        }
        private void client_acc_Load(object sender, EventArgs e)
        {
            interest_rate.SelectedIndex = 0;
            days_payment.SelectedIndex = 0;
         
        }

    

        private void txt_loan_amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_loan_amount_TextChanged(object sender, EventArgs e)
        {
            if (txt_loan_amount.Text == String.Empty)
            {

                lbl_totalDays.Text = "₱ 0.00";
                lbl_totalInterest.Text = "₱ 0.00";
                lbl_totalPayment.Text = "₱ 0.00";
            }
            else {
                loanComputation();
            }
        }

        private void interest_rate_TextChanged(object sender, EventArgs e)
        {
            if (txt_loan_amount.Text == String.Empty)
            {
                lbl_totalDays.Text = "₱ 0.00";
                lbl_totalInterest.Text = "₱ 0.00";
                lbl_totalPayment.Text = "₱ 0.00";
            }
            else
            {
                loanComputation();
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {

            if (this.txt_uName.Text == String.Empty ||
            this.txt_email.Text == String.Empty ||
            this.txt_bday.Text == String.Empty ||
            this.txt_contact.Text == String.Empty ||
            this.txt_address.Text == String.Empty ||
            txt_loan_amount.Text == String.Empty)
            {

                MessageBox.Show("Fill all data", "3RCJ LENDING System", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else {
                auth();
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void txt_contact_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

      
    }
}
