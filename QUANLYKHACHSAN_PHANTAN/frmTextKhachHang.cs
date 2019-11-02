using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QUANLYKHACHSAN_PHANTAN.KhachHang_Wcf;

namespace QUANLYKHACHSAN_PHANTAN
{
    public partial class frmTextKhachHang : Form
    {
        string lb_TitleName;
        KhachHang_Ent khach;
        int kieuForm;
        bool isShortCutCreate = false;//Lưu Trạng Thái Nếu Có Tham Chiếu Đến Form Này Không Trực Tiếp Từ Form Quản Lý Khách Hàng
        frmQLKhachHang frmQLKH;
        frmDatPhong frmDPh;
        
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

        public KhachHang_Ent Khach
        {
            get
            {
                return khach;
            }

            set
            {
                khach = value;
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
        //1: là form thêm khách hàng
        //2: là form sửa khách hàng
        public frmTextKhachHang(frmQLKhachHang fql, string title)
        {
            InitializeComponent();
            this.Text = "Thêm Khách Hàng";
            Lb_TitleName = title;
            KieuForm = 1;
            this.Size = new Size(664, 389);
            frmQLKH = fql;
        }

        public frmTextKhachHang(frmQLKhachHang fql, string title, KhachHang_Ent kh)
        {   
            InitializeComponent();
            Lb_TitleName = title;
            this.Text = "Sửa Khách Hàng";
            this.khach = kh;
            KieuForm = 2;
            this.Size = new Size(664, 389);
            frmQLKH = fql;
        }

        //Mở frmTextKhachHang qua Lối Tắt từ Form Đặt Phòng
        public frmTextKhachHang(frmDatPhong fdph, string title)
        {
            InitializeComponent();
            isShortCutCreate = true;
            this.Text = "Thêm Khách Hàng";
            Lb_TitleName = title;
            KieuForm = 1;
            this.Size = new Size(664, 389);
            frmDPh = fdph;
        }

        public frmTextKhachHang()
        {
            InitializeComponent();
        }

        private void frmTextKhachHang_Load(object sender, EventArgs e)
        {
            lbTieuDe.Text = Lb_TitleName;

            if (KieuForm == 2)
            {
                txtCMND.Enabled = false;
                btnNhapLai.Visible = false;
                txtHo.Text = khach.Ho;
                txtTen.Text = khach.Ten;
                cbx_GioiTinh.SelectedIndex = 0;
                dtp_NgaySinh.Value = khach.Date_of_birth;
                txtSoDT.Text = khach.Sodienthoai;
                txtCMND.Text = khach.So_cmnd;
                cbx_QuocTich.Text = khach.Quoc_tich;
            }
            else
            {
                txtHo.Text = "Nguyễn Quang";
                txtTen.Text = "Hải";
                cbx_GioiTinh.SelectedIndex = 0;
                txtSoDT.Text = "012234567";
                txtCMND.Text = "123456789";
                cbx_QuocTich.Text = "Việt Nam";
            }
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (KieuForm == 1)
            {
                Luu_Them();
            }
            if (KieuForm == 2)
            {
                Luu_Sua();
            }
        }

        private void Clear_TextBox()
        {
            txtHo.Text = "";
            txtTen.Text = "";
            txtCMND.Text = "";
            txtSoDT.Text = "";
            cbx_QuocTich.SelectedIndex = -1;
            cbx_GioiTinh.SelectedIndex = -1;
            dtp_NgaySinh.Value = DateTime.Now;
        }

        private bool CheckNull()
        {
            if (txtHo.Text == null)
            {
                return false;
            }
            if (cbx_GioiTinh.Text.Equals(""))
            {
                return false;
            }
            return true;
        }
        private void Luu_Them()
        {
            if (!CheckNull())
            {
                MessageBox.Show("Chưa Nhập Đủ Thông Tin", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                KhachHang_WCFClient kh_wcf = new KhachHang_WCFClient(); ;
                KhachHang_Ent kh = new KhachHang_Ent();
                kh.Ho = txtHo.Text.Trim();
                kh.Ten = txtTen.Text.Trim();
                kh.So_cmnd = txtCMND.Text.Trim();
                kh.Sodienthoai = txtSoDT.Text.Trim();
                kh.Quoc_tich = cbx_QuocTich.Text.Trim();
                if (cbx_GioiTinh.SelectedIndex == 0)
                {
                    kh.Gioi_tinh = "nam";
                }
                else
                {
                    kh.Gioi_tinh = "nu";
                }
                kh.Date_of_birth = dtp_NgaySinh.Value;
                if (kh_wcf.ThemKhachHang(kh))
                {
                    DialogResult ds = MessageBox.Show("Lưu Thành Công, Tiếp Tục ?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (ds == DialogResult.Yes)
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
                    DialogResult ds = MessageBox.Show("Lưu Thất Bại, Thử Lại ?", "Lỗi", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
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
        }

        
        private void Luu_Sua()
        {
            if (!CheckNull())
            {
                MessageBox.Show("Chưa Nhập Đủ Thông Tin", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                KhachHang_WCFClient kh_wcf = new KhachHang_WCFClient(); ;
                KhachHang_Ent kh = new KhachHang_Ent();

                kh.Id_khach = khach.Id_khach;
                kh.Ho = txtHo.Text.Trim();
                kh.Ten = txtTen.Text.Trim();
                kh.So_cmnd = txtCMND.Text.Trim();
                kh.Sodienthoai = txtSoDT.Text.Trim();
                kh.Quoc_tich = cbx_QuocTich.Text.Trim();
                if (cbx_GioiTinh.SelectedIndex == 1)
                {
                    kh.Gioi_tinh = "nam";
                }
                else
                {
                    kh.Gioi_tinh = "nu";
                }
                kh.Date_of_birth = dtp_NgaySinh.Value;
                if (kh_wcf.CapNhatKhachHang(kh))
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
        }

        private void frmTextKhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(isShortCutCreate)
            {
                return;
            }

            KhachHang_WCFClient kh_wcf = new KhachHang_WCFClient();
            frmQLKH.Loading_DSKH(frmQLKH.DataTable_DSKH(kh_wcf.GetKhachHangs().ToList()));
            frmQLKH.Custom_DataGridView(frmQLKH.dgv_DSKhachHang);
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            Clear_TextBox();
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
    }

}
