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
using QUANLYKHACHSAN_PHANTAN.NhanVien_Wcf;

namespace QUANLYKHACHSAN_PHANTAN
{
    public partial class frmTextNhanVien : Form
    {
        string lb_TitleName;
        int id_NhanVien;
        int kieuForm;
        frmQuanLyNhanVien frmQLNV;

        public string Lb_TitleName
        {
            get
            {
                return lb_TitleName;
            }

            set
            {
                lb_TitleName = value;
            }
        }

        public int Id_NhanVien
        {
            get
            {
                return id_NhanVien;
            }

            set
            {
                id_NhanVien = value;
            }
        }

        public int KieuForm
        {
            get
            {
                return kieuForm;
            }

            set
            {
                kieuForm = value;
            }
        }


        //Kiểu Form
        //1: là form thêm nhân viên
        //2: là form sửa nhân viên

        public frmTextNhanVien()
        {
            InitializeComponent();
        }

        public frmTextNhanVien(frmQuanLyNhanVien fql,string title)
        {
            InitializeComponent();
            this.Text = "Thêm Nhân Viên";
            Lb_TitleName = title;
            KieuForm = 1;
            this.Size = new Size(524, 516);
            frmQLNV = fql;
        }

        public frmTextNhanVien(frmQuanLyNhanVien fql, string title, int id_nhanvien)
        {
            InitializeComponent();
            Lb_TitleName = title;
            this.Text = "Sửa Nhân Viên";
            Id_NhanVien = id_nhanvien;
            KieuForm = 2;
            this.Size = new Size(524, 415);
            label8.Visible = false;
            label9.Visible = false;
            txtMatKhau.Visible = false;
            txtNhapLai.Visible = false;
            frmQLNV = fql;
        }

        

