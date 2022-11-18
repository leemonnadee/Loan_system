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
    public partial class Accounts : Form
    {
        string mycon = connection.ipconnection;
        
        public Accounts()
        {
            InitializeComponent();
       
        
        }
        
        public string filter(string str) {
           
            return str.Replace("'", "''").Trim();
        }
        void dateConvert() {
            string sourceDate =txt_bday.Text ;
            String.Format("{0:yyyy-MM-dd}", sourceDate);
            MessageBox.Show(String.Format("{0:yyyy-MM-dd}", sourceDate));
        }
        
        void clear() {
            txt_uName.Text = string.Empty;
            txt_pWord.Text = string.Empty;
            txt_firstname.Text = string.Empty;  
 
            txt_bday.Text = string.Empty;
            txt_address.Text = string.Empty;
            txt_contact.Text = string.Empty;
            txt_role.SelectedIndex = 0;
            //txt_id.Text = string.Empty;

        }
        void showallData()
        {


            try
            {

                string query = "SELECT * FROM `user`";

                MySqlConnection conn = new MySqlConnection(mycon);
                MySqlCommand mycommand = new MySqlCommand(query, conn);

                MySqlDataAdapter myadapter = new MySqlDataAdapter();
                myadapter.SelectCommand = mycommand;
                DataTable table = new DataTable();
                dtable.DataSource = table;
                myadapter.Fill(table);



                this.dtable.Columns[0].Visible = false;
                this.dtable.Columns[2].Visible = false;

                this.dtable.Columns[4].Visible = false;
                this.dtable.Columns[6].Visible = false;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        void delete()
        {
            try
            {
                string query = "DELETE FROM `user` WHERE id='"+txt_id.Text+"'";
               MySqlConnection conn = new MySqlConnection(mycon);
                MySqlCommand mycommand = new MySqlCommand(query, conn);



                MySqlDataReader myreader1;



                conn.Open();


                myreader1 = mycommand.ExecuteReader();
                MessageBox.Show("Delete Successfully", "3RCJ LENDING System", MessageBoxButtons.OK, MessageBoxIcon.Information);

                showallData();
                clear();
            }
            catch (Exception ex) {
                //MessageBox.Show(ex.Message);
            }



        }
        void insert()
        {

            try
            {
                var key = "b14ca5898a4e4133bbce2ea2315a1916";

                var str = filter(txt_pWord.Text);
                var encryptPassword = Encryption.EncryptString(key, str);
                string query = "INSERT INTO `user`(`id`, `username`, `password`, `name`, `bday`, `contact`, `address`, `role`) VALUES" +
                    " ('','"+filter(this.txt_uName.Text)+"','"+encryptPassword +"','"+ filter(txt_firstname.Text) + "','" + this.txt_bday.Text+"','"+this.txt_contact.Text+"','"+filter(this.txt_address.Text)+"','"+ txt_role.Text + "')";
                MySqlConnection conn = new MySqlConnection(mycon);
                MySqlCommand mycommand = new MySqlCommand(query, conn);



                MySqlDataReader myreader1;
                
             
                
                conn.Open();

           
                myreader1 = mycommand.ExecuteReader();
                MessageBox.Show("Insert Successfully", "3RCJ LENDING System", MessageBoxButtons.OK, MessageBoxIcon.Information);

                showallData();
                clear();
                conn.Close();
            }
            catch (Exception e) {
                MessageBox.Show(e.Message);
            }
        
        }
        void update() {

            try
            {
                var key = "b14ca5898a4e4133bbce2ea2315a1916";

                var str = filter(txt_pWord.Text);
                var encryptPassword = Encryption.EncryptString(key, str);
                string query = "UPDATE `user` SET " +
                    "`username`='"+filter(this.txt_uName.Text)+"'," +

                    "`password`='"+filter(encryptPassword) +"'," +
                    "`name`='"+filter(this.txt_uName.Text)+"'," +
                    "`bday`='"+this.txt_bday.Text+"'," +
                    "`contact`='"+this.txt_contact.Text+"'," +
                    "`address`='"+filter(this.txt_address.Text)+"'," +
                    "`role`='"+this.txt_role.Text+"' WHERE id='"+this.txt_id.Text+"'";
                MySqlConnection conn = new MySqlConnection(mycon);
                MySqlCommand mycommand = new MySqlCommand(query, conn);



                MySqlDataReader myreader1;



                conn.Open();


                myreader1 = mycommand.ExecuteReader();
                showallData();
                MessageBox.Show("Update Complete", "3RCJ LENDING System", MessageBoxButtons.OK, MessageBoxIcon.Information);

              
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Accounts_Load(object sender, EventArgs e)
        {
           
        
            
            txt_role.SelectedIndex = 0;
            showallData();
            btn_delete.Enabled = false;
            btn_update.Enabled = false;



        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            clear();
          
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (txt_uName.Text == string.Empty ||
                 txt_pWord.Text == string.Empty ||
                  txt_pWord.Text == string.Empty ||
                  txt_firstname.Text == string.Empty ||
                     txt_address.Text == string.Empty ||
                      txt_contact.Text == string.Empty
                )
            {
                MessageBox.Show("Fill out all data", "3RCJ LENDING System", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else {
                insert();
          
            }
           
            

      
         
           
       

        
           
           
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (txt_uName.Text == string.Empty ||
                           txt_pWord.Text == string.Empty ||
                            txt_pWord.Text == string.Empty ||
                            txt_firstname.Text == string.Empty ||
                               txt_address.Text == string.Empty ||
                                txt_contact.Text == string.Empty 
                          )
            {
                MessageBox.Show("Fill out all data", "3RCJ LENDING System", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
               
                update();
                btn_delete.Enabled = false;
                btn_update.Enabled = false;
                btn_save.Enabled = true;
            }
           ;
        }

        private void txt_contact_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

      

        private void dtable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtable.Rows[e.RowIndex];
                // lbl_idno.Text = row.Cells["user_id"].Value.ToString();
                txt_uName.Text = row.Cells["username"].Value.ToString();

                txt_firstname.Text = row.Cells["name"].Value.ToString();

                txt_bday.Text = row.Cells["bday"].Value.ToString();
                txt_address.Text = row.Cells["address"].Value.ToString();
                txt_contact.Text = row.Cells["contact"].Value.ToString();
                txt_role.Text = row.Cells["role"].Value.ToString();
                txt_id.Text = row.Cells["id"].Value.ToString();
                btn_delete.Enabled = true;
                btn_update.Enabled = true;
                btn_save.Enabled = false;
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to delete this Account?", "Delete Data", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                delete();
                btn_delete.Enabled = false;
                btn_update.Enabled = false;
                btn_save.Enabled = true;
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
            
        }

        }
    }

