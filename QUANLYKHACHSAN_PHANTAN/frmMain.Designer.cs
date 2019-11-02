namespace QUANLYKHACHSAN_PHANTAN
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTime = new System.Windows.Forms.Label();
            this.lbAccount = new System.Windows.Forms.Label();
            this.btnShowMenu = new System.Windows.Forms.Button();
            this.imgs_Button = new System.Windows.Forms.ImageList(this.components);
            this.pnl_Menu = new System.Windows.Forms.Panel();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.btnDichVu = new System.Windows.Forms.Button();
            this.btnPhong = new System.Windows.Forms.Button();
            this.btnKhachHang = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.btnDatPhong = new System.Windows.Forms.Button();
            this.btnTaiKhoan = new System.Windows.Forms.Button();
            this.pnl_SubForm = new System.Windows.Forms.Panel();
            this.timer_System = new System.Windows.Forms.Timer(this.components);
            this.cmnstrp_NhanVien = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.QuanLyTaiKhoanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DoiMatKhauToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DangXuatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.pnl_Menu.SuspendLayout();
            this.cmnstrp_NhanVien.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.panel1.Controls.Add(this.lbTime);
            this.panel1.Controls.Add(this.lbAccount);
            this.panel1.Controls.Add(this.btnShowMenu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1101, 38);
            this.panel1.TabIndex = 0;
            // 
            // lbTime
            // 
            this.lbTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbTime.BackColor = System.Drawing.Color.Transparent;
            this.lbTime.ForeColor = System.Drawing.Color.White;
            this.lbTime.Location = new System.Drawing.Point(246, 9);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(546, 21);
            this.lbTime.TabIndex = 2;
            this.lbTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbAccount
            // 
            this.lbAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAccount.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAccount.ForeColor = System.Drawing.Color.White;
            this.lbAccount.Location = new System.Drawing.Point(839, 9);
            this.lbAccount.Name = "lbAccount";
            this.lbAccount.Size = new System.Drawing.Size(250, 21);
            this.lbAccount.TabIndex = 1;
            this.lbAccount.Text = "Xin Chào, Trần Huỳnh Công Lộc";
            this.lbAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnShowMenu
            // 
            this.btnShowMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.btnShowMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnShowMenu.FlatAppearance.BorderSize = 0;
            this.btnShowMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowMenu.ForeColor = System.Drawing.Color.White;
            this.btnShowMenu.Location = new System.Drawing.Point(0, 0);
            this.btnShowMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnShowMenu.Name = "btnShowMenu";
            this.btnShowMenu.Size = new System.Drawing.Size(56, 38);
            this.btnShowMenu.TabIndex = 0;
            this.btnShowMenu.UseVisualStyleBackColor = false;
            this.btnShowMenu.Click += new System.EventHandler(this.btnShowMenu_Click);
            // 
            // imgs_Button
            // 
            this.imgs_Button.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgs_Button.ImageStream")));
            this.imgs_Button.TransparentColor = System.Drawing.Color.Transparent;
            this.imgs_Button.Images.SetKeyName(0, "icon_menu.png");
            this.imgs_Button.Images.SetKeyName(1, "icon_Account.png");
            this.imgs_Button.Images.SetKeyName(2, "icon_door.png");
            this.imgs_Button.Images.SetKeyName(3, "icon-customer.png");
            this.imgs_Button.Images.SetKeyName(4, "check-out.png");
            this.imgs_Button.Images.SetKeyName(5, "growth.png");
            this.imgs_Button.Images.SetKeyName(6, "hotel.png");
            this.imgs_Button.Images.SetKeyName(7, "rating.png");
            // 
            // pnl_Menu
            // 
            this.pnl_Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.pnl_Menu.Controls.Add(this.btnBaoCao);
            this.pnl_Menu.Controls.Add(this.btnDichVu);
            this.pnl_Menu.Controls.Add(this.btnPhong);
            this.pnl_Menu.Controls.Add(this.btnKhachHang);
            this.pnl_Menu.Controls.Add(this.btnCheckOut);
            this.pnl_Menu.Controls.Add(this.btnDatPhong);
            this.pnl_Menu.Controls.Add(this.btnTaiKhoan);
            this.pnl_Menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_Menu.Location = new System.Drawing.Point(0, 38);
            this.pnl_Menu.Name = "pnl_Menu";
            this.pnl_Menu.Size = new System.Drawing.Size(164, 631);
            this.pnl_Menu.TabIndex = 1;
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.BackColor = System.Drawing.Color.Teal;
            this.btnBaoCao.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBaoCao.FlatAppearance.BorderSize = 0;
            this.btnBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnBaoCao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaoCao.Location = new System.Drawing.Point(0, 260);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(164, 52);
            this.btnBaoCao.TabIndex = 13;
            this.btnBaoCao.Text = "Báo Cáo ";
            this.btnBaoCao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBaoCao.UseVisualStyleBackColor = false;
            // 
            // btnDichVu
            // 
            this.btnDichVu.BackColor = System.Drawing.Color.Teal;
            this.btnDichVu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDichVu.FlatAppearance.BorderSize = 0;
            this.btnDichVu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDichVu.ForeColor = System.Drawing.Color.White;
            this.btnDichVu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDichVu.Location = new System.Drawing.Point(0, 208);
            this.btnDichVu.Name = "btnDichVu";
            this.btnDichVu.Size = new System.Drawing.Size(164, 52);
            this.btnDichVu.TabIndex = 12;
            this.btnDichVu.Text = "QL Dịch Vụ";
            this.btnDichVu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDichVu.UseVisualStyleBackColor = false;
            this.btnDichVu.Click += new System.EventHandler(this.btnDichVu_Click);
            // 
            // btnPhong
            // 
            this.btnPhong.BackColor = System.Drawing.Color.Teal;
            this.btnPhong.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPhong.FlatAppearance.BorderSize = 0;
            this.btnPhong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhong.ForeColor = System.Drawing.Color.White;
            this.btnPhong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPhong.Location = new System.Drawing.Point(0, 156);
            this.btnPhong.Name = "btnPhong";
            this.btnPhong.Size = new System.Drawing.Size(164, 52);
            this.btnPhong.TabIndex = 11;
            this.btnPhong.Text = "QL Phòng";
            this.btnPhong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPhong.UseVisualStyleBackColor = false;
            this.btnPhong.Click += new System.EventHandler(this.btnPhong_Click);
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.BackColor = System.Drawing.Color.Teal;
            this.btnKhachHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKhachHang.FlatAppearance.BorderSize = 0;
            this.btnKhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhachHang.ForeColor = System.Drawing.Color.White;
            this.btnKhachHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKhachHang.Location = new System.Drawing.Point(0, 104);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Size = new System.Drawing.Size(164, 52);
            this.btnKhachHang.TabIndex = 10;
            this.btnKhachHang.Text = "QL Khách Hàng";
            this.btnKhachHang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKhachHang.UseVisualStyleBackColor = false;
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.BackColor = System.Drawing.Color.Teal;
            this.btnCheckOut.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCheckOut.FlatAppearance.BorderSize = 0;
            this.btnCheckOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckOut.ForeColor = System.Drawing.Color.White;
            this.btnCheckOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheckOut.Location = new System.Drawing.Point(0, 52);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(164, 52);
            this.btnCheckOut.TabIndex = 2;
            this.btnCheckOut.Text = "Trả Phòng";
            this.btnCheckOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCheckOut.UseVisualStyleBackColor = false;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // btnDatPhong
            // 
            this.btnDatPhong.BackColor = System.Drawing.Color.Teal;
            this.btnDatPhong.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDatPhong.FlatAppearance.BorderSize = 0;
            this.btnDatPhong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatPhong.ForeColor = System.Drawing.Color.White;
            this.btnDatPhong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDatPhong.Location = new System.Drawing.Point(0, 0);
            this.btnDatPhong.Name = "btnDatPhong";
            this.btnDatPhong.Size = new System.Drawing.Size(164, 52);
            this.btnDatPhong.TabIndex = 1;
            this.btnDatPhong.Text = "Đặt Phòng";
            this.btnDatPhong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDatPhong.UseVisualStyleBackColor = false;
            this.btnDatPhong.Click += new System.EventHandler(this.btnDatPhong_Click);
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.BackColor = System.Drawing.Color.Teal;
            this.btnTaiKhoan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnTaiKhoan.FlatAppearance.BorderSize = 0;
            this.btnTaiKhoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaiKhoan.ForeColor = System.Drawing.Color.White;
            this.btnTaiKhoan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaiKhoan.Location = new System.Drawing.Point(0, 579);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Size = new System.Drawing.Size(164, 52);
            this.btnTaiKhoan.TabIndex = 0;
            this.btnTaiKhoan.Text = "QL Nhân Viên";
            this.btnTaiKhoan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTaiKhoan.UseVisualStyleBackColor = false;
            this.btnTaiKhoan.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnTaiKhoan_MouseClick);
            // 
            // pnl_SubForm
            // 
            this.pnl_SubForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_SubForm.Location = new System.Drawing.Point(164, 38);
            this.pnl_SubForm.Name = "pnl_SubForm";
            this.pnl_SubForm.Size = new System.Drawing.Size(937, 631);
            this.pnl_SubForm.TabIndex = 2;
            // 
            // timer_System
            // 
            this.timer_System.Enabled = true;
            this.timer_System.Interval = 1000;
            this.timer_System.Tick += new System.EventHandler(this.timerSystem_Tick);
            // 
            // cmnstrp_NhanVien
            // 
            this.cmnstrp_NhanVien.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmnstrp_NhanVien.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmnstrp_NhanVien.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.QuanLyTaiKhoanToolStripMenuItem,
            this.DoiMatKhauToolStripMenuItem,
            this.DangXuatToolStripMenuItem});
            this.cmnstrp_NhanVien.Name = "cmnstrp_NhanVien";
            this.cmnstrp_NhanVien.Size = new System.Drawing.Size(261, 100);
            // 
            // QuanLyTaiKhoanToolStripMenuItem
            // 
            this.QuanLyTaiKhoanToolStripMenuItem.Name = "QuanLyTaiKhoanToolStripMenuItem";
            this.QuanLyTaiKhoanToolStripMenuItem.Size = new System.Drawing.Size(260, 32);
            this.QuanLyTaiKhoanToolStripMenuItem.Text = "Quản Lý Nhân Viên";
            this.QuanLyTaiKhoanToolStripMenuItem.Click += new System.EventHandler(this.QuanLyNhanVienToolStripMenuItem_Click);
            // 
            // DoiMatKhauToolStripMenuItem
            // 
            this.DoiMatKhauToolStripMenuItem.Name = "DoiMatKhauToolStripMenuItem";
            this.DoiMatKhauToolStripMenuItem.Size = new System.Drawing.Size(260, 32);
            this.DoiMatKhauToolStripMenuItem.Text = "Đổi Mật Khẩu";
            this.DoiMatKhauToolStripMenuItem.Click += new System.EventHandler(this.DoiMatKhauToolStripMenuItem_Click);
            // 
            // DangXuatToolStripMenuItem
            // 
            this.DangXuatToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DangXuatToolStripMenuItem.Name = "DangXuatToolStripMenuItem";
            this.DangXuatToolStripMenuItem.Size = new System.Drawing.Size(260, 32);
            this.DangXuatToolStripMenuItem.Text = "Đăng Xuất";
            this.DangXuatToolStripMenuItem.Click += new System.EventHandler(this.DangXuatToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 669);
            this.Controls.Add(this.pnl_SubForm);
            this.Controls.Add(this.pnl_Menu);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMain";
            this.Text = " Giao Diện Chính";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            this.pnl_Menu.ResumeLayout(false);
            this.cmnstrp_NhanVien.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnShowMenu;
        private System.Windows.Forms.ImageList imgs_Button;
        private System.Windows.Forms.Panel pnl_Menu;
        private System.Windows.Forms.Button btnTaiKhoan;
        private System.Windows.Forms.Panel pnl_SubForm;
        private System.Windows.Forms.Label lbAccount;
        private System.Windows.Forms.Button btnDatPhong;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Timer timer_System;
        private System.Windows.Forms.ContextMenuStrip cmnstrp_NhanVien;
        private System.Windows.Forms.ToolStripMenuItem QuanLyTaiKhoanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DangXuatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DoiMatKhauToolStripMenuItem;
        private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.Button btnDichVu;
        private System.Windows.Forms.Button btnPhong;
        private System.Windows.Forms.Button btnKhachHang;
        private System.Windows.Forms.Button btnCheckOut;
    }
}