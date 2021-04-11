using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAss.dto
{
    public class CheckInDto
    {
        private int eventAttendeesID;
        private string name, email, other;
        private int eventID;
        private bool check;

        public CheckInDto()
        {
        }

        public CheckInDto(int eventAttendeesID, string name, string email, string other, int eventID, bool check)
        {
            this.eventAttendeesID = eventAttendeesID;
            this.name = name;
            this.email = email;
            this.other = other;
            this.eventID = eventID;
            this.check = check;
        }

        public int EventAttendeesID { get => eventAttendeesID; set => eventAttendeesID = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Other { get => other; set => other = value; }
        public int EventID { get => eventID; set => eventID = value; }
        public bool Check { get => check; set => check = value; }
    }
}
