namespace QuanLyCongVan
{
    partial class frm_SaoLuu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_SaoLuu));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtTenfile = new DevExpress.XtraEditors.TextEdit();
            this.txtSaoluu = new DevExpress.XtraEditors.ButtonEdit();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.bSaoluu = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenfile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaoluu.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelControl1.Location = new System.Drawing.Point(213, 34);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(207, 34);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Sao Lưu Dữ Liệu";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(54, 149);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(55, 21);
            this.labelControl3.TabIndex = 27;
            this.labelControl3.Text = "Tên file";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(54, 241);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(52, 21);
            this.labelControl4.TabIndex = 28;
            this.labelControl4.Text = "Nơi lưu";
            // 
            // txtTenfile
            // 
            this.txtTenfile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtTenfile.Location = new System.Drawing.Point(156, 142);
            this.txtTenfile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenfile.Name = "txtTenfile";
            this.txtTenfile.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenfile.Properties.Appearance.Options.UseFont = true;
            this.txtTenfile.Size = new System.Drawing.Size(355, 28);
            this.txtTenfile.TabIndex = 25;
            // 
            // txtSaoluu
            // 
            this.txtSaoluu.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtSaoluu.Location = new System.Drawing.Point(156, 238);
            this.txtSaoluu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSaoluu.Name = "txtSaoluu";
            this.txtSaoluu.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaoluu.Properties.Appearance.Options.UseFont = true;
            this.txtSaoluu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("txtSaoluu.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.txtSaoluu.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txtSaoluu.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit1_Properties_ButtonClick);
            this.txtSaoluu.Size = new System.Drawing.Size(355, 28);
            this.txtSaoluu.TabIndex = 26;
            this.txtSaoluu.EditValueChanged += new System.EventHandler(this.txtSaoluu_EditValueChanged);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Location = new System.Drawing.Point(369, 316);
            this.simpleButton2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(87, 28);
            this.simpleButton2.TabIndex = 23;
            this.simpleButton2.Text = "Thoát";
            this.simpleButton2.Click += new System.EventHandler(this.bThoat_Click);
            // 
            // bSaoluu
            // 
            this.bSaoluu.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSaoluu.Appearance.Options.UseFont = true;
            this.bSaoluu.Location = new System.Drawing.Point(256, 316);
            this.bSaoluu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bSaoluu.Name = "bSaoluu";
            this.bSaoluu.Size = new System.Drawing.Size(87, 28);
            this.bSaoluu.TabIndex = 24;
            this.bSaoluu.Text = "Sao Lưu";
            this.bSaoluu.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frm_SaoLuu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 382);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtTenfile);
            this.Controls.Add(this.txtSaoluu);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.bSaoluu);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_SaoLuu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sao lưu hệ thống";
            this.Load += new System.EventHandler(this.frm_Saoluu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTenfile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaoluu.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtTenfile;
        private DevExpress.XtraEditors.ButtonEdit txtSaoluu;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton bSaoluu;
    }
}