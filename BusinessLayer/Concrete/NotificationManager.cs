﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        INotificationDal _notificationDal;
         
        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void Delete(Notification t)
        {
            _notificationDal.Delete(t);
        }

        public List<Notification> GetList()
        {
            return _notificationDal.GetListAll();
        }

        public void Insert(Notification t)
        {
            _notificationDal.Insert(t);
        }

        public Notification TGetById(int id)
        {
            return _notificationDal.GetById(id);
        }

        public void Update(Notification t)
        {
            _notificationDal.Update(t);
        }
    }
}
