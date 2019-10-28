namespace QUANLYKHACHSAN_PHANTAN
{
    partial class frmQLKhachHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQLKhachHang));
            this.imgs_Button = new System.Windows.Forms.ImageList(this.components);
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.btnReload = new System.Windows.Forms.Button();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bn_DSKhachHang = new System.Windows.Forms.BindingNavigator(this.components);
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dgv_DSKhachHang = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnSuaKH = new System.Windows.Forms.Button();
            this.btnThemKH = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bn_DSKhachHang)).BeginInit();
            this.bn_DSKhachHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DSKhachHang)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgs_Button
            // 
            this.imgs_Button.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgs_Button.ImageStream")));
            this.imgs_Button.TransparentColor = System.Drawing.Color.Transparent;
            this.imgs_Button.Images.SetKeyName(0, "icon_reload.png");
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(65, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // btnReload
            // 
            this.btnReload.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnReload.FlatAppearance.BorderSize = 0;
            this.btnReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReload.Location = new System.Drawing.Point(952, 0);
            this.btnReload.Margin = new System.Windows.Forms.Padding(4);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(60, 66);
            this.btnReload.TabIndex = 4;
            this.btnReload.UseVisualStyleBackColor = true;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.ForeColor = System.Drawing.Color.Black;
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(52, 24);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bn_DSKhachHang
            // 
            this.bn_DSKhachHang.AddNewItem = null;
            this.bn_DSKhachHang.BackColor = System.Drawing.SystemColors.Control;
            this.bn_DSKhachHang.CountItem = this.bindingNavigatorCountItem;
            this.bn_DSKhachHang.DeleteItem = null;
            this.bn_DSKhachHang.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bn_DSKhachHang.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bn_DSKhachHang.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bn_DSKhachHang.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bn_DSKhachHang.Location = new System.Drawing.Point(0, 570);
            this.bn_DSKhachHang.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bn_DSKhachHang.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bn_DSKhachHang.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bn_DSKhachHang.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bn_DSKhachHang.Name = "bn_DSKhachHang";
            this.bn_DSKhachHang.PositionItem = this.bindingNavigatorPositionItem;
            this.bn_DSKhachHang.Size = new System.Drawing.Size(1012, 27);
            this.bn_DSKhachHang.TabIndex = 15;
            this.bn_DSKhachHang.Text = "bn_DSNhanVien";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.DarkGreen;
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(343, 12);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(108, 36);
            this.btnTimKiem.TabIndex = 1;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // dgv_DSKhachHang
            // 
            this.dgv_DSKhachHang.AllowUserToAddRows = false;
            this.dgv_DSKhachHang.AllowUserToDeleteRows = false;
            this.dgv_DSKhachHang.AllowUserToResizeColumns = false;
            this.dgv_DSKhachHang.AllowUserToResizeRows = false;
            this.dgv_DSKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DSKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_DSKhachHang.Location = new System.Drawing.Point(0, 107);
            this.dgv_DSKhachHang.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_DSKhachHang.Name = "dgv_DSKhachHang";
            this.dgv_DSKhachHang.ReadOnly = true;
            this.dgv_DSKhachHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_DSKhachHang.Size = new System.Drawing.Size(1012, 490);
            this.dgv_DSKhachHang.TabIndex = 16;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnReload);
            this.panel4.Controls.Add(this.btnTimKiem);
            this.panel4.Controls.Add(this.txtTimKiem);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 41);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1012, 66);
            this.panel4.TabIndex = 14;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.AutoCompleteCustomSource.AddRange(new string[] {
            "Lộc",
            "Đức"});
            this.txtTimKiem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.ForeColor = System.Drawing.Color.DarkGray;
            this.txtTimKiem.Location = new System.Drawing.Point(16, 12);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(317, 34);
            this.txtTimKiem.TabIndex = 0;
            this.txtTimKiem.Text = "Nhập CMND";
            this.txtTimKiem.Enter += new System.EventHandler(this.txtTimKiem_Enter);
            // 
            // btnSuaKH
            // 
            this.btnSuaKH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSuaKH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(116)))), ((int)(((byte)(205)))));
            this.btnSuaKH.FlatAppearance.BorderSize = 0;
            this.btnSuaKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaKH.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaKH.ForeColor = System.Drawing.Color.White;
            this.btnSuaKH.Location = new System.Drawing.Point(0, 119);
            this.btnSuaKH.Margin = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.btnSuaKH.Name = "btnSuaKH";
            this.btnSuaKH.Size = new System.Drawing.Size(199, 53);
            this.btnSuaKH.TabIndex = 2;
            this.btnSuaKH.Text = "Sửa Khách Hàng";
            this.btnSuaKH.UseVisualStyleBackColor = false;
            // 
            // btnThemKH
            // 
            this.btnThemKH.BackColor = System.Drawing.Color.SeaGreen;
            this.btnThemKH.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThemKH.FlatAppearance.BorderSize = 0;
            this.btnThemKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemKH.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemKH.ForeColor = System.Drawing.Color.White;
            this.btnThemKH.Location = new System.Drawing.Point(0, 48);
            this.btnThemKH.Margin = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.btnThemKH.Name = "btnThemKH";
            this.btnThemKH.Size = new System.Drawing.Size(199, 53);
            this.btnThemKH.TabIndex = 1;
            this.btnThemKH.Text = "Thêm Khách Hàng";
            this.btnThemKH.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(199, 48);
            this.panel3.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSuaKH);
            this.panel2.Controls.Add(this.btnThemKH);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1012, 41);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(199, 556);
            this.panel2.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1211, 41);
            this.panel1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1140, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "Quản Lý Khách Hàng";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Location = new System.Drawing.Point(1140, 0);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(71, 41);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "Đóng";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmQLKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.ClientSize = new System.Drawing.Size(1211, 597);
            this.Controls.Add(this.bn_DSKhachHang);
            this.Controls.Add(this.dgv_DSKhachHang);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmQLKhachHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Khách Hàng";
            this.Load += new System.EventHandler(this.frmQLKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bn_DSKhachHang)).EndInit();
            this.bn_DSKhachHang.ResumeLayout(false);
            this.bn_DSKhachHang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DSKhachHang)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imgs_Button;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.BindingNavigator bn_DSKhachHang;
        private System.Windows.Forms.Button btnTimKiem;
        public System.Windows.Forms.DataGridView dgv_DSKhachHang;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnSuaKH;
        private System.Windows.Forms.Button btnThemKH;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThoat;
    }
}