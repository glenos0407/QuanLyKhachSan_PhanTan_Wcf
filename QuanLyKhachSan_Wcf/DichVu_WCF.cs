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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DichVu_WCF" in both code and config file together.
    public class DichVu_WCF : IDichVu_WCF
    {
        DB_KhachSanDataContext db;
        public DichVu_WCF()
        {
            db = new DB_KhachSanDataContext();
        }

        public bool CapNhatDichVu(DichVu_Ent dv_ent)
        {
            DichVu dv = db.DichVus.Where(n => n.id_DichVu.Equals(dv_ent.Id_DichVu)).SingleOrDefault();
            LoaiDichVu loaiDV = db.LoaiDichVus.Where(n => n.ten_loai_dich_vu.Equals(dv_ent.TenLoaiDichVu)).SingleOrDefault();

            if (dv == null)
            {
                return false;
            }

            if (loaiDV == null)
            {
                try
                {
                    LoaiDichVu ldv = new LoaiDichVu();

                    ldv.ten_loai_dich_vu = dv_ent.TenLoaiDichVu;

                    db.LoaiDichVus.InsertOnSubmit(ldv);
                    db.SubmitChanges();
                }
                catch
                {
                    return false;
                }
            }

            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.LoaiDichVus);

            try
            {
                dv.ten_dich_vu = dv_ent.TenDichVu;
            dv.gia_dich_vu = dv_ent.DonGia;
            dv.id_loai_dich_vu = db.LoaiDichVus.Where(n => n.ten_loai_dich_vu.Equals(dv_ent.TenLoaiDichVu)).SingleOrDefault().id_LoaiDichVu;

            db.SubmitChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public List<DichVu_Ent> GetDichVus()
        {
            List<DichVu_Ent> dv_ents = new List<DichVu_Ent>();

            var dsDichVu = from ldv in db.LoaiDichVus
                           join dv in db.DichVus on ldv.id_LoaiDichVu equals dv.id_loai_dich_vu
                           select new
                           {
                               maDV = dv.id_DichVu,
                               tenDichVu = dv.ten_dich_vu,
                               donGiaDV = dv.gia_dich_vu,
                               maLoai = ldv.id_LoaiDichVu,
                               tenLoaiDichVu = ldv.ten_loai_dich_vu
                           };

            foreach (var dv in dsDichVu)
            {
                DichVu_Ent dv_ent = new DichVu_Ent();

                dv_ent.Id_DichVu = dv.maDV;
                dv_ent.TenDichVu = dv.tenDichVu;
                dv_ent.DonGia = dv.donGiaDV;
                dv_ent.Id_LoaiDichVu = dv.maLoai;
                dv_ent.TenLoaiDichVu = dv.tenLoaiDichVu;

                dv_ents.Add(dv_ent);
            }

            return dv_ents;
        }

        public string GetTenLoaiDichVu_byIdLoaiDichVu(int idLoaiDV)
        {
            LoaiDichVu ldv = db.LoaiDichVus.Where(n => n.id_LoaiDichVu == idLoaiDV).SingleOrDefault();

            if (ldv != null)
            {
                return ldv.ten_loai_dich_vu.Trim();
            }

            return "";
        }

        public DichVu_Ent GetDichVu_byIdDichVu(int idDV)
        {
            DichVu dv = db.DichVus.Where(n => n.id_DichVu == idDV).SingleOrDefault();
            DichVu_Ent dv_ent = new DichVu_Ent();

            if (dv != null)
            {
                dv_ent.Id_DichVu = dv.id_DichVu;
                dv_ent.TenDichVu = dv.ten_dich_vu;
                dv_ent.DonGia = dv.gia_dich_vu;
                dv_ent.Id_LoaiDichVu = dv.id_loai_dich_vu;
                dv_ent.TenLoaiDichVu = GetTenLoaiDichVu_byIdLoaiDichVu(dv.id_loai_dich_vu);
            }

            return dv_ent;
        }

        public bool ThemDichVu(DichVu_Ent dv_ent)
        {
            DichVu dichVu = db.DichVus.Where(n => n.ten_dich_vu.Equals(dv_ent.TenDichVu)).SingleOrDefault();
            LoaiDichVu loaiDV = db.LoaiDichVus.Where(n => n.ten_loai_dich_vu.Equals(dv_ent.TenLoaiDichVu)).SingleOrDefault();

            if (dichVu != null)
            {
                return false;
            }

            if (loaiDV == null)
            {
                try
                {
                    LoaiDichVu ldv = new LoaiDichVu();

                    ldv.ten_loai_dich_vu = dv_ent.TenLoaiDichVu;

                    db.LoaiDichVus.InsertOnSubmit(ldv);
                    db.SubmitChanges();
                }
                catch
                {
                    return false;
                }
            }

            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.LoaiDichVus);

            try
            {
                DichVu dv = new DichVu();

                dv.ten_dich_vu = dv_ent.TenDichVu;
                dv.gia_dich_vu = dv_ent.DonGia;
                dv.id_loai_dich_vu = db.LoaiDichVus.Where(n => n.ten_loai_dich_vu.Equals(dv_ent.TenLoaiDichVu)).SingleOrDefault().id_LoaiDichVu;

                db.DichVus.InsertOnSubmit(dv);
                db.SubmitChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public int GetIDLoaiDV_byTenLoai(string TenLoaiDV)
        {
            LoaiDichVu ldv = db.LoaiDichVus.Where(n => n.ten_loai_dich_vu.Equals(TenLoaiDV)).SingleOrDefault();

            if(ldv == null)
            {
                return -1;
            }

            return ldv.id_LoaiDichVu;
        }

        public int GetIDDichVu_byTenDV(string TenDV)
        {
            DichVu ldv = db.DichVus.Where(n => n.ten_dich_vu.Equals(TenDV)).SingleOrDefault();

            if (ldv == null)
            {
                return -1;
            }

            return ldv.id_DichVu;
        }

        public List<DichVu_Ent> TimKiemDichVu_byIDLoaiDV(int IDLoaiDV)
        {
           List<DichVu_Ent> dv_ents = new List<DichVu_Ent>();

            var dsDichVu = from ldv in db.LoaiDichVus
                           join dv in db.DichVus on ldv.id_LoaiDichVu equals dv.id_loai_dich_vu
                           where ldv.id_LoaiDichVu == IDLoaiDV
                           select new
                           {
                               maDV = dv.id_DichVu,
                               tenDichVu = dv.ten_dich_vu,
                               donGiaDV = dv.gia_dich_vu,
                               maLoai = ldv.id_LoaiDichVu,
                               tenLoaiDichVu = ldv.ten_loai_dich_vu
                           };

            foreach (var dv in dsDichVu)
            {
                DichVu_Ent dv_ent = new DichVu_Ent();

                dv_ent.Id_DichVu = dv.maDV;
                dv_ent.TenDichVu = dv.tenDichVu;
                dv_ent.DonGia = dv.donGiaDV;
                dv_ent.Id_LoaiDichVu = dv.maLoai;
                dv_ent.TenLoaiDichVu = dv.tenLoaiDichVu;

                dv_ents.Add(dv_ent);
            }

            return dv_ents;
        }

        public List<DichVu_Ent> TimKiemDichVu_byIDDichVu(int IDDichVu)
        {
            List<DichVu_Ent> dv_ents = new List<DichVu_Ent>();

            var dsDichVu = from ldv in db.LoaiDichVus
                           join dv in db.DichVus on ldv.id_LoaiDichVu equals dv.id_loai_dich_vu
                           where dv.id_DichVu  == IDDichVu
                           select new
                           {
                               maDV = dv.id_DichVu,
                               tenDichVu = dv.ten_dich_vu,
                               donGiaDV = dv.gia_dich_vu,
                               maLoai = ldv.id_LoaiDichVu,
                               tenLoaiDichVu = ldv.ten_loai_dich_vu
                           };

            foreach (var dv in dsDichVu)
            {
                DichVu_Ent dv_ent = new DichVu_Ent();

                dv_ent.Id_DichVu = dv.maDV;
                dv_ent.TenDichVu = dv.tenDichVu;
                dv_ent.DonGia = dv.donGiaDV;
                dv_ent.Id_LoaiDichVu = dv.maLoai;
                dv_ent.TenLoaiDichVu = dv.tenLoaiDichVu;

                dv_ents.Add(dv_ent);
            }

            return dv_ents;
        }

        public bool XoaDichVu_byIDDichVu(int idDichVu)
        {
            DichVu dv = db.DichVus.Where(n => n.id_DichVu.Equals(idDichVu)).SingleOrDefault();

            if (dv == null)
            {
                return false;
            }

            try
            {
                db.DichVus.DeleteOnSubmit(dv);
                db.SubmitChanges();

            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
