﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace rogue_launcher
{
    //Classe Cbdd permettant d'effectuer des requêtes SQL
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
            String connectString = "SERVER=185.213.24.116;DATABASE=roguelike;PORT=3306;UID=roguelike;PASSWORD=cciroguelike2018";
            this.connection = new MySqlConnection(connectString);
        }

        //Fonction permettant d'enregistrer un nouvel utilisateur, renvoie true si succès, sinon renvoie false
        public bool Signup(User user)
        {
            try
            {
                this.connection.Open();

                MySqlCommand query = this.connection.CreateCommand();

                //On crypte le mot de passe avec la méthode de cryptage SHA2
                query.CommandText = "INSERT INTO users (email, username, password) VALUES (@email, @username, SHA2(@password, 224))";

                query.Parameters.AddWithValue("@email", user.Email);
                query.Parameters.AddWithValue("@username", user.Pseudo);
                query.Parameters.AddWithValue("@password", user.Password);

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

        //On check si un email est déjà enregistré dans la BDD
        public bool CheckEmail(String email)
        {
            //On renvoie true si c'est le cas, sinon non
            bool result = true;

            try
            {
                this.connection.Open();

                //On crée une commande MySql
                MySqlCommand query = this.connection.CreateCommand();

                query.CommandText = "SELECT email FROM users WHERE email = @email";

                query.Parameters.AddWithValue("@email", email);

                //On utilise la classe MysqlDataReader
                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    //Si le DataReader contient des données on renvoie true, sinon false
                    if (reader.HasRows)
                    {
                        result = true;
                    } else
                    {
                        result = false;
                    }
                }

                //On ferme la connexion
                this.connection.Close();
            } catch (Exception e)
            {
                //Si il y a une erreur, on l'affiche dans une messagebox
                MessageBox.Show("Erreur : " + e, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                result = false;
            }

            //On renvoie le résultat pour déterminer si un email existe ou non
            return result;
        }

        //@TODO: à fusionner avec CheckEmail ?
        //On check si un username est déjà enregistré
        public bool CheckUsername(String username)
        {
            bool result = true;

            try
            {
                this.connection.Open();

                MySqlCommand query = this.connection.CreateCommand();

                //On demande à la BDD de sélectionner la ligne où username est égal au paramètre que l'on lui a donné
                query.CommandText = "SELECT username FROM users WHERE username = @username";

                //On remplace la valeur "@username" avec la variable username
                query.Parameters.AddWithValue("@username", username);

                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    //Ici encore, on vérifie si la requête renvoie des données
                    if (reader.HasRows)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }

                //Fermeture de la connexion
                this.connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erreur : " + e, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                result = false;
            }

            //On retourne le booléen
            return result;
        }

        //On vérifie si un utilisateur est banni
        public bool CheckBan(String email)
        {
            bool result = true;
            try
            {
                this.connection.Open();

                MySqlCommand query = this.connection.CreateCommand();

                //La requête récupère le paramètre ban de la table users où email est égal à la variable email
                query.CommandText = "SELECT ban FROM users WHERE email = @email";

                query.Parameters.AddWithValue("@email", email);

                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //Si la valeur récupérée est égale à 1, l'utilisateur est banni. On renvoie donc true
                            if(reader.GetInt32(0) == 1)
                            {
                                result = true;
                            }
                            else
                            {
                                result = false;
                            }
                        }
                    }
                }

                this.connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erreur : " + e, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                result = false;
            }

            return result;
        }

        //On récupère les infos de l'utilisateur dans l'objet session User afin de le connecter à l'application
        public User Signin(string email, string password)
        {
            //On déclare un objet User null afin de le remplir par après
            User user = null;

            try
            {
                this.connection.Open();

                MySqlCommand query = this.connection.CreateCommand();

                //On sélectionne les champs dans la bdd pour les récupérer et les insérer dans l'objet session user
                query.CommandText = "SELECT id, email, username, admin FROM users WHERE email = @email AND password = SHA2(@password, 224)";

                query.Parameters.AddWithValue("@email", email);
                query.Parameters.AddWithValue("@password", password);

                //On réutilise l'objet MySqlDataReader
                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //On crée un nouvel objet User avec comme paramètres les informations récupérées dans la base de données.
                            //reader[0] : ID
                            //reader[1] : email
                            //reader[2] : username
                            //reader[3] : ban
                            //false : on considère que quand il se connecte, l'utilisateur n'est pas banni, on set donc directement à false
                            user = new User(Convert.ToInt32(reader[0]), Convert.ToString(reader[1]), Convert.ToString(reader[2]), Convert.ToBoolean(reader[3]), false);
                        }
                    }
                    else
                    {
                        user = null;
                    }
                }
                this.connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erreur : " + e, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return user;
        }

        //On récupère l'intégralité des utilisateurs de la bdd pour les afficher dans le panel admin
        public List<User> ShowUsers()
        {
            //On crée une liste d'objets User car on ne connaît pas le nombre d'utilisateurs dans la bdd
            List<User> users = new List<User>();

            try
            {
                this.connection.Open();

                MySqlCommand query = this.connection.CreateCommand();

                //On récupère tout sauf le mot de passe : il est crypté, ça ne sert à rien
                query.CommandText = "SELECT id, email, username, admin, ban FROM users";

                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //Pour chaque ligne récupérée dans la BDD, on ajoute dans la liste un nouvel utilisateur avec les informations récupérées dans la BDD
                            users.Add(new User(Convert.ToInt32(reader[0]), Convert.ToString(reader[1]), Convert.ToString(reader[2]), Convert.ToBoolean(reader[3]), Convert.ToBoolean(reader[4])));
                        }
                    }
                }

                this.connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erreur : " + e, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //On renvoie la liste des utilisateurs récupérés dans la base de données
            return users;
        }

        //On supprime un utilisateur grâce à son id
        public bool DeleteUser(int id)
        {
            bool result = false;

            try
            {
                this.connection.Open();

                MySqlCommand query = this.connection.CreateCommand();

                //Requête pour supprimer la ligne de l'utilisateur via son ID
                query.CommandText = "DELETE FROM users WHERE id IN (@id)";

                query.Parameters.AddWithValue("@id", id);

                query.ExecuteNonQuery();

                this.connection.Close();

                this.connection.Open();

                query = this.connection.CreateCommand();

                query.CommandText = "DELETE FROM partie WHERE FKid_user IN (@id)";

                query.Parameters.AddWithValue("@id", id);

                query.ExecuteNonQuery();

                this.connection.Close();

                result = true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Erreur : " + e, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }

            //Si la supression a fonctionné on renvoie true, sinon false
            return result;
        }

        //On met à jour un utilisateur dans la base de données via le panel administrateur
        public bool UpdateUser(User user)
        {
            bool result = false;

            try
            {
                this.connection.Open();

                MySqlCommand query = this.connection.CreateCommand();

                //On crée la base de la requête qui sera utilisée dans tous les cas
                query.CommandText = "UPDATE users SET email = @email, username = @username, ban = @ban, admin = @admin";

                //Si la fonction getPassword de l'objet user ne renvoie pas un string vide,
                //on ajoute à la requête le paramètre password ainsi que la variable password
                if (user.Password != "")
                {
                    query.CommandText += ", password = SHA2(@password, 224)";
                    query.Parameters.AddWithValue("@password", user.Password);
                }

                //Enfin, on ajoute la condition où on compare l'ID afin de sélectionner le bon utilisateur
                query.CommandText += " WHERE id = @id";

                //On remplace les paramètres dans la query par les variables
                query.Parameters.AddWithValue("@email", user.Email);
                query.Parameters.AddWithValue("@username", user.Pseudo);
                query.Parameters.AddWithValue("@ban", (user.Ban ? 1 : 0));
                query.Parameters.AddWithValue("@admin", (user.Admin ? 1 : 0));
                query.Parameters.AddWithValue("@id", user.Id);

                //On exécute la query
                query.ExecuteNonQuery();

                this.connection.Close();
                result = true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Erreur : " + e, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }

            //Renvoie true si ça a fonctionné, sinon false
            return result;
        }
    }
}
