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
    public class KhachHang_Ent
    {
        string id_khach, ho, ten, so_cmnd, sodienthoai, quoc_tich;
        bool gioi_tinh;
        DateTime date_of_birth;

        public KhachHang_Ent(string id_khach, string ho, string ten, string so_cmnd, string sodienthoai, string quoc_tich, bool gioi_tinh, DateTime date_of_birth)
        {
            this.id_khach = id_khach;
            this.ho = ho;
            this.ten = ten;
            this.so_cmnd = so_cmnd;
            this.sodienthoai = sodienthoai;
            this.quoc_tich = quoc_tich;
            this.gioi_tinh = gioi_tinh;
            this.date_of_birth = date_of_birth;
        }

        public KhachHang_Ent()
        {

        }

        [DataMember]
        public string Id_khach
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
        public string So_cmnd
        {
            get
            {
                return so_cmnd;
            }

            set
            {
                so_cmnd = value;
            }
        }

        [DataMember]
        public string Sodienthoai
        {
            get
            {
                return sodienthoai;
            }

            set
            {
                sodienthoai = value;
            }
        }

        [DataMember]
        public string Quoc_tich
        {
            get
            {
                return quoc_tich;
            }

            set
            {
                quoc_tich = value;
            }
        }

        [DataMember]
        public bool Gioi_tinh
        {
            get
            {
                return gioi_tinh;
            }

            set
            {
                gioi_tinh = value;
            }
        }

        [DataMember]
        public DateTime Date_of_birth
        {
            get
            {
                return date_of_birth;
            }

            set
            {
                date_of_birth = value;
            }
        }
    }
}
