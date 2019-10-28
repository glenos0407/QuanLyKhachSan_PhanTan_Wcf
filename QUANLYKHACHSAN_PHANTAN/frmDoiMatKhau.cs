using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Threading;
using QUANLYKHACHSAN_PHANTAN.NhanVien_Wcf;

namespace QUANLYKHACHSAN_PHANTAN
{
    public partial class frmDoiMatKhau : Form
    {
        frmMain fmain;
        //NhanVien_Ent nv = new NhanVien_Ent();
        public string Email { get; set; }

        public frmDoiMatKhau()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public frmDoiMatKhau(string em, frmMain fm)
        {
            InitializeComponent();
            Email = em;
            fmain = fm;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult ds = MessageBox.Show("Hủy Đổi Mật Khẩu ?", "THOÁT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (ds == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }

        private string maHoaMatKhau(string pass)
        {
            //Tạo MD5 
            MD5 mh = MD5.Create();

            //Chuyển kiểu chuổi thành kiểu byte
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(pass);

            //Mã hóa chuỗi đã chuyển
            byte[] hash = mh.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }

            string temp = sb.ToString();
            temp.Reverse();
            return temp;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMatKhauMoi.Text.Equals("") || txtMatKhauCu.Text.Equals(""))
            {
                return;
            }

            if (!txtMatKhauMoi.Text.Equals(txtNhapLai.Text.Trim()))
            {
                MessageBox.Show("Mật Khẩu Không Trùng Khớp", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            NhanVien_WCFClient nv_wcf = new NhanVien_WCFClient();

            string matkhaucu = maHoaMatKhau(txtMatKhauCu.Text.Trim());
            string matkhaumoi = maHoaMatKhau(txtMatKhauMoi.Text.Trim());

            if (nv_wcf.CapNhatMatKhau(Email, matkhaucu, matkhaumoi))
            {
                MessageBox.Show("Đổi Mật Khẩu Thành Công. Yêu Cầu Đăng Nhập Lại", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Thread th = new Thread(open_backlogin);
                Thread.Sleep(300);
#pragma warning disable CS0618 // Type or member is obsolete
                th.ApartmentState = ApartmentState.STA;
#pragma warning restore CS0618 // Type or member is obsolete
                th.Start();
                this.Close();
                fmain.isDead = true;
                fmain.Close();
            }
            else
            {
                MessageBox.Show("Không Hợp Lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void open_backlogin()
        {
            Application.Run(new frmLogin());
        }
    }
}
