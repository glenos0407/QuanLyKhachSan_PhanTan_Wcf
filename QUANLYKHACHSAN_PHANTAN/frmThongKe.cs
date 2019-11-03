using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QUANLYKHACHSAN_PHANTAN.NhanVien_Wcf;
using QUANLYKHACHSAN_PHANTAN.KhachHang_Wcf;
using QUANLYKHACHSAN_PHANTAN.Phong_Wcf;
using QUANLYKHACHSAN_PHANTAN.PhieuCheckIn_Wcf;
using QUANLYKHACHSAN_PHANTAN.DichVu_Wcf;
using System.Windows.Forms;

namespace QUANLYKHACHSAN_PHANTAN
{
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult ds = MessageBox.Show("Thoát Báo Cáo Thống Kê ?", "THOÁT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (ds == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }

        //DataTable
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
            dt.Columns.Add("Tổng Tiền", typeof(string));
            dt.Columns.Add("Tình Trạng", typeof(string));

            //Lọc Dữ Liệu Phiếu Đặt Phòng và Phiếu Mua Bán Dịch Vụ
            foreach (PhieuCheckIn_Ent p_ent in dsPCI)
            {
                string nameServ = dv_wcf.GetTenDichVu_byIdDichVu(p_ent.Id_DichVu);

                if (p_ent.Id_DichVu != 0)
                {
                    string tinhTrang = "";

                    if (p_ent.TrangThaiHoaDon == 0)
                    {
                        tinhTrang = "Chưa Thanh Toán";
                    }
                    if (p_ent.TrangThaiHoaDon == 1)
                    {
                        tinhTrang = "Đã Thanh Toán";
                    }

                    dt.Rows.Add(p_ent.Id_phieu_checkin, ph_wcf.GetTenLoaiPhong_by_IDLoai(p_ent.Id_Phong), ph_wcf.getsoPhong_byID(p_ent.Id_Phong), kh_wcf.getHoKhacHang_byID(p_ent.Id_khach) + " " + kh_wcf.getTenKhacHang_byID(p_ent.Id_khach),
                           p_ent.Gio_check_in + " " + p_ent.Ngay_check_in.ToShortDateString(), p_ent.Gio_check_out + " " + p_ent.Ngay_check_out.ToShortDateString(), nameServ, p_ent.SoLuongDichVu.ToString(), (p_ent.SoLuongDichVu * dv_wcf.GetGiaDichVu_byIdDichVu(p_ent.Id_DichVu)),tinhTrang);
                }
                else
                {
                    TimeSpan date = p_ent.Ngay_check_out - p_ent.Ngay_check_in;
                    decimal donGia = ph_wcf.DonGia(ph_wcf.GetIDLoaiPhong_by_IDPhong(p_ent.Id_Phong).ToString());
                    string tienPhong = (donGia * Convert.ToInt32(date.Days)).ToString();

                    string tinhTrang = "";

                    if (p_ent.TrangThaiHoaDon == 0)
                    {
                        tinhTrang = "Trống";
                    }
                    if (p_ent.TrangThaiHoaDon == 1)
                    {
                        tinhTrang = "Có Khách";
                    }

                    dt.Rows.Add(p_ent.Id_phieu_checkin, ph_wcf.GetTenLoaiPhong_by_IDLoai(p_ent.Id_Phong), ph_wcf.getsoPhong_byID(p_ent.Id_Phong), kh_wcf.getHoKhacHang_byID(p_ent.Id_khach) + " " + kh_wcf.getTenKhacHang_byID(p_ent.Id_khach),
                           p_ent.Gio_check_in + " " + p_ent.Ngay_check_in.ToShortDateString(), p_ent.Gio_check_out + " " + p_ent.Ngay_check_out.ToShortDateString(), nameServ, p_ent.SoLuongDichVu.ToString(), tienPhong, tinhTrang);
                }
            }

            return dt;
        }

        //Load DataGridView
        public void Loading_BaoCao(DataTable dt)
        {
            dgv_BaoCao.Columns.Clear();
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            bnvgt_BaoCao.BindingSource = bs;
            dgv_BaoCao.DataSource = bs;
        }

        //Custom Theme DataGridView
        public void Custom_DataGridView(DataGridView dgv)
        {
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                column.HeaderCell.Style.Font = new Font("Segoe UI Semibold", 12);
                column.Width = 200;

                //if (column.Index == 0)
                //{
                //    column.Width = 200;
                //}
                //if (column.Index == 1)
                //{
                //    column.Width = 200;
                //}
                //if (column.Index == 2)
                //{
                //    column.Width = 100;
                //}
                //if (column.Index == 3)
                //{
                //    column.Width = 120;
                //}
                //if (column.Index == 4)
                //{
                //    column.Width = 120;
                //}
                //if (column.Index == 5)
                //{
                //    column.Width = 120;
                //}
                //if (column.Index == 6)
                //{
                //    column.Width = 220;
                //}
                //if (column.Index == 7)
                //{
                //    column.Width = 220;
                //}
                //if (column.Index == 8)
                //{
                //    column.Width = 220;
                //}
            }

            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void rbtnNgayHienTai_CheckedChanged(object sender, EventArgs e)
        {
            PhieuCheckIn_WCFClient p_wcf = new PhieuCheckIn_WCFClient();
            List<PhieuCheckIn_Ent> list = new List<PhieuCheckIn_Ent>();
            list = p_wcf.lsPhieuCheckIn_ToDate(DateTime.Now).ToList();

            Loading_BaoCao(DataTable_DSP(list));
            Custom_DataGridView(dgv_BaoCao);
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            PhieuCheckIn_WCFClient p_wcf = new PhieuCheckIn_WCFClient();
            List<PhieuCheckIn_Ent> list = new List<PhieuCheckIn_Ent>();
            list = p_wcf.GetPhieuCheckIns().ToList();

            Loading_BaoCao(DataTable_DSP(list));
            Custom_DataGridView(dgv_BaoCao);
        }

        private void rbtnThangHienTai_CheckedChanged(object sender, EventArgs e)
        {
            PhieuCheckIn_WCFClient p_wcf = new PhieuCheckIn_WCFClient();
            List<PhieuCheckIn_Ent> list = new List<PhieuCheckIn_Ent>();
            list = p_wcf.lsPhieuCheckIn_ToMonth(DateTime.Now).ToList();

            Loading_BaoCao(DataTable_DSP(list));
            Custom_DataGridView(dgv_BaoCao);
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            PhieuCheckIn_WCFClient p_wcf = new PhieuCheckIn_WCFClient();
            List<PhieuCheckIn_Ent> list = new List<PhieuCheckIn_Ent>();

            try
            {
                DateTime date = new DateTime(Convert.ToInt32(txtNam.Text), Convert.ToInt32(cbx_Thang.Text.Trim()), 1);
                list = p_wcf.lsPhieuCheckIn_ToMonth(date).ToList();

                Loading_BaoCao(DataTable_DSP(list));
                Custom_DataGridView(dgv_BaoCao);
            }
            catch
            {
                MessageBox.Show("Chưa Đủ Thông Tin", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
