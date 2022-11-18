namespace Loan_system.Admin_Module
{
    partial class admin_dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(admin_dashboard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.container = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btn_transaction = new System.Windows.Forms.Button();
            this.btn_dashboard = new System.Windows.Forms.Button();
            this.btn_logout = new System.Windows.Forms.Button();
            this.btn_create = new System.Windows.Forms.Button();
            this.btn_badRecord = new System.Windows.Forms.Button();
            this.btn_monthly = new System.Windows.Forms.Button();
            this.btn_dailyReport = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(42)))), ((int)(((byte)(43)))));
            this.panel1.Controls.Add(this.btn_transaction);
            this.panel1.Controls.Add(this.btn_dashboard);
            this.panel1.Controls.Add(this.btn_logout);
            this.panel1.Controls.Add(this.btn_create);
            this.panel1.Controls.Add(this.btn_badRecord);
            this.panel1.Controls.Add(this.btn_monthly);
            this.panel1.Controls.Add(this.btn_dailyReport);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(315, 885);
            this.panel1.TabIndex = 0;
            // 
            // container
            // 
            this.container.BackColor = System.Drawing.Color.White;
            this.container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.container.Location = new System.Drawing.Point(315, 0);
            this.container.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(1136, 885);
            this.container.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btn_transaction
            // 
            this.btn_transaction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_transaction.FlatAppearance.BorderSize = 0;
            this.btn_transaction.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_transaction.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(50)))), ((int)(((byte)(51)))));
            this.btn_transaction.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(50)))), ((int)(((byte)(51)))));
            this.btn_transaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_transaction.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_transaction.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_transaction.Image = global::Loan_system.Properties.Resources.Order_History_40px;
            this.btn_transaction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_transaction.Location = new System.Drawing.Point(2, 511);
            this.btn_transaction.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_transaction.Name = "btn_transaction";
            this.btn_transaction.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btn_transaction.Size = new System.Drawing.Size(312, 58);
            this.btn_transaction.TabIndex = 7;
            this.btn_transaction.Text = "Transactions";
            this.btn_transaction.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_transaction.UseVisualStyleBackColor = true;
            this.btn_transaction.Click += new System.EventHandler(this.btn_transaction_Click);
            // 
            // btn_dashboard
            // 
            this.btn_dashboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_dashboard.FlatAppearance.BorderSize = 0;
            this.btn_dashboard.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_dashboard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(50)))), ((int)(((byte)(51)))));
            this.btn_dashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(50)))), ((int)(((byte)(51)))));
            this.btn_dashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dashboard.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dashboard.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_dashboard.Image = ((System.Drawing.Image)(resources.GetObject("btn_dashboard.Image")));
            this.btn_dashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_dashboard.Location = new System.Drawing.Point(1, 231);
            this.btn_dashboard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_dashboard.Name = "btn_dashboard";
            this.btn_dashboard.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btn_dashboard.Size = new System.Drawing.Size(315, 64);
            this.btn_dashboard.TabIndex = 1;
            this.btn_dashboard.Text = "Dashboard";
            this.btn_dashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_dashboard.UseVisualStyleBackColor = true;
            this.btn_dashboard.Click += new System.EventHandler(this.btn_dashboard_Click);
            // 
            // btn_logout
            // 
            this.btn_logout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_logout.FlatAppearance.BorderSize = 0;
            this.btn_logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_logout.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_logout.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_logout.Image = global::Loan_system.Properties.Resources.Logout_Rounded_40px;
            this.btn_logout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_logout.Location = new System.Drawing.Point(3, 657);
            this.btn_logout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Padding = new System.Windows.Forms.Padding(51, 0, 0, 0);
            this.btn_logout.Size = new System.Drawing.Size(311, 73);
            this.btn_logout.TabIndex = 6;
            this.btn_logout.Text = "Logout";
            this.btn_logout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_logout.UseVisualStyleBackColor = true;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // btn_create
            // 
            this.btn_create.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_create.FlatAppearance.BorderSize = 0;
            this.btn_create.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_create.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(50)))), ((int)(((byte)(51)))));
            this.btn_create.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(50)))), ((int)(((byte)(51)))));
            this.btn_create.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_create.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_create.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_create.Image = ((System.Drawing.Image)(resources.GetObject("btn_create.Image")));
            this.btn_create.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_create.Location = new System.Drawing.Point(0, 302);
            this.btn_create.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_create.Name = "btn_create";
            this.btn_create.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btn_create.Size = new System.Drawing.Size(311, 64);
            this.btn_create.TabIndex = 2;
            this.btn_create.Text = "Create Account";
            this.btn_create.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // btn_badRecord
            // 
            this.btn_badRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_badRecord.FlatAppearance.BorderSize = 0;
            this.btn_badRecord.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_badRecord.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(50)))), ((int)(((byte)(51)))));
            this.btn_badRecord.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(50)))), ((int)(((byte)(51)))));
            this.btn_badRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_badRecord.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_badRecord.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_badRecord.Image = ((System.Drawing.Image)(resources.GetObject("btn_badRecord.Image")));
            this.btn_badRecord.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_badRecord.Location = new System.Drawing.Point(2, 578);
            this.btn_badRecord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_badRecord.Name = "btn_badRecord";
            this.btn_badRecord.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btn_badRecord.Size = new System.Drawing.Size(312, 58);
            this.btn_badRecord.TabIndex = 5;
            this.btn_badRecord.Text = "Bad Records";
            this.btn_badRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_badRecord.UseVisualStyleBackColor = true;
            this.btn_badRecord.Click += new System.EventHandler(this.btn_badRecord_Click);
            // 
            // btn_monthly
            // 
            this.btn_monthly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_monthly.FlatAppearance.BorderSize = 0;
            this.btn_monthly.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_monthly.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(50)))), ((int)(((byte)(51)))));
            this.btn_monthly.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(50)))), ((int)(((byte)(51)))));
            this.btn_monthly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_monthly.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_monthly.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_monthly.Image = ((System.Drawing.Image)(resources.GetObject("btn_monthly.Image")));
            this.btn_monthly.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_monthly.Location = new System.Drawing.Point(0, 439);
            this.btn_monthly.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_monthly.Name = "btn_monthly";
            this.btn_monthly.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btn_monthly.Size = new System.Drawing.Size(312, 57);
            this.btn_monthly.TabIndex = 4;
            this.btn_monthly.Text = "Monthly Report";
            this.btn_monthly.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_monthly.UseVisualStyleBackColor = true;
            this.btn_monthly.Click += new System.EventHandler(this.btn_monthly_Click);
            // 
            // btn_dailyReport
            // 
            this.btn_dailyReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_dailyReport.AutoSize = true;
            this.btn_dailyReport.FlatAppearance.BorderSize = 0;
            this.btn_dailyReport.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_dailyReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(50)))), ((int)(((byte)(51)))));
            this.btn_dailyReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(50)))), ((int)(((byte)(51)))));
            this.btn_dailyReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dailyReport.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dailyReport.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_dailyReport.Image = ((System.Drawing.Image)(resources.GetObject("btn_dailyReport.Image")));
            this.btn_dailyReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_dailyReport.Location = new System.Drawing.Point(0, 370);
            this.btn_dailyReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_dailyReport.Name = "btn_dailyReport";
            this.btn_dailyReport.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btn_dailyReport.Size = new System.Drawing.Size(312, 62);
            this.btn_dailyReport.TabIndex = 3;
            this.btn_dailyReport.Text = "Daily Report";
            this.btn_dailyReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_dailyReport.UseVisualStyleBackColor = true;
            this.btn_dailyReport.Click += new System.EventHandler(this.btn_dailyReport_Click);
            // 
            // admin_dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1451, 885);
            this.Controls.Add(this.container);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "admin_dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "emp_Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.admin_dashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_badRecord;
        private System.Windows.Forms.Button btn_monthly;
        private System.Windows.Forms.Button btn_dailyReport;
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.Button btn_logout;
        private System.Windows.Forms.Panel container;
        private System.Windows.Forms.Button btn_dashboard;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn_transaction;
    }
}