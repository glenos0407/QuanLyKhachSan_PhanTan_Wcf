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
    public class NhanVien_Ent
    {
        
        int id_nhanvien;
        string ho;
        string ten;
        string gioiTinh;
        DateTime ngaySinh;
        string chucVu;
        string caLamViec;
        string email;
        
        public NhanVien_Ent()
        {
            this.Id_nhanvien = id_nhanvien;
            this.Ho = ho;
            this.Ten = ten;
            this.GioiTinh = gioiTinh;
            this.NgaySinh = ngaySinh;
            this.ChucVu = chucVu;
            this.CaLamViec = caLamViec;
            this.Email = email;
        }

        
        [DataMember]
        public int Id_nhanvien
        {
            get
            {
                return id_nhanvien;
            }

            set
            {
                id_nhanvien = value;
            }
        }

        [DataMember]
        public string Ho
        {
            get
            {
                return ho;
            }

            set
            {
                ho = value;
            }
        }

        [DataMember]
        public string Ten
        {
            get
            {
                return ten;
            }

            set
            {
                ten = value;
            }
        }

        [DataMember]
        public string GioiTinh
        {
            get
            {
                return gioiTinh;
            }

            set
            {
                gioiTinh = value;
            }
        }

        [DataMember]
        public DateTime NgaySinh
        {
            get
            {
                return ngaySinh;
            }

            set
            {
                ngaySinh = value;
            }
        }

        [DataMember]
        public string ChucVu
        {
            get
            {
                return chucVu;
            }

            set
            {
                chucVu = value;
            }
        }

        [DataMember]
        public string CaLamViec
        {
            get
            {
                return caLamViec;
            }

            set
            {
                caLamViec = value;
            }
        }

        [DataMember]
        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }
    }
}
