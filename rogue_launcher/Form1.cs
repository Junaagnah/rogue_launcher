using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Fenêtre d'acceuil lors de l'execution du launcher
namespace rogue_launcher
{
    public partial class Form1 : Form
    {
        //Déclaration des variables nécessaires au fonctionnement de la classe
        public User user;

        //Constructeur
        public Form1()
        {
            InitializeComponent();
            this.user = null;
            Settingspic.Hide();
            ButtonPlay.Hide();
            welcomeText.Hide();
            welcomeText.Text = "";
        }

        //Bouton qui va appeler l'affichage de la fenêtre de connexion
        private void button1_Click(object sender, EventArgs e)
        {
            Signin signin = new Signin(this);
            signin.Show();
        }

        //Bouton qui va appeler l'affichage de la fenêtre d'incription
        private void button2_Click(object sender, EventArgs e)
        {
            Signup signup = new Signup();
            signup.Show();
        }

        //Bouton d'accès aux paramètres
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings(this, this.user);
            settings.Show();
        }
    }
}
