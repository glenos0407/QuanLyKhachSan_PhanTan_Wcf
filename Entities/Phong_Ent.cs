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
    public class Phong_Ent
    {
        int id_Phong;
        string id_loai_phong, so_Phong, ghi_chu;
        int tang, so_luong_nguoi;
        string tinh_trang;


        [DataMember]
        public string So_Phong
        {
            get
            {
                return so_Phong;
            }

            set
            {
                so_Phong = value;
            }
        }
      
       
        [DataMember]
        public string Ghi_chu
        {
            get
            {
                return ghi_chu;
            }

            set
            {
                ghi_chu = value;
            }
        }
        [DataMember]
        public int Tang
        {
            get
            {
                return tang;
            }

            set
            {
                tang = value;
            }
        }
        [DataMember]
        public int So_luong_nguoi
        {
            get
            {
                return so_luong_nguoi;
            }

            set
            {
                so_luong_nguoi = value;
            }
        }

        [DataMember]
        public string Tinh_trang
        {
            get
            {
                return tinh_trang;
            }

            set
            {
                tinh_trang = value;
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
        public string Id_loai_phong
        {
            get
            {
                return id_loai_phong;
            }

            set
            {
                id_loai_phong = value;
            }
        }

        public Phong_Ent()
        {
            this.Id_Phong = id_Phong;
            this.Id_loai_phong = id_loai_phong;
            this.So_Phong = so_Phong;
            this.Ghi_chu = ghi_chu;
            this.Tang = tang;
            this.So_luong_nguoi = so_luong_nguoi;
            this.Tinh_trang = tinh_trang;
        }
       
    }
}
