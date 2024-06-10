using GUIs.Models.VIEW;
using QLNT.Models.EF;
using QLNT.Models.VIEW;

namespace QLNT.Models.DAO
{
	public class adminDAO
	{
		private QLNTContext context = new QLNTContext();
		public void InsertOrUpdate(Admin item)
		{
			if (item.Id == 0)
			{
				context.Admins.Add(item);
			}
			context.SaveChanges();
		}
		public Admin getItem(int id)
		{
			var query = context.Admins.Where(x => x.Id == id).FirstOrDefault();

			return query;
		}
		public adminVIEW getItemView(int id)
		{
			var query = (from a in context.Admins
						 where a.Id == id
						 select new adminVIEW
						 {
							Id=a.Id,
							Ten=a.Ten,
							Sdt=a.Sdt,
							Email=a.Email,
							Username=a.Username,
							Password=a.Password
						 }).FirstOrDefault();
			return query;
		}
		public int Login(string username, string password)
		{
			var query = (from a in context.Admins
						 where a.Username == username && a.Password == password
						 select new adminVIEW
						 {
							 Id = a.Id,
						 }).FirstOrDefault();
			if (query != null)
				return query.Id;
			return -1;
		}
	}
}
