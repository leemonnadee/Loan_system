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
    public partial class emplyee_dashboard : Form
    {
        public emplyee_dashboard()
        {
            InitializeComponent();
        }

        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            btn_dashboard.BackColor = Color.FromArgb(199, 119, 119);
            btn_create.BackColor = Color.Transparent;
            btn_dailyReport.BackColor = Color.Transparent; 
             btn_monthly.BackColor = Color.Transparent;
            btn_dailyPayment.BackColor = Color.Transparent;



            container.Controls.Clear();
            Employee_Module.dash_transaction acc = new Employee_Module.dash_transaction();
            acc.TopLevel = false;
            container.Controls.Clear();
            container.Controls.Add(acc);
            acc.Show();
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            btn_create.BackColor = Color.FromArgb(199, 119, 119);
            btn_dashboard.BackColor = Color.Transparent;
            btn_dailyReport.BackColor = Color.Transparent; 
            btn_dailyPayment.BackColor = Color.Transparent;
            btn_monthly.BackColor = Color.Transparent;


            Employee_Module.client_acc acc = new Employee_Module.client_acc();
            acc.TopLevel = false;
            container.Controls.Clear();
            container.Controls.Add(acc);
            acc.Show();
        }

        private void btn_dailyReport_Click(object sender, EventArgs e)
        {
            btn_dailyReport.BackColor = Color.FromArgb(199, 119, 119);
            btn_dashboard.BackColor = Color.Transparent;
            btn_create.BackColor = Color.Transparent; 
           btn_dailyPayment.BackColor = Color.Transparent;
            btn_monthly.BackColor = Color.Transparent;
        
            Employee_Module.Daily_report acc = new Employee_Module.Daily_report() ;
            acc.TopLevel = false;
            container.Controls.Clear();
            container.Controls.Add(acc);

            acc.Show();
        }

        private void btn_monthly_Click(object sender, EventArgs e)
        {
            btn_monthly.BackColor = Color.FromArgb(199, 119, 119);
            btn_dashboard.BackColor = Color.Transparent;
            btn_create.BackColor = Color.Transparent; ;
           btn_dailyPayment.BackColor = Color.Transparent;
            btn_dailyReport.BackColor = Color.Transparent;
            Employee_Module.Monthly_Report amr = new Employee_Module.Monthly_Report();
            amr.TopLevel = false;
            container.Controls.Clear();
            container.Controls.Add(amr);
            amr.Show();
        }


      
    

        private void btn_logout_Click(object sender, EventArgs e)
        {
            Loginform lf = new Loginform();
            lf.Show();
            this.Hide();
        }

        private void btn_dailyPayment_Click(object sender, EventArgs e)
        {
           
           btn_dailyPayment.BackColor = Color.FromArgb(199, 119, 119);
           btn_dashboard.BackColor = Color.Transparent;
            btn_create.BackColor = Color.Transparent; 
            btn_monthly.BackColor = Color.Transparent; 
            btn_monthly.BackColor = Color.Transparent;
            Employee_Module.Daily_payment dp = new Employee_Module.Daily_payment();
            dp.TopLevel = false;
            container.Controls.Clear();
            container.Controls.Add(dp);
            dp.Show();
        }

        private void emplyee_dashboard_Load(object sender, EventArgs e)
        {
            btn_dashboard.BackColor = Color.FromArgb(199, 119, 119);
            btn_create.BackColor = Color.Transparent;
            btn_dailyReport.BackColor = Color.Transparent;
            btn_monthly.BackColor = Color.Transparent;
            btn_dailyPayment.BackColor = Color.Transparent;



            container.Controls.Clear();
            Employee_Module.dash_transaction acc = new Employee_Module.dash_transaction();
            acc.TopLevel = false;
            container.Controls.Clear();
            container.Controls.Add(acc);
            acc.Show();
        }
    }
}
