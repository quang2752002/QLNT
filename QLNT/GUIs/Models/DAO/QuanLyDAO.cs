using GUIs.Models.EF;
using GUIs.Models.VIEW;
using System.Linq;

namespace GUIs.Models.DAO
{
    public class QuanLyDAO
    {
        private QLNTContext context=new QLNTContext();
        public void InsertOrUpdate(QuanLy item)
        {
            if (item.UserId == 0)
            {
                context.QuanLies.Add(item);
            }
            context.SaveChanges();
        }
        public QuanLy getItem(int id)
        {
            var query = context.QuanLies.Where(x=>x.UserId == id).FirstOrDefault();

            return query;
        }
        public QuanLyVIEW getItemView(int id)
        {
            var query = (from a in context.QuanLies
                         where a.UserId == id
                         select new QuanLyVIEW
                         {
                             UserId = a.UserId,
                             Ten = a.Ten,
                             Email = a.Email,
                             Username = a.Username,
                             Password = a.Password,
                             
                         }).FirstOrDefault();

            return query;
        }
        public int Login(string  username,string password)
        {
            var query = (from a in context.QuanLies
                         where (a.Username == username&&a.Password == password)
                         select new QuanLyVIEW
                         {
                           UserId=a.UserId,
                           Ten = a.Ten,
                         }).FirstOrDefault();
            if(query == null)
                return -1;
            return query.UserId;
        }

    }
}
