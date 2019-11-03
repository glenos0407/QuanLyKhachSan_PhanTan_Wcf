using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QUANLYKHACHSAN_PHANTAN.PhieuCheckIn_Wcf;
using QUANLYKHACHSAN_PHANTAN.KhachHang_Wcf;
using QUANLYKHACHSAN_PHANTAN.Phong_Wcf;
using QUANLYKHACHSAN_PHANTAN.DichVu_Wcf;

namespace QUANLYKHACHSAN_PHANTAN
{
    public partial class frmTraPhong : Form
    {
        public frmTraPhong()
        {
            InitializeComponent();
        }

        private void frmTraPhong_Load(object sender, EventArgs e)
        {
            PhieuCheckIn_WCFClient p_wcf = new PhieuCheckIn_WCFClient();
            List<PhieuCheckIn_Ent> lstP = p_wcf.GetPhieuCheckIns_NoCheckOut().ToList();
            loaDataToGridView(DataTable_DSPhieu(lstP));
            Custom_DataGridView(dgv_DSPhieuCheckIn);

            btnReload.Image = imgs_Button.Images[0];
        }
        public DataTable DataTable_DSPhieu(List<PhieuCheckIn_Ent> dsPhieu)
        {
            Phong_WCFClient ph_wcf = new Phong_WCFClient();
            KhachHang_WCFClient kh_wcf = new KhachHang_WCFClient();
            DataTable dt = new DataTable();

            dt.Columns.Add("Mã Phiếu Check In", typeof(string));
            dt.Columns.Add("Loại Phòng", typeof(string));
            dt.Columns.Add("Số Phòng", typeof(string));
            dt.Columns.Add("Họ Tên Khách Hàng", typeof(string));
            dt.Columns.Add("Thời Gian Check In", typeof(string));
            dt.Columns.Add("Thời gian Check Out", typeof(string));


            foreach (PhieuCheckIn_Ent p_ent in dsPhieu)
            {
                dt.Rows.Add(p_ent.Id_phieu_checkin, ph_wcf.GetTenLoaiPhong_by_IDLoai(p_ent.Id_Phong), ph_wcf.getsoPhong_byID(p_ent.Id_Phong), kh_wcf.getHoKhacHang_byID(p_ent.Id_khach) + " " + kh_wcf.getTenKhacHang_byID(p_ent.Id_khach),
                           p_ent.Gio_check_in + " " + p_ent.Ngay_check_in.ToShortDateString(), p_ent.Gio_check_out + " " + p_ent.Ngay_check_out.ToShortDateString());
            }

            return dt;
        }
        public void loaDataToGridView(DataTable dt)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            bn_DSPhieu.BindingSource = bs;
            dgv_DSPhieuCheckIn.DataSource = bs;
        }
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
                //    column.Width = 200;
                //}
                //if (column.Index == 3)
                //{
                //    column.Width = 200;
                //}
                //if (column.Index == 4)
                //{
                //    column.Width = 200;
                //}
                //if (column.Index == 5)
                //{
                //    column.Width = 160;
                //}
            }

            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.AutoGenerateColumns = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

            DialogResult ds = MessageBox.Show("Thoát Trả Phòng ?", "THOÁT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (ds == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }

        private void btnTraPhong_Click(object sender, EventArgs e)
        {
            if (dgv_DSPhieuCheckIn.SelectedRows.Count > 0)
            {
                Phong_WCFClient phong_wcf = new Phong_WCFClient();
                PhieuCheckIn_WCFClient p_wcf = new PhieuCheckIn_WCFClient();
                DateTime date = DateTime.Now;
                TimeSpan now = new TimeSpan(date.Hour, date.Minute, date.Second);

                int idPhong = phong_wcf.GetIDPhong_by_SoPhong((dgv_DSPhieuCheckIn.SelectedRows[0].Cells[2].Value.ToString().Trim()));

                if (p_wcf.TraPhong(Convert.ToInt32(dgv_DSPhieuCheckIn.SelectedRows[0].Cells[0].Value.ToString().Trim()), now, date))
                {
                    if (phong_wcf.update_TinhTrangPhong(idPhong, 0))
                    {
                        MessageBox.Show(this, "Thành Công!");

                        PhieuCheckIn_WCFClient temp = new PhieuCheckIn_WCFClient();
                        List<PhieuCheckIn_Ent> lstP = temp.GetPhieuCheckIns_NoCheckOut().ToList();
                        loaDataToGridView(DataTable_DSPhieu(lstP));
                        Custom_DataGridView(dgv_DSPhieuCheckIn);
                    }
                    else
                    {
                        MessageBox.Show(this, "Thất Bại!");
                    }
                }
                else
                {
                    MessageBox.Show(this, "Thất Bại!");
                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            PhieuCheckIn_WCFClient p_wcf = new PhieuCheckIn_WCFClient();
            List<PhieuCheckIn_Ent> lstP = p_wcf.GetPhieuCheckIns_NoCheckOut().ToList();
            loaDataToGridView(DataTable_DSPhieu(lstP));
            Custom_DataGridView(dgv_DSPhieuCheckIn);
        }

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            txtTimKiem.ForeColor = Color.Black;
            txtTimKiem.Clear();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text.Trim() == "")
            {
                return;
            }
            else
            {
                KhachHang_WCFClient kh_wcf = new KhachHang_WCFClient();
                List<KhachHang_Ent> dsKhachHang = kh_wcf.TimKiem_KhachHang_by_CMND(txtTimKiem.Text.Trim()).ToList();
                PhieuCheckIn_WCFClient pck_wcf = new PhieuCheckIn_WCFClient();

                try
                {
                    if (pck_wcf.isKhachThue(dsKhachHang[0].Id_khach))
                    {
                        PhieuCheckIn_WCFClient p_wcf = new PhieuCheckIn_WCFClient();
                        List<PhieuCheckIn_Ent> lstP = pck_wcf.GetPhieuCheckIns_NoCheckOut_byIDKhach(dsKhachHang[0].Id_khach).ToList();
                        loaDataToGridView(DataTable_DSPhieu(lstP));
                        Custom_DataGridView(dgv_DSPhieuCheckIn);
                    }
                    else
                    {
                        MessageBox.Show("Khách Này Đã Trả Phòng", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Không Tồn Tại","", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
