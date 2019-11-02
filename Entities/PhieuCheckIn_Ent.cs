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
    public class PhieuCheckIn_Ent
    {
        private int id_phieu_checkin, soLuongKhach, soLuongDichVu, id_khach, id_DichVu, id_Phong, id_NhanVien;
        private DateTime ngay_check_in, ngay_check_out;
        private TimeSpan gio_check_in, gio_check_out;
        private double giam_gia;
        private int trangThaiHoaDon;

        public PhieuCheckIn_Ent(int id_phieu_checkin, int soLuongKhach, int soLuongDichVu, int id_khach, int id_DichVu, int id_Phong, int id_NhanVien, DateTime ngay_check_in, DateTime ngay_check_out, TimeSpan gio_check_in, TimeSpan gio_check_out, double giam_gia, int trangThaiHoaDon)
        {
            this.Id_phieu_checkin = id_phieu_checkin;
            this.SoLuongKhach = soLuongKhach;
            this.SoLuongDichVu = soLuongDichVu;
            this.Id_khach = id_khach;
            this.Id_DichVu = id_DichVu;
            this.Id_Phong = id_Phong;
            this.Id_NhanVien = id_NhanVien;
            this.Ngay_check_in = ngay_check_in;
            this.Ngay_check_out = ngay_check_out;
            this.Gio_check_in = gio_check_in;
            this.Gio_check_out = gio_check_out;
            this.Giam_gia = giam_gia;
            this.TrangThaiHoaDon = trangThaiHoaDon;
        }

        public PhieuCheckIn_Ent()
        {
            this.Id_phieu_checkin = id_phieu_checkin;
            this.SoLuongKhach = soLuongKhach;
            this.SoLuongDichVu = soLuongDichVu;
            this.Id_khach = id_khach;
            this.Id_DichVu = id_DichVu;
            this.Id_Phong = id_Phong;
            this.Id_NhanVien = id_NhanVien;
            this.Ngay_check_in = ngay_check_in;
            this.Ngay_check_out = ngay_check_out;
            this.Gio_check_in = gio_check_in;
            this.Gio_check_out = gio_check_out;
            this.Giam_gia = giam_gia;
        }

        [DataMember]
        public int Id_phieu_checkin
        {
            get
            {
                return id_phieu_checkin;
            }

            set
            {
                id_phieu_checkin = value;
            }
        }
        [DataMember]
        public int SoLuongKhach
        {
            get
            {
                return soLuongKhach;
            }

            set
            {
                soLuongKhach = value;
            }
        }
        [DataMember]
        public int SoLuongDichVu
        {
            get
            {
                return soLuongDichVu;
            }

            set
            {
                soLuongDichVu = value;
            }
        }
        [DataMember]
        public int Id_khach
        {
            get
            {
                return id_khach;
            }

            set
            {
                id_khach = value;
            }
        }
        [DataMember]
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
        [DataMember]
        public int Id_Phong
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
        [DataMember]
        public int Id_NhanVien
        {
            get
            {
                return id_NhanVien;
            }

            set
            {
                id_NhanVien = value;
            }
        }
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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

        [DataMember]
        public int TrangThaiHoaDon
        {
            get
            {
                return trangThaiHoaDon;
            }

            set
            {
                trangThaiHoaDon = value;
            }
        }
    }
}
