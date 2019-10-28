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

namespace QUANLYKHACHSAN_PHANTAN
{
    public partial class frmQuanLyNhanVien : Form
    {
        public frmQuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void frmQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            btnReload.Image = imgs_Button.Images[0];

           NhanVien_WCFClient nv_wcf = new NhanVien_WCFClient();
           List<NhanVien_Ent> dsNhanVien = nv_wcf.GetNhanViens().ToList();

            Loading_DSNhanVien(DataTable_DSNhanVien(dsNhanVien));

            Custom_DataGridView(dgv_DSNhanVien);

            Load_AutoCompleteSource();

            string[] CaLamViec = {"Ca Làm Việc", "Sáng", "Chiều", "Tối" };
            cbx_CaLamViec.DataSource = CaLamViec;

            cbx_CaLamViec.SelectedIndex = 0;
            cbx_ChucVu.SelectedIndex = 0;
        }

        //Load AutoComplete Source
        private void Load_AutoCompleteSource()
        {
            NhanVien_WCFClient nv_wcf = new NhanVien_WCFClient();
            var acsc = new AutoCompleteStringCollection();
            try
            {
                foreach (NhanVien_Ent nv_ent in nv_wcf.GetNhanViens())
                {
                    acsc.Add(nv_ent.Ho + " " + nv_ent.Ten);
                    acsc.Add(nv_ent.Ten);
                }
                this.txtTimKiem.AutoCompleteSource = AutoCompleteSource.CustomSource;
                this.txtTimKiem.AutoCompleteCustomSource = acsc;
            }
            catch(Exception)
            {
                return;
            }
        }

        //Load DataGridView
        public void Loading_DSNhanVien(DataTable dt)
        {
            dgv_DSNhanVien.Columns.Clear();
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            bn_DSNhanVien.BindingSource = bs;
            dgv_DSNhanVien.DataSource = bs;
        }

        //Lọc Danh Sách Nhân Viên
        public DataTable DataTable_DSNhanVien(List<NhanVien_Ent> dsNhanVien)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("STT", typeof(int));
            dt.Columns.Add("Họ và Tên", typeof(string));
            dt.Columns.Add("Giới Tính", typeof(string));
            dt.Columns.Add("Ngày Sinh", typeof(DateTime));
            dt.Columns.Add("Chức Vụ", typeof(string));
            dt.Columns.Add("Ca Làm Việc", typeof(string));
            dt.Columns.Add("Email", typeof(string));

            int stt = 1;
            foreach (NhanVien_Ent nv_ent in dsNhanVien)
            {
                dt.Rows.Add(stt, nv_ent.Ho + " " + nv_ent.Ten, nv_ent.GioiTinh, nv_ent.NgaySinh, nv_ent.ChucVu, nv_ent.CaLamViec, nv_ent.Email);
                stt++;
            }

