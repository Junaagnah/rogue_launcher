using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;

// Fenêtre d'acceuil lors de l'execution du launcher
namespace rogue_launcher
{
    public partial class MainScreen : Form
    {
        //Déclaration des variables nécessaires au fonctionnement de la classe
        public User user;
        private Updater updater;
        private String userSession = "user";

        //Constructeur
        public MainScreen()
        {
            InitializeComponent();
            this.user = null;
            Settingspic.Hide();
            ButtonPlay.Hide();
            welcomeText.Hide();
            welcomeText.Text = "";
            this.updater = new Updater(this);
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

        //On déclare les événements FormClosing et Shown
        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            this.Shown += Form1_Shown;
        }

        //Fonction qui permet de vérifier si l'utilisateur a accès à internet ou non
        private bool IsOnline()
        {
            bool result = false;

            try
            {
                using (WebClient client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    result = true;
                }
            }
            catch
            {
                result = false;
            }

            return result;
        }

        //Quand on ferme l'appli, on supprime le fichier user
        private void Form1_FormClosing(Object Sender, FormClosingEventArgs e)
        {
            if (File.Exists(this.userSession))
            {
                File.Delete(this.userSession);
            }
        }

        //Quand le Form s'affiche, appelle cette fonction
        private void Form1_Shown(Object sender, EventArgs e)
        {
            //Si l'utilisateur est hors ligne
            if (!IsOnline())
            {
                //Et si le jeu est déjà téléchargé, on lui permet de jouer en hors ligne
                if (Directory.Exists("game"))
                {
                    ButtonConnect.Hide();
                    ButtonSignup.Hide();
                    ButtonPlay.Show();
                    welcomeText.Text = "Vous êtes hors ligne.";
                    welcomeText.Show();
                    MessageBox.Show("Vous êtes hors ligne, vous pouvez jouer mais votre score ne sera pas enregistré.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    if (File.Exists(this.userSession))
                    {
                        File.Delete(this.userSession);
                    }

                    //On insère la valeur offline dans le fichier user qui sera lu par le jeu par après
                    using (StreamWriter writer = new StreamWriter(this.userSession, true))
                    {
                        writer.Write("offline");
                    }
                }
                else
                {
                    //Sinon, on ferme l'appli
                    MessageBox.Show("Vous êtes hors ligne et vous n'avez pas téléchargé le jeu. Veuillez vous connecter à internet une première fois afin de pouvoir jouer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            else
            {
                //Si il est connecté à internet, on lance le background worker
                BackgroundDownloader.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //On lance la méthode checkVersion de l'objet updater qui va effectuer la mise à jour    
            this.updater.checkVersion();

        }

        private void ButtonPlay_Click(object sender, EventArgs e)
        {
            //Lancement du jeu et fermeture du launcher
            Process.Start("game\\Roguelike.exe");
            this.Close();
        }
    }
}
