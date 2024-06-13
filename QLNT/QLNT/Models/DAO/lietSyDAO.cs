using GUIs.Models.VIEW;
using QLNT.Models.EF;
using System.Drawing;
using System.Security.Policy;
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
                            DiaChiId=a.DiaChiId??0,
                            HoTen=a.HoTen??"",
                            Sdt=a.Sdt??"",
                            NgaySinh=a.NgaySinh??DateTime.Now,
                            NgayMat=a.NgayMat??DateTime.Now,
                            DonVi=a.DonVi ?? "",
                            CapBac=a.CapBac ?? "",
                            ViTriHang=a.ViTriHang.Value,
                            ViTriCot=a.ViTriCot.Value,
                            MoTa=a.MoTa ?? "",
                            TinhTrang=a.TinhTrang ?? "",
                             TrangThai = a.TrangThai
                         }).FirstOrDefault();
            return query;
        }


        public List<lietSyVIEW> ShowList(out int total, string name = "", int index = 1, int size = 10, string trangthai = "active")
        {
            if (name == null)
                name = "";

            var query = (from a in context.LietSies
                         join b in context.NghiaTrangs on a.NghiaTrangId equals b.NghiaTrangId
                         join c in context.DiaChis on a.DiaChiId equals c.DiaChiId into cGroup
                         from c in cGroup.DefaultIfEmpty() // Perform left join
                         join d in context.DiaChis on c.ParentId equals d.DiaChiId into dGroup
                         from d in dGroup.DefaultIfEmpty() // Perform left join
                         join e in context.DiaChis on d.ParentId equals e.DiaChiId into eGroup
                         from e in eGroup.DefaultIfEmpty() // Perform left join
                         where a.TrangThai == trangthai
                         select new lietSyVIEW
                         {
                             LietSyId = a.LietSyId,
                             NghiaTrangId = a.NghiaTrangId.Value,
                             DiaChiId = a.DiaChiId ?? 0, // Set default value for DiaChiId
                             HoTen = a.HoTen ?? "",
                             Sdt = a.Sdt ?? "",
                             tenNghiaTrang = b.Ten,
                             NgaySinh = a.NgaySinh ?? DateTime.Now,
                             NgayMat = a.NgayMat ?? DateTime.Now,
                             DonVi = a.DonVi ?? "",
                             CapBac = a.CapBac ?? "",
                             ViTriHang = a.ViTriHang.Value,
                             ViTriCot = a.ViTriCot.Value,
                             MoTa = a.MoTa ?? "",
                             TinhTrang = a.TinhTrang ?? "",
                             diachi = (c != null && d != null && e != null) ? $"{c.Ten},{d.Ten},{e.Ten}" : "Chưa rõ", // Construct diachi
                             TrangThai = a.TrangThai
                         });

            // Apply name filter if provided
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(x => x.HoTen.Contains(name));
            }

            total = query.Count(); // Count total results

            

            // Apply pagination
            if (size > 0 && index > 0)
            {
                query = query.Skip((index - 1) * size).Take(size);
            }

            return query.ToList(); // Execute query and return results
        }


        public List<lietSyVIEW> getList(out int total, int idNghiaTrang, string name = "", int index = 1, int size = 10, string trangthai = "active")
		{
			var query = (from a in context.LietSies
						 join c in context.DiaChis on a.DiaChiId equals c.DiaChiId into cGroup
						 from c in cGroup.DefaultIfEmpty() // Perform left join
						 join d in context.DiaChis on c.ParentId equals d.DiaChiId into dGroup
						 from d in dGroup.DefaultIfEmpty() // Perform left join
						 join e in context.DiaChis on d.ParentId equals e.DiaChiId into eGroup
						 from e in eGroup.DefaultIfEmpty() // Perform left join
						 where a.NghiaTrangId == idNghiaTrang && a.TrangThai == trangthai
						 select new lietSyVIEW
						 {
							 LietSyId = a.LietSyId,
							 NghiaTrangId = a.NghiaTrangId.Value,
							 DiaChiId = a.DiaChiId??0,
							 HoTen = a.HoTen ?? "",
							 Sdt = a.Sdt??"",
							 NgaySinh = a.NgaySinh??DateTime.Now,
							 NgayMat = a.NgayMat??DateTime.Now,
							 ngaySinhS = a.NgaySinh.Value.ToString("dd/MM/yyyy")??"Chưa rõ",
							 ngayMatS =  a.NgayMat.Value.ToString("dd/MM/yyyy")??"Chưa rõ" ,
							 DonVi = a.DonVi ?? "",
							 CapBac = a.CapBac ?? "",
							 ViTriHang = a.ViTriHang.Value,
							 ViTriCot = a.ViTriCot.Value,
							 MoTa = a.MoTa ?? "",
							 diachi = (c != null && d != null && e != null) ? $"{c.Ten},{d.Ten},{e.Ten}" : "Chưa rõ", // Construct diachi						
							 TinhTrang = a.TinhTrang??"",
							 TrangThai = a.TrangThai
						 });

			if (!string.IsNullOrEmpty(name))
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
		public List<lietSyVIEW> Search(out int total,string name, int namSinh, int namMat, int thanhpho, int quan, int phuong,
							   int nghiaTrangThanhPho, int nghiaTrangQuan, int nghiatrangPhuong, int nghiaTrangId,int index)
		{
			
			var query = (from a in context.LietSies
						 
						 join c in context.DiaChis on a.DiaChiId equals c.DiaChiId into cGroup
						 from c in cGroup.DefaultIfEmpty() // Perform left join
						 join d in context.DiaChis on c.ParentId equals d.DiaChiId into dGroup
						 from d in dGroup.DefaultIfEmpty() // Perform left join
						 join e in context.DiaChis on d.ParentId equals e.DiaChiId into eGroup
						 from e in eGroup.DefaultIfEmpty() // Perform left join
						 join f in context.NghiaTrangs on a.NghiaTrangId equals f.NghiaTrangId
						 join g in context.DiaChis on f.DiaChiId equals g.DiaChiId
						 join h in context.DiaChis on g.ParentId equals h.DiaChiId
						 join i in context.DiaChis on h.ParentId equals i.DiaChiId
						 where a.TrangThai == "active"
						 select new lietSyVIEW
						 {
							 LietSyId = a.LietSyId,
							 DiaChiId = a.DiaChiId ?? 0,
							 HoTen = a.HoTen,
							 Sdt = a.Sdt,
							 tenNghiaTrang=f.Ten,
							 ngaySinhS = a.NgaySinh.Value.ToString("dd/MM/yyyy") ?? "Chưa rõ",
							 ngayMatS = a.NgayMat.Value.ToString("dd/MM/yyyy") ?? "Chưa rõ",
							 NgaySinh = a.NgaySinh ?? System.DateTime.Today,
							 NgayMat = a.NgayMat ?? System.DateTime.Today,
							 DonVi = a.DonVi,
							 CapBac = a.CapBac,
							 ViTriHang = a.ViTriHang.Value,
							 ViTriCot = a.ViTriCot.Value,
							 diachi = (c != null && d != null && e != null) ? $"{c.Ten},{d.Ten},{e.Ten}" : "Chưa rõ", // Construct diachi	
							 MoTa = a.MoTa,
							 TinhTrang = a.TinhTrang,
							 tinh=i.Ten,
							 huyen=h.Ten,
							 xa=g.Ten,
							 TrangThai = a.TrangThai
						 });
			if (!string.IsNullOrEmpty(name) && name != "")
			{
				query = query.Where(x => x.HoTen.Contains(name));
			}
			// Apply optional filtering by namSinh if provided
			if (namSinh > 0)
			{
				query = query.Where(q => q.NgaySinh.Year == namSinh);
			}

			// Apply optional filtering by namMat if provided
			if (namMat > 0)
			{
				query = query.Where(q => q.NgayMat.Year == namMat);
			}
			diaChiDAO diaChiDAO = new diaChiDAO();

			//Quê quán
			if (thanhpho > 0 && quan == 0 && phuong == 0)//có tỉnh k có huyện k có xã
			{
				var listhuyen = diaChiDAO.getDiaChiChild(thanhpho);
				var listxa = new List<diaChiVIEW>();
				foreach (var item in listhuyen)
				{
					listxa.AddRange(diaChiDAO.getDiaChiChild(item.DiaChiId));
				}
				List<int> listId = listxa.Select(x => x.DiaChiId).ToList();
				query = query.Where(q => listId.Contains(q.DiaChiId));
			}

			if (thanhpho > 0 && quan > 0 && phuong == 0)//có tỉnh có huyện k có xã
			{
				var listxa = diaChiDAO.getDiaChiChild(quan);
				List<int> listId = listxa.Select(x => x.DiaChiId).ToList();
				query = query.Where(q => listId.Contains(q.DiaChiId));
			}
			if (thanhpho > 0 && quan > 0 && phuong > 0)//có tỉnh có huyện có xã
			{

				query = query.Where(q => q.DiaChiId == phuong);
			}

			//Nghĩa trang
			if (nghiaTrangThanhPho > 0 && nghiaTrangQuan == 0 && nghiatrangPhuong == 0 && nghiaTrangId == 0)//có tỉnh k có huyện k có xã k có nghĩa trang
			{
				var listhuyen = diaChiDAO.getDiaChiChild(nghiaTrangThanhPho);
				var listxa = new List<diaChiVIEW>();
				foreach (var item in listhuyen)
				{
					listxa.AddRange(diaChiDAO.getDiaChiChild(item.DiaChiId));
				}
				List<int> listId = listxa.Select(x => x.DiaChiId).ToList();
				var rs = context.NghiaTrangs.Where(q => listId.Contains(q.DiaChiId.Value));
				List<int> listIdNghiaTrang = rs.Select(x => x.DiaChiId.Value).ToList();
				query = query.Where(q => listIdNghiaTrang.Contains(q.DiaChiId));
			}
			if (nghiaTrangThanhPho > 0 && nghiaTrangQuan > 0 && nghiatrangPhuong == 0 && nghiaTrangId == 0)//có tỉnh có huyện k có xã k có nghĩa trang
			{

				var listxa = diaChiDAO.getDiaChiChild(nghiaTrangQuan);
				List<int> listId = listxa.Select(x => x.DiaChiId).ToList();
				var rs = context.NghiaTrangs.Where(q => listId.Contains(q.DiaChiId.Value));
				List<int> listIdNghiaTrang = rs.Select(x => x.DiaChiId.Value).ToList();
				query = query.Where(q => listIdNghiaTrang.Contains(q.DiaChiId));
			}
			if (nghiaTrangThanhPho > 0 && nghiaTrangQuan > 0 && nghiatrangPhuong > 0 && nghiaTrangId == 0)//có tỉnh có huyện có xã k có nghĩa trang
			{
				var rs = context.NghiaTrangs.Where(q => q.DiaChiId == nghiatrangPhuong);
				List<int> listIdNghiaTrang = rs.Select(x => x.DiaChiId.Value).ToList();
				query = query.Where(q => listIdNghiaTrang.Contains(q.DiaChiId));
			}
			if (nghiaTrangThanhPho > 0 && nghiaTrangQuan > 0 && nghiatrangPhuong > 0 && nghiaTrangId > 0)//có tỉnh có huyện có xã k có nghĩa trang
			{
				query = query.Where(q => q.NghiaTrangId == nghiaTrangId);
			}
			total = query.Count();
			if ( index > 0)
			{
				query = query.Skip((index - 1) * 10).Take(10);
			}

			return query.ToList();
		}

	}
}
