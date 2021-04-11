using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAss.dto
{
    public class EventAttendeesDtoToExportReport
    {
        private string name, email, other;
        private bool isChecked;

        public EventAttendeesDtoToExportReport()
        {
        }

        public EventAttendeesDtoToExportReport(string name, string email, string other, bool isChecked)
        {
            this.name = name;
            this.email = email;
            this.other = other;
            this.isChecked = isChecked;
        }

        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Other { get => other; set => other = value; }
        public bool IsChecked { get => isChecked; set => isChecked = value; }
    }
}
