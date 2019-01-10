using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;
using System.IO;

// Fenêtre qui receuillera les login et mot de passes Utilisateurs afin de les connecter
namespace rogue_launcher
{
    public partial class Signin : Form
    {
        // Déclaration des variables nécessaires au fonctionnement de la classe
        Cbdd bdd = new Cbdd();
        MainScreen form = null;

        // Constructeur
        public Signin(MainScreen f)
        {
            InitializeComponent();
            form = f;
        }

        // Actions du bouton CONNEXION
        private void button1_Click(object sender, EventArgs e)
        {
            String email = Signin_email.Text;
            String passwd = Signin_password.Text;

            // On vérifie que les champs ne sont pas vides
            if (email != "" && passwd != "")
            {
                bool isEmail = false;

                if (email.Length > 0)
                {
                    foreach (char c in email)
                    {
                        // On vérifie que l'email renseigné contiens bien un '@'
                        if (c == '@')
                        {
                            isEmail = true;
                        }
                    }
                }

                if (isEmail)
                {
                    if (bdd.CheckEmail(email)){ // On vérifie que l'email est bien enregistré dans la base de donnée

                        if (bdd.CheckBan(email)) // On vérifie que le compte associé a l'email n'est pas banni
                        {
                            MessageBox.Show("Votre compte a été banni  ¯\\_(ツ)_/¯", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            // On vérifie que le mot de passe et l'email correspondent
                            User user = bdd.Signin(email, passwd);
                            // si ce n'est pas null c'est que la requête a bien renvoyé un utilisateur
                            if (user != null)
                            {
                                //On modifie l'affichage du premier menu puis on ferme la fenêtre de connexion
                                form.user = user;
                                form.ButtonConnect.Hide();
                                form.ButtonSignup.Hide();
                                form.Settingspic.Show();
                                form.ButtonPlay.Show();
                                form.welcomeText.Show();
                                form.welcomeText.Text = "Bienvenue \r\n" + user.Pseudo;

                                String userSession = "user";

                                if (File.Exists(userSession))
                                {
                                    File.Delete(userSession);
                                }

                                //Quand l'utilisateur se connecte, on écrit son id dans le fichier user pour le jeu
                                using(StreamWriter writer = new StreamWriter(userSession, true))
                                {
                                    writer.Write(user.Id);
                                }

                                this.Close();
                            }
                            else

                            // Les différents messages d'erreur renvoyés lorsque les conditions ne sont pas remplies
                            {
                                MessageBox.Show("Le mot de passe est incorrect.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cette adresse e-mail ne correspond a aucun compte enregistré, merci de créer un compte si vous n'en possédez pas.", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                } else
                {
                    MessageBox.Show("Veuillez entrer une adresse e-mail valide.", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            } else
            {
                MessageBox.Show("Merci de remplir tous les champs.", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
