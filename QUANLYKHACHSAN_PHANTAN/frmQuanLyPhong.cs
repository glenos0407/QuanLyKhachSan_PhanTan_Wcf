using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QUANLYKHACHSAN_PHANTAN.Phong_Wcf;


namespace QUANLYKHACHSAN_PHANTAN
{
    public partial class frmQuanLyPhong : Form
    {
        public frmQuanLyPhong()
        {
            InitializeComponent();
        }

        private void frmQuanLyPhong_Load(object sender, EventArgs e)
        {
            btnReload.Image = imgs_Button.Images[0];
            Phong_WCFClient p_wcf = new Phong_WCFClient();
            List<Phong_Ent> dsP = p_wcf.GetPhongs().ToList();
            Loading_DSP(DataTable_DSP(dsP));
            Custom_DataGridView(dgv_DSPhong);
        }
        public void Loading_DSP(DataTable dt)
        {
            dgv_DSPhong.Columns.Clear();
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            bn_DSPhong.BindingSource = bs;
            dgv_DSPhong.DataSource = bs;

            string[] Tang = {"Tầng","Tầng 1", "Tầng 2", "Tầng 3", "Tầng 4" };
            cbx_Tang.DataSource = Tang;
            cbx_Tang.SelectedIndex = 0;

            string[] TinhTrang = { "Tình trạng", "Phòng trống", "Phòng đã đặt" };
            cbx_TinhTrang.DataSource = TinhTrang;
            cbx_TinhTrang.SelectedIndex = 0;

            string[] LoaiPhong = { "Loại phòng", "Phòng Standard", "Phòng Deluxe", "Phòng Express View", "Phòng VIP" };
            cbx_LoaiPhong.DataSource = LoaiPhong;
            cbx_LoaiPhong.SelectedIndex = 0;
        }

        public DataTable DataTable_DSP(List<Phong_Ent> dsPhong)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã phòng", typeof(int));
            dt.Columns.Add("Số Phòng", typeof(string));
            dt.Columns.Add("Tầng", typeof(int));
            dt.Columns.Add("Số người", typeof(string));
            dt.Columns.Add("Tình Trạng", typeof(string));
            dt.Columns.Add("Loại Phòng", typeof(string));
            dt.Columns.Add("Ghi chú", typeof(string));          
            foreach (Phong_Ent p_ent in dsPhong)
            { 
                dt.Rows.Add(p_ent.Id_Phong, p_ent.So_Phong, p_ent.Tang, p_ent.So_luong_nguoi, p_ent.Tinh_trang, p_ent.Id_loai_phong, p_ent.Ghi_chu);
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
                    column.Width = 100;
                }
                if (column.Index == 2)
                {
                    column.Width = 120;
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
                    column.Width = 220;
                }
                if (column.Index == 6)
                {
                    column.Width = 300;
                }
            }

            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmTextPhong ftp = new frmTextPhong(this, "Thêm Phòng");
            ftp.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //if (dgv_DSPhong.SelectedRows.Count >= 1)
            //{
            //    Phong_WCFClient p_wcf;
            //    Phong_Ent p_ent = new Phong_Ent();              
            //    for (int i = 0; i < dgv_DSPhong.SelectedRows.Count; i++)
            //    {
            //        p_ent.Id_Phong = dgv_DSPhong.SelectedRows[i].Cells[1].Value.ToString().Trim();
            //        p_wcf = new Phong_WCFClient();
            //        if (!p_wcf.CapNhatPhong(p_ent))
            //        {
            //            break;
            //        }
            //    }
            //    p_wcf = new Phong_WCFClient();
            //    Loading_DSP(DataTable_DSP(p_wcf.GetPhongs().ToList()));
            //    Custom_DataGridView(dgv_DSPhong);
            //}
            //else
            //{
            //    MessageBox.Show("Chọn 1 Phòng Cần Sửa", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //    return;
            //}
            string idp = dgv_DSPhong.SelectedRows[0].Cells[1].Value.ToString().Trim();
           // MessageBox.Show(idp);
            frmTextPhong ftp = new frmTextPhong(this, "Sửa Phòng",idp);
            ftp.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgv_DSPhong.SelectedRows.Count == 0)
            {
                return;
            }
            DialogResult dr = MessageBox.Show("Bạn Có Muốn Xóa ?", "XÓA PHÒNG", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                if (dgv_DSPhong.SelectedRows.Count >= 1)
                {
                    Phong_WCFClient p_wcf;

                    for (int i = 0; i < dgv_DSPhong.SelectedRows.Count; i++)
                    {
                        string id = dgv_DSPhong.SelectedRows[i].Cells[1].Value.ToString().Trim();
                        p_wcf = new Phong_WCFClient();
                        if (!p_wcf.XoaPhong(id))
                        {
                            break;
                        }
                    }
                    p_wcf = new Phong_WCFClient();
                    Loading_DSP(DataTable_DSP(p_wcf.GetPhongs().ToList()));
                    Custom_DataGridView(dgv_DSPhong);
                }
            }
            else
            {
                return;
            }
        }

        private void cbxTang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_Tang.SelectedIndex == 0)
            {
                return;
            }
            else
            {
                Phong_WCFClient p_wcf = new Phong_WCFClient();
                List<Phong_Ent> dsP = new List<Phong_Ent>();
                 dsP = p_wcf.SapXepTang(cbx_Tang.SelectedIndex).ToList();
                Loading_DSP(DataTable_DSP(dsP));
                Custom_DataGridView(dgv_DSPhong);
            }
        }

        private void cbx_TinhTrang_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbx_TinhTrang.SelectedIndex == 0)
            {
                return;
            }
            else
            {
                Phong_WCFClient p_wcf = new Phong_WCFClient();
                List<Phong_Ent> dsP = p_wcf.SapXepTinhTrang(cbx_TinhTrang.SelectedItem.ToString()).ToList();
                Loading_DSP(DataTable_DSP(dsP));
                Custom_DataGridView(dgv_DSPhong);
            }
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

        private void cbx_LoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_LoaiPhong.SelectedIndex == 0)
            {
                return;
            }
            else
            {
                Phong_WCFClient p_wcf = new Phong_WCFClient();
                List<Phong_Ent> dsP = p_wcf.SapXepLoaiPhong(cbx_LoaiPhong.SelectedItem.ToString()).ToList();
                Loading_DSP(DataTable_DSP(dsP));
                Custom_DataGridView(dgv_DSPhong);
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            Phong_WCFClient p_wcf = new Phong_WCFClient();
            List<Phong_Ent> dsP = p_wcf.Tim_Kiem_By_SoPhong(txtTimKiem.Text).ToList();           
            Loading_DSP(DataTable_DSP(dsP));
            Custom_DataGridView(dgv_DSPhong);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            cbx_Tang.SelectedIndex = 0;
            cbx_TinhTrang.SelectedIndex = 0;
            cbx_LoaiPhong.SelectedIndex = 0;
            txtTimKiem.Clear();
            Phong_WCFClient p_wcf = new Phong_WCFClient();
            List<Phong_Ent> dsP = p_wcf.GetPhongs().ToList();
            Loading_DSP(DataTable_DSP(dsP));
            Custom_DataGridView(dgv_DSPhong);
        }
    }
}

