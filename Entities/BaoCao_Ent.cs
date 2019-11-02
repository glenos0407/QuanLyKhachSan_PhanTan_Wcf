using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Entities
{
    [DataContract]
    public class BaoCao_Ent
    {                                     
        DateTime ngay_check_in;
        TimeSpan  gio_check_in;
        DateTime ngay_check_out;
        TimeSpan gio_check_out;
        double giam_gia;
        KhachHang_Ent kh_ent;
        NhanVien_Ent nv_ent;

        public BaoCao_Ent(DateTime ngay_check_in, TimeSpan gio_check_in, DateTime ngay_check_out, TimeSpan gio_check_out, double giam_gia, KhachHang_Ent kh_ent, NhanVien_Ent nv_ent)
        {
            this.ngay_check_in = ngay_check_in;
            this.gio_check_in = gio_check_in;
            this.ngay_check_out = ngay_check_out;
            this.gio_check_out = gio_check_out;
            this.giam_gia = giam_gia;
            this.kh_ent = kh_ent;
            this.nv_ent = nv_ent;
        }

        public BaoCao_Ent() { }

        public DateTime Ngay_check_in
        {
            get
            {
                return ngay_check_in;
            }

            set
            {
                ngay_check_in = value;
            }
        }

        public TimeSpan Gio_check_in
        {
            get
            {
                return gio_check_in;
            }

            set
            {
                gio_check_in = value;
            }
        }

        public DateTime Ngay_check_out
        {
            get
            {
                return ngay_check_out;
            }

            set
            {
                ngay_check_out = value;
            }
        }

        public TimeSpan Gio_check_out
        {
            get
            {
                return gio_check_out;
            }

            set
            {
                gio_check_out = value;
            }
        }

        public double Giam_gia
        {
            get
            {
                return giam_gia;
            }

            set
            {
                giam_gia = value;
            }
        }

        public KhachHang_Ent Kh_ent
        {
            get
            {
                return kh_ent;
            }

            set
            {
                kh_ent = value;
            }
        }

        public NhanVien_Ent Nv_ent
        {
            get
            {
                return nv_ent;
            }

            set
            {
                nv_ent = value;
            }
        }

        //public BaoCao_Ent()
        //{
        //    Ngay_check_in = ngay_check_in;
        //    Gio_check_in = gio_check_in;
        //    Ngay_check_out = ngay_check_out;
        //    Gio_check_out = gio_check_out;
        //    Giam_gia = giam_gia;
        //    Kh_ent = kh_ent;
        //    Nv_ent = nv_ent;
        //}

        //public DateTime Ngay_check_in { get => ngay_check_in; set => ngay_check_in = value; }
        //public TimeSpan Gio_check_in { get => gio_check_in; set => gio_check_in = value; }
        //public DateTime Ngay_check_out { get => ngay_check_out; set => ngay_check_out = value; }
        //public TimeSpan Gio_check_out { get => gio_check_out; set => gio_check_out = value; }
        //public double Giam_gia { get => giam_gia; set => giam_gia = value; }
        //public KhachHang_Ent Kh_ent { get => kh_ent; set => kh_ent = value; }
        //public NhanVien_Ent Nv_ent { get => nv_ent; set => nv_ent = value; }

        public double TinhTienPhong(double donGia, int soNgay)
        {
            return (donGia*soNgay)-((Giam_gia*donGia)/100);
        }

        public double TinhTienDichVu(double donGia, int soLuong)
        {
            return donGia * soLuong;
        }
    }
}
