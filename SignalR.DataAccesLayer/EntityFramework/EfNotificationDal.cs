using SignalR.DataAccesLayer.Abstract;
using SignalR.DataAccesLayer.Concrete;
using SignalR.DataAccesLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccesLayer.EntityFramework
{
	public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
	{
		public EfNotificationDal(SignalRContext context) : base(context)
		{

		}

		public List<Notification> GetAllNotificationByFalse()
		{
			using var context = new SignalRContext();
			return context.Notifications.Where(x=>x.Status==false).ToList();
		}

        public void NotificationChangeToFalse(int id)
        {
			using var context = new SignalRContext();
			var vv=context.Notifications.Where(x=>x.NotificationID==id).FirstOrDefault();
			vv.Status=false;
			context.SaveChanges();
        }

        public void NotificationChangeToTrue(int id)
        {
            using var context = new SignalRContext();
            var vv = context.Notifications.Where(x => x.NotificationID == id).FirstOrDefault();
            vv.Status = true;
			context.SaveChanges();
        }

        public int NotificationCountByStatusFalse()
		{
			using var context = new SignalRContext();
			int vv=context.Notifications.Where(x=>x.Status==false).Count();
			return vv;
		}
	}
}
