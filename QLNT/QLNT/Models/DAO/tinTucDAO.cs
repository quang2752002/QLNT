using GUIs.Models.VIEW;
using QLNT.Models.EF;
using QLNT.Models.VIEW;

namespace QLNT.Models.DAO
{
	public class tinTucDAO
	{
		private QLNTContext context = new QLNTContext();
		public void InsertOrUpdate(TinTuc item)
		{
			if (item.Id == 0)
			{
				context.TinTucs.Add(item);
			}
			context.SaveChanges();
		}
		public TinTuc getItem(int id)
		{
			var query = context.TinTucs.Where(x => x.Id == id).FirstOrDefault();

			return query;
		}
		public tinTucVIEW getItemView(int id)
		{
			var query = (from a in context.TinTucs
						 where a.Id == id
						 select new tinTucVIEW
						 {
							Id=a.Id,
							Anh=a.Anh,
							Tieude=a.Tieude,
							Noidung=a.Noidung,
							TrangThai=a.TrangThai						 
						 }).FirstOrDefault();
			return query;
		}
		public List<tinTucVIEW> ShowList(out int total, string name = "", int index = 1, int size = 10, string trangthai = "active")
		{

			if (name == null) name = "";
			var query = (from a in context.TinTucs
						 where a.TrangThai == trangthai 
						 select new tinTucVIEW
						 {

							 Id = a.Id,
							 Anh = a.Anh,
							 Tieude = a.Tieude,
							 Noidung = a.Noidung,
							 TrangThai = a.TrangThai
						 });

			if (!string.IsNullOrEmpty(name) && name != "")
			{
				query = query.Where(x => x.Tieude.Contains(name));
			}
			total = query.Count();
			if (size > 0 && index > 0)
			{
				query = query.Skip((index - 1) * size).Take(size);
			}

			return query.ToList();
		}
		public List<tinTucVIEW> getList()
		{

		
			var query = (from a in context.TinTucs
						 where a.TrangThai == "active"
						 select new tinTucVIEW
						 {

							 Id = a.Id,
							 Anh = a.Anh,
							 Tieude = a.Tieude,
							 Noidung = a.Noidung,
							 TrangThai = a.TrangThai
						 });


			return query.ToList();
		}
	}
}
