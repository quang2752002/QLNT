using GUIs.Models.VIEW;
using QLNT.Models.EF;

namespace QLNT.Models.DAO
{
    public class anhMoPhanDAO
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
        public anhMoPhanVIEW getItemView(int id)
        {
            var query = (from a in context.AnhMoPhans
                         where a.AnhId == id 
                         select new anhMoPhanVIEW
                         {
                             AnhId = a.AnhId,
                             LietSyId = a.LietSyId.Value,
                             Img = a.Img,
                             MoTa = a.MoTa,
                             TrangThai = a.TrangThai
                         }).FirstOrDefault();

            return query;
        }
        public List<anhMoPhanVIEW> ShowList(int lietSyId)
        {
            var query = (from a in context.AnhMoPhans
                         where a.LietSyId == lietSyId && a.TrangThai == "active"
                         select new anhMoPhanVIEW
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

