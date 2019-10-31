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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IKhachHang_WCF" in both code and config file together.
    [ServiceContract]
    public interface IKhachHang_WCF
    {
        [OperationContract]
        List<KhachHang_Ent> GetKhachHangs();

        [OperationContract]
        bool ThemKhachHang(KhachHang_Ent kh_ent);

        [OperationContract]
        bool CapNhatKhachHang(KhachHang_Ent kh_ent);

        [OperationContract]
        List<KhachHang_Ent> TimKiem_KhachHang_by_CMND(string CMND);

        [OperationContract]
        KhachHang_Ent GetKhachHang_byCMND(string CMND);
    }
}
