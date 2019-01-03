using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;
using System.ComponentModel;

namespace rogue_launcher
{
    //Classe gérant les mises à jour du jeu
    class Updater
    {
        //Variables nécessaires au fonctionnement de la classe
        private MainScreen form;
        private String localVersion = "localversion";
        private String url = "http://185.213.24.116/~roguelike/updater";
        private String serverVersion;
        private String UpdatedGame;

        //Constructeur prenant l'instance de la Form principale en paramètre
        public Updater(MainScreen f)
        {
            this.form = f;
        }

        public void checkVersion()
        {

            //On vérifie si l'updater a déjà été lancé en vérifiant si le fichier localversion existe
            if (!File.Exists(this.localVersion))
            {
                //S'il n'existe pas, on le crée et on y insert 0 comme version de base
                using(StreamWriter writer = new StreamWriter(this.localVersion, true))
                {
                    writer.Write("0");
                }
            }

            //On initialise le webclient qui va lire le fichier contenant le numéro de version et le chemin vers le jeu à télécharger
            WebClient client = new WebClient();

            Stream stream = client.OpenRead(this.url + "/version.txt");
            StreamReader reader = new StreamReader(stream);

            //On utilise une Liste pour stocker chaque ligne du fichier
            String line;
            List<String> lines = new List<String>();
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
            }

            //Le fichier comporte deux lignes, on les affecte donc chaque ligne aux deux variables ci-dessous
            this.serverVersion = lines[0];
            this.UpdatedGame = lines[1];

            //On récupère le numéro de version contenu dans localversion
            this.localVersion = File.ReadAllText(this.localVersion);

            //Si le numéro de version local diffère de celui disponible en téléchargement, on met à jour le jeu
            if (this.localVersion != this.serverVersion)
            {
                //Avertissement de l'utilisateur
                MessageBox.Show("Une nouvelle version est disponible, elle va être téléchargée.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                //La tâche étant effectuée dans un background worker, on appelle la fonction Invoke afin de pouvoir modifier les éléments présents sur la main form
                this.form.Invoke(new Action(() => {
                    this.form.ButtonConnect.Hide();
                    this.form.ButtonSignup.Hide();
                    this.form.DownloadProgressBar.Show();
                }));

                //On vérifie si le dossier game existe, et si oui on le supprime (afin de laisser la place à la nouvelle version)
                if (Directory.Exists("game"))
                {
                    Directory.Delete("game", true);
                }

                //On vérifie si le fichier qui va être téléchargé existe déjà, et si oui on le supprime
                if (File.Exists("game.zip"))
                {
                    File.Delete("game.zip");
                }

                //On utilise la méthode DownloadFileAsync pour pouvoir modifier la progressbar pendant le téléchargement
                using(WebClient wc = new WebClient())
                {
                    //On utilise l'événement DownloadProgressChanged pour modifier la progressbar au fur et à mesure que le téléchargement avance
                    wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                    wc.DownloadFileAsync(new System.Uri(this.url + "/" + this.UpdatedGame), "game.zip");
                }

                FileInfo file = new FileInfo("game.zip");

                //On vérifie si le fichier et toujours en cours d'utilisation, et si oui on attend
                while (DownloadingFile(file)) {
                    //Ne rien faire
                };

                this.localVersion = "localversion";

                ExtractGame();

            }
        }

        //Fonction permettant d'extraire le zip du jeu dans le dossier "game"
        public void ExtractGame()
        {
            ZipFile.ExtractToDirectory("game.zip", "game");

            //On supprime le fichier à la fin de l'extraction
            if (File.Exists("game.zip"))
            {
                File.Delete("game.zip");
            }

            //On écrit le nouveau numéro de version dans le fichier texte
            File.WriteAllText(this.localVersion, this.serverVersion);

            MessageBox.Show("Mise à jour terminée !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.form.Invoke(new Action(() => {
                this.form.ButtonConnect.Show();
                this.form.ButtonSignup.Show();
                this.form.DownloadProgressBar.Hide();
            }));
        }

        //Événement permettant la modification de la progressbar
        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.form.Invoke(new Action(() => {
                this.form.DownloadProgressBar.Value = e.ProgressPercentage;
            }));
        }

        //Fonction permettant de verifier si un fichier est disponible ou non
        private bool DownloadingFile(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //On renvoie true si on ne peut pas ouvrir le fichier
                return true;
            }
            finally
            {
                //Si on arrive à ouvrir le fichier, on ferme le stream et on renvoie false
                if (stream != null)
                    stream.Close();
            }
            return false;
        }
    }
}
