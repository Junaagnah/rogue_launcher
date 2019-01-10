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
    //Fenêtre permettant la modification d'un utilisateur
    public partial class EditUser : Form
    {
        //Déclaration des variables nécessaires au fonctionnement de la fenêtre
        private User user;
        private Admin adminForm;
        private Cbdd bdd = new Cbdd();
        //Le constructeur prend en paramètre un utilisateur et la référence de la fenêtre admin qui est la fenêtre précédente
        public EditUser(User user, Admin admin)
        {
            InitializeComponent();
            this.user = user;
            this.adminForm = admin;

            //On remplit les champs de la fenêtre avec les paramètres de l'utilisateur
            idlabel.Text = Convert.ToString(this.user.Id);
            email.Text = this.user.Email;
            username.Text = this.user.Pseudo;
            ban.Checked = this.user.Ban;
            adminchk.Checked = this.user.Admin;
        }

        //Bouton annuler
        private void button2_Click(object sender, EventArgs e)
        {
            //On ferme la fenêtre
            this.Close();
        }

        //Bouton enregistrer
        private void button1_Click(object sender, EventArgs e)
        {
            //On vérifie les tous les champs obligatoires sont bien remplis
            if (email.Text != "" && username.Text != "")
            {
                //On affecte à la variable user les informations contenues dans les champs
                this.user = new User(Convert.ToInt32(idlabel.Text), email.Text, username.Text, adminchk.Checked, ban.Checked);

                //Si les champs mot de passe ou confirmation ne sont pas vides
                if ((passwd.Text != "" || confpasswd.Text != ""))
                {
                    //On vérifie que les mots de passe correspondent bien
                    if (passwd.Text == confpasswd.Text)
                    {
                        //Si c'est le cas, on affecte le nouveau mot de passe à l'utilisateur, puis on appelle la fonction UpdateUser pour mettre à jour l'utilisateur
                        this.user.Password = passwd.Text;
                        if (bdd.UpdateUser(this.user))
                        {
                            //Si tout s'est bien passé, on affiche un message à l'utilisateur et on met à jour la listview du panel administrateur
                            MessageBox.Show("L'utilisateur a bien été modifié !", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            adminForm.listView1.Items.Clear();
                            adminForm.users = bdd.ShowUsers();
                            adminForm.FillListView();
                            //Enfin, on ferme cette fenêtre qui ne sert plus à rien
                            this.Close();
                        }
                    }
                    else
                    {
                        //Sinon, on affiche un message d'erreur
                        MessageBox.Show("Les mots de passe ne correspondent pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else //Si les champs mot de passe et confirmation ne sont pas vides
                {
                    //On appelle la fonction UpdateUser afin de mettre à jour l'utilisateur
                    if (bdd.UpdateUser(this.user) == true)
                    {
                        MessageBox.Show("L'utilisateur a bien été modifié !", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        adminForm.listView1.Items.Clear();
                        adminForm.users = bdd.ShowUsers();
                        adminForm.FillListView();
                        this.Close();
                    }
                }
            }
            else
            {
                //Si les champs obligatoires sont vides, on affiche un message d'erreur
                MessageBox.Show("Merci de remplir les champs email et nom d'utilisateur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
