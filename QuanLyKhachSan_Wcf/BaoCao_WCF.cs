using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Entities;
using DAL;
using System.Data;

namespace QuanLyKhachSan_Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BaoCao_WCF" in both code and config file together.
    public class BaoCao_WCF : IBaoCao_WCF
    {
        DB_KhachSanDataContext db;
        public BaoCao_WCF()
        {
            db = new DB_KhachSanDataContext();
        }

        //private IQueryable BaoCaoTong()
        //{
        //    IQueryable dsBaoCaoTong = from phieuchekin in db.PhieuCheck_Ins
        //                              join p in db.Phongs on phieuchekin.id_Phong equals p.id_Phong
        //                              join lp in db.LoaiPhongs on p.id_loai_phong equals lp.id_loai_phong
        //                              join kh in db.KhachHangs on phieuchekin.id_khach equals kh.id_khach
        //                              join dichVu in db.DichVus on phieuchekin.id_DichVu equals dichVu.id_DichVu
        //                              join nv in db.NhanViens on phieuchekin.id_NhanVien equals nv.id_NhanVien
        //                              where phieuchekin.ngay_check_out == DateTime.Now
        //                              select new
        //                              {
        //                                  kh.ho,
        //                                  kh.ten,
        //                                  kh.so_cmnd,
        //                                  p.id_Phong,
        //                                  lp.ten_loai_phong,
        //                                  p.so_Phong,
        //                                  p.tang,
        //                                  lp.gia_loai_phong,
        //                                  dichVu.ten_dich_vu,
        //                                  dichVu.gia_dich_vu,
        //                                  phieuchekin.ngay_check_in,
        //                                  phieuchekin.gio_check_in,
        //                                  phieuchekin.ngay_check_out,
        //                                  phieuchekin.gio_check_out,
        //                                  phieuchekin.giam_gia,
        //                                  hoNV = nv.ho,
        //                                  tenNV = nv.ten,
        //                              };

        //    return dsBaoCaoTong;
        //}

        public List<BaoCao_Ent> GetBaoCaos(DateTime dt)
        {
            var dsBaoCaoTong = (from phieuchekin in db.PhieuCheck_Ins
                                                   join p in db.Phongs on phieuchekin.id_Phong equals p.id_Phong
                                                   join lp in db.LoaiPhongs on p.id_loai_phong equals lp.id_loai_phong
                                                   join kh in db.KhachHangs on phieuchekin.id_khach equals kh.id_khach
                                                   join dichVu in db.DichVus on phieuchekin.id_DichVu equals dichVu.id_DichVu
                                                   join nv in db.NhanViens on phieuchekin.id_NhanVien equals nv.id_NhanVien
                                                   //where phieuchekin.ngay_check_out == DateTime.Now
                                                   select new
                                                   {
                                                       hoKhachHang = kh.ho,
                                                       tenKhachHang = kh.ten,
                                                       cmndKhachHang = kh.so_cmnd,
                                                       idPhong = p.id_Phong,
                                                       loaiPhong = lp.ten_loai_phong,
                                                       soPhong = p.so_Phong,
                                                       tang = p.tang,
                                                       giaPhong = lp.gia_loai_phong,
                                                       tenDichVu = dichVu.ten_dich_vu,
                                                       giaDichVu = dichVu.gia_dich_vu,
                                                       ngay_check_in = phieuchekin.ngay_check_in,
                                                       gio_check_in = phieuchekin.gio_check_in,
                                                       ngay_check_out = phieuchekin.ngay_check_out,
                                                       gio_check_out = phieuchekin.gio_check_out,
                                                       giam_gia = phieuchekin.giam_gia,
                                                       hoNhanVien = nv.ho,
                                                       tenNhanVien = nv.ten,
                                                   });

            List<BaoCao_Ent> dsBaoCao = new List<BaoCao_Ent>();

            foreach (var chiTietBaoCao in dsBaoCaoTong)
            {
                BaoCao_Ent pck_ent = new BaoCao_Ent();
                NhanVien_Ent nv_ent = new NhanVien_Ent();
                KhachHang_Ent kh_ent = new KhachHang_Ent();

                kh_ent.Ho = chiTietBaoCao.hoKhachHang;
                kh_ent.Ten = chiTietBaoCao.tenKhachHang;
                kh_ent.So_cmnd = chiTietBaoCao.cmndKhachHang;
                pck_ent.Kh_ent = kh_ent;
                pck_ent.Ngay_check_in = chiTietBaoCao.ngay_check_in;
                pck_ent.Gio_check_in = chiTietBaoCao.gio_check_in;
                pck_ent.Ngay_check_out = chiTietBaoCao.ngay_check_out;
                pck_ent.Gio_check_out = chiTietBaoCao.gio_check_out;
                pck_ent.Giam_gia = Convert.ToDouble(chiTietBaoCao.giam_gia);
                nv_ent.Ho = chiTietBaoCao.hoNhanVien;
                nv_ent.Ten = chiTietBaoCao.tenNhanVien;

                dsBaoCao.Add(pck_ent);
            }

            return dsBaoCao;
        }
    }
}
