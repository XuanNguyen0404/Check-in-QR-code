using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAss.dto
{
    public class EventAttendeesDtoExcel
    {
        private string  name, email, other;

        public EventAttendeesDtoExcel(string name, string email, string other)
        {
            this.name = name;
            this.email = email;
            this.other = other;
        }

        public EventAttendeesDtoExcel()
        {
        }

        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Other { get => other; set => other = value; }

    }
}
