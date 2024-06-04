using GUIs.Helper;
using GUIs.Models.EF;
using GUIs.Models.VIEW;
using System.Collections.Generic;
using System.Linq;

namespace GUIs.Models.DAO
{
    public class LietSyDAO
    {
        private QLNTContext context = new QLNTContext();
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
        public LietSyVIEW getItemView(int id)
        {
            var query = (from a in context.LietSies
                         where a.LietSyId == id && a.TrangThai == "active"
                         select new LietSyVIEW
                         {
                             LietSyId = a.LietSyId,
                             DiaChiId = a.DiaChiId??0,
                             HoTen = a.HoTen,
                             Sdt = a.Sdt,
                             NgaySinh = a.NgaySinh??System.DateTime.Today,
                             NgayMat = a.NgayMat?? System.DateTime.Today,
                             DonVi = a.DonVi,
                             CapBac = a.CapBac,
                             ViTriHang = a.ViTriHang.Value,
                             ViTriCot = a.ViTriCot.Value,
                             MoTa = a.MoTa,
                             TinhTrang = a.TinhTrang,
                             TrangThai = a.TrangThai
                         }).FirstOrDefault();

            return query;
        }
        public List<LietSyVIEW> ShowList()
        {
            var query = (from a in context.LietSies
                         where a.TrangThai == "active"
                         select new LietSyVIEW
                         {
                             LietSyId = a.LietSyId,
                             DiaChiId = a.DiaChiId ?? 0,
                             HoTen = a.HoTen,
                             Sdt = a.Sdt,
                             NgaySinh = a.NgaySinh ?? System.DateTime.Today,
                             NgayMat = a.NgayMat ?? System.DateTime.Today,
                             DonVi = a.DonVi,
                             CapBac = a.CapBac,
                             ViTriHang = a.ViTriHang.Value,
                             ViTriCot = a.ViTriCot.Value,
                             MoTa = a.MoTa,
                             TinhTrang = a.TinhTrang,
                             TrangThai = a.TrangThai
                         }).ToList();

            return query;
        }
        public List<LietSyVIEW> Search(string name, int namSinh, int namMat, int thanhpho, int quan, int phuong,
                                int nghiaTrangThanhPho, int nghiaTrangQuan, int nghiatrangPhuong,int nghiaTrangId)
        {
            
            var query = (from a in context.LietSies
                        join b in context.DiaChis on a.DiaChiId equals b.DiaChiId
                        join c in context.NghiaTrangs on a.NghiaTrangId equals c.NghiaTrangId
                        where  a.TrangThai == "active"
                        select new LietSyVIEW
                        {
                            LietSyId = a.LietSyId,
                            DiaChiId = a.DiaChiId ?? 0,
                            HoTen = a.HoTen,
                            Sdt = a.Sdt,
                            NgaySinh = a.NgaySinh ?? System.DateTime.Today,
                            NgayMat = a.NgayMat ?? System.DateTime.Today,
                            DonVi = a.DonVi,
                            CapBac = a.CapBac,
                            ViTriHang = a.ViTriHang.Value,
                            ViTriCot = a.ViTriCot.Value,
                            MoTa = a.MoTa,
                            TinhTrang = a.TinhTrang,
                            TrangThai = a.TrangThai
                        }).ToList();
            if (name != null && name != "")
            {
                query = query.Where(q => q.HoTen.Contains(name)).ToList();
            }
            // Apply optional filtering by namSinh if provided
            if (namSinh > 0)
            {
                query = query.Where(q => q.NgaySinh.Year == namSinh).ToList();
            }

            // Apply optional filtering by namMat if provided
            if (namMat > 0)
            {
                query = query.Where(q => q.NgayMat.Year == namMat).ToList();
            }
            DiaChiDAO diaChiDAO = new DiaChiDAO();

            //Quê quán
            if (thanhpho > 0&&quan==0&&phuong==0)//có tỉnh k có huyện k có xã
            {
                var listhuyen = diaChiDAO.getDiaChiChild(thanhpho);
                var listxa = new List<DiaChiVIEW>();
                foreach (var item in listhuyen)
                {
                    listxa.AddRange(diaChiDAO.getDiaChiChild(item.DiaChiId));
                }
                List<int> listId = listxa.Select(x => x.DiaChiId).ToList();
                query = query.Where(q => listId.Contains(q.DiaChiId)).ToList();
            }
            
            if (thanhpho > 0 && quan > 0 && phuong == 0)//có tỉnh có huyện k có xã
            {
                var listxa = diaChiDAO.getDiaChiChild(quan);
                List<int> listId = listxa.Select(x => x.DiaChiId).ToList();
                query = query.Where(q => listId.Contains(q.DiaChiId)).ToList();
            }
            if (thanhpho > 0 && quan > 0 && phuong> 0)//có tỉnh có huyện có xã
            {
                
                query = query.Where(q => q.DiaChiId==phuong).ToList();
            }

            //Nghĩa trang
            if (nghiaTrangThanhPho > 0 && nghiaTrangQuan == 0 && nghiatrangPhuong == 0 && nghiaTrangId == 0)//có tỉnh k có huyện k có xã k có nghĩa trang
            {
                var listhuyen = diaChiDAO.getDiaChiChild(nghiaTrangThanhPho);
                var listxa = new List<DiaChiVIEW>();
                foreach (var item in listhuyen)
                {
                    listxa.AddRange(diaChiDAO.getDiaChiChild(item.DiaChiId));
                }
                List<int> listId = listxa.Select(x => x.DiaChiId).ToList();
                var rs=context.NghiaTrangs.Where(q=>listId.Contains(q.DiaChiId.Value)).ToList();
                List<int> listIdNghiaTrang = rs.Select(x => x.DiaChiId.Value).ToList();
                query = query.Where(q => listIdNghiaTrang.Contains(q.DiaChiId)).ToList();
            }
            if (nghiaTrangThanhPho > 0 && nghiaTrangQuan > 0 && nghiatrangPhuong == 0 && nghiaTrangId == 0)//có tỉnh có huyện k có xã k có nghĩa trang
            {
               
                var listxa = diaChiDAO.getDiaChiChild(nghiaTrangQuan);
                List<int> listId = listxa.Select(x => x.DiaChiId).ToList();
                var rs = context.NghiaTrangs.Where(q => listId.Contains(q.DiaChiId.Value)).ToList();
                List<int> listIdNghiaTrang = rs.Select(x => x.DiaChiId.Value).ToList();
                query = query.Where(q => listIdNghiaTrang.Contains(q.DiaChiId)).ToList();
            }
            if (nghiaTrangThanhPho > 0 && nghiaTrangQuan > 0 && nghiatrangPhuong > 0 &&nghiaTrangId==0)//có tỉnh có huyện có xã k có nghĩa trang
            {   
                var rs = context.NghiaTrangs.Where(q => q.DiaChiId==nghiatrangPhuong).ToList();
                List<int> listIdNghiaTrang = rs.Select(x => x.DiaChiId.Value).ToList();
                query = query.Where(q => listIdNghiaTrang.Contains(q.DiaChiId)).ToList();
            }
            if (nghiaTrangThanhPho > 0 && nghiaTrangQuan > 0 && nghiatrangPhuong > 0 && nghiaTrangId > 0)//có tỉnh có huyện có xã k có nghĩa trang
            {                
                query = query.Where(q => q.NghiaTrangId==nghiaTrangId).ToList();
            }


            return query.ToList();
        }
      
        

    }
}
