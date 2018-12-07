using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rogue_launcher
{
    // Fenêtre qui permettra à un utilisateur de s'inscrire
    public partial class Signup : Form
    {
        // Déclaration des variables nécessaires au fonctionnement de la classe
        Cbdd bdd = new Cbdd();

        // Constructeur
        public Signup()
        {
            InitializeComponent();
        }

        // Bouton ANNULER pour fermer la fenêtre d'inscription
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Actions du bouton VALIDER
        private void button1_Click(object sender, EventArgs e)
        {

            // on récupère et on stocke les champs à renseigner
            String email = Signup_email.Text;
            String username = Signup_username.Text;
            String passwd = Signup_passwd.Text;
            String confpasswd = Signup_confpasswd.Text;

            // On vérifie si tous les champs sont remplis
            if (email != "" && username != "" && passwd != "" && confpasswd != "")
            {
                bool isEmail = false;

                foreach (Char c in email)
                {
                    // On vérifie que l'email comporte bien un @
                    if (c == '@')
                    {
                        isEmail = true;
                    }
                }

                if (isEmail) // Si l'email contient bien un @
                {
                    if (passwd == confpasswd) // Que les mots de passe correspondent
                    {
                        if (!bdd.CheckEmail(email)) // Que l'email renseigné n'est pas déjà utilisé
                        {
                            if (!bdd.CheckUsername(username)) // Que le nom d'utilisateur rensigné n'est pas déjà utilisé
                            {
                                if (bdd.Signup(email, username, passwd)) // Fonction de stockage du nouveau compte utilisateur dans la base de données
                                {
                                    MessageBox.Show("Inscription réussie !", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    this.Close();
                                }
                                // Liste des différentes erreurs lorsque les conditions ne sont pas remplies
                            } else {
                                MessageBox.Show("Le nom d'utilisateur est déjà utilisé !", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        } else
                        {
                            MessageBox.Show("L'adresse e-mail est déjà utilisée !", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    } else
                    {
                        MessageBox.Show("Les mots de passe ne sont pas les mêmes.", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
