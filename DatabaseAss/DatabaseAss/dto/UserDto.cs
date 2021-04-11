using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAss.dto
{
    public class UserDto
    {
        private string name;
        private string userName;
        private string password;

        public UserDto( string name, string userName, string password)
        {
            this.name = name;
            this.userName = userName;
            this.password = password;
        }

        public UserDto()
        {
        }

        public string Name { get => name; set => name = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
    }
}
