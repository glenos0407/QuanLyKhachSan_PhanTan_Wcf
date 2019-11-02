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
using QUANLYKHACHSAN_PHANTAN.Phong_Wcf;

namespace QUANLYKHACHSAN_PHANTAN
{
    public partial class frmTextPhong : Form
    {
        string lb_TitleName;
        string id_Phong;
        int kieuForm;
        frmQuanLyPhong frmQLP;

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

        public string Id_Phong
        {
            get
            {
                return id_Phong;
            }

            set
            {
                id_Phong = value;
            }
        }

        public frmTextPhong()
        {
            InitializeComponent();
        }
        public frmTextPhong(frmQuanLyPhong fql, string title)
        {
            InitializeComponent();
            Lb_TitleName = title;
            KieuForm = 1;
            this.Size = new Size(524, 516);
            frmQLP = fql;
        }

        public frmTextPhong(frmQuanLyPhong fql, string title, string id_Phong)
        {
            InitializeComponent();
            Lb_TitleName = title;
            Id_Phong = id_Phong;
            KieuForm = 2;
            this.Size = new Size(524, 516);
            //cbx_TinhTrang.Visible = false;
            frmQLP = fql;
        }

        private void frmTextPhong_Load(object sender, EventArgs e)
        {
            if (kieuForm == 2)
            {
                Phong_WCFClient p_wcf = new Phong_WCFClient();
                Phong_Ent p_ent = p_wcf.GetPhong_by_ID(id_Phong);
                txtSoPhong.Text = p_ent.So_Phong.Trim();
                cbx_SoNguoi.Text = (p_ent.So_luong_nguoi.ToString());
                cbx_Tang.Text = p_ent.Tang.ToString();
                if (p_ent.Id_loai_phong.Equals("1"))
                {
                    cbx_LoaiPhong.Text = "Phòng Standard";
                } 
                else if (p_ent.Id_loai_phong.Equals("2"))
                {
                    cbx_LoaiPhong.Text = "Phòng Deluxe";
                }
                if (p_ent.Id_loai_phong.Equals("3"))
                {
                    cbx_LoaiPhong.Text = "Phòng Express View";
                }
                else
                {
                    cbx_LoaiPhong.Text = "Phòng VIP";
                }
            }
            else
            {
                lbTieuDe.Text = Lb_TitleName;
                cbx_LoaiPhong.SelectedIndex = 0;
                cbx_SoNguoi.SelectedIndex = 0;
                cbx_Tang.SelectedIndex = 0;
                //cbx_TinhTrang.SelectedIndex = 0;
            }
            
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
        private void Clear_TextBox()
        {
           
            txtSoPhong.Clear();
            txtGhiChu.Clear();
            cbx_LoaiPhong.SelectedIndex = -1;
          
            cbx_Tang.SelectedIndex = -1;
            cbx_SoNguoi.SelectedIndex = -1;          
        }
        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            Clear_TextBox();
        }
        private bool CheckNull()
        {
            if (cbx_LoaiPhong.Text.Equals(""))
            {
                return false;
            }
            if (cbx_Tang.Text.Equals(""))
            {
                return false;
            }
            if (cbx_SoNguoi.Text.Equals(""))
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
            Phong_WCFClient p_wcf = new Phong_WCFClient();
            Phong_Ent p_ent = new Phong_Ent();
           // p_ent.Id_Phong = 1;
            p_ent.So_Phong = txtSoPhong.Text.Trim();
            p_ent.Ghi_chu = txtGhiChu.Text.Trim();
            if (cbx_LoaiPhong.SelectedIndex == 0)
            {
                p_ent.Id_loai_phong = "1";
            }
            if (cbx_LoaiPhong.SelectedIndex == 1)
            {
                p_ent.Id_loai_phong = "2";
            }
            if (cbx_LoaiPhong.SelectedIndex == 2)
            {
                p_ent.Id_loai_phong = "3";
            }
            if (cbx_LoaiPhong.SelectedIndex == 3)
            {
                p_ent.Id_loai_phong = "4";
            }
            if (cbx_Tang.SelectedIndex == 0)
            {
                p_ent.Tang = 1;

            }

            if (cbx_Tang.SelectedIndex == 1)
            {
                p_ent.Tang = 2;

            }
             if (cbx_Tang.SelectedIndex == 2)
            {
                p_ent.Tang = 3;
            }
            if (cbx_Tang.SelectedIndex == 3)
            {
                p_ent.Tang = 4;
            }
            if (cbx_SoNguoi.SelectedIndex == 0)
            {
                p_ent.So_luong_nguoi = 1;
            }
            if (cbx_SoNguoi.SelectedIndex == 1)
            {
                p_ent.So_luong_nguoi = 2;
            }
            if (cbx_SoNguoi.SelectedIndex == 2)
            {
                p_ent.So_luong_nguoi = 3;
            }
            if (cbx_SoNguoi.SelectedIndex == 3)
            {
                p_ent.So_luong_nguoi = 4;
            }
            if (cbx_SoNguoi.SelectedIndex == 4)
            {
                p_ent.So_luong_nguoi = 5;
            }
            
            if (p_wcf.ThemPhong(p_ent))
            {
                DialogResult ds = MessageBox.Show("Lưu Thành Công, Tiếp Tục ?", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                DialogResult ds = MessageBox.Show("Lưu Thất Bại, Thử Lại ?", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (!CheckNull())
            {
                MessageBox.Show("Chưa Nhập Đủ Thông Tin", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Phong_WCFClient p_wcf = new Phong_WCFClient();

            Phong_Ent p_ent = new Phong_Ent();
            p_ent.Id_Phong = Convert.ToInt32(id_Phong);
            p_ent.So_Phong = txtSoPhong.Text.Trim();
            p_ent.Ghi_chu = txtGhiChu.Text.Trim();
            if (cbx_LoaiPhong.SelectedIndex == 0)
            {
                p_ent.Id_loai_phong = "1";
            }
            if (cbx_LoaiPhong.SelectedIndex == 1)
            {
                p_ent.Id_loai_phong = "2";
            }
            if (cbx_LoaiPhong.SelectedIndex == 2)
            {
                p_ent.Id_loai_phong = "3";
            }
            if (cbx_LoaiPhong.SelectedIndex == 3)
            {
                p_ent.Id_loai_phong = "4";
            }

                if (cbx_Tang.SelectedIndex == 0)
            {
                p_ent.Tang = 1;

            }

            if (cbx_Tang.SelectedIndex == 1)
            {
                p_ent.Tang = 2;

            }
            if (cbx_Tang.SelectedIndex == 2)
            {
                p_ent.Tang = 3;
            }
            if (cbx_Tang.SelectedIndex == 3)
            {
                p_ent.Tang = 4;
            }
            if (cbx_SoNguoi.SelectedIndex == 0)
            {
                p_ent.So_luong_nguoi = 1;
            }
            if (cbx_SoNguoi.SelectedIndex == 1)
            {
                p_ent.So_luong_nguoi = 2;
            }
            if (cbx_SoNguoi.SelectedIndex == 2)
            {
                p_ent.So_luong_nguoi = 3;
            }
            if (cbx_SoNguoi.SelectedIndex == 3)
            {
                p_ent.So_luong_nguoi = 4;
            }
            if (cbx_SoNguoi.SelectedIndex == 4)
            {
                p_ent.So_luong_nguoi = 5;
            }

            if (p_wcf.CapNhatPhong(p_ent))
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

        private void frmTextPhong_FormClosing(object sender, FormClosingEventArgs e)
        {
            Phong_WCFClient p_wcf = new Phong_WCFClient();
            frmQLP.Loading_DSP(frmQLP.DataTable_DSP(p_wcf.GetPhongs().ToList()));
            frmQLP.Custom_DataGridView(frmQLP.dgv_DSPhong);
        }
    }
}
