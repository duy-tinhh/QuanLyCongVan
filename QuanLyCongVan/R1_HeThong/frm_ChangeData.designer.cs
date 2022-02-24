namespace QuanLyCongVan
{
    partial class frm_ChangeData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ChangeData));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.bChuyen = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.txtThuMuc = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.pro = new DevExpress.XtraEditors.ProgressBarControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtThuMuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pro.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl1.Location = new System.Drawing.Point(160, 15);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(256, 34);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Nhập data từ Access";
            // 
            // bChuyen
            // 
            this.bChuyen.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bChuyen.Appearance.Options.UseFont = true;
            this.bChuyen.Location = new System.Drawing.Point(180, 251);
            this.bChuyen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bChuyen.Name = "bChuyen";
            this.bChuyen.Size = new System.Drawing.Size(87, 28);
            this.bChuyen.TabIndex = 6;
            this.bChuyen.Text = "Thực hiện";
            this.bChuyen.Click += new System.EventHandler(this.bChuyen_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Location = new System.Drawing.Point(285, 251);
            this.simpleButton2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(87, 28);
            this.simpleButton2.TabIndex = 7;
            this.simpleButton2.Text = "Thoát";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // txtThuMuc
            // 
            this.txtThuMuc.EditValue = "D:\\QuanLyCongVan";
            this.txtThuMuc.Location = new System.Drawing.Point(78, 191);
            this.txtThuMuc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtThuMuc.Name = "txtThuMuc";
            this.txtThuMuc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThuMuc.Properties.Appearance.Options.UseFont = true;
            this.txtThuMuc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtThuMuc.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit1_Properties_ButtonClick);
            this.txtThuMuc.Size = new System.Drawing.Size(421, 28);
            this.txtThuMuc.TabIndex = 11;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(7, 194);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(65, 21);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Thư mục";
            // 
            // pro
            // 
            this.pro.Location = new System.Drawing.Point(78, 126);
            this.pro.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pro.Name = "pro";
            this.pro.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pro.Properties.ShowTitle = true;
            this.pro.Size = new System.Drawing.Size(421, 22);
            this.pro.TabIndex = 12;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(78, 59);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(4, 16);
            this.labelControl4.TabIndex = 13;
            this.labelControl4.Text = " ";
            // 
            // frm_ChangeData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 331);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.pro);
            this.Controls.Add(this.txtThuMuc);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.bChuyen);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ChangeData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kết nối cơ sở dữ liệu";
            this.Load += new System.EventHandler(this.frm_Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtThuMuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pro.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton bChuyen;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.ButtonEdit txtThuMuc;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ProgressBarControl pro;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}