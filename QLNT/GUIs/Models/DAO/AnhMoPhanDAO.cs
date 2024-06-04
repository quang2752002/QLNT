using GUIs.Models.EF;
using GUIs.Models.VIEW;
using System.Collections.Generic;
using System.Linq;

namespace GUIs.Models.DAO
{
    public class AnhMoPhanDAO
    {
        private QLNTContext context = new QLNTContext();
        public void InsertOrUpdate(AnhMoPhan item)
        {
            if (item.AnhId == 0)
            {
                context.AnhMoPhans.Add(item);
            }
            context.SaveChanges();
        }
        public AnhMoPhan getItem(int id)
        {
            var query = context.AnhMoPhans.Where(x => x.AnhId == id).FirstOrDefault();

            return query;
        }
        public AnhMoPhanVIEW getItemView(int id)
        {
            var query = (from a in context.AnhMoPhans
                         where a.AnhId == id && a.TrangThai == "active"
                         select new AnhMoPhanVIEW
                         {
                             AnhId = a.AnhId,
                             LietSyId = a.LietSyId.Value,
                             Img = a.Img,
                             MoTa = a.MoTa,
                             TrangThai = a.TrangThai
                         }).FirstOrDefault();

            return query;
        }
        public List<AnhMoPhanVIEW> ShowList(int lietSyId)
        {
            var query = (from a in context.AnhMoPhans
                         where a.LietSyId==lietSyId&&a.TrangThai == "active"
                         select new AnhMoPhanVIEW
                         {
                             AnhId = a.AnhId,
                             LietSyId = a.LietSyId.Value,
                             Img = a.Img,
                             MoTa = a.MoTa,
                             TrangThai = a.TrangThai
                         }).ToList();

            return query;
        }
    }
}