        private void frmTextNhanVien_Load(object sender, EventArgs e)
        {
            lbTieuDe.Text = Lb_TitleName;

            //Load Dữ Liệu Thêm Nhân Viên
            if (KieuForm == 1)
            {
                txtHo.Text = "Nguyễn Quang";
                txtTen.Text = "Hải";
                txtEmail.Text = "hai@gmail.com";
                txtMatKhau.Text = "123";
                txtNhapLai.Text = "123";
                cbx_CaLamViec.SelectedIndex = 0;
                cbx_ChucVu.SelectedIndex = 0;
                cbx_GioiTinh.SelectedIndex = 0;
            }

            //Load Dữ Liệu Nhân Viên Cần Sửa
            if (KieuForm == 2)
            {
                NhanVien_WCFClient nv_wcf = new NhanVien_WCFClient();

                NhanVien_Ent nv_ent = nv_wcf.GetNhanVien_by_ID(Id_NhanVien);
                txtHo.Text = nv_ent.Ho.Trim();
                txtTen.Text = nv_ent.Ten.Trim();
                txtEmail.Text = nv_ent.Email.Trim();

                cbx_GioiTinh.Text = nv_ent.GioiTinh;
                cbx_ChucVu.Text = nv_ent.ChucVu;
                cbx_CaLamViec.Text = nv_ent.CaLamViec;

                dtp_NgaySinh.Value = nv_ent.NgaySinh;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult ds = MessageBox.Show("Bạn Muốn Hủy ?", "QUAY VỀ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

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

        private bool CheckNull()
        {
            if(cbx_GioiTinh.Text.Equals(""))
            {
                return false;
            }
            if (cbx_ChucVu.Text.Equals(""))
            {
                return false;
            }
            if (cbx_CaLamViec.Text.Equals(""))
            {
                return false;
            }
            return true;
        }

        //Reload
        private void Clear_TextBox()
        {
            txtHo.Clear();
            txtTen.Clear();
            txtEmail.Clear();
            txtMatKhau.Clear();
            txtNhapLai.Clear();
            cbx_CaLamViec.SelectedIndex = -1;
            cbx_ChucVu.SelectedIndex = -1;
            cbx_GioiTinh.SelectedIndex = -1;
            dtp_NgaySinh.Value = DateTime.Now;
        }

        private void Luu_Them()
        {
            if (!CheckNull())
            {
                MessageBox.Show("Chưa Nhập Đủ Thông Tin", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!txtMatKhau.Text.Trim().Equals(txtNhapLai.Text.Trim()))
            {
                MessageBox.Show("Mật Khẩu Không Giống Nhau", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NhanVien_WCFClient nv_wcf = new NhanVien_WCFClient();

            NhanVien_Ent nv_ent = new NhanVien_Ent();
            nv_ent.Ho = txtHo.Text.Trim();
            nv_ent.Ten = txtTen.Text.Trim();


            if (cbx_GioiTinh.SelectedIndex == 0)
            {
                nv_ent.GioiTinh = "nam";
            }
            if (cbx_GioiTinh.SelectedIndex == 1)
            {
                nv_ent.GioiTinh = "nu";
            }

            nv_ent.NgaySinh = dtp_NgaySinh.Value;

            if (cbx_ChucVu.SelectedIndex == 0)
            {
                nv_ent.ChucVu = "quanly";
               
            }
            if (cbx_ChucVu.SelectedIndex == 1)
            {
                nv_ent.ChucVu = "nhanvien";
               
            }


            if (cbx_CaLamViec.SelectedIndex == 0)
            {
                nv_ent.CaLamViec = "sang";
            }
            if (cbx_CaLamViec.SelectedIndex == 1)
            {
                nv_ent.CaLamViec = "chieu";
            }
            if (cbx_CaLamViec.SelectedIndex == 2)
            {
                nv_ent.CaLamViec = "toi";
            }

            nv_ent.Email = txtEmail.Text.Trim();

            string matKhau = maHoaMatKhau(txtNhapLai.Text.Trim());

            if (nv_wcf.ThemNhanVien(nv_ent, matKhau))
            {
                DialogResult ds = MessageBox.Show("Lưu Thành Công, Tiếp Tục ?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if(ds == DialogResult.Yes)
                {
                    Clear_TextBox();
                    return;
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                DialogResult ds = MessageBox.Show("Lưu Thất Bại, Thử Lại ?", "LỖI", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (ds == DialogResult.Yes)
                {
                    return;
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void Luu_Sua()
        {
            if (!CheckNull())
            {
                MessageBox.Show("Chưa Nhập Đủ Thông Tin", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NhanVien_WCFClient nv_wcf = new NhanVien_WCFClient();

            NhanVien_Ent nv_ent = new NhanVien_Ent();
            nv_ent.Ho = txtHo.Text.Trim();
            nv_ent.Ten = txtTen.Text.Trim();

            //Nam
            if (cbx_GioiTinh.SelectedIndex == 0)
            {
                nv_ent.GioiTinh = "nam";
            }
            //Nữ
            if (cbx_GioiTinh.SelectedIndex == 1)
            {
                nv_ent.GioiTinh = "nu";
            }

            nv_ent.NgaySinh = dtp_NgaySinh.Value;

            //Quản Lý
            if (cbx_ChucVu.SelectedIndex == 0)
            {
                nv_ent.ChucVu = "quanly";

            }
            //Nhân Viên
            if (cbx_ChucVu.SelectedIndex == 1)
            {
                nv_ent.ChucVu = "nhanvien";

            }

            //Sáng
            if (cbx_CaLamViec.SelectedIndex == 0)
            {
                nv_ent.CaLamViec = "sang";
            }
            //Chiều
            if (cbx_CaLamViec.SelectedIndex == 1)
            {
                nv_ent.CaLamViec = "chieu";
            }
            //Tối
            if (cbx_CaLamViec.SelectedIndex == 2)
            {
                nv_ent.CaLamViec = "toi";
            }

            nv_ent.Email = txtEmail.Text.Trim();

            //Xử Lý Update
            if (nv_wcf.CapNhatNhanVien(nv_ent))
            {
                DialogResult ds = MessageBox.Show("Lưu Thành Công, Tiếp Tục ?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (ds == DialogResult.Yes)
                {
                    return;
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                DialogResult ds = MessageBox.Show("Lưu Thất Bại, Thử Lại ?", "LỖI", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (ds == DialogResult.Yes)
                {
                    return;
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(KieuForm == 1)
            {
                Luu_Them();
            }
            if(KieuForm == 2)
            {
                Luu_Sua();
            }
        }

        private void frmTextNhanVien_Shown(object sender, EventArgs e)
        {
           
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            Clear_TextBox();
        }

        private void frmTextNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            NhanVien_WCFClient nv_wcf = new NhanVien_WCFClient();
            frmQLNV.Loading_DSNhanVien(frmQLNV.DataTable_DSNhanVien(nv_wcf.GetNhanViens().ToList()));
            frmQLNV.Custom_DataGridView(frmQLNV.dgv_DSNhanVien);
        }
    }
}
