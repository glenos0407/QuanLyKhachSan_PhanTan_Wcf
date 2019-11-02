using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QUANLYKHACHSAN_PHANTAN.NhanVien_Wcf;
using QUANLYKHACHSAN_PHANTAN.KhachHang_Wcf;
using QUANLYKHACHSAN_PHANTAN.Phong_Wcf;
using QUANLYKHACHSAN_PHANTAN.PhieuCheckIn_Wcf;
using QUANLYKHACHSAN_PHANTAN.DichVu_Wcf;

namespace QUANLYKHACHSAN_PHANTAN
{
    public partial class frmDatPhong : Form
    {
        string maKH;
        int ID_NV;
        bool isShowing = true;

        public frmDatPhong()
        {
            InitializeComponent();
        }

        public frmDatPhong(int idnv)
        {
            InitializeComponent();
            ID_NV = idnv;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult ds = MessageBox.Show("Thoát Giao Diện Đặt Phòng ?", "THOÁT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (ds == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }

        private void frmDatPhong_Load(object sender, EventArgs e)
        {
            PhieuCheckIn_WCFClient p_wcf = new PhieuCheckIn_WCFClient();
            List<PhieuCheckIn_Ent> list = new List<PhieuCheckIn_Ent>();
            list = p_wcf.GetPhieuCheckIns().ToList();

            InitializeThongTinChung();

            //Khởi Tao Dữ Liệu Ban Đầu
            string[] LoaiPhong = { "", "Phòng Standard", "Phòng Deluxe", "Phòng Express View", "Phòng VIP" };
            cbx_LoaiPhong.DataSource = LoaiPhong;
            txtThue.Text = "10";
            txtPhuThu.Text = "0";
            txtGiamGia.Text = "0";
            txtTimKiem.Text = "123456789";

            Loading_DSP(DataTable_DSP(list));
            Custom_DataGridView(dgv_DSPhieuCheckIn);
        }

        private void InitializeThongTinChung()
        {
            PhieuCheckIn_WCFClient pci_wcf = new PhieuCheckIn_WCFClient();
            NhanVien_WCFClient nv_wcf = new NhanVien_WCFClient();
            txtIdPhieu.Text = (pci_wcf.GetPhieuCheckIns()[pci_wcf.GetPhieuCheckIns().Length - 1].Id_phieu_checkin + 1).ToString();
            txtHoTenNV.Text = (nv_wcf.GetHoTen_NhanVien(ID_NV));
        }

        private void ClearTextBox()
        {
            txtHo.Clear();
            txtCMND.Clear();
            txtQuocTich.Items.Clear();
            txtSDT.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            txtTen.Clear();
        }

        public void Loading_DSP(DataTable dt)
        {
            dgv_DSPhieuCheckIn.Columns.Clear();
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            bn_DSDatPhong.BindingSource = bs;
            dgv_DSPhieuCheckIn.DataSource = bs;
        }

        public DataTable DataTable_DSP(List<PhieuCheckIn_Ent> dsPCI)
        {
            Phong_WCFClient ph_wcf = new Phong_WCFClient();
            KhachHang_WCFClient kh_wcf = new KhachHang_WCFClient();
            DichVu_WCFClient dv_wcf = new DichVu_WCFClient();
            DataTable dt = new DataTable();

            dt.Columns.Add("Mã Phiếu Check In", typeof(string));
            dt.Columns.Add("Loại Phòng", typeof(string));
            dt.Columns.Add("Số Phòng", typeof(string));
            dt.Columns.Add("Họ Tên Khách Hàng", typeof(string));
            dt.Columns.Add("Thời Gian Check In", typeof(string));
            dt.Columns.Add("Thời gian Check Out", typeof(string));
            dt.Columns.Add("Tên Dịch Vụ", typeof(string));
            dt.Columns.Add("Số Lượng Dịch Vụ", typeof(string));


            foreach (PhieuCheckIn_Ent p_ent in dsPCI)
            {
                string nameServ = dv_wcf.GetTenDichVu_byIdDichVu(p_ent.Id_DichVu);

                dt.Rows.Add(p_ent.Id_phieu_checkin, ph_wcf.GetTenLoaiPhong_by_IDLoai(p_ent.Id_Phong), ph_wcf.getsoPhong_byID(p_ent.Id_Phong), kh_wcf.getHoKhacHang_byID(p_ent.Id_khach) + " " + kh_wcf.getTenKhacHang_byID(p_ent.Id_khach),
                           p_ent.Gio_check_in + " " + p_ent.Ngay_check_in.ToShortDateString(), p_ent.Gio_check_out + " " + p_ent.Ngay_check_out.ToShortDateString(), nameServ, p_ent.SoLuongDichVu.ToString());
            }
            return dt;
        }

        public void Custom_DataGridView(DataGridView dgv)
        {
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                column.HeaderCell.Style.Font = new Font("Segoe UI Semibold", 12);

                if (column.Index == 0)
                {
                    column.Width = 200;
                }
                if (column.Index == 1)
                {
                    column.Width = 200;
                }
                if (column.Index == 2)
                {
                    column.Width = 200;
                }
                if (column.Index == 3)
                {
                    column.Width = 200;
                }
                if (column.Index == 4)
                {
                    column.Width = 200;
                }
                if (column.Index == 5)
                {
                    column.Width = 200;
                }
                if (column.Index == 6)
                {
                    column.Width = 200;
                }
                if (column.Index == 7)
                {
                    column.Width = 200;
                }
            }
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        void locPhong()
        {
            Phong_WCFClient p_wcf = new Phong_WCFClient();

            foreach (var item in p_wcf.GetPhongTrong_byLoaiPhong(cbx_LoaiPhong.SelectedIndex))
            {
                cbx_SoPhong.Items.Add(item.So_Phong);
                cbx_SoPhong.Tag = item.Tang;
            }
        }

        private void cbx_SoPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            Phong_WCFClient p_wcf = new Phong_WCFClient();
            decimal donGia = 0;
            if (cbx_LoaiPhong.Text.Equals("Phòng Standard"))
            {
                donGia = p_wcf.DonGia("1");
            }
            else if (cbx_LoaiPhong.Text.Equals("Phòng Deluxe"))
            {
                donGia = p_wcf.DonGia("2");
            }
            else if (cbx_LoaiPhong.Text.Equals("Phòng Express View"))
            {
                donGia = p_wcf.DonGia("3");
            }
            else
            {
                donGia = p_wcf.DonGia("4");
            }
            txtTang.Text = cbx_SoPhong.Tag.ToString();
            if (DateTime.Now.Hour < 14)
            {
                txtPhuThu.Text = (Convert.ToDecimal(0.3) * donGia).ToString();
            }
        }

        private void autoCompleteSource()
        {
            txtTimKiem.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtTimKiem.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtTimKiem.AutoCompleteCustomSource.Clear();
            KhachHang_WCFClient kh_wcf = new KhachHang_WCFClient();
            foreach (KhachHang_Ent item in kh_wcf.GetKhachHangs())
            {
                txtTimKiem.AutoCompleteCustomSource.Add(item.So_cmnd.Trim());
            }
        }

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            txtTimKiem.ForeColor = Color.Black;
            txtTimKiem.Clear();
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            //txtTimKiem.ForeColor = Color.DarkGray;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            KhachHang_WCFClient kh_wcf = new KhachHang_WCFClient();
            KhachHang_Ent kh_ent = kh_wcf.GetKhachHang_byCMND(txtTimKiem.Text.Trim());

            if (kh_ent == null)
            {
                ClearTextBox();
                return;
            }

            foreach (var item in kh_wcf.TimKiem_KhachHang_by_CMND(txtTimKiem.Text.Trim()))
            {
                maKH = item.Id_khach.ToString();
                txtHo.Text = item.Ho;
                txtTen.Text = item.Ten;
                txtCMND.Text = item.So_cmnd;
                txtQuocTich.Text = item.Quoc_tich;
                if (item.Gioi_tinh.Equals("Nam"))
                {
                    cboGioiTinh.Text = "Nam";
                }
                else
                {
                    cboGioiTinh.Text = "Nữ";
                }
                txtSDT.Text = item.Sodienthoai;
                dtpNgaySinh.Text = item.Date_of_birth.ToString();
            }
        }

