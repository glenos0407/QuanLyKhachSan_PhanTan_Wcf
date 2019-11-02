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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "KhachHang_WCF" in both code and config file together.
    public class KhachHang_WCF : IKhachHang_WCF
    {
        DB_KhachSanDataContext db;

        public KhachHang_WCF()
        {
            db = new DB_KhachSanDataContext();
        }

        public KhachHang_Ent GetKhachHang_byCMND(string CMND)
        {
            KhachHang kh = db.KhachHangs.Where(n => n.so_cmnd.Equals(CMND)).SingleOrDefault();
            KhachHang_Ent kh_ent;

            if (kh == null)
            {
                return null;
            }
            else{
                kh_ent = new KhachHang_Ent();

                kh_ent.Id_khach = kh.id_khach;
                kh_ent.Ho = kh.ho.Trim();
                kh_ent.Ten = kh.ten.Trim();
                kh_ent.Date_of_birth = kh.date_of_birth;
                kh_ent.So_cmnd = kh.so_cmnd;
                if (kh.gioi_tinh == 0)
                {
                    kh_ent.Gioi_tinh = "Nữ";
                }
                if (kh.gioi_tinh == 1)
                {
                    kh_ent.Gioi_tinh = "Nam";
                }
                kh_ent.Sodienthoai = kh.so_dien_thoai;
                kh_ent.Quoc_tich = kh.quoc_tich;
            }

            return kh_ent;
        }

        public List<KhachHang_Ent> GetKhachHangs()
        {
            List<KhachHang_Ent> kh_ents = new List<KhachHang_Ent>();

            foreach (KhachHang kh in db.KhachHangs.Select(n => n))
            {
                KhachHang_Ent kh_ent = new KhachHang_Ent();
                kh_ent.Id_khach = kh.id_khach;
                kh_ent.Ho = kh.ho.Trim();
                kh_ent.Ten = kh.ten.Trim();
                kh_ent.Date_of_birth = kh.date_of_birth;
                kh_ent.So_cmnd = kh.so_cmnd;
                if(kh.gioi_tinh == 1)
                {
                    kh_ent.Gioi_tinh = "Nam";
                }
                if (kh.gioi_tinh == 0)
                {
                    kh_ent.Gioi_tinh = "Nữ";
                }
                kh_ent.Sodienthoai = kh.so_dien_thoai;
                kh_ent.Quoc_tich = kh.quoc_tich;
                kh_ents.Add(kh_ent);
            }

            

            return kh_ents;
        }

        public bool CapNhatKhachHang(KhachHang_Ent kh_ent)
        {
            KhachHang kh = db.KhachHangs.Where(n => n.id_khach.Equals(kh_ent.Id_khach)).SingleOrDefault();

            if (kh == null)
            {
                return false;
            }

            try
            {
                kh.ho = kh_ent.Ho;
                kh.ten = kh_ent.Ten;
                kh.date_of_birth = kh_ent.Date_of_birth;
                kh.so_cmnd = kh_ent.So_cmnd;
                kh.so_dien_thoai = kh_ent.Sodienthoai;
                if (kh_ent.Gioi_tinh == "nam")
                {
                    kh.gioi_tinh = 1;
                }
                if (kh_ent.Gioi_tinh == "nu")
                {
                    kh.gioi_tinh = 0;
                }
                kh.quoc_tich = kh_ent.Quoc_tich;
                db.SubmitChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool ThemKhachHang(KhachHang_Ent kh_ent)
        {
            KhachHang KhachHangCMND = db.KhachHangs.Where(n => n.so_cmnd.Equals(kh_ent.So_cmnd)).SingleOrDefault();

            if (KhachHangCMND != null)
            {
                return false;
            }
            try
            {
                KhachHang kh = new KhachHang();

                kh.ho = kh_ent.Ho;
                kh.ten = kh_ent.Ten;
                kh.so_cmnd = kh_ent.So_cmnd;
                kh.so_dien_thoai = kh_ent.Sodienthoai;
                if (kh_ent.Gioi_tinh == "nam")
                {
                    kh.gioi_tinh = 1;
                }
                if (kh_ent.Gioi_tinh == "nu")
                {
                    kh.gioi_tinh = 0;
                }
                kh.quoc_tich = kh_ent.Quoc_tich;
                kh.date_of_birth = kh_ent.Date_of_birth;

                db.KhachHangs.InsertOnSubmit(kh);
                db.SubmitChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public List<KhachHang_Ent> TimKiem_KhachHang_by_CMND(string CMND)
        {
            List<KhachHang_Ent> kh_ents = new List<KhachHang_Ent>();

            foreach (KhachHang kh in db.KhachHangs.Where(n => n.so_cmnd.Equals(CMND)))
            {
                KhachHang_Ent kh_ent = new KhachHang_Ent();

                kh_ent.Id_khach = kh.id_khach;
                kh_ent.Ho = kh.ho.Trim();
                kh_ent.Ten = kh.ten.Trim();
                kh_ent.Date_of_birth = kh.date_of_birth;
                kh_ent.So_cmnd = kh.so_cmnd;
                if (kh.gioi_tinh == 0)
                {
                    kh_ent.Gioi_tinh = "Nữ";
                }
                if (kh.gioi_tinh == 1)
                {
                    kh_ent.Gioi_tinh = "Nam";
                }
                kh_ent.Sodienthoai = kh.so_dien_thoai;
                kh_ent.Quoc_tich = kh.quoc_tich;
                kh_ents.Add(kh_ent);
            }
            return kh_ents;
        }

        public string getTenKhacHang_byID(int id)
        {
            KhachHang kh = db.KhachHangs.Where(n => n.id_khach == id).SingleOrDefault();
            
            if (kh == null)

            {
                return "";
            }

            return kh.ten;
        }

        public string getHoKhacHang_byID(int id)
        {
            KhachHang kh = db.KhachHangs.Where(n => n.id_khach == id).SingleOrDefault();
            
            if(kh == null)
            
            {
                return "";
            }

            return kh.ho;
        }
    }
}
