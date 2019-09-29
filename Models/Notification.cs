using System;

namespace PCServ.Models
{
    public class Notification
    {
        int id;
        string message;
        User user;
        string pcDescription;
        DateTime createTime;
        DateTime readTime;
        DateTime upgradeTime;
        DateTime closeTime;
        Boolean isRead;
        Boolean isEnd;

        public int Id { get => id; set => id = value; }
        public string Message { get => message; set => message = value; }
        public User User { get => user; set => user = value; }
        public string PcDescription { get => pcDescription; set => pcDescription = value; }
        public DateTime CreateTime { get => createTime; set => createTime = value; }
        public DateTime ReadTime { get => readTime; set => readTime = value; }
        public DateTime UpgradeTime { get => upgradeTime; set => upgradeTime = value; }
        public DateTime CloseTime { get => closeTime; set => closeTime = value; }
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
            CreateTime = DateTime.Now;
            this.IsRead = false;
            this.IsEnd = false;
        }
    }
}