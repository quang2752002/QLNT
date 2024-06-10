using GUIs.Models.VIEW;
using QLNT.Models.EF;
using System.Drawing;
using System.Xml.Linq;

namespace QLNT.Models.DAO
{
    public class lietSyDAO
    {
        private QLNTContext context=new QLNTContext();
        public void InsertOrUpdate(LietSy item)
        {
            if (item.LietSyId == 0)
            {
                context.LietSies.Add(item);
            }
            context.SaveChanges();
        }
        public LietSy getItem(int id)
        {
            var query = context.LietSies.Where(x => x.LietSyId == id).FirstOrDefault();

            return query;
        }
        public lietSyVIEW getItemView(int id)
        {
            var query = (from a in context.LietSies
                         where a.LietSyId == id
                         select new lietSyVIEW
                         {
                            LietSyId = a.LietSyId,
                            NghiaTrangId=a.NghiaTrangId.Value,
                            DiaChiId=a.DiaChiId.Value,
                            HoTen=a.HoTen,
                            Sdt=a.Sdt,
                            NgaySinh=a.NgaySinh??DateTime.Now,
                            NgayMat=a.NgayMat??DateTime.Now,
                            DonVi=a.DonVi,
                            CapBac=a.CapBac,
                            ViTriHang=a.ViTriHang.Value,
                            ViTriCot=a.ViTriCot.Value,
                            MoTa=a.MoTa,
                            TinhTrang=a.TinhTrang,
                             TrangThai = a.TrangThai
                         }).FirstOrDefault();
            return query;
        }

       
        public List<lietSyVIEW> ShowList(out int total, string name = "", int index = 1, int size = 10, string trangthai = "active")
        {

            if (name == null) name = "";
            var query = (from a in context.LietSies
                         join b in context.NghiaTrangs on a.NghiaTrangId equals b.NghiaTrangId
                         where a.TrangThai == trangthai
                         select new lietSyVIEW
                         {
                             LietSyId = a.LietSyId,
                             NghiaTrangId = a.NghiaTrangId.Value,
                             DiaChiId = a.DiaChiId.Value,
                             HoTen = a.HoTen,
                             Sdt = a.Sdt,
                             tenNghiaTrang=b.Ten,
                             NgaySinh = a.NgaySinh ?? DateTime.Now,
                             NgayMat = a.NgayMat ?? DateTime.Now,
                             DonVi = a.DonVi,
                             CapBac = a.CapBac,
                             ViTriHang = a.ViTriHang.Value,
                             ViTriCot = a.ViTriCot.Value,
                             MoTa = a.MoTa,
                             TinhTrang = a.TinhTrang,
                             TrangThai = a.TrangThai
                         });

            if (!string.IsNullOrEmpty(name) && name != "")
            {
                query = query.Where(x => x.HoTen.Contains(name));
            }
            total = query.Count();
            if (size > 0 && index > 0)
            {
                query = query.Skip((index - 1) * size).Take(size);
            }

            return query.ToList();
        }
        public List<lietSyVIEW> getList( out int total, int idNghiaTrang, string name = "", int index = 1, int size = 10, string trangthai = "active")
        {

            var query = (from a in context.LietSies
                         where a.NghiaTrangId == idNghiaTrang && a.TrangThai == trangthai
                         select new lietSyVIEW
                         {
                             LietSyId = a.LietSyId,
                             NghiaTrangId = a.NghiaTrangId.Value,
                             DiaChiId = a.DiaChiId.Value,
                             HoTen = a.HoTen,
                             Sdt = a.Sdt,
                             NgaySinh = a.NgaySinh ?? DateTime.Now,
                             NgayMat = a.NgayMat ?? DateTime.Now,
                             DonVi = a.DonVi,
                             CapBac = a.CapBac,
                             ViTriHang = a.ViTriHang.Value,
                             ViTriCot = a.ViTriCot.Value,
                             MoTa = a.MoTa,
                             TinhTrang = a.TinhTrang,
                             TrangThai = a.TrangThai
                         });
            if (!string.IsNullOrEmpty(name) && name != "")
            {
                query = query.Where(x => x.HoTen.Contains(name));
            }
            total = query.Count();
            if (size > 0 && index > 0)
            {
                query = query.Skip((index - 1) * size).Take(size);
            }

            return query.ToList();
           
        }
       
    }
}
