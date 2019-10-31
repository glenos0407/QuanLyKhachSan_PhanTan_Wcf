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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "INhanVien_WCF" in both code and config file together.
    [ServiceContract]
    public interface INhanVien_WCF
    {
        [OperationContract]
        NhanVien_Ent GetNhanVien_by_ID(int id);

        [OperationContract]
        int GetChucVu(int id);

        [OperationContract]
        string GetHoTen_NhanVien(int id);

        [OperationContract]
        int GetID_by_Email(string email);

        [OperationContract]
        string GetEmail_by_ID(int id);

        [OperationContract]
        List<NhanVien_Ent> GetNhanViens();

        [OperationContract]
        List<NhanVien_Ent> SapXepChucVu(int chucvu);

        [OperationContract]
        List<NhanVien_Ent> SapXepCaLamViec(int caLamViec);

        [OperationContract]
        bool DangNhapHeThong(string email, string pass);

        [OperationContract]
        bool ThemNhanVien(NhanVien_Ent nv_ent, string matKhau);

        [OperationContract]
        bool CapNhatNhanVien(NhanVien_Ent nv_ent, string old_email);

        [OperationContract]
        bool CapNhatMatKhau(string email, string matKhaucu, string matkhaumoi);

        [OperationContract]
        bool XoaNhanVien_by_Email(string email);

        [OperationContract]
        List<NhanVien_Ent> TimKiem_NhanVien_by_HoTen(string ho, string ten);

    }
}