            return dt;
        }

        //Custom Theme DataGridView
        public void Custom_DataGridView(DataGridView dgv)
        {

            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                column.HeaderCell.Style.Font = new Font("Segoe UI Semibold", 12);

                if (column.Index == 0)
                {
                    column.Width = 38;
                }
                if (column.Index == 1)
                {
                    column.Width = 200;
                }
                if (column.Index == 2)
                {
                    column.Width = 100;
                }
                if (column.Index == 3)
                {
                    column.Width = 120;
                }
                if (column.Index == 4)
                {
                    column.Width = 120;
                }
                if (column.Index == 5)
                {
                    column.Width = 120;
                }
                if (column.Index == 6)
                {
                    column.Width = 220;
                }
            }

            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }


        private void frmQuanLyTaiKhoan_Shown(object sender, EventArgs e)
        {
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult ds = MessageBox.Show("Thoát Quản Lý Nhân Viên ?", "THOÁT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (ds == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            txtTimKiem.ForeColor = Color.Black;
            txtTimKiem.Clear();
           
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            txtTimKiem.ForeColor = Color.DarkGray;
        }

        private void cbx_ChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_ChucVu.SelectedIndex == 0)
            {
                return;
            }
            else
            {
                NhanVien_WCFClient nv_wcf = new NhanVien_WCFClient();
                List<NhanVien_Ent> dsNhanVien = nv_wcf.SapXepChucVu(cbx_ChucVu.SelectedIndex).ToList();
                Loading_DSNhanVien(DataTable_DSNhanVien(dsNhanVien));
                Custom_DataGridView(dgv_DSNhanVien);
            }
        }

        private void cbx_CaLamViec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_CaLamViec.SelectedIndex == 0)
            {
                return;
            }
            else
            {
                NhanVien_WCFClient nv_wcf = new NhanVien_WCFClient();
                List<NhanVien_Ent> dsNhanVien = nv_wcf.SapXepCaLamViec(cbx_CaLamViec.SelectedIndex).ToList();
                Loading_DSNhanVien(DataTable_DSNhanVien(dsNhanVien));
                Custom_DataGridView(dgv_DSNhanVien);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            cbx_CaLamViec.SelectedIndex = 0;
            cbx_ChucVu.SelectedIndex = 0;
            txtTimKiem.Clear();
            NhanVien_WCFClient nv_wcf = new NhanVien_WCFClient();
            List<NhanVien_Ent> dsNhanVien = nv_wcf.GetNhanViens().ToList();
            Loading_DSNhanVien(DataTable_DSNhanVien(dsNhanVien));
            Custom_DataGridView(dgv_DSNhanVien);
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            frmTextNhanVien ftnv = new frmTextNhanVien(this, "Thêm Nhân Viên");
            ftnv.ShowDialog();
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            if (dgv_DSNhanVien.SelectedRows.Count == 1)
            {
                NhanVien_WCFClient nv_wcf = new NhanVien_WCFClient();
                int id = nv_wcf.GetID_by_Email(dgv_DSNhanVien.SelectedRows[0].Cells[6].Value.ToString().Trim());
                frmTextNhanVien ftnv = new frmTextNhanVien(this, "Sửa Nhân Viên", id);
                ftnv.ShowDialog();
            }
            else
            {
                MessageBox.Show("Chọn 1 Nhân Viên Cần Sửa", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            string email = "";

            if (dgv_DSNhanVien.SelectedRows.Count == 0)
            {
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn Có Muốn Xóa ?", "XÓA NHÂN VIÊN", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                if (dgv_DSNhanVien.SelectedRows.Count >= 1)
                {
                    NhanVien_WCFClient nv_wcf;

                    for (int i = 0; i < dgv_DSNhanVien.SelectedRows.Count; i++)
                    {
                        email = dgv_DSNhanVien.SelectedRows[i].Cells[6].Value.ToString().Trim();
                        nv_wcf = new NhanVien_WCFClient();
                        if (!nv_wcf.XoaNhanVien_by_Email(email))
                        {
                            break;
                        }
                    }

                    nv_wcf = new NhanVien_WCFClient();
                    Loading_DSNhanVien(DataTable_DSNhanVien(nv_wcf.GetNhanViens().ToList()));
                    Custom_DataGridView(dgv_DSNhanVien);
                }
            }
            else
            {
                return;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if(txtTimKiem.Text.Trim() == "")
            {
                return;
            }
            else
            {
                //Tách Họ Tên**
                string[] strTimKiem = txtTimKiem.Text.Split(' ');
                string ten = strTimKiem[strTimKiem.Count() - 1];
                string ho = "";

                for (int i = 0; i < (strTimKiem.Count()-1); i++)
                {
                    ho += strTimKiem[i] + " ";
                }
                //**

                NhanVien_WCFClient nv_wcf = new NhanVien_WCFClient();
                List<NhanVien_Ent> dsNhanVien = nv_wcf.TimKiem_NhanVien_by_HoTen(ho.Trim(), ten.Trim()).ToList();
                Loading_DSNhanVien(DataTable_DSNhanVien(dsNhanVien));
                Custom_DataGridView(dgv_DSNhanVien);
            }
        }
    }
}
