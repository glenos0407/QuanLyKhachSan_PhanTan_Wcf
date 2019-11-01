using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QUANLYKHACHSAN_PHANTAN.BaoCao_Wcf;
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
                if (column.Index == 7)
                {
                    column.Width = 220;
                }
            }

            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void rbtnNgayHienTai_CheckedChanged(object sender, EventArgs e)
        {
            
            Custom_DataGridView(dgv_BaoCao);
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            BaoCao_WCFClient bc_wcf = new BaoCao_WCFClient();
            dgv_BaoCao.DataSource = bc_wcf.GetBaoCaos(DateTime.Now);
        }
    }
}
