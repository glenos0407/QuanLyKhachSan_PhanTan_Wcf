using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Entities;
using DAL;

namespace QuanLyKhachSan_Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDichVu_WCF" in both code and config file together.
    [ServiceContract]
    public interface IDichVu_WCF
    {

        [OperationContract]
        List<DichVu_Ent> GetDichVus();

        [OperationContract]
        DichVu_Ent GetDichVu_byIdDichVu(int idDV);

        [OperationContract]
        string GetTenLoaiDichVu_byIdLoaiDichVu(int idLoaiDV);

        [OperationContract]
        List<DichVu_Ent> TimKiemDichVu_byIDLoaiDV(int IDLoaiDV);

        [OperationContract]
        bool ThemDichVu(DichVu_Ent dv_ent);

        [OperationContract]
        bool CapNhatDichVu(DichVu_Ent dv_ent);

        [OperationContract]
        bool XoaDichVu_byIDDichVu(int idDichVu);

        [OperationContract]
        int GetIDLoaiDV_byTenLoai(string TenLoaiDV);

        [OperationContract]
        int GetIDDichVu_byTenDV(string TenDV);

        [OperationContract]
        List<DichVu_Ent> TimKiemDichVu_byIDDichVu(int IDDichVu);

        [OperationContract]
        string GetTenDichVu_byIdDichVu(int idDV);

        [OperationContract]
        double GetGiaDichVu_byIdDichVu(int idDV);
    }
}