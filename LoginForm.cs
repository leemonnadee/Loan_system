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

namespace Loan_system
{
    public partial class Loginform : Form
        
    {
        public static string name;
        string mycon = connection.ipconnection;
        public Loginform()
        {
            InitializeComponent();
        }





        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }




       
        private void kryptonButton1_Click(object sender, EventArgs e)
        {
           
            LoginAuth() ;

        }
        public void LoginAuth()
        {



            try
            {
                var key = "b14ca5898a4e4133bbce2ea2315a1916";

                var str = uPass.Text;
                var encryptPassword = Encryption.EncryptString(key, str);
               

                //connection query you can try on  workbench first 
                string query = "Select * from loan_db.user where username='" + uName.Text + "' and password='" + encryptPassword + "'and role='"+ comboBox1.Text + "'";

                MySqlConnection conn = new MySqlConnection(mycon);
                MySqlCommand mycommand = new MySqlCommand(query, conn);

                MySqlDataReader myreader1;

                //opening connection
                conn.Open();
                //execute the query
                myreader1 = mycommand.ExecuteReader();


                if (myreader1.Read())
                {
                    string role = myreader1.GetString("role");
                    name = myreader1.GetString("name");

                    if (role.Contains("Admin"))
                    {
                        Admin_Module.admin_dashboard ad = new Admin_Module.admin_dashboard();
                        ad.Show();
                        this.Hide();
                    }
                    else if(role.Contains("Employee")){
                        Employee_Module.emplyee_dashboard eme = new Employee_Module.emplyee_dashboard();

                        eme.Show();
                        this.Hide();
                    
                    }




                }
                else {
                    MessageBox.Show("Incorrect \n username or  password", "3RCJ LENDING System", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

       

       

        private void btn_exit_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }

    
    }
}