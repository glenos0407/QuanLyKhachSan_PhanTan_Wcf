using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QUANLYKHACHSAN_PHANTAN.DichVu_Wcf;

namespace QUANLYKHACHSAN_PHANTAN
{
    public partial class frmQLDichVu : Form
    {
        bool isShowing = true;
        bool isReload = false;

        public frmQLDichVu()
        {
            InitializeComponent();
        }


        private void frmQLDichVu_Load(object sender, EventArgs e)
        {
            btnReload.Image = imgs_Button.Images[0];
            DichVu_WCFClient dv_wcf = new DichVu_WCFClient();
            List<DichVu_Ent> dsDichVu = dv_wcf.GetDichVus().ToList();
            Loading_DSDichVu(DataTable_DSDichVu(dsDichVu));
            Custom_DataGridView(dgv_dsDichVu);

            cbx_LoaiDichVu.DataSource = InitializeTenLoaiDV(dsDichVu);
            cbx_LoaiDichVu.SelectedIndex = -1;
        }

        //Load Toàn Bộ Tên Loại Dịch Vụ
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult ds = MessageBox.Show("Thoát Quản Lý Dịch Vụ ?", "THOÁT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (ds == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }

        //Load DataGridView
        public void Loading_DSDichVu(DataTable dt)
        {
            dgv_dsDichVu.Columns.Clear();
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            bnvgt_dsDichVu.BindingSource = bs;
            dgv_dsDichVu.DataSource = bs;
        }

        //Lọc Danh Sách Dịch Vụ
        public DataTable DataTable_DSDichVu(List<DichVu_Ent> dsDichVu)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("STT", typeof(int));
            dt.Columns.Add("Mã Dịch Vụ", typeof(int));
            dt.Columns.Add("Tên Dịch Vụ", typeof(string));
            dt.Columns.Add("Đơn Giá", typeof(double));
            dt.Columns.Add("Loại Dịch Vụ", typeof(string));


            int stt = 1;
            foreach (DichVu_Ent dv_ent in dsDichVu)
            {
                dt.Rows.Add(stt, dv_ent.Id_DichVu, dv_ent.TenDichVu, dv_ent.DonGia, dv_ent.TenLoaiDichVu);
                stt++;
            }

            return dt;
        }

        //Custom Theme DataGridView
        public void Custom_DataGridView(DataGridView dgv)
        {

            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.DefaultCellStyle.Font = new Font("Segoe UI", 12);
                column.HeaderCell.Style.Font = new Font("Segoe UI Semibold", 14);

                if (column.Index == 0)
                {
                    column.Width = 60;
                }
                if (column.Index == 1)
                {
                    column.Visible = false;
                }
                if (column.Index == 2)
                {
                    column.Width = 250;
                }
                if (column.Index == 3)
                {
                    column.Width = 160;
                }
                if (column.Index == 4)
                {
                    column.Width = 160;
                }
            }

            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            txtTimKiem.ForeColor = Color.Black;
            txtTimKiem.Clear();
        }

        private void cbx_LoaiDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isReload)
            {
                isReload = false;
                return;
            }

            if (!isShowing)
            {
                if (cbx_LoaiDichVu.SelectedIndex == -1)
                {
                    return;
                }
                else
                {
                    DichVu_WCFClient dv_wcf = new DichVu_WCFClient();
                    int idLoai = dv_wcf.GetIDLoaiDV_byTenLoai(cbx_LoaiDichVu.Text.Trim());
                    List<DichVu_Ent> dsDichVu = dv_wcf.TimKiemDichVu_byIDLoaiDV(idLoai).ToList();
                    Loading_DSDichVu(DataTable_DSDichVu(dsDichVu));
                    Custom_DataGridView(dgv_dsDichVu);
                }
            }
        }

        private void frmQLDichVu_Shown(object sender, EventArgs e)
        {
            isShowing = false;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            DichVu_WCFClient dv_wcf = new DichVu_WCFClient();
            List<DichVu_Ent> dsDichVu = dv_wcf.GetDichVus().ToList();
            Loading_DSDichVu(DataTable_DSDichVu(dsDichVu));
            Custom_DataGridView(dgv_dsDichVu);

            isReload = true;
            //Load Lại Combox
            DichVu_WCFClient dv_temp = new DichVu_WCFClient();
            List<DichVu_Ent> temp = dv_temp.GetDichVus().ToList();
            cbx_LoaiDichVu.DataSource = InitializeTenLoaiDV(temp);
            cbx_LoaiDichVu.SelectedIndex = -1;
        }

        private void btnThemDV_Click(object sender, EventArgs e)
        {
            frmTextDichVu ftdv = new frmTextDichVu(this, "Thêm Dịch Vụ");
            ftdv.FormBorderStyle = FormBorderStyle.None;
            ftdv.ShowDialog();
        }

        private void btnSuaDV_Click(object sender, EventArgs e)
        {
            if (dgv_dsDichVu.SelectedRows.Count == 1)
            {
                DichVu_WCFClient dv_wcf = new DichVu_WCFClient();
                int id = Convert.ToInt32(dgv_dsDichVu.SelectedRows[0].Cells[1].Value.ToString().Trim());
                frmTextDichVu ftdv = new frmTextDichVu(this, "Sửa Dịch Vụ", id);
                ftdv.FormBorderStyle = FormBorderStyle.None;
                ftdv.ShowDialog();
            }
            else
            {
                MessageBox.Show("Chọn 1 Dịch Vụ Cần Sữa", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return;
            }
        }

        private void cbx_LoaiDichVu_Click(object sender, EventArgs e)
        {

        }

        private void cbx_LoaiDichVu_DropDown(object sender, EventArgs e)
        {
            //Load Lại Combox
            DichVu_WCFClient dv_temp = new DichVu_WCFClient();
            List<DichVu_Ent> temp = dv_temp.GetDichVus().ToList();
            cbx_LoaiDichVu.DataSource = InitializeTenLoaiDV(temp);
        }

        private void btnXoaDV_Click(object sender, EventArgs e)
        {
            if (dgv_dsDichVu.SelectedRows.Count == 0)
            {
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn Có Muốn Xóa ?", "XÓA Dịch Vụ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                if (dgv_dsDichVu.SelectedRows.Count >= 1)
                {
                    DichVu_WCFClient dv_wcf;

                    for (int i = 0; i < dgv_dsDichVu.SelectedRows.Count; i++)
                    {
                        int id = Convert.ToInt32(dgv_dsDichVu.SelectedRows[i].Cells[1].Value.ToString().Trim());
                        dv_wcf = new DichVu_WCFClient();
                        if (!dv_wcf.XoaDichVu_byIDDichVu(id))
                        {
                            break;
                        }
                    }

                    dv_wcf = new DichVu_WCFClient();
                    Loading_DSDichVu(DataTable_DSDichVu(dv_wcf.GetDichVus().ToList()));
                    Custom_DataGridView(dgv_dsDichVu);
                }
            }
            else
            {
                return;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text.Trim() == "")
            {
                return;
            }
            else
            {
                DichVu_WCFClient dv_wcf = new DichVu_WCFClient();
                int id = dv_wcf.GetIDDichVu_byTenDV(txtTimKiem.Text.Trim());
                List<DichVu_Ent> dsDichVu = dv_wcf.TimKiemDichVu_byIDDichVu(id).ToList();
                Loading_DSDichVu(DataTable_DSDichVu(dsDichVu));
                Custom_DataGridView(dgv_dsDichVu);
            }
        }
    }
}
