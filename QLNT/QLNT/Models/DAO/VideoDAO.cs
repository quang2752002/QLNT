using QLNT.Models.EF;
using QLNT.Models.VIEW;

namespace QLNT.Models.DAO
{
    public class VideoDAO
    {
        private QLNTContext context = new QLNTContext();
        public void InsertOrUpdate(Video item)
        {
            if (item.Id == 0)
            {
                context.Videos.Add(item);
            }
            context.SaveChanges();
        }
        public Video getItem(int id)
        {
            var query = context.Videos.Where(x => x.Id == id).FirstOrDefault();

            return query;
        }
		public List<Video> getList()
		{
			var query = (from a in context.Videos
                      
						 select new Video
						 {

							 Id = a.Id,
							Url = a.Url,
						 });


			return query.ToList();
		}
		public videoVIEW getItemView(int id)
		{
			var query = (from a in context.Videos
						 where a.Id == id
						 select new videoVIEW
						 {

							 Id = a.Id,
							 Url = a.Url,
						 }).FirstOrDefault();


			return query;
		}

	}
}
