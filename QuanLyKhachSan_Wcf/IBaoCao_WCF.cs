using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using Entities;

namespace QuanLyKhachSan_Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBaoCao_WCF" in both code and config file together.
    [ServiceContract]
    public interface IBaoCao_WCF
    {
        [OperationContract]
        List<BaoCao_Ent> GetBaoCaos(DateTime dt);
    }
}
