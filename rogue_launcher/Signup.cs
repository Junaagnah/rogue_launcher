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
        private Cbdd bdd = new Cbdd();
        private bool isEmail;
        private String errorMsg;

        public bool IsEmail { get => isEmail; set => isEmail = value; }
        public String ErrorMsg { get => errorMsg; set => errorMsg = value; }

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

            Inscription(email, username, passwd, confpasswd);
        }

        public void Inscription(String email, String username, String passwd, String confpasswd)
        {
            // On vérifie si tous les champs sont remplis
            if (email != "" && username != "" && passwd != "" && confpasswd != "")
            {
                IsEmail = false;

                foreach (Char c in email)
                {
                    // On vérifie que l'email comporte bien un @
                    if (c == '@')
                    {
                        IsEmail = true;
                    }
                }

                if (IsEmail) // Si l'email contient bien un @
                {
                    if (Password.checkPasswd(passwd))
                    {
                        try
                        {
                            CheckPasswordEquals(passwd, confpasswd);

                            if (!bdd.CheckEmail(email)) // Que l'email renseigné n'est pas déjà utilisé
                            {
                                if (checkPseudo(username))
                                {
                                    if (!bdd.CheckUsername(username)) // Que le nom d'utilisateur rensigné n'est pas déjà utilisé
                                    {
                                        User newUser = new User(email, username, passwd);

                                        if (bdd.Signup(newUser)) // Fonction d'enregistrement du nouveau compte utilisateur dans la base de données
                                        {
                                            MessageBox.Show("Inscription réussie !", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                            this.Close();
                                        }
                                    }
                                    // Liste des différentes erreurs lorsque les conditions ne sont pas remplies
                                    else
                                    {
                                        MessageBox.Show("Le nom d'utilisateur est déjà utilisé !", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                        }
                        catch (ArgumentException e)
                        {
                            MessageBox.Show(e.Message, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez entrer une adresse e-mail valide.", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Merci de remplir tous les champs.", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool checkPseudo(string pseudo)
        {
            bool isPseudo = true;

            ErrorMsg = "";

            for (int i = 0; i < pseudo.Length; i++)
            {
                if (pseudo[i] == ' ')
                {
                    isPseudo = false;
                    ErrorMsg = "Votre pseudo ne peut pas contenir d'espace.";
                    break;
                }
            }
            
            if (!isPseudo)
            {
                MessageBox.Show(ErrorMsg, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isPseudo;
        }

        //Vérifie si les mots de passe sont égaux, sinon renvoie une exception
        public void CheckPasswordEquals(String passwd, String confpasswd)
        {
            if (passwd != confpasswd)
            {
                throw new ArgumentException("Les mots de passe ne correspondent pas.");
            }
        }
    }
}
