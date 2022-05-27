namespace QuanLiVLXD
{
    partial class frmBaoCaoNhapHang
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
            this.dgBCNH = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnThucHien = new System.Windows.Forms.Button();
            this.cbHD = new System.Windows.Forms.ComboBox();
            this.chbHD = new System.Windows.Forms.CheckBox();
            this.cbNCC = new System.Windows.Forms.ComboBox();
            this.chbNCC = new System.Windows.Forms.CheckBox();
            this.dtpDen = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTu = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgBCNH)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgBCNH
            // 
            this.dgBCNH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBCNH.Location = new System.Drawing.Point(298, 100);
            this.dgBCNH.Name = "dgBCNH";
            this.dgBCNH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgBCNH.Size = new System.Drawing.Size(819, 461);
            this.dgBCNH.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnIn);
            this.groupBox1.Controls.Add(this.btnThucHien);
            this.groupBox1.Controls.Add(this.cbHD);
            this.groupBox1.Controls.Add(this.chbHD);
            this.groupBox1.Controls.Add(this.cbNCC);
            this.groupBox1.Controls.Add(this.chbNCC);
            this.groupBox1.Controls.Add(this.dtpDen);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpTu);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(45, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 461);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức năng";
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(56, 411);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(120, 33);
            this.btnIn.TabIndex = 4;
            this.btnIn.Text = "In";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnThucHien
            // 
            this.btnThucHien.Location = new System.Drawing.Point(56, 372);
            this.btnThucHien.Name = "btnThucHien";
            this.btnThucHien.Size = new System.Drawing.Size(120, 33);
            this.btnThucHien.TabIndex = 4;
            this.btnThucHien.Text = "Thực hiện";
            this.btnThucHien.UseVisualStyleBackColor = true;
            // 
            // cbHD
            // 
            this.cbHD.FormattingEnabled = true;
            this.cbHD.Location = new System.Drawing.Point(26, 318);
            this.cbHD.Name = "cbHD";
            this.cbHD.Size = new System.Drawing.Size(184, 32);
            this.cbHD.TabIndex = 3;
            // 
            // chbHD
            // 
            this.chbHD.AutoSize = true;
            this.chbHD.Location = new System.Drawing.Point(26, 283);
            this.chbHD.Name = "chbHD";
            this.chbHD.Size = new System.Drawing.Size(150, 28);
            this.chbHD.TabIndex = 2;
            this.chbHD.Text = "Theo hóa đơn";
            this.chbHD.UseVisualStyleBackColor = true;
            // 
            // cbNCC
            // 
            this.cbNCC.FormattingEnabled = true;
            this.cbNCC.Location = new System.Drawing.Point(26, 239);
            this.cbNCC.Name = "cbNCC";
            this.cbNCC.Size = new System.Drawing.Size(184, 32);
            this.cbNCC.TabIndex = 3;
            // 
            // chbNCC
            // 
            this.chbNCC.AutoSize = true;
            this.chbNCC.Location = new System.Drawing.Point(26, 204);
            this.chbNCC.Name = "chbNCC";
            this.chbNCC.Size = new System.Drawing.Size(119, 28);
            this.chbNCC.TabIndex = 2;
            this.chbNCC.Text = "Theo NCC";
            this.chbNCC.UseVisualStyleBackColor = true;
            // 
            // dtpDen
            // 
            this.dtpDen.CustomFormat = "dd/MM/yyyy";
            this.dtpDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDen.Location = new System.Drawing.Point(26, 135);
            this.dtpDen.Name = "dtpDen";
            this.dtpDen.Size = new System.Drawing.Size(184, 29);
            this.dtpDen.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Đến ngày";
            // 
            // dtpTu
            // 
            this.dtpTu.CustomFormat = "dd/MM/yyyy";
            this.dtpTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTu.Location = new System.Drawing.Point(26, 68);
            this.dtpTu.Name = "dtpTu";
            this.dtpTu.Size = new System.Drawing.Size(184, 29);
            this.dtpTu.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(396, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(493, 39);
            this.label3.TabIndex = 0;
            this.label3.Text = "BÁO CÁO NHẬP HÀNG KHO";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmBaoCaoNhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1908, 935);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgBCNH);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBaoCaoNhapHang";
            this.Text = "frmBaoCaoNhapHang";
            this.Load += new System.EventHandler(this.frmBaoCaoNhapHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgBCNH)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgBCNH;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnThucHien;
        private System.Windows.Forms.ComboBox cbHD;
        private System.Windows.Forms.CheckBox chbHD;
        private System.Windows.Forms.ComboBox cbNCC;
        private System.Windows.Forms.CheckBox chbNCC;
        private System.Windows.Forms.DateTimePicker dtpDen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}