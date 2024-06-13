using QLNT.Models.EF;
using QLNT.Models.VIEW;

namespace QLNT.Models.DAO
{
    public class nghiaTrangDAO
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
        public nghiaTrangVIEW getItemView(int id)
        {
            var query = (from a in context.NghiaTrangs
                         where a.NghiaTrangId == id 
                         select new nghiaTrangVIEW
                         {
                             NghiaTrangId = a.NghiaTrangId,
                             DiaChiId = a.DiaChiId.Value,
                             Ten = a.Ten,
                             Sdt = a.Sdt,
                             Email = a.Email,
                             Soluong = a.Soluong??0,
                             DiaChi = a.DiaChi,
                             DienTich = a.DienTich??0,
                             MoTa = a.MoTa,
                             TrangThai = a.TrangThai
                         }).FirstOrDefault();

            return query;
        }
        public nghiaTrangVIEW getNghiaTrangByIdXa(int idxa)
        {
            var query = (from a in context.NghiaTrangs
                         where a.DiaChiId == idxa && a.TrangThai == "active"
                         select new nghiaTrangVIEW
                         {
                             NghiaTrangId = a.NghiaTrangId,
                             DiaChiId = a.DiaChiId.Value,
                             Ten = a.Ten,
                             Sdt = a.Sdt,
                             Email = a.Email,
                             Soluong = a.Soluong??0,
                             DiaChi = a.DiaChi,
                             DienTich = a.DienTich??0,
                             MoTa = a.MoTa,
                             TrangThai = a.TrangThai
                         }).FirstOrDefault();

            return query;
        }
        public List<nghiaTrangVIEW> ShowList(out int total, string name = "", int index = 1, int size = 10,string trangthai="active")
        {
            if (name == null) name = "";
            var query = (from a in context.NghiaTrangs
                         join b in context.DiaChis on a.DiaChiId equals b.DiaChiId
                         join c in context.DiaChis on b.ParentId equals c.DiaChiId 
                         join d in context.DiaChis on c.ParentId equals d.DiaChiId
                         where a.TrangThai==trangthai
                         select new nghiaTrangVIEW
                         {
                             NghiaTrangId = a.NghiaTrangId,
                             DiaChiId = a.DiaChiId.Value,
                             Ten = a.Ten,
                             Sdt = a.Sdt,
                             Email = a.Email,
                             Soluong = a.Soluong??0,
                             DiaChi = b.Ten+","+c.Ten+","+d.Ten,
                             DienTich = a.DienTich.Value,
                             MoTa = a.MoTa,
                             TrangThai = a.TrangThai
                         });
            if (!string.IsNullOrEmpty(name) && name != "")
            {
                query = query.Where(x => x.Ten.Contains(name));
            }
            total = query.Count();
            if (size > 0 && index > 0)
            {
                query = query.Skip((index - 1) * size).Take(size);
            }
            
            return query.ToList();
        }
		public List<nghiaTrangVIEW> getList()
		{
			
			var query = (from a in context.NghiaTrangs
						 where a.TrangThai == "active"
						 select new nghiaTrangVIEW
						 {
							 NghiaTrangId = a.NghiaTrangId,
							 DiaChiId = a.DiaChiId.Value,
							 Ten = a.Ten,
							 Sdt = a.Sdt,
							 Email = a.Email,
							 Soluong = a.Soluong ?? 0,
							 DiaChi = a.DiaChi,
							 DienTich = a.DienTich.Value,
							 MoTa = a.MoTa,
							 TrangThai = a.TrangThai
						 });
			

			return query.ToList();
		}
        
	}
}
