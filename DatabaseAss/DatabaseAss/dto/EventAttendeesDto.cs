using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAss.dto
{
    public class EventAttendeesDto
    {
        private int id;
        private string  name, email, other;
        private int groupID;

        public EventAttendeesDto(int id, string name, string email, string other, int groupID)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.other = other;
            this.groupID = groupID;
        }

        public EventAttendeesDto()
        {
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Other { get => other; set => other = value; }
        public int GroupID { get => groupID; set => groupID = value; }
    }
}
