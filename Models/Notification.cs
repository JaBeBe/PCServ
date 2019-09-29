using System;

namespace PCServ.Models
{
    public class Notification
    {
        int id;
        string message;
        User user;
        string pcDescription;
        DateTime addNotification;
        DateTime readTime;
        DateTime upgradeNote;
        DateTime closeNotification;
        Boolean isRead;
        Boolean isEnd;

        public int Id { get => id; set => id = value; }
        public string Message { get => message; set => message = value; }
        public User User { get => user; set => user = value; }
        public string PcDescription { get => pcDescription; set => pcDescription = value; }
        public DateTime AddNotification { get => addNotification; set => addNotification = value; }
        public DateTime ReadTime { get => readTime; set => readTime = value; }
        public DateTime UpgradeNote { get => upgradeNote; set => upgradeNote = value; }
        public DateTime CloseNotification { get => closeNotification; set => closeNotification = value; }
        public bool IsRead { get => isRead; set => isRead = value; }
        public bool IsEnd { get => isEnd; set => isEnd = value; }

        private Notification()
        {

        }

        public Notification(string message, User user, string pcDescription)
        {
            this.User = user;
            this.Message = message;
            this.PcDescription = pcDescription;
            AddNotification = new DateTime.Now();
            this.IsRead = false;
            this.IsEnd = false;
        }
    }
}