        private void dtpNgayTraPhong_ValueChanged(object sender, EventArgs e)
        {
            Phong_WCFClient p_wcf = new Phong_WCFClient();
            TimeSpan date = dtpNgayTraPhong.Value - DateTime.Now.Date;

            if (date.Days <= 0)
            {
                MessageBox.Show("Nhập Ngày Lớn Hơn Ngày Hiện Tại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpNgayTraPhong.Focus();
            }
            else if (cbx_LoaiPhong.Text.Equals(""))
            {
                MessageBox.Show("Chọn Loại Phòng Cần Đặt", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbx_LoaiPhong.Focus();
            }
            else
            {
                decimal donGia = 0;

                if (cbx_LoaiPhong.Text.Equals("Phòng Standard"))
                {
                    donGia = p_wcf.DonGia("1");
                }
                else if (cbx_LoaiPhong.Text.Equals("Phòng Deluxe"))
                {
                    donGia = p_wcf.DonGia("2");
                }
                else if (cbx_LoaiPhong.Text.Equals("Phòng Express View"))
                {
                    donGia = p_wcf.DonGia("3");
                }
                else if (cbx_LoaiPhong.Text.Equals("Phòng VIP"))
                {
                    donGia = p_wcf.DonGia("4");
                }

                txtTienPhong.Text = (donGia * Convert.ToInt32(date.Days)).ToString();
            }
        }

        private decimal ThanhToan()
        {
            TimeSpan date = dtpNgayTraPhong.Value - DateTime.Now.Date;
            return Convert.ToDecimal(date.Days);

        }

        private bool CheckNull()
        {
            if (cbx_LoaiPhong.Text.Equals(""))
            {
                return false;
            }
            if (cbx_SoPhong.Text.Equals(""))
            {
                return false;
            }
            if (cbox_SoNguoi.Text.Equals(""))
            {
                return false;
            }
            return true;
        }

        private void btnLuuDatPhong_Click(object sender, EventArgs e)
        {
            Phong_WCFClient ph_wcf = new Phong_WCFClient();
            NhanVien_WCFClient nv_wcf = new NhanVien_WCFClient();
            PhieuCheckIn_WCFClient phieu_wcf = new PhieuCheckIn_WCFClient();
            PhieuCheckIn_Ent p_ent = new PhieuCheckIn_Ent();

            if (!CheckNull())
            {
                MessageBox.Show("Chưa Nhập Đủ Thông Tin", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            p_ent.Id_khach = Convert.ToInt32(maKH);
            p_ent.Id_NhanVien = ID_NV;
            p_ent.Id_Phong = ph_wcf.getIDPhong(cbx_SoPhong.Text);
            p_ent.Giam_gia = Convert.ToDouble(txtGiamGia.Text);
            p_ent.SoLuongKhach = Convert.ToInt32(cbox_SoNguoi.Text);
            p_ent.Ngay_check_in = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan gio_in = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            p_ent.Gio_check_in = gio_in;
            p_ent.Ngay_check_out = Convert.ToDateTime(dtpNgayTraPhong.Text.ToString());
            TimeSpan gio_out = new TimeSpan(14, 00, 00);

            //p_ent.Id_DichVu = 0;

            p_ent.Gio_check_out = gio_out;
            if (phieu_wcf.ThemPhieuCheckIn(p_ent))
            {
                DialogResult ds = MessageBox.Show("Lưu Thành Công, Tiếp Tục ?", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (ds == DialogResult.OK)
                {
                    List<PhieuCheckIn_Ent> list = new List<PhieuCheckIn_Ent>();
                    list = phieu_wcf.lsPhieuCheckIn_ToDate(DateTime.Now.Date).ToList();
                    ph_wcf.update_TinhTrangPhong(p_ent.Id_Phong,1);
                    Loading_DSP(DataTable_DSP(list));
                    Custom_DataGridView(dgv_DSPhieuCheckIn);
                    return;
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

        private void cbx_LoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbx_SoPhong.Items.Clear();
            locPhong();

            
            TimeSpan date = dtpNgayTraPhong.Value - DateTime.Now.Date;

            if (isShowing || date.Days <= 0)
            {
                return;
            }

            Phong_WCFClient p_wcf = new Phong_WCFClient();

            if (date.Days <= 0)
            {
                MessageBox.Show("Nhập Ngày Lớn Hơn Ngày Hiện Tại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpNgayTraPhong.Focus();
            }
            else
            {
                decimal donGia = 0;

                if (cbx_LoaiPhong.Text.Equals("Phòng Standard"))
                {
                    donGia = p_wcf.DonGia("1");
                }
                else if (cbx_LoaiPhong.Text.Equals("Phòng Deluxe"))
                {
                    donGia = p_wcf.DonGia("2");
                }
                else if (cbx_LoaiPhong.Text.Equals("Phòng Express View"))
                {
                    donGia = p_wcf.DonGia("3");
                }
                else if (cbx_LoaiPhong.Text.Equals("Phòng VIP"))
                {
                    donGia = p_wcf.DonGia("4");
                }

                txtTienPhong.Text = (donGia * Convert.ToInt32(date.Days)).ToString();
            }
        }

        private void btnThemKhach_Click(object sender, EventArgs e)
        {
            frmTextKhachHang frm = new frmTextKhachHang(this, "Thêm Khách Hàng");
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.ShowDialog();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            KhachHang_WCFClient kh_wcf = new KhachHang_WCFClient();
            KhachHang_Ent kh_ent = kh_wcf.GetKhachHang_byCMND(txtTimKiem.Text.Trim());

            if (kh_ent == null)
            {
                MessageBox.Show("Kiểm Tra Lại !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtHo.Text = kh_ent.Ho.Trim();
            txtTen.Text = kh_ent.Ten.Trim();
            txtSDT.Text = kh_ent.Sodienthoai.Trim();
            txtCMND.Text = kh_ent.So_cmnd.Trim();
            if (kh_ent.Gioi_tinh.Equals("Nam"))
            {
                cboGioiTinh.Text = "Nam";
            }
            else
            {
                cboGioiTinh.Text = "Nữ";
            }
            txtQuocTich.Text = kh_ent.Quoc_tich.Trim();
        }

        private void cboGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmDatPhong_Shown(object sender, EventArgs e)
        {
            isShowing = false;
        }

        private void btnReaload_Click(object sender, EventArgs e)
        {
            PhieuCheckIn_WCFClient p_wcf = new PhieuCheckIn_WCFClient();
            List<PhieuCheckIn_Ent> list = new List<PhieuCheckIn_Ent>();
            list = p_wcf.GetPhieuCheckIns().ToList();

            Loading_DSP(DataTable_DSP(list));
            Custom_DataGridView(dgv_DSPhieuCheckIn);
        }
    }
}
