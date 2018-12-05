using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rogue_launcher
{
    public class User
    {
        public int id;
        public String email;
        public String pseudo;
        private bool admin;
        private bool ban;

        public User(int id, String email, String pseudo, bool admin, bool ban)
        {
            this.id = id;
            this.email = email;
            this.pseudo = pseudo;
            this.admin = admin;
            this.ban = ban;
        }

        public bool isAdmin()
        {
            return this.admin;
        }

        public bool isBan()
        {
            return this.ban;
        }
    }
}
