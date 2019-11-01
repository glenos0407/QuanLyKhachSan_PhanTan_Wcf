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
    public class DichVu_Ent
    {
        string tenDichVu, tenLoaiDichVu;
        double donGia;
        int id_LoaiDichVu; 
        int id_DichVu;
        
        public DichVu_Ent()
        {
            this.DonGia = donGia;
            this.TenDichVu = tenDichVu;
            this.Id_DichVu = id_DichVu;
            this.Id_LoaiDichVu = id_LoaiDichVu;
            this.TenLoaiDichVu = tenLoaiDichVu;
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
        public string TenDichVu
        {
            get
            {
                return tenDichVu;
            }

            set
            {
                tenDichVu = value;
            }
        }

        [DataMember]
        public string TenLoaiDichVu
        {
            get
            {
                return tenLoaiDichVu;
            }

            set
            {
                tenLoaiDichVu = value;
            }
        }

        [DataMember]
        public double DonGia
        {
            get
            {
                return donGia;
            }

            set
            {
                donGia = value;
            }
        }
        [DataMember]
        public int Id_LoaiDichVu
        {
            get
            {
                return id_LoaiDichVu;
            }

            set
            {
                id_LoaiDichVu = value;
            }
        }
    }
}
