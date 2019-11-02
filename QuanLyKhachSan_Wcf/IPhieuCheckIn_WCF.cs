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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPhieuCheckIn_WCF" in both code and config file together.
    [ServiceContract]
    public interface IPhieuCheckIn_WCF
    {
        [OperationContract]
        bool ThemPhieuCheckIn(PhieuCheckIn_Ent phieucheckin_ent);

        [OperationContract]
        List<PhieuCheckIn_Ent> lsPhieuCheckIn_ToDate(DateTime date);

        [OperationContract]
        List<PhieuCheckIn_Ent> GetPhieuCheckIns();

        [OperationContract]
        List<PhieuCheckIn_Ent> GetKh_ChuaThanhToan_ByID(int idKH);

        [OperationContract]
        bool ThemPhieuCheckIn_DichVu(PhieuCheckIn_Ent phieucheckin_ent);

        [OperationContract]
        List<PhieuCheckIn_Ent> GetPhieuCheckIns_NoCheckOut();
    }
}
