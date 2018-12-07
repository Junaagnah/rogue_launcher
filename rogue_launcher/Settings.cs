using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace rogue_launcher
{
    //Fenêtre des paramètres
    public partial class Settings : Form
    {
        //Déclarations des variables nécessaires au fonctionnement de la fenêtre
        Form1 form;
        User user;

        //Le constructeur prend en paramètres la référence de Form1 qui est la fenêtre précédente, ainsi que l'objet session user
        public Settings(Form1 f, User user)
        {
            InitializeComponent();
            this.form = f;
            this.user = user;
        }

        //Bouton de déconnexion
        private void button1_Click(object sender, EventArgs e)
        {
            //On vide la variable session, on vide le label2 affichant "Bienvenue " + pseudo, on cache l'icône des paramètres et on réaffiche le bouton inscription
            form.user = null;
            form.welcomeText.Text = "";
            form.welcomeText.Hide();
            form.Settingspic.Hide();
            form.ButtonPlay.Hide();
            form.ButtonSignup.Show();
            form.ButtonConnect.Show();

            String userSession = "user";

            //On n'oublie pas de supprimer le fichier user si l'utilisateur se déconnecte
            if (File.Exists(userSession))
            {
                File.Delete(userSession);
            }

            this.Close();
        }

        //Bouton affichant le panel administrateur
        private void button2_Click(object sender, EventArgs e)
        {
            //Si l'utilisateur connecté est administrateur on affiche le panel admin, sinon on affiche un message d'erreur
            if (this.user.isAdmin())
            {
                Admin admin = new Admin();
                admin.Show();
                this.Close();
            } else
            {
                MessageBox.Show("Vous devez être administrateur pour accéder à cette fenêtre.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
