using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rogue_launcher
{
    //Classe User permettant de gérer des utilisateurs
    public class User
    {
        //Déclaration des variables privées et readonly de la classe
        readonly int id; //ID de l'utilisateur
        readonly String email; //Email de l'utilisateur
        readonly String pseudo; //Pseudo de l'utilisateur
        private String password = ""; //Mot de passe de l'utilisateur, on le set à vide pour une réutilisation dans Cbdd
        readonly bool admin; //Si l'utilisateur est administrateur
        readonly bool ban; //Si l'utilisateur est banni

        //Constructeur de base
        public User(String email, String pseudo)
        {
            this.email = email;
            this.pseudo = pseudo;
        }

        //Constructeur utilisé pour l'inscription d'un user
        public User(String email, String pseudo, String password) : this(email, pseudo)
        {
            this.password = password;
        }

        //Constructeur utilisé pour la modification d'user via EditUser
        public User(int id, String email, String pseudo, bool admin, bool ban) : this(email, pseudo)
        {
            this.id = id;
            this.admin = admin;
            this.ban = ban;
        }

        //On utilise l'encapsulation afin de set nos variables privées
        public int Id { get => id; }
        public string Email { get => email; }
        public string Pseudo { get => pseudo; }
        public string Password { get => password; set => password = value; }
        public bool Admin { get => admin; }
        public bool Ban { get => ban; }
    }
}
