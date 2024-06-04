using GUIs.Models.EF;
using GUIs.Models.VIEW;
using System.Collections.Generic;
using System.Linq;

namespace GUIs.Models.DAO
{
    public class DiaChiDAO
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
            var query = context.DiaChis.Where(x=>x.DiaChiId==id).FirstOrDefault();

            return query;
        }
        public DiaChiVIEW getItemView(int id)
        {
            var query = (from a in context.DiaChis
                         where a.DiaChiId == id && a.TrangThai == "active"
                         select new DiaChiVIEW
                         {
                             DiaChiId=a.DiaChiId,
                             ParentId=a.ParentId??0,
                             Ten=a.Ten,
                             Cap=a.Cap,
                             TrangThai=a.TrangThai
                         }).FirstOrDefault();

            return query;
        }
        
        public List<DiaChiVIEW> getDiaChiChild(int id)
        {
            
            var query = (from a in context.DiaChis
                         where a.ParentId == id && a.TrangThai == "active"
                         select new DiaChiVIEW
                         {
                             DiaChiId = a.DiaChiId,
                             ParentId = a.ParentId ?? 0,
                             Ten = a.Ten,
                             Cap = a.Cap,
                             TrangThai = a.TrangThai
                         }).ToList();

            return query;
        }
        public List<DiaChiVIEW> ShowList()
        {
            var query = (from a in context.DiaChis
                         where a.TrangThai == "active"&&a.ParentId==null
                         select new DiaChiVIEW
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
