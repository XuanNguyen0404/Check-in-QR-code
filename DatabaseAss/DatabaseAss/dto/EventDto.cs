using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAss.dto
{
    public class EventDto
    {
        private int id;
        private string name, description, emailContent, userID, status;

        public EventDto(string name, string description, string emailContent, string userID)
        {
            this.name = name;
            this.description = description;
            this.emailContent = emailContent;
            this.userID = userID;
        }

  

        public EventDto()
        {
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string EmailContent { get => emailContent; set => emailContent = value; }
        public string UserID { get => userID; set => userID = value; }
        public string Status { get => status; set => status = value; }
    }
}
