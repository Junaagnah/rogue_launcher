using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace rogue_launcher
{
    class Cbdd
    {
        //Déclaration objet connexion Mysql
        private MySqlConnection connection;

        //Constructeur
        public Cbdd()
        {
            this.InitConnection();
        }

        //On initialise la connexion à la base de données
        private void InitConnection()
        {
            String connectString = "SERVER=localhost;DATABASE=roguelike;PORT=3306;UID=root;PASSWORD=";
            this.connection = new MySqlConnection(connectString);
        }

        //Fonction permettant d'enregistrer un nouvel utilisateur, renvoie true si succès, sinon renvoie false
        public bool Singup(String email, String username, String password)
        {
            try
            {
                this.connection.Open();

                MySqlCommand query = this.connection.CreateCommand();

                //On crypte le mot de passe avec la méthode de cryptage SHA2
                query.CommandText = "INSERT INTO users (email, username, password) VALUES (@email, @username, SHA2(@password)";

                query.Parameters.AddWithValue("@email", email);
                query.Parameters.AddWithValue("@username", username);
                query.Parameters.AddWithValue("@password", password);

                //Execution de la requête
                query.ExecuteNonQuery();

                this.connection.Close();

                return true;
            } catch (Exception e)
            {
                //Si erreur, on l'affiche dans une messagebox
                MessageBox.Show("Erreur : " + e, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }
    }
}
