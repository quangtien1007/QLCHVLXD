﻿namespace QuanLiVLXD
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.accToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDangNhap = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTaoTK = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDoiMK = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQLTK = new System.Windows.Forms.ToolStripMenuItem();
            this.tacVuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNhapHang = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBanHang = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGiaoHang = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.nhàCungCấpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.khoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.loạiHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hàngHóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelCentral = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sttTTTaiKhoan = new System.Windows.Forms.ToolStripStatusLabel();
            this.sttTTThoiGian = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.panelCentral.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accToolStripMenuItem,
            this.tacVuToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(245, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // accToolStripMenuItem
            // 
            this.accToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDangNhap,
            this.menuTaoTK,
            this.menuDoiMK,
            this.menuDangXuat,
            this.menuQLTK});
            this.accToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accToolStripMenuItem.Name = "accToolStripMenuItem";
            this.accToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
            this.accToolStripMenuItem.Text = "Tài khoản";
            // 
            // menuDangNhap
            // 
            this.menuDangNhap.Name = "menuDangNhap";
            this.menuDangNhap.Size = new System.Drawing.Size(196, 24);
            this.menuDangNhap.Text = "Đăng nhập";
            this.menuDangNhap.Click += new System.EventHandler(this.menuDangNhap_Click);
            // 
            // menuTaoTK
            // 
            this.menuTaoTK.Name = "menuTaoTK";
            this.menuTaoTK.Size = new System.Drawing.Size(196, 24);
            this.menuTaoTK.Text = "Tạo tài khoản";
            this.menuTaoTK.Click += new System.EventHandler(this.menuTaoTK_Click);
            // 
            // menuDoiMK
            // 
            this.menuDoiMK.Name = "menuDoiMK";
            this.menuDoiMK.Size = new System.Drawing.Size(196, 24);
            this.menuDoiMK.Text = "Đổi mật khẩu";
            this.menuDoiMK.Click += new System.EventHandler(this.menuDoiMK_Click);
            // 
            // menuDangXuat
            // 
            this.menuDangXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuDangXuat.Name = "menuDangXuat";
            this.menuDangXuat.Size = new System.Drawing.Size(196, 24);
            this.menuDangXuat.Text = "Đăng xuất";
            this.menuDangXuat.Click += new System.EventHandler(this.menuDangXuat_Click);
            // 
            // menuQLTK
            // 
            this.menuQLTK.Name = "menuQLTK";
            this.menuQLTK.Size = new System.Drawing.Size(196, 24);
            this.menuQLTK.Text = "Quản lí tài khoản";
            this.menuQLTK.Click += new System.EventHandler(this.menuQLTK_Click);
            // 
            // tacVuToolStripMenuItem
            // 
            this.tacVuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNhapHang,
            this.menuBanHang,
            this.menuGiaoHang,
            this.menuDanhMuc,
            this.nhàCungCấpToolStripMenuItem,
            this.khoToolStripMenuItem,
            this.menuKhachHang,
            this.loạiHàngToolStripMenuItem,
            this.hàngHóaToolStripMenuItem});
            this.tacVuToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tacVuToolStripMenuItem.Name = "tacVuToolStripMenuItem";
            this.tacVuToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.tacVuToolStripMenuItem.Text = "Tác vụ";
            // 
            // menuNhapHang
            // 
            this.menuNhapHang.Name = "menuNhapHang";
            this.menuNhapHang.Size = new System.Drawing.Size(222, 24);
            this.menuNhapHang.Text = "Nhập hàng";
            this.menuNhapHang.Click += new System.EventHandler(this.menuNhapHang_Click);
            // 
            // menuBanHang
            // 
            this.menuBanHang.Name = "menuBanHang";
            this.menuBanHang.Size = new System.Drawing.Size(222, 24);
            this.menuBanHang.Text = "Bán hàng";
            // 
            // menuGiaoHang
            // 
            this.menuGiaoHang.Name = "menuGiaoHang";
            this.menuGiaoHang.Size = new System.Drawing.Size(222, 24);
            this.menuGiaoHang.Text = "Xuất hàng";
            this.menuGiaoHang.Click += new System.EventHandler(this.menuGiaoHang_Click);
            // 
            // menuDanhMuc
            // 
            this.menuDanhMuc.Name = "menuDanhMuc";
            this.menuDanhMuc.Size = new System.Drawing.Size(222, 24);
            this.menuDanhMuc.Text = "Danh mục hàng hóa";
            // 
            // nhàCungCấpToolStripMenuItem
            // 
            this.nhàCungCấpToolStripMenuItem.Name = "nhàCungCấpToolStripMenuItem";
            this.nhàCungCấpToolStripMenuItem.Size = new System.Drawing.Size(222, 24);
            this.nhàCungCấpToolStripMenuItem.Text = "Nhà cung cấp";
            this.nhàCungCấpToolStripMenuItem.Click += new System.EventHandler(this.nhàCungCấpToolStripMenuItem_Click);
            // 
            // khoToolStripMenuItem
            // 
            this.khoToolStripMenuItem.Name = "khoToolStripMenuItem";
            this.khoToolStripMenuItem.Size = new System.Drawing.Size(222, 24);
            this.khoToolStripMenuItem.Text = "Kho";
            // 
            // menuKhachHang
            // 
            this.menuKhachHang.Name = "menuKhachHang";
            this.menuKhachHang.Size = new System.Drawing.Size(222, 24);
            this.menuKhachHang.Text = "Khách hàng";
            this.menuKhachHang.Click += new System.EventHandler(this.menuKhachHang_Click);
            // 
            // loạiHàngToolStripMenuItem
            // 
            this.loạiHàngToolStripMenuItem.Name = "loạiHàngToolStripMenuItem";
            this.loạiHàngToolStripMenuItem.Size = new System.Drawing.Size(222, 24);
            this.loạiHàngToolStripMenuItem.Text = "Loại hàng";
            this.loạiHàngToolStripMenuItem.Click += new System.EventHandler(this.loạiHàngToolStripMenuItem_Click);
            // 
            // hàngHóaToolStripMenuItem
            // 
            this.hàngHóaToolStripMenuItem.Name = "hàngHóaToolStripMenuItem";
            this.hàngHóaToolStripMenuItem.Size = new System.Drawing.Size(222, 24);
            this.hàngHóaToolStripMenuItem.Text = "Hàng hóa";
            this.hàngHóaToolStripMenuItem.Click += new System.EventHandler(this.hàngHóaToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.helpToolStripMenuItem.Text = "Trợ giúp";
            // 
            // panelCentral
            // 
            this.panelCentral.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelCentral.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelCentral.BackgroundImage")));
            this.panelCentral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelCentral.Controls.Add(this.statusStrip1);
            this.panelCentral.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelCentral.Location = new System.Drawing.Point(0, 28);
            this.panelCentral.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelCentral.Name = "panelCentral";
            this.panelCentral.Size = new System.Drawing.Size(1924, 975);
            this.panelCentral.TabIndex = 28;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.White;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sttTTTaiKhoan,
            this.sttTTThoiGian});
            this.statusStrip1.Location = new System.Drawing.Point(0, 944);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1924, 30);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sttTTTaiKhoan
            // 
            this.sttTTTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sttTTTaiKhoan.Name = "sttTTTaiKhoan";
            this.sttTTTaiKhoan.Size = new System.Drawing.Size(188, 25);
            this.sttTTTaiKhoan.Text = "toolStripStatusLabel1";
            // 
            // sttTTThoiGian
            // 
            this.sttTTThoiGian.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sttTTThoiGian.Name = "sttTTThoiGian";
            this.sttTTThoiGian.Size = new System.Drawing.Size(188, 25);
            this.sttTTThoiGian.Text = "toolStripStatusLabel2";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1709, 849);
            this.Controls.Add(this.panelCentral);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmMain";
            this.Text = "Quản lý vật liệu xây dựng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelCentral.ResumeLayout(false);
            this.panelCentral.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem accToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuDoiMK;
        private System.Windows.Forms.ToolStripMenuItem menuDangXuat;
        private System.Windows.Forms.ToolStripMenuItem tacVuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuNhapHang;
        private System.Windows.Forms.ToolStripMenuItem menuBanHang;
        private System.Windows.Forms.ToolStripMenuItem menuGiaoHang;
        private System.Windows.Forms.ToolStripMenuItem menuDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuDangNhap;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sttTTTaiKhoan;
        private System.Windows.Forms.ToolStripStatusLabel sttTTThoiGian;
        private System.Windows.Forms.ToolStripMenuItem menuQLTK;
        private System.Windows.Forms.ToolStripMenuItem menuTaoTK;
        private System.Windows.Forms.ToolStripMenuItem nhàCungCấpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem khoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuKhachHang;
        private System.Windows.Forms.ToolStripMenuItem loạiHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hàngHóaToolStripMenuItem;
        public System.Windows.Forms.Panel panelCentral;
    }
}

