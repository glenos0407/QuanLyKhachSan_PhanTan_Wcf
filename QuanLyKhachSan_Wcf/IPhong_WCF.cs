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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPhong_WCF" in both code and config file together.
    [ServiceContract]
    public interface IPhong_WCF
    {
        [OperationContract]
        List<Phong_Ent> GetPhongs();

        [OperationContract]
        int GetIDPhong_by_SoPhong(string sp);

        [OperationContract]
        bool ThemPhong(Phong_Ent phong_ent);

        [OperationContract]
        bool CapNhatPhong(Phong_Ent phong_ent);

        [OperationContract]
        bool XoaPhong(string id_Phong);

        [OperationContract]
        Phong_Ent GetPhong_by_ID(string id);

        [OperationContract]
        List<Phong_Ent> SapXepTang(int Tang);

        [OperationContract]
        List<Phong_Ent> SapXepTinhTrang(string TinhTrang);

        [OperationContract]
        List<Phong_Ent> SapXepLoaiPhong(string idLoaiPhong);

        [OperationContract]
        List<Phong_Ent> Tim_Kiem_By_SoPhong(string soPhong);

        [OperationContract]
        List<Phong_Ent> GetPhongTrong_byLoaiPhong(int idLoaiPhong);

        [OperationContract]
        decimal DonGia(string id_LoaiPhong);

        [OperationContract]
        int getIDPhong(string soPhong);

        [OperationContract]
        string getsoPhong_byID(int id);

        [OperationContract]
        double TinhTienPhong(int idLoaiPhong, int soNgay);

        [OperationContract]
        bool update_TinhTrangPhong(int idPhong, int trangThai);

        [OperationContract]
        string GetTenLoaiPhong_by_IDLoai(int id);
    }
}
