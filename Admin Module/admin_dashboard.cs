using Loan_system.Employee_Module;
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
    public partial class admin_dashboard : Form
    {
        string uName = Loginform.name;
        public admin_dashboard()
        {
            InitializeComponent();
        }

       

     
     

      

        private void btn_dashboard_Click(object sender, EventArgs e)
        {
           
            btn_dashboard.BackColor = Color.FromArgb(199, 119, 119) ;
            btn_create.BackColor=Color.Transparent;
            btn_dailyReport.BackColor = Color.Transparent; ;
            btn_badRecord.BackColor = Color.Transparent; ;
            btn_monthly.BackColor= Color.Transparent;
            container.Controls.Clear();
            Admin_Module.client_list amr = new Admin_Module.client_list();
            amr.TopLevel = false;
            container.Controls.Clear();
            container.Controls.Add(amr);
            amr.Show();

       
          

        }

        public void btn_monthly_Click(object sender, EventArgs e)
        {
            btn_monthly.BackColor = Color.FromArgb(199, 119, 119);
            btn_dashboard.BackColor = Color.Transparent;
            btn_create.BackColor = Color.Transparent; ;
            btn_badRecord.BackColor = Color.Transparent; ;
            btn_dailyReport.BackColor = Color.Transparent;
            Admin_Module.MonthlyReport amr = new Admin_Module.MonthlyReport();
            amr.TopLevel = false;
            container.Controls.Clear();
            container.Controls.Add(amr);
            amr.Show();
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            btn_create.BackColor = Color.FromArgb(199, 119, 119);
            btn_dashboard.BackColor = Color.Transparent;
            btn_dailyReport.BackColor = Color.Transparent; ;
            btn_badRecord.BackColor = Color.Transparent; ;
            btn_monthly.BackColor = Color.Transparent;

       
            Admin_Module.Accounts acc=new Admin_Module.Accounts();
            acc.TopLevel = false;
            container.Controls.Clear();
            container.Controls.Add(acc);
            acc.Show();
        }

        private void btn_dailyReport_Click(object sender, EventArgs e)
        {
            btn_dailyReport.BackColor = Color.FromArgb(199, 119, 119);
            btn_dashboard.BackColor = Color.Transparent;
            btn_create.BackColor = Color.Transparent; ;
            btn_badRecord.BackColor = Color.Transparent; ;
            btn_monthly.BackColor = Color.Transparent;
            container.Controls.Clear();
            Daily_report acc = new Daily_report();
            acc.TopLevel = false;
            container.Controls.Clear();
            container.Controls.Add(acc);

            acc.Show();
        }

        private void btn_badRecord_Click(object sender, EventArgs e)
        {
            btn_badRecord.BackColor = Color.FromArgb(199, 119, 119);
            btn_dashboard.BackColor = Color.Transparent;
            btn_create.BackColor = Color.Transparent; ;
            btn_monthly.BackColor = Color.Transparent; ;
            btn_monthly.BackColor = Color.Transparent;
            Admin_Module.BadRecords abr = new Admin_Module.BadRecords();
            abr.TopLevel = false;
            container.Controls.Clear();
            container.Controls.Add(abr);
            abr.Show();
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            Loginform lf = new Loginform();
            lf.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Opacity = 1;
            
        }

        private void admin_dashboard_Load(object sender, EventArgs e)
        {
            btn_dashboard.BackColor = Color.FromArgb(199, 119, 119);
            btn_create.BackColor = Color.Transparent;
            btn_dailyReport.BackColor = Color.Transparent; ;
            btn_badRecord.BackColor = Color.Transparent; ;
            btn_monthly.BackColor = Color.Transparent;
            container.Controls.Clear();
            Admin_Module.client_list amr = new Admin_Module.client_list();
            amr.TopLevel = false;
            container.Controls.Clear();
            container.Controls.Add(amr);
            amr.Show();
            

        }
    }
}
