using GUIs.Models.VIEW;
using QLNT.Models.EF;

namespace QLNT.Models.DAO
{
    public class diaChiDAO
    {
        private QLNTContext context = new QLNTContext();
        public void InsertOrUpdate(DiaChi item)
        {
            if (item.DiaChiId == 0)
            {
                context.DiaChis.Add(item);
            }
            context.SaveChanges();
        }
        public DiaChi getItem(int id)
        {
            var query = context.DiaChis.Where(x => x.DiaChiId == id).FirstOrDefault();

            return query;
        }
        public diaChiVIEW getItemView(int id)
        {
            var query = (from a in context.DiaChis
                         where a.DiaChiId == id
                         select new diaChiVIEW
                         {
                             DiaChiId = a.DiaChiId,
                             ParentId = a.ParentId ?? 0,
                             Ten = a.Ten,
                             Cap = a.Cap,
                             TrangThai = a.TrangThai
                         }).FirstOrDefault();
            return query;
        }
		public List<diaChiVIEW> getDiaChiChild(int id)
		{

			var query = (from a in context.DiaChis
						 where a.ParentId == id && a.TrangThai == "active"
						 select new diaChiVIEW
						 {
							 DiaChiId = a.DiaChiId,
							 ParentId = a.ParentId ?? 0,
							 Ten = a.Ten,
							 Cap = a.Cap,
							 TrangThai = a.TrangThai
						 }).ToList();

			return query;
		}

		public List<diaChiVIEW> getDiaChiChild(out int total, int id, string name = "", int index = 1, int size = 10, string trangthai = "active")
        {

            var query = (from a in context.DiaChis
                         where a.ParentId == id && a.TrangThai == trangthai
                         select new diaChiVIEW
                         {
                             DiaChiId = a.DiaChiId,
                             ParentId = a.ParentId ?? 0,
                             Ten = a.Ten,
                             Cap = a.Cap,
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
        public List<diaChiVIEW> ShowList(out int total, string name = "", int index = 1, int size = 10, string trangthai = "active")
        {

            if (name == null) name = "";
            var query = (from a in context.DiaChis
                         where a.TrangThai == trangthai && a.ParentId == null
                         select new diaChiVIEW
                         {
                             DiaChiId = a.DiaChiId,
                             ParentId = a.ParentId ?? 0,
                             Ten = a.Ten,
                             Cap = a.Cap,
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
        public List<diaChiVIEW> getList()
        {

            var query = (from a in context.DiaChis
                         where a.ParentId == null && a.TrangThai == "active"
                         select new diaChiVIEW
                         {
                             DiaChiId = a.DiaChiId,
                             ParentId = a.ParentId ?? 0,
                             Ten = a.Ten,
                             Cap = a.Cap,
                             TrangThai = a.TrangThai
                         });



            return query.ToList();
        }
		public List<diaChiVIEW> getListChild(int id)
		{

			var query = (from a in context.DiaChis
						 where a.ParentId == id && a.TrangThai == "active"
						 select new diaChiVIEW
						 {
							 DiaChiId = a.DiaChiId,
							 ParentId = a.ParentId ?? 0,
							 Ten = a.Ten,
							 Cap = a.Cap,
							 TrangThai = a.TrangThai
						 }).ToList();



			return query;
		}
       
	}
}

