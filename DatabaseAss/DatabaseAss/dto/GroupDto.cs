using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAss.dto
{
    public class GroupDto
    {
        private int id;
        private string name, description, userID;

        public GroupDto(int id, string name, string description, string userID)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.userID = userID;
        }

        public GroupDto()
        {
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string UserID { get => userID; set => userID = value; }
    }
}
