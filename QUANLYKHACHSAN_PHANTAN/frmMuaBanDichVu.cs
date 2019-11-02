using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using QUANLYKHACHSAN_PHANTAN.DichVu_Wcf;
using QUANLYKHACHSAN_PHANTAN.KhachHang_Wcf;
using QUANLYKHACHSAN_PHANTAN.PhieuCheckIn_Wcf;
using QUANLYKHACHSAN_PHANTAN.Phong_Wcf;

namespace QUANLYKHACHSAN_PHANTAN
{
    public partial class frmMuaBanDichVu : Form
    {
        DataTable dt = new DataTable();
        bool isShowing = true;
        bool isReload = false;
        int idNhanVien = 0;
        public int soLuong;

        public frmMuaBanDichVu()
        {
            InitializeComponent();
        }

        public frmMuaBanDichVu(int idNhanV)
        {
            InitializeComponent();
            idNhanVien = idNhanV;
        }

        private void Load_AutoCompleteSource()
        {
            DichVu_WCFClient dv_wcf = new DichVu_WCFClient();
            var acsc = new AutoCompleteStringCollection();

            try
            {
                foreach (DichVu_Ent item in dv_wcf.GetDichVus())
                {
                    acsc.Add(item.TenDichVu.ToString());
                }

                this.txtTimKiemDV.AutoCompleteSource = AutoCompleteSource.CustomSource;
                this.txtTimKiemDV.AutoCompleteCustomSource = acsc;
            }
            catch (Exception)
            {
                return;
            }
        }

        public void Loading_DSDV(DataTable dt)
        {
            dgv_DSDichVu.Columns.Clear();
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            bn_DSDV.BindingSource = bs;
            dgv_DSDichVu.DataSource = bs;
        }

        private List<string> InitializeTenLoaiDV(List<DichVu_Ent> dsDichVu)
        {
            List<string> dsTenLoaiDVs = new List<string>();

            foreach (DichVu_Ent dv_ent in dsDichVu)
            {
                if (!dsTenLoaiDVs.Contains(dv_ent.TenLoaiDichVu))
                {
                    dsTenLoaiDVs.Add(dv_ent.TenLoaiDichVu);
                }
            }
            return dsTenLoaiDVs;
        }

        public DataTable DataTable_DSDV(List<DichVu_Ent> ds)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Dịch Vụ", typeof(int));
            dt.Columns.Add("Tên Dịch Vụ", typeof(string));
            dt.Columns.Add("Đơn Giá", typeof(double));
            foreach (DichVu_Ent dv_ent in ds)
            {
                dt.Rows.Add(dv_ent.Id_DichVu, dv_ent.TenDichVu, dv_ent.DonGia);
            }
            return dt;
        }

        public void Custom_DataGridView(DataGridView dgv)
        {

            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.DefaultCellStyle.Font = new Font("Segoe UI", 12);
                column.HeaderCell.Style.Font = new Font("Segoe UI Semibold", 14);
                if (column.Index == 0)
                {
                    column.Width = 50;
                }
                if (column.Index == 1)
                {
                    column.Width = 180;
                }
                if (column.Index == 2)
                {
                    column.Width = 100;
                }
            }
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void frmMuaBanDichVu_Load(object sender, EventArgs e)
        {
            DichVu_WCFClient dv_wcf = new DichVu_WCFClient();
            List<DichVu_Ent> dsDichVu = dv_wcf.GetDichVus().ToList();
            Loading_DSDV(DataTable_DSDV(dsDichVu));
            Custom_DataGridView(dgv_DSDichVu);

            cbxLoaiDichVu.DataSource = InitializeTenLoaiDV(dsDichVu);
            cbxLoaiDichVu.SelectedIndex = -1;
            TaoDatatable();

            Load_AutoCompleteSource();


        }

