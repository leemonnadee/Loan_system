using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loan_system.components
{
    public partial class bad_records : UserControl
    {
        public bad_records()
        {
            InitializeComponent();
        }

        public String name { get => lbl_name.Text; set => lbl_name.Text = value; }
        public String days { get => lbl_days.Text; set => lbl_days.Text = value; }
        public String amount { get => lbl_amount.Text; set => lbl_amount.Text = value; }

    };
     
        
}
