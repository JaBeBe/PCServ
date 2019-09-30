using System;
using PCServ.Models;
namespace PCServ.Controllers.DataControllers
{
    public class NotificationController
    {

        public void UpgratesNotification(Notification notification, string message = notification.Message, string pcDescription = Notification.PcDescription)
        {
            notification.Message = message;
            notification.PcDescription = pcDescription;
            notification.UpgradeTime = DateTime.Now;
            SaveUpgrates(notification);

        }

        public void IsReadChange(Notification notification)
        {
            notification.IsRead = true;
            notification.ReadTime = DateTime.Now;
            SaveUpgrates(notification);
        }
        public void IsCloseChange(Notification notification)
        {
            notification.IsEnd = true;
            notification.CloseTime = DateTime.Now;
            SaveUpgrates(notification);
        }

        private void SaveToDataBase(Notification notification)
        {
            //To Do
        }
        private void SaveUpgrates(Notification notification)
        {
            //To Do
        }
    }
}