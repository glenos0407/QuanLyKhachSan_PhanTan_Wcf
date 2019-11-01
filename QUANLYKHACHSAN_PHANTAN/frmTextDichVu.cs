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
using QUANLYKHACHSAN_PHANTAN.DichVu_Wcf;
using System.Text.RegularExpressions;

namespace QUANLYKHACHSAN_PHANTAN
{
    public partial class frmTextDichVu : Form
    {
        string lb_TitleName;
        int id_DichVu;
        int kieuForm;
        bool isClickBtnHuy = false;
        frmQLDichVu frmQLDV;

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

        public int Id_DichVu
        {
            get
            {
                return id_DichVu;
            }

            set
            {
                id_DichVu = value;
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

        public frmTextDichVu()
        {
            InitializeComponent();
        }
        public frmTextDichVu(frmQLDichVu fql, string title)
        {
            InitializeComponent();
            this.Text = "Thêm Dịch Vụ";
            Lb_TitleName = title;
            KieuForm = 1;
            frmQLDV = fql;
        }
        public frmTextDichVu(frmQLDichVu fql, string title, int id_dichvu)
        {
            InitializeComponent();
            Lb_TitleName = title;
            this.Text = "Sửa Dịch Vụ";
            Id_DichVu = id_dichvu;
            KieuForm = 2;
            frmQLDV = fql;
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            isClickBtnHuy = true;
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
        private bool CheckNull()
        {
           
            
            if (txtTenDichVu.Text.Trim().Equals(""))
            {
                return false;
            }

            if (txtGiaDichVu.Text.Trim().Equals(""))
            {
                return false;
            }

            Regex rg_GiaDichVu = new Regex(@"^\d+$");
            if (!rg_GiaDichVu.IsMatch(txtGiaDichVu.Text.Trim()))
            {
                return false;
            }

            if (cbx_LoaiDichVu.Text.Equals(""))
            {
                return false;
            }
       
            return true;
        }
        private void Clear_TextBox()
        {
            txtTenDichVu.Clear();
            txtGiaDichVu.Clear();
            cbx_LoaiDichVu.SelectedIndex = -1;
        }

        private void Luu_Them()
        {
            isClickBtnHuy = true;

            if (!CheckNull())
            {
                MessageBox.Show("Chưa Nhập Đủ Thông Tin", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DichVu_WCFClient dv_wcf = new DichVu_WCFClient();

            DichVu_Ent dv_ent = new DichVu_Ent();

            dv_ent.TenDichVu = txtTenDichVu.Text.Trim();
            dv_ent.DonGia = Convert.ToDouble(txtGiaDichVu.Text.Trim());
            dv_ent.TenLoaiDichVu = cbx_LoaiDichVu.Text;

            if (dv_wcf.ThemDichVu(dv_ent))
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

        private void Luu_Sua()
        {
            isClickBtnHuy = true;

            if (!CheckNull())
            {
                MessageBox.Show("Chưa Nhập Đủ Thông Tin", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DichVu_WCFClient dv_wcf = new DichVu_WCFClient();

            DichVu_Ent dv_ent = new DichVu_Ent();

            dv_ent.Id_DichVu = Id_DichVu;
            dv_ent.TenDichVu = txtTenDichVu.Text.Trim();
            dv_ent.DonGia = Convert.ToDouble(txtGiaDichVu.Text.Trim());
            dv_ent.TenLoaiDichVu = cbx_LoaiDichVu.Text;

            if (dv_wcf.CapNhatDichVu(dv_ent))
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

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            Clear_TextBox();
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

        private void frmTextDichVu_Load(object sender, EventArgs e)
        {
            DichVu_WCFClient tempdv_wcf = new DichVu_WCFClient();
            cbx_LoaiDichVu.DataSource = InitializeTenLoaiDV(tempdv_wcf.GetDichVus().ToList());

            lbTieuDe.Text = Lb_TitleName;

            //Load Dữ Liệu Thêm Dịch Vụ
            if (KieuForm == 1)
            {
                txtTenDichVu.Text = "Bún Thịt Nướng";
                txtGiaDichVu.Text = "50000";
                cbx_LoaiDichVu.SelectedIndex = 0;
            }

            //Load Dữ Liệu Dịch Vụ Cần Sửa
            if (KieuForm == 2)
            {
                DichVu_WCFClient dv_wcf = new DichVu_WCFClient();

                DichVu_Ent dv_ent = dv_wcf.GetDichVu_byIdDichVu(Id_DichVu);
                txtTenDichVu.Text = dv_ent.TenDichVu;
                txtGiaDichVu.Text = dv_ent.DonGia.ToString().Trim();
                cbx_LoaiDichVu.Text = dv_ent.TenLoaiDichVu;
            }
        }

        private void frmTextDichVu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DichVu_WCFClient dv_wcf = new DichVu_WCFClient();
            frmQLDV.Loading_DSDichVu(frmQLDV.DataTable_DSDichVu(dv_wcf.GetDichVus().ToList()));
            frmQLDV.Custom_DataGridView(frmQLDV.dgv_dsDichVu);

            if (txtTenDichVu.Text.Trim().Equals("") && txtGiaDichVu.Text.Trim().Equals(""))
            {
                if(cbx_LoaiDichVu.SelectedIndex == -1)
                {
                    return;
                }
            }

            if (isClickBtnHuy) { return; }

            DialogResult ds = MessageBox.Show("Bạn Muốn Thoát ?", "QUAY VỀ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (ds == DialogResult.Yes)
            {
                return;
            }
            else
            {
                e.Cancel = true;
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
    }
}
