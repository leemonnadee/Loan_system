using Loan_system.Employee_Module;
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

namespace Loan_system.Admin_Module
{
    public partial class editable_expenses : Form
    {
        public String mycon = connection.ipconnection;
        public editable_expenses()
        {
            InitializeComponent();
        }

        private void txt_uName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        public void btn_delete_Click(object sender, EventArgs e)
        {
       
            this.Hide();
         


        }
        public string filter(string str)
        {

            return str.Replace("'", "''");

        }
        
        public void add() {
            try
            {

                string query = "INSERT INTO `expenses`(`expenses_id`, `description`, `amount`) VALUES ('','"+filter(txt_description.Text)+"','"+double.Parse(txt_cost.Text)+"')";
                MySqlConnection con = new MySqlConnection(mycon);
                MySqlCommand mycommand = new MySqlCommand(query, con);
                MySqlDataReader myreader1;
                con.Open();
                myreader1 = mycommand.ExecuteReader();
                MessageBox.Show("Expenses Added", "3RCJ LENDING System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                txt_cost.Text = String.Empty;
                txt_description.Text = String.Empty;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            if (txt_cost.Text == String.Empty ||
            txt_description.Text == String.Empty)
            {

                MessageBox.Show("Fill all form", "3RCJ LENDING System", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else {
                add();
            }

        }
    }
}
