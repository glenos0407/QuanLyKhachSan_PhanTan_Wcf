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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Phong_WCF" in both code and config file together.
    public class Phong_WCF : IPhong_WCF
    {
        DB_KhachSanDataContext db;

        public Phong_WCF()
        {
            db = new DB_KhachSanDataContext();
        }

        public bool CapNhatPhong(Phong_Ent phong_ent)
        {
            Phong p = db.Phongs.Where(n => n.id_Phong.Equals(phong_ent.Id_Phong)).SingleOrDefault();
            if (p == null)
            {
                return false;
            }
            try
            {
                p.id_loai_phong = Convert.ToInt32(phong_ent.Id_loai_phong);
                p.ghi_chu = phong_ent.Ghi_chu;
                p.so_luong_nguoi = phong_ent.So_luong_nguoi;
                p.so_Phong = phong_ent.So_Phong;
                p.tang = phong_ent.Tang;
                db.SubmitChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public List<Phong_Ent> GetPhongs()
        {
            List<Phong_Ent> phong_ents = new List<Phong_Ent>();
            foreach (Phong p in db.Phongs.Select(n => n))
            {
                Phong_Ent p_ent = new Phong_Ent();
                p_ent.Id_Phong = Convert.ToInt32(p.id_Phong);
                //  p_ent.Id_loai_phong = p.id_loai_phong;
                if (p.id_loai_phong == 1) p_ent.Id_loai_phong = "Phòng Standard";
                else if (p.id_loai_phong == 2) p_ent.Id_loai_phong = "Phòng Deluxe";
                else if (p.id_loai_phong == 3) p_ent.Id_loai_phong = "Phòng Express View";
                else if (p.id_loai_phong == 4) p_ent.Id_loai_phong = "Phòng VIP";
                p_ent.Ghi_chu = p.ghi_chu;
                p_ent.So_luong_nguoi = p.so_luong_nguoi;
                p_ent.So_Phong = p.so_Phong;
                p_ent.Tang = p.tang;
                if (p.tinh_trang == 0)
                {
                    p_ent.Tinh_trang = "Phòng trống";
                }
                else
                {
                    p_ent.Tinh_trang = "Phòng đã đặt";
                }


                phong_ents.Add(p_ent);
            }
            return phong_ents;
        }

        public Phong_Ent GetPhong_by_ID(string id)
        {
            Phong_Ent p_ent = new Phong_Ent();
            Phong p = db.Phongs.Where(n => n.id_Phong.Equals(id)).SingleOrDefault();
            if (p != null)
            {
                p_ent.Id_Phong = Convert.ToInt32(id);
                p_ent.So_Phong = p.so_Phong;
                p_ent.Id_loai_phong = (p.id_loai_phong).ToString();
                p_ent.Ghi_chu = p.ghi_chu;
                p_ent.Tang = p.tang;
                p_ent.So_luong_nguoi = p.so_luong_nguoi;
                //Get Tinh Trang
                if (p.tinh_trang == 0)
                {
                    p_ent.Tinh_trang = "Phòng đã đặt";
                }
                else
                {
                    p_ent.Tinh_trang = "Phòng Trống";
                }
            }
            return p_ent;
        }

        public List<Phong_Ent> SapXepTang(int Tang)
        {
            List<Phong_Ent> p_ents = new List<Phong_Ent>();
            IQueryable phongs = db.Phongs.Where(n => n.tang == Tang);
            if (phongs != null)
            {
                foreach (Phong p in phongs)
                {
                    Phong_Ent p_ent = new Phong_Ent();
                    p_ent.Id_Phong = Convert.ToInt32(p.id_Phong);
                    p_ent.So_Phong = p.so_Phong.Trim();
                    p_ent.Id_loai_phong = (p.id_loai_phong).ToString();
                    //  p_ent.Ghi_chu = p.ghi_chu.Trim();
                    p_ent.So_luong_nguoi = p.so_luong_nguoi;
                    if (p.id_loai_phong == 1) p_ent.Id_loai_phong = "Phòng Standard";
                    else if (p.id_loai_phong == 2) p_ent.Id_loai_phong = "Phòng Deluxe";
                    else if (p.id_loai_phong == 3) p_ent.Id_loai_phong = "Phòng Express View";
                    else if (p.id_loai_phong == 4) p_ent.Id_loai_phong = "Phòng VIP";
                    p_ent.Tang = p.tang;
                    //Get Gioi Tinh
                    if (p.tinh_trang == 0)
                    {
                        p_ent.Tinh_trang = "Phòng trống";
                    }
                    else
                    {
                        p_ent.Tinh_trang = "Phòng đã đặt";
                    }
                    p_ents.Add(p_ent);
                }
            }
            return p_ents;
        }

        public List<Phong_Ent> SapXepTinhTrang(string TinhTrang)
        {
            List<Phong_Ent> p_ents = new List<Phong_Ent>();
            int tam = 0;
            if (TinhTrang.Equals("Phòng đã đặt")) tam = 1;
            else tam = 0;
            IQueryable phongs = db.Phongs.Where(n => n.tinh_trang == tam);

            if (phongs != null)
            {
                foreach (Phong p in phongs)
                {
                    Phong_Ent p_ent = new Phong_Ent();

                    p_ent.Id_Phong = Convert.ToInt32(p.id_Phong);
                    p_ent.So_Phong = p.so_Phong.Trim();
                    p_ent.Id_loai_phong = p.id_loai_phong.ToString();
                    p_ent.So_luong_nguoi = p.so_luong_nguoi;
                    //p_ent.Ghi_chu = p.ghi_chu.Trim();
                    if (p.id_loai_phong == 1) p_ent.Id_loai_phong = "Phòng Standard";
                    else if (p.id_loai_phong == 2) p_ent.Id_loai_phong = "Phòng Deluxe";
                    else if (p.id_loai_phong == 3) p_ent.Id_loai_phong = "Phòng Express View";
                    else if (p.id_loai_phong == 4) p_ent.Id_loai_phong = "Phòng VIP";
                    p_ent.Tang = p.tang;
                    //Get tinh trang
                    if (p.tinh_trang == 0)
                    {
                        p_ent.Tinh_trang = "Phòng trống";
                    }
                    else
                    {
                        p_ent.Tinh_trang = "Phòng đã đặt";
                    }
                    p_ents.Add(p_ent);
                }
            }

            return p_ents;
        }

        public List<Phong_Ent> SapXepLoaiPhong(string idLoaiPhong)
        {
            List<Phong_Ent> p_ents = new List<Phong_Ent>();
            string temp = "";
            if (idLoaiPhong.Equals("Phòng Standard")) temp = "1";
            if (idLoaiPhong.Equals("Phòng Deluxe")) temp = "2";
            if (idLoaiPhong.Equals("Phòng Express View")) temp = "3";
            if (idLoaiPhong.Equals("Phòng VIP")) temp = "4";
            IQueryable phongs = db.Phongs.Where(n => n.id_loai_phong.Equals(temp));

            if (phongs != null)
            {
                foreach (Phong p in phongs)
                {
                    Phong_Ent p_ent = new Phong_Ent();

                    p_ent.Id_Phong = Convert.ToInt32(p.id_Phong);
                    p_ent.So_Phong = p.so_Phong.Trim();
                    p_ent.So_luong_nguoi = p.so_luong_nguoi;
                    //p_ent.Ghi_chu = p.ghi_chu.Trim();
                    if (p.id_loai_phong == 1) p_ent.Id_loai_phong = "Phòng Standard";
                    else if (p.id_loai_phong == 2) p_ent.Id_loai_phong = "Phòng Deluxe";
                    else if (p.id_loai_phong == 3) p_ent.Id_loai_phong = "Phòng Express View";
                    else if (p.id_loai_phong == 4) p_ent.Id_loai_phong = "Phòng VIP";
                    p_ent.Tang = p.tang;
                    //Get tinh trang
                    if (p.tinh_trang == 0)
                    {
                        p_ent.Tinh_trang = "Phòng trống";
                    }
                    else
                    {
                        p_ent.Tinh_trang = "Phòng đã đặt";
                    }
                    p_ents.Add(p_ent);
                }
            }
            return p_ents;
        }

        public bool ThemPhong(Phong_Ent phong_ent)
        {
            Phong ph = db.Phongs.Where(n => n.so_Phong.Equals(phong_ent.So_Phong)).SingleOrDefault();
            
            if(ph != null)
            {
                return false;
            }

            try
            {
                Phong p = new Phong();
                p.id_Phong = phong_ent.Id_Phong;
                p.id_loai_phong = Convert.ToInt32(phong_ent.Id_loai_phong);
                p.ghi_chu = phong_ent.Ghi_chu;
                p.so_luong_nguoi = phong_ent.So_luong_nguoi;
                p.so_Phong = phong_ent.So_Phong;
                p.tang = phong_ent.Tang;
                p.tinh_trang = Convert.ToInt32(phong_ent.Tinh_trang);
                //p.ghi_chu = null;
                db.Phongs.InsertOnSubmit(p);
                db.SubmitChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool XoaPhong(string id_Phong)
        {
            Phong p = db.Phongs.Where(n => n.id_Phong.Equals(id_Phong)).SingleOrDefault();
            if (p == null)
            {
                return false;
            }
            try
            {
                db.Phongs.DeleteOnSubmit(p);
                db.SubmitChanges();

            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public List<Phong_Ent> Tim_Kiem_By_SoPhong(string soPhong)
        {
            List<Phong_Ent> p_ents = new List<Phong_Ent>();

            foreach (Phong p in db.Phongs.Where(n => n.so_Phong.Equals(soPhong)))
            {
                Phong_Ent p_ent = new Phong_Ent();
                p_ent.Id_Phong = Convert.ToInt32(p.id_Phong);
                if (p.id_loai_phong == 1) p_ent.Id_loai_phong = "Phòng Standard";
                else if (p.id_loai_phong == 2) p_ent.Id_loai_phong = "Phòng Deluxe";
                else if (p.id_loai_phong == 3) p_ent.Id_loai_phong = "Phòng Express View";
                else if (p.id_loai_phong == 4) p_ent.Id_loai_phong = "Phòng VIP";
                p_ent.Ghi_chu = p.ghi_chu;
                p_ent.So_luong_nguoi = p.so_luong_nguoi;
                p_ent.So_Phong = p.so_Phong;
                p_ent.Tang = p.tang;
                if (p.tinh_trang == 0)
                {
                    p_ent.Tinh_trang = "Phòng trống";
                }
                else
                {
                    p_ent.Tinh_trang = "Phòng đã đặt";
                }
                p_ents.Add(p_ent);
            }
            return p_ents;
        }

        public List<Phong_Ent> PhongTrong_LoaiPhong(string idLoaiPhong)
        {
            List<Phong_Ent> p_ents = new List<Phong_Ent>();
            string temp = "";
            if (idLoaiPhong.Equals("Phòng Standard")) temp = "1";
            if (idLoaiPhong.Equals("Phòng Deluxe")) temp = "2";
            if (idLoaiPhong.Equals("Phòng Express View")) temp = "3";
            if (idLoaiPhong.Equals("Phòng VIP")) temp = "4";
            IQueryable phongs = db.Phongs.Where(n => n.id_loai_phong == Convert.ToInt32(temp) && n.tinh_trang == 0);
            if (phongs != null)
            {
                foreach (Phong p in phongs)
                {
                    Phong_Ent p_ent = new Phong_Ent();

                    p_ent.Id_Phong = Convert.ToInt32(p.id_Phong);
                    p_ent.So_Phong = p.so_Phong.Trim();
                    p_ent.So_luong_nguoi = p.so_luong_nguoi;
                    if (p.id_loai_phong == 1) p_ent.Id_loai_phong = "Phòng Standard";
                    else if (p.id_loai_phong == 2) p_ent.Id_loai_phong = "Phòng Deluxe";
                    else if (p.id_loai_phong == 3) p_ent.Id_loai_phong = "Phòng Express View";
                    else if (p.id_loai_phong == 4) p_ent.Id_loai_phong = "Phòng VIP";
                    p_ent.Tang = p.tang;
                    if (p.tinh_trang == 0)
                    {
                        p_ent.Tinh_trang = "Phòng trống";
                    }
                    else
                    {
                        p_ent.Tinh_trang = "Phòng đã đặt";
                    }
                    p_ents.Add(p_ent);
                }
            }
            return p_ents;
        }

        public decimal DonGia(string id_LoaiPhong)
        {
            LoaiPhong lp = db.LoaiPhongs.Where(n => n.id_loai_phong == Convert.ToInt32(id_LoaiPhong)).SingleOrDefault();
            return Convert.ToDecimal(lp.gia_loai_phong);
        }

        public int getIDPhong(string soPhong)
        {
            Phong p = db.Phongs.Where(n => n.so_Phong.Equals(soPhong)).SingleOrDefault();
            return p.id_Phong;
        }

        public string getsoPhong_byID(int id)
        {
            Phong p = db.Phongs.Where(n => n.id_Phong == id).SingleOrDefault();
            return p.so_Phong;
        }
    }
}
