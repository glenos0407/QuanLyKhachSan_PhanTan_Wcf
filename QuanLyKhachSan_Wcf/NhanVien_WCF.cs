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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "NhanVien_WCF" in both code and config file together.
    public class NhanVien_WCF : INhanVien_WCF
    {
        DB_KhachSanDataContext db;

        public NhanVien_WCF()
        {
            db = new DB_KhachSanDataContext();
        }

        //Lấy Thông Tin Nhân Viên theo ID
        public NhanVien_Ent GetNhanVien_by_ID(int id)
        {
            NhanVien_Ent nv_ent = new NhanVien_Ent();
            NhanVien nv = db.NhanViens.Where(n => n.id_NhanVien == id).SingleOrDefault();

            if (nv != null)
            {
                nv_ent.Id_nhanvien = id;
                nv_ent.Ho = nv.ho.Trim();
                nv_ent.Ten = nv.ten.Trim();

                //Get Gioi Tinh
                if (nv.gioi_tinh == 0)
                {
                    nv_ent.GioiTinh = "Nữ";
                }
                else
                {
                    nv_ent.GioiTinh = "Nam";
                }

                nv_ent.NgaySinh = (DateTime)nv.ngay_sinh;

                //Get Chuc Vu
                if (nv.chuc_vu == 1)
                {
                    nv_ent.ChucVu = "Quản Lý";
                }
                else
                {
                    nv_ent.ChucVu = "Nhân Viên";
                }

                //Get Ca Lam Viec
                if (nv.ca_lam_viec == 1)
                {
                    nv_ent.CaLamViec = "Sáng";
                }
                if (nv.ca_lam_viec == 2)
                {
                    nv_ent.CaLamViec = "Chiều";
                }
                if (nv.ca_lam_viec == 3)
                {
                    nv_ent.CaLamViec = "Tối";
                }

                nv_ent.Email = nv.email.Trim();
            }

            return nv_ent;
        }

        //1: là admin
        //2: là nhân viên
        public int GetChucVu(int id)
        {
            return db.NhanViens.Where(n => n.id_NhanVien == id).SingleOrDefault().chuc_vu;
        }

        public string GetHoTen_NhanVien(int id)
        {
            NhanVien nv = db.NhanViens.Where(n => n.id_NhanVien == id).SingleOrDefault();
            return nv.ho.Trim() + " " + nv.ten.Trim();
        }

        public int GetID_by_Email(string email)
        {
            return db.NhanViens.Where(n => n.email.Equals(email)).SingleOrDefault().id_NhanVien;
        }

        public string GetEmail_by_ID(int id)
        {
            return db.NhanViens.Where(n => n.id_NhanVien.Equals(id)).SingleOrDefault().email.Trim();
        }

        public List<NhanVien_Ent> GetNhanViens()
        {
            List<NhanVien_Ent> nv_ents = new List<NhanVien_Ent>();

            foreach (NhanVien nv in db.NhanViens.Select(n => n))
            {
                NhanVien_Ent nv_ent = new NhanVien_Ent();

                nv_ent.Id_nhanvien = nv.id_NhanVien;
                nv_ent.Ho = nv.ho.Trim();
                nv_ent.Ten = nv.ten.Trim();

                //Get Gioi Tinh
                if (nv.gioi_tinh == 0)
                {
                    nv_ent.GioiTinh = "Nữ";
                }
                else
                {
                    nv_ent.GioiTinh = "Nam";
                }

                nv_ent.NgaySinh = (DateTime)nv.ngay_sinh;

                //Get Chuc Vu
                if (nv.chuc_vu == 1)
                {
                    nv_ent.ChucVu = "Quản Lý";
                }
                else
                {
                    nv_ent.ChucVu = "Nhân Viên";
                }

                //Get Ca Lam Viec
                if (nv.ca_lam_viec == 1)
                {
                    nv_ent.CaLamViec = "Sáng";
                }
                if (nv.ca_lam_viec == 2)
                {
                    nv_ent.CaLamViec = "Chiều";
                }
                if (nv.ca_lam_viec == 3)
                {
                    nv_ent.CaLamViec = "Tối";
                }

                nv_ent.Email = nv.email.Trim();

                nv_ents.Add(nv_ent);
            }

            return nv_ents;
        }

        public List<NhanVien_Ent> SapXepChucVu(int chucvu)
        {
            List<NhanVien_Ent> nv_ents = new List<NhanVien_Ent>();
            IQueryable nhanViens = db.NhanViens.Where(n => n.chuc_vu == chucvu);

            if (nhanViens != null)
            {
                foreach (NhanVien nv in nhanViens)
                {
                    NhanVien_Ent nv_ent = new NhanVien_Ent();

                    nv_ent.Id_nhanvien = nv.id_NhanVien;
                    nv_ent.Ho = nv.ho.Trim();
                    nv_ent.Ten = nv.ten.Trim();

                    //Get Gioi Tinh
                    if (nv.gioi_tinh == 0)
                    {
                        nv_ent.GioiTinh = "Nữ";
                    }
                    else
                    {
                        nv_ent.GioiTinh = "Nam";
                    }

                    nv_ent.NgaySinh = (DateTime)nv.ngay_sinh;

                    //Get Chuc Vu
                    if (nv.chuc_vu == 1)
                    {
                        nv_ent.ChucVu = "Quản Lý";
                    }
                    else
                    {
                        nv_ent.ChucVu = "Nhân Viên";
                    }

                    //Get Ca Lam Viec
                    if (nv.ca_lam_viec == 1)
                    {
                        nv_ent.CaLamViec = "Sáng";
                    }
                    if (nv.ca_lam_viec == 2)
                    {
                        nv_ent.CaLamViec = "Chiều";
                    }
                    if (nv.ca_lam_viec == 3)
                    {
                        nv_ent.CaLamViec = "Tối";
                    }

                    nv_ent.Email = nv.email.Trim();

                    nv_ents.Add(nv_ent);
                }
            }

            return nv_ents;
        }

        public List<NhanVien_Ent> SapXepCaLamViec(int caLamViec)
        {
            List<NhanVien_Ent> nv_ents = new List<NhanVien_Ent>();
            IQueryable nhanViens = db.NhanViens.Where(n => n.ca_lam_viec == caLamViec);

            if (nhanViens != null)
            {
                foreach (NhanVien nv in nhanViens)
                {
                    NhanVien_Ent nv_ent = new NhanVien_Ent();

                    nv_ent.Id_nhanvien = nv.id_NhanVien;
                    nv_ent.Ho = nv.ho.Trim();
                    nv_ent.Ten = nv.ten.Trim();

                    //Get Gioi Tinh
                    if (nv.gioi_tinh == 0)
                    {
                        nv_ent.GioiTinh = "Nữ";
                    }
                    else
                    {
                        nv_ent.GioiTinh = "Nam";
                    }

                    nv_ent.NgaySinh = (DateTime)nv.ngay_sinh;

                    //Get Chuc Vu
                    if (nv.chuc_vu == 1)
                    {
                        nv_ent.ChucVu = "Quản Lý";
                    }
                    else
                    {
                        nv_ent.ChucVu = "Nhân Viên";
                    }

                    //Get Ca Lam Viec
                    if (nv.ca_lam_viec == 1)
                    {
                        nv_ent.CaLamViec = "Sáng";
                    }
                    if (nv.ca_lam_viec == 2)
                    {
                        nv_ent.CaLamViec = "Chiều";
                    }
                    if (nv.ca_lam_viec == 3)
                    {
                        nv_ent.CaLamViec = "Tối";
                    }

                    nv_ent.Email = nv.email.Trim();

                    nv_ents.Add(nv_ent);
                }
            }

            return nv_ents;
        }

        public bool DangNhapHeThong(string email, string pass)
        {
            if (db.NhanViens.Where(n => n.email.Equals(email) && n.mat_khau.Equals(pass)).SingleOrDefault() != null)
            {
                return true;
            }

            return false;
        }

        public bool ThemNhanVien(NhanVien_Ent nv_ent, string matKhau)
        {
            NhanVien nv;

            NhanVien NVTestEmail = db.NhanViens.Where(n => n.email.Equals(nv_ent.Email)).SingleOrDefault();

            if (NVTestEmail != null)
            {
                return false;
            }

            try
            {
                nv = new NhanVien();

                nv.ho = nv_ent.Ho;
                nv.ten = nv_ent.Ten;

                if (nv_ent.GioiTinh == "nam")
                {
                    nv.gioi_tinh = 1;
                }
                if (nv_ent.GioiTinh == "nu")
                {
                    nv.gioi_tinh = 0;
                }

                nv.ngay_sinh = nv_ent.NgaySinh;

                if (nv_ent.ChucVu == "nhanvien")
                {
                    nv.chuc_vu = 2;
                }
                if (nv_ent.ChucVu == "quanly")
                {
                    nv.chuc_vu = 1;
                }

                if (nv_ent.CaLamViec == "sang")
                {
                    nv.ca_lam_viec = 1;
                }
                if (nv_ent.CaLamViec == "chieu")
                {
                    nv.ca_lam_viec = 2;
                }
                if (nv_ent.CaLamViec == "toi")
                {
                    nv.ca_lam_viec = 3;
                }

                nv.email = nv_ent.Email;
                nv.mat_khau = matKhau;

                db.NhanViens.InsertOnSubmit(nv);
                db.SubmitChanges();

            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool CapNhatNhanVien(NhanVien_Ent nv_ent)
        {
            NhanVien nv = db.NhanViens.Where(n => n.email.Equals(nv_ent.Email)).SingleOrDefault();

            if (nv == null)
            {
                return false;
            }

            try
            {
                nv.ho = nv_ent.Ho;
                nv.ten = nv_ent.Ten;

                if (nv_ent.GioiTinh == "nam")
                {
                    nv.gioi_tinh = 1;
                }
                if (nv_ent.GioiTinh == "nu")
                {
                    nv.gioi_tinh = 0;
                }

                nv.ngay_sinh = nv_ent.NgaySinh;

                if (nv_ent.ChucVu == "nhanvien")
                {
                    nv.chuc_vu = 2;
                }
                if (nv_ent.ChucVu == "quanly")
                {
                    nv.chuc_vu = 1;
                }

                if (nv_ent.CaLamViec == "sang")
                {
                    nv.ca_lam_viec = 1;
                }
                if (nv_ent.CaLamViec == "chieu")
                {
                    nv.ca_lam_viec = 2;
                }
                if (nv_ent.CaLamViec == "toi")
                {
                    nv.ca_lam_viec = 3;
                }

                nv.email = nv_ent.Email;

                db.SubmitChanges();

            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool CapNhatMatKhau(string email, string matKhaucu, string matkhaumoi)
        {
            NhanVien nv = db.NhanViens.Where(n => n.email.Equals(email)).SingleOrDefault();
            NhanVien nv_testpass = db.NhanViens.Where(n => n.email.Equals(email) && n.mat_khau.Equals(matKhaucu)).SingleOrDefault();

            if (nv == null)
            {
                return false;
            }

            if (nv_testpass == null)
            {
                return false;
            }

            try
            {
                nv.mat_khau = matkhaumoi;
                db.SubmitChanges();

            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool XoaNhanVien_by_Email(string email)
        {
            NhanVien nv = db.NhanViens.Where(n => n.email.Equals(email)).SingleOrDefault();

            if (nv == null)
            {
                return false;
            }

            try
            {
                db.NhanViens.DeleteOnSubmit(nv);
                db.SubmitChanges();

            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public List<NhanVien_Ent> TimKiem_NhanVien_by_HoTen(string ho, string ten)
        {
            List<NhanVien_Ent> nv_ents = new List<NhanVien_Ent>();

            foreach (NhanVien nv in db.NhanViens.Where(n => n.ho.Equals(ho) || n.ten.Equals(ten)))
            {
                NhanVien_Ent nv_ent = new NhanVien_Ent();

                nv_ent.Id_nhanvien = nv.id_NhanVien;
                nv_ent.Ho = nv.ho.Trim();
                nv_ent.Ten = nv.ten.Trim();

                //Get Gioi Tinh
                if (nv.gioi_tinh == 0)
                {
                    nv_ent.GioiTinh = "Nữ";
                }
                else
                {
                    nv_ent.GioiTinh = "Nam";
                }

                nv_ent.NgaySinh = (DateTime)nv.ngay_sinh;

                //Get Chuc Vu
                if (nv.chuc_vu == 1)
                {
                    nv_ent.ChucVu = "Quản Lý";
                }
                else
                {
                    nv_ent.ChucVu = "Nhân Viên";
                }

                //Get Ca Lam Viec
                if (nv.ca_lam_viec == 1)
                {
                    nv_ent.CaLamViec = "Sáng";
                }
                if (nv.ca_lam_viec == 2)
                {
                    nv_ent.CaLamViec = "Chiều";
                }
                if (nv.ca_lam_viec == 3)
                {
                    nv_ent.CaLamViec = "Tối";
                }

                nv_ent.Email = nv.email.Trim();

                nv_ents.Add(nv_ent);
            }

            return nv_ents;
        }
    }
}
