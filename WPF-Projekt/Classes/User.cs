using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Projekt
{
    class User
    {
        private int id;
        private string username;
        private string password;

        public User(string username, string password, int id)
        {
            this.username = username;
            this.password = password;
            this.id = id;
        }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
