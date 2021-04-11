using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAss.dto
{
    public class UserJoinToEventDto
    {
        private int id, eventID;
        private string userID;

        public UserJoinToEventDto(int id, int eventID, string userID)
        {
            this.id = id;
            this.eventID = eventID;
            this.userID = userID;
        }

        public UserJoinToEventDto()
        {
        }

        public int Id { get => id; set => id = value; }
        public int EventID { get => eventID; set => eventID = value; }
        public string UserID { get => userID; set => userID = value; }
    }
}
