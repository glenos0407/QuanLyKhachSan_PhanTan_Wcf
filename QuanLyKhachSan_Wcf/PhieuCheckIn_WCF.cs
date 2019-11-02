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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PhieuCheckIn_WCF" in both code and config file together.
    public class PhieuCheckIn_WCF : IPhieuCheckIn_WCF
    {
        DB_KhachSanDataContext db = new DB_KhachSanDataContext();

        public List<PhieuCheckIn_Ent> lsPhieuCheckIn_ToDate(DateTime date)
        {
            List<PhieuCheckIn_Ent> ls = new List<PhieuCheckIn_Ent>();
            foreach (PhieuCheck_In p in db.PhieuCheck_Ins.Where(n => n.ngay_check_in == date))
            {
                PhieuCheckIn_Ent p_ent = new PhieuCheckIn_Ent();
                p_ent.Id_Phong = Convert.ToInt32(p.id_Phong);
                p_ent.Id_phieu_checkin = p.id_phieu_checkin;
                p_ent.Id_khach = Convert.ToInt32(p.id_khach);
                p_ent.Ngay_check_in = (DateTime) p.ngay_check_in;
                p_ent.Ngay_check_out = (DateTime) p.ngay_check_out;
                p_ent.Gio_check_in = (TimeSpan) p.gio_check_in;
                p_ent.Gio_check_out = (TimeSpan) p.gio_check_out;
                ls.Add(p_ent);
            }
            return ls;
        }

        public bool ThemPhieuCheckIn(PhieuCheckIn_Ent phieucheckin_ent)
        {
            Phong phongID = db.Phongs.Where(n=>n.id_Phong == phieucheckin_ent.Id_Phong && n.tinh_trang == 1).SingleOrDefault();

            if(phongID != null)
            {
                return false;
            }

            try
            {
                PhieuCheck_In p = new PhieuCheck_In();
                p.id_phieu_checkin = phieucheckin_ent.Id_phieu_checkin;
                //p.id_DichVu = phieucheckin_ent.Id_DichVu;
                p.id_khach = phieucheckin_ent.Id_khach;
                p.id_Phong = phieucheckin_ent.Id_Phong;
                p.id_NhanVien = phieucheckin_ent.Id_NhanVien;
                p.giam_gia = phieucheckin_ent.Giam_gia;
                p.ngay_check_in = phieucheckin_ent.Ngay_check_in;
                p.ngay_check_out = phieucheckin_ent.Ngay_check_out;
                p.gio_check_in = phieucheckin_ent.Gio_check_in;
                p.gio_check_out = phieucheckin_ent.Gio_check_out;
                p.soLuongDichVu = phieucheckin_ent.SoLuongDichVu;
                p.soLuongKhach = phieucheckin_ent.SoLuongKhach;
                db.PhieuCheck_Ins.InsertOnSubmit(p);
                db.SubmitChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public List<PhieuCheckIn_Ent> GetPhieuCheckIns()
        {
            PhieuCheckIn_Ent p_ent;
            List<PhieuCheckIn_Ent> ls = new List<PhieuCheckIn_Ent>();
            var p = db.PhieuCheck_Ins;

            if (p == null)
            {
                return null;
            }
            else
            {
                foreach (var item in p)
                {
                    p_ent = new PhieuCheckIn_Ent();
                    p_ent.Id_Phong = Convert.ToInt32(item.id_Phong);
                    p_ent.Id_phieu_checkin = item.id_phieu_checkin;
                    p_ent.Id_khach = Convert.ToInt32(item.id_khach);
                    p_ent.Ngay_check_in = (DateTime)item.ngay_check_in;
                    p_ent.Ngay_check_out = (DateTime)item.ngay_check_out;
                    p_ent.Gio_check_in = (TimeSpan)item.gio_check_in;
                    p_ent.Gio_check_out = (TimeSpan)item.gio_check_out;
                    p_ent.Id_NhanVien = Convert.ToInt32(item.id_NhanVien);
                    p_ent.Id_DichVu = Convert.ToInt32(item.id_DichVu);
                    p_ent.SoLuongDichVu = Convert.ToInt32(item.soLuongDichVu);
                    p_ent.TrangThaiHoaDon = Convert.ToInt32(item.TrangThaiPhieuCK);
                    ls.Add(p_ent);
                }
            }
            return ls;
        }

        public List<PhieuCheckIn_Ent> GetPhieuCheckIns_NoCheckOut()
        {
            PhieuCheckIn_Ent p_ent;
            List<PhieuCheckIn_Ent> ls = new List<PhieuCheckIn_Ent>();
            var p = db.PhieuCheck_Ins.Where(n => n.TrangThaiPhieuCK == 0);

            if (p == null)
            {
                return null;
            }
            else
            {
                foreach (var item in p)
                {
                    p_ent = new PhieuCheckIn_Ent();
                    p_ent.Id_Phong = Convert.ToInt32(item.id_Phong);
                    p_ent.Id_phieu_checkin = item.id_phieu_checkin;
                    p_ent.Id_khach = Convert.ToInt32(item.id_khach);
                    p_ent.Ngay_check_in = (DateTime)item.ngay_check_in;
                    p_ent.Ngay_check_out = (DateTime)item.ngay_check_out;
                    p_ent.Gio_check_in = (TimeSpan)item.gio_check_in;
                    p_ent.Gio_check_out = (TimeSpan)item.gio_check_out;
                    p_ent.Id_NhanVien = Convert.ToInt32(item.id_NhanVien);
                    p_ent.Id_DichVu = Convert.ToInt32(item.id_DichVu);
                    p_ent.SoLuongDichVu = Convert.ToInt32(item.soLuongDichVu);
                    p_ent.TrangThaiHoaDon = Convert.ToInt32(item.TrangThaiPhieuCK);
                    ls.Add(p_ent);
                }
            }
            return ls;
        }

        public List<PhieuCheckIn_Ent> GetKh_ChuaThanhToan_ByID(int idKH)
        {
            PhieuCheckIn_Ent p_ent;
            List<PhieuCheckIn_Ent> ls = new List<PhieuCheckIn_Ent>();
            var p = db.PhieuCheck_Ins.Where(n => n.id_khach == idKH && n.TrangThaiPhieuCK == 0);

            if (p == null)
            {
                return null;
            }
            else
            {
                foreach (var item in p)
                {
                    p_ent = new PhieuCheckIn_Ent();
                    p_ent.Id_Phong = Convert.ToInt32(item.id_Phong);
                    p_ent.Id_phieu_checkin = item.id_phieu_checkin;
                    p_ent.Id_khach = Convert.ToInt32(item.id_khach);
                    p_ent.Ngay_check_in = (DateTime)item.ngay_check_in;
                    p_ent.Ngay_check_out = (DateTime)item.ngay_check_out;
                    p_ent.Gio_check_in = (TimeSpan) item.gio_check_in;
                    p_ent.Gio_check_out = (TimeSpan) item.gio_check_out;
                    p_ent.Id_NhanVien = Convert.ToInt32(item.id_NhanVien);
                    p_ent.Id_DichVu = Convert.ToInt32(item.id_DichVu);
                    p_ent.SoLuongDichVu = Convert.ToInt32(item.soLuongDichVu);
                    p_ent.TrangThaiHoaDon = Convert.ToInt32(item.TrangThaiPhieuCK);
                    ls.Add(p_ent);
                }
            }
            return ls;
        }

        public bool ThemPhieuCheckIn_DichVu(PhieuCheckIn_Ent phieucheckin_ent)
        {
            var ph = db.PhieuCheck_Ins.Where(n => n.id_khach == phieucheckin_ent.Id_khach && n.TrangThaiPhieuCK == phieucheckin_ent.TrangThaiHoaDon);
            if (ph == null)
            {
                return false;
            }
            foreach (var item in ph)
            {
                if (item.id_DichVu == null)
                {
                    db.PhieuCheck_Ins.DeleteOnSubmit(item);
                    db.SubmitChanges();
                }
            }
            try
            {
                PhieuCheck_In p = new PhieuCheck_In();
                p.id_phieu_checkin = phieucheckin_ent.Id_phieu_checkin;
                p.id_DichVu = phieucheckin_ent.Id_DichVu;
                p.id_khach = phieucheckin_ent.Id_khach;
                p.id_Phong = phieucheckin_ent.Id_Phong;
                p.id_NhanVien = phieucheckin_ent.Id_NhanVien;
                p.giam_gia = phieucheckin_ent.Giam_gia;
                p.ngay_check_in = phieucheckin_ent.Ngay_check_in;
                p.ngay_check_out = phieucheckin_ent.Ngay_check_out;
                p.gio_check_in = phieucheckin_ent.Gio_check_in;
                p.gio_check_out = phieucheckin_ent.Gio_check_out;
                p.soLuongDichVu = phieucheckin_ent.SoLuongDichVu;
                p.soLuongKhach = phieucheckin_ent.SoLuongKhach;
                p.TrangThaiPhieuCK = phieucheckin_ent.TrangThaiHoaDon;
                db.PhieuCheck_Ins.InsertOnSubmit(p);
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
