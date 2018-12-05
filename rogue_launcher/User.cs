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
        public String pseudo;
        private bool admin;

        public User(int id, String pseudo, bool admin)
        {
            this.id = id;
            this.pseudo = pseudo;
            this.admin = admin;
        }

        public bool isAdmin()
        {
            return this.admin;
        }
    }
}
