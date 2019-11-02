using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYKHACHSAN_PHANTAN
{
    public partial class frmSoLuong : Form
    {
        frmMuaBanDichVu frm_MBdv;
        public frmSoLuong()
        {
            InitializeComponent();
        }

        public frmSoLuong(frmMuaBanDichVu fmbdv)
        {
            InitializeComponent();
            frm_MBdv = fmbdv;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Regex rg = new Regex(@"^\d+$");

            if (!rg.IsMatch(txtSoLuong.Text.Trim())){
                MessageBox.Show("Sai Định Dạng","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            frm_MBdv.soLuong = Convert.ToInt32(txtSoLuong.Text.Trim());
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {  
             this.Close();
        }
    }
}
