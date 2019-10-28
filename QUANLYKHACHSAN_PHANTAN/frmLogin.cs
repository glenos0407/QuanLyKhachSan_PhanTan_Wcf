using System;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Threading;
using QUANLYKHACHSAN_PHANTAN.NhanVien_Wcf;

namespace QUANLYKHACHSAN_PHANTAN
{
    public partial class frmLogin : Form
    {
        string email;

        public frmLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None; 
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Resource_Img.icon_user;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.BackgroundImage = Resource_Img._043;

            txtEmail.Text = "admin@gmail.com";
            txtMatKhau.Text = "123456";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult ds = MessageBox.Show("Bạn Có Muốn Thoát ?", "Thoát", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

            if (ds == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            else
            {
                return;
            }
        }

        private void cbxHienMK_CheckedChanged(object sender, EventArgs e)
        {
            if (txtMatKhau.UseSystemPasswordChar)
            {
                txtMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;
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

        private void open_frmMain()
        {
            NhanVien_WCFClient nv_wcf = new NhanVien_WCFClient();
            int id_nv = nv_wcf.GetID_by_Email(email);
            Application.Run(new frmMain(id_nv));
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            NhanVien_WCFClient nv_wcf = new NhanVien_WCFClient();

            if (nv_wcf.DangNhapHeThong(txtEmail.Text.Trim(), maHoaMatKhau(txtMatKhau.Text.Trim())))
            {
                email = txtEmail.Text.Trim();
                Thread th = new Thread(open_frmMain);
                th.Start();
                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng Nhập Thất Bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
