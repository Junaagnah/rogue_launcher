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
            String connectString = "SERVER=localhost;DATABASE=roguelike;PORT=3307;UID=root;PASSWORD=";
            this.connection = new MySqlConnection(connectString);
        }

        //Fonction permettant d'enregistrer un nouvel utilisateur, renvoie true si succès, sinon renvoie false
        public bool Signup(String email, String username, String password)
        {
            try
            {
                this.connection.Open();

                MySqlCommand query = this.connection.CreateCommand();

                //On crypte le mot de passe avec la méthode de cryptage SHA2
                query.CommandText = "INSERT INTO users (email, username, password) VALUES (@email, @username, SHA2(@password, 224))";

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

        public bool CheckEmail(String email)
        {
            bool result = true;

            try
            {
                this.connection.Open();

                MySqlCommand query = this.connection.CreateCommand();

                query.CommandText = "SELECT email FROM users WHERE email = @email";

                query.Parameters.AddWithValue("@email", email);

                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = true;
                    } else
                    {
                        result = false;
                    }
                }

                this.connection.Close();
            } catch (Exception e)
            {
                MessageBox.Show("Erreur : " + e, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                result = false;
            }

            return result;
        }

        public bool CheckUsername(String username)
        {
            bool result = true;

            try
            {
                this.connection.Open();

                MySqlCommand query = this.connection.CreateCommand();

                query.CommandText = "SELECT email FROM users WHERE username = @username";

                query.Parameters.AddWithValue("@username", username);

                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
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

        public bool CheckBan(String email)
        {
            bool result = true;
            try
            {
                this.connection.Open();

                MySqlCommand query = this.connection.CreateCommand();

                query.CommandText = "SELECT ban FROM users WHERE email = @email";

                query.Parameters.AddWithValue("@email", email);

                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
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

        public bool CheckAdmin(String email, String password)
        {
            bool result = true;
            try
            {
                this.connection.Open();

                MySqlCommand query = this.connection.CreateCommand();

                query.CommandText = "SELECT admin FROM users WHERE email = @email AND password = SHA2(@password, 224)";

                query.Parameters.AddWithValue("@email", email);

                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (reader.GetInt32(0) == 1)
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

        public User Signin(string email, string password)
        {
            User user = null;

            try
            {
                this.connection.Open();

                MySqlCommand query = this.connection.CreateCommand();

                query.CommandText = "SELECT id, email, username, admin FROM users WHERE email = @email AND password = SHA2(@password, 224)";

                query.Parameters.AddWithValue("@email", email);
                query.Parameters.AddWithValue("@password", password);

                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
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

        public List<User> ShowUsers()
        {
            List<User> users = new List<User>();

            try
            {
                this.connection.Open();

                MySqlCommand query = this.connection.CreateCommand();

                query.CommandText = "SELECT id, email, username, admin, ban FROM users";

                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
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

            return users;
        }

        public bool DeleteUser(int id)
        {
            bool result = false;

            try
            {
                this.connection.Open();

                MySqlCommand query = this.connection.CreateCommand();

                query.CommandText = "DELETE FROM users WHERE id IN (@id)";

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

            return result;
        }
    }
}