        void TaoDatatable()
        {
            dt.Columns.Add("Tên Dịch Vụ", typeof(string));
            dt.Columns.Add("Số Lượng", typeof(int));
            dt.Columns.Add("Đơn Giá", typeof(double));
        }

        private void cbxLoaiDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isReload)
            {
                isReload = false;
                return;
            }

            if (!isShowing)
            {
                if (cbxLoaiDichVu.SelectedIndex == -1)
                {
                    return;
                }
                else
                {
                    DichVu_WCFClient dv_wcf = new DichVu_WCFClient();
                    int idLoai = dv_wcf.GetIDLoaiDV_byTenLoai(cbxLoaiDichVu.Text.Trim());
                    List<DichVu_Ent> dsDichVu = dv_wcf.TimKiemDichVu_byIDLoaiDV(idLoai).ToList();
                    Loading_DSDV(DataTable_DSDV(dsDichVu));
                    Custom_DataGridView(dgv_DSDichVu);
                }
            }
        }

        private void frmMuaBanDichVu_Shown(object sender, EventArgs e)
        {
            isShowing = false;
        }


        private void btnTimKiemDV_Click(object sender, EventArgs e)
        {
            if (txtTimKiemDV.Text.Trim() == "")
            {
                return;
            }
            else
            {
                DichVu_WCFClient dv_wcf = new DichVu_WCFClient();
                int id = dv_wcf.GetIDDichVu_byTenDV(txtTimKiemDV.Text.Trim());
                List<DichVu_Ent> dsDichVu = dv_wcf.TimKiemDichVu_byIDDichVu(id).ToList();
                Loading_DSDV(DataTable_DSDV(dsDichVu));
                Custom_DataGridView(dgv_DSDichVu);
            }
        }

        private void dgv_DSDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vt = dgv_DSDichVu.CurrentCell.RowIndex;
            dgv_DSDichVu.CurrentRow.Selected = true;
            txtGiaDV.Text = dgv_DSDichVu.Rows[vt].Cells[2].Value.ToString();
            txtTenDv.Text = dgv_DSDichVu.Rows[vt].Cells[1].Value.ToString();

            //Cho Nhập Số Lượng
            frmSoLuong frmSL = new frmSoLuong(this);
            frmSL.ShowDialog();

            dgv_DSDichVu.CurrentRow.Selected = true;

            dt.Rows.Add(dgv_DSDichVu.Rows[vt].Cells[1].Value.ToString(), soLuong.ToString(), dgv_DSDichVu.Rows[vt].Cells[2].Value);

            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            bn_DSCTDV.BindingSource = bs;
            dgvCTDV.DataSource = bs;

            double tien = 0;

            for (int i = 0; i < dgvCTDV.Rows.Count; i++)
            {
                tien += Convert.ToDouble(dgvCTDV.Rows[i].Cells[1].Value) * Convert.ToDouble(dgvCTDV.Rows[i].Cells[2].Value);
                txtTongTien.Text = tien.ToString();
            }
        }

        private void btnDatDichVu_Click(object sender, EventArgs e)
        {
           
        }

        private void dgvCTDV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            double tien = 0;
            for (int i = 0; i < dgvCTDV.Rows.Count; i++)
            {
                tien += Convert.ToDouble(dgvCTDV.Rows[i].Cells[1].Value) * Convert.ToDouble(dgvCTDV.Rows[i].Cells[2].Value);
                txtTongTien.Text = tien.ToString();
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            double tien = 0;
            for (int i = 0; i < dgvCTDV.Rows.Count; i++)
            {
                tien += Convert.ToDouble(dgvCTDV.Rows[i].Cells[1].Value) * Convert.ToDouble(dgvCTDV.Rows[i].Cells[2].Value);
                txtTongTien.Text = tien.ToString();
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            DichVu_WCFClient dv_wcf = new DichVu_WCFClient();
            Phong_WCFClient p_wcf = new Phong_WCFClient();
            PhieuCheckIn_WCFClient pck_wcf = new PhieuCheckIn_WCFClient();
            KhachHang_WCFClient kh_wcf = new KhachHang_WCFClient();
            PhieuCheckIn_Ent p_dv_ent = new PhieuCheckIn_Ent();
            int idPhong = p_wcf.GetIDPhong_by_SoPhong(txtSoPhong.Text.Trim());

            if (txtSoPhong.Text.Trim().Equals(""))
            {
                MessageBox.Show("Nhập Số Phòng","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            int idKhach = 0;

            foreach (var item in pck_wcf.GetPhieuCheckIns())
            {
                if (item.Id_Phong == idPhong && item.TrangThaiHoaDon == 0)
                {
                    idKhach = item.Id_khach;
                }
            }

            PhieuCheckIn_Ent p_ent = new PhieuCheckIn_Ent();

            foreach (var item in pck_wcf.GetPhieuCheckIns().ToList())
            {
                if(item.Id_khach == idKhach)
                {
                    p_ent.Ngay_check_in = item.Ngay_check_in;
                    p_ent.Gio_check_in = item.Gio_check_in;
                    p_ent.Ngay_check_out = item.Ngay_check_out;
                    p_ent.Gio_check_out = item.Gio_check_out;
                    p_ent.Giam_gia = item.Giam_gia;
                    p_ent.SoLuongKhach = item.SoLuongKhach;
                }
            }

            int checkLoi = 0;

            for (int i = 0; i < dgvCTDV.Rows.Count - 1; i++)
            {
                p_dv_ent.Id_Phong = idPhong;
                p_dv_ent.Id_khach = Convert.ToInt32(idKhach);
                p_dv_ent.Id_NhanVien = idNhanVien;
                p_dv_ent.Id_DichVu = dv_wcf.GetIDDichVu_byTenDV(dgvCTDV.Rows[i].Cells[0].Value.ToString());
                p_dv_ent.SoLuongDichVu = Convert.ToInt32(dgvCTDV.Rows[i].Cells[1].Value);
                p_dv_ent.Ngay_check_in = (DateTime) p_ent.Ngay_check_in;
                p_dv_ent.Gio_check_in = p_ent.Gio_check_in;
                p_dv_ent.Ngay_check_out = p_ent.Ngay_check_out;
                p_dv_ent.Gio_check_out = p_ent.Gio_check_out;
                p_dv_ent.Giam_gia = p_ent.Giam_gia;
                p_dv_ent.SoLuongKhach = p_ent.SoLuongKhach;
                p_dv_ent.TrangThaiHoaDon = 1;
                p_dv_ent.SoLuongDichVu = Convert.ToInt32(dgvCTDV.Rows[i].Cells[1].Value.ToString().Trim());

                if (!pck_wcf.ThemPhieuCheckIn_DichVu(p_dv_ent))
                {
                    checkLoi = 1;
                    MessageBox.Show("Có Lỗi Xảy Ra!","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
            }

            if (checkLoi == 0)
            {
                MessageBox.Show("Lưu Thành Công","", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void txtSoPhong_TextChanged(object sender, EventArgs e)
        {
            Phong_WCFClient p_wcf = new Phong_WCFClient();
            PhieuCheckIn_WCFClient pck_wcf = new PhieuCheckIn_WCFClient();
            KhachHang_WCFClient kh_wcf = new KhachHang_WCFClient();

            int idKhach = 0;

            int idPhong = p_wcf.GetIDPhong_by_SoPhong(txtSoPhong.Text.Trim());

            foreach (var item in pck_wcf.GetPhieuCheckIns())
            {
                if(item.Id_Phong == idPhong && item.TrangThaiHoaDon == 0)
                {
                    idKhach = item.Id_khach;
                    break;
                }
            }

            txtHoTenKH.Text = kh_wcf.getHoKhacHang_byID(idKhach) + " " + kh_wcf.getTenKhacHang_byID(idKhach);
        }
    }
}
