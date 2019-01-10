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
        //Déclaration des variables publiques et privées de la classe
        private int id; //ID de l'utilisateur
        private String email; //Email de l'utilisateur
        private String pseudo; //Pseudo de l'utilisateur
        private String password = ""; //Mot de passe de l'utilisateur, on le set à vide pour une réutilisation dans Cbdd
        private bool admin; //Si l'utilisateur est administrateur
        private bool ban; //Si l'utilisateur est banni

        //On rend obligatoire la définition des paramètres suivants via le constructeur de la classe
        public User(int id, String email, String pseudo, bool admin, bool ban)
        {
            this.id = id;
            this.email = email;
            this.pseudo = pseudo;
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


        //La propriété admin étant privée, on y accède via une fonction pour éviter de la modifier par accident
        //public bool isAdmin()
        //{
        //    return this.admin;
        //}

        //Idem pour la propriété ban, qui est utilisée dans le panel admin
        //public bool isBan()
        //{
        //    return this.ban;
        //}

        //On permet de setter le mot de passe de l'utilisateur avec une fonction au lieu d'y accéder directement pour éviter de la modifier accidentellement
        //public void setPassword(String passwd)
        //{
        //    this.password = passwd;
        //}

        //Même cas que admin et ban
        //public String getPassword()
        //{
        //    return this.password;
        //}
    }
}
