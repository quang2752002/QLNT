using GUIs.Models.EF;
using GUIs.Models.VIEW;
using System.Collections.Generic;
using System.Linq;

namespace GUIs.Models.DAO
{
    public class NghiaTrangDAO
    {
        private QLNTContext context = new QLNTContext();
        public void InsertOrUpdate(NghiaTrang item)
        {
            if (item.NghiaTrangId == 0)
            {
                context.NghiaTrangs.Add(item);
            }
            context.SaveChanges();
        }
        public NghiaTrang getItem(int id)
        {
            var query = context.NghiaTrangs.Where(x => x.NghiaTrangId == id).FirstOrDefault();

            return query;
        }
        public NghiaTrangVIEW getItemView(int id)
        {
            var query = (from a in context.NghiaTrangs
                         where a.NghiaTrangId == id&&a.TrangThai=="active"
                         select new NghiaTrangVIEW
                         {
                             NghiaTrangId = a.NghiaTrangId,
                             DiaChiId = a.DiaChiId.Value,
                             Ten = a.Ten,
                             Sdt = a.Sdt,
                             Email = a.Email,
                             Soluong = a.Soluong.Value,
                             DiaChi = a.DiaChi,
                             DienTich = a.DienTich.Value,
                             MoTa = a.MoTa,
                             TrangThai = a.TrangThai
                         }).FirstOrDefault();

            return query;
        }
        public NghiaTrangVIEW getItemDiaChi(int id)
        {
            var query = (from a in context.NghiaTrangs
                         where a.DiaChiId == id && a.TrangThai == "active"
                         select new NghiaTrangVIEW
                         {
                             NghiaTrangId = a.NghiaTrangId,
                             DiaChiId = a.DiaChiId.Value,
                             Ten = a.Ten,
                             Sdt = a.Sdt,
                             Email = a.Email,
                             Soluong = a.Soluong.Value,
                             DiaChi = a.DiaChi,
                             DienTich = a.DienTich.Value,
                             MoTa = a.MoTa,
                             TrangThai = a.TrangThai
                         }).FirstOrDefault();

            return query;
        }
        public List<NghiaTrangVIEW> ShowList()
        {
            var query = (from a in context.NghiaTrangs
                         where  a.TrangThai == "active"
                         select new NghiaTrangVIEW
                         {
                             NghiaTrangId = a.NghiaTrangId,
                             DiaChiId = a.DiaChiId.Value,
                             Ten = a.Ten,
                             Sdt = a.Sdt,
                             Email = a.Email,
                             Soluong = a.Soluong.Value,
                             DiaChi = a.DiaChi,
                             DienTich = a.DienTich.Value,
                             MoTa = a.MoTa,
                             TrangThai = a.TrangThai
                         }).ToList();

            return query;
        }
    }
}
