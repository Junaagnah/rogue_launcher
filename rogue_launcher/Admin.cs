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
    //Fenêtre d'administration des utilisateurs
    public partial class Admin : Form
    {
        //Déclaration des variables nécessaires au fonctionnement de la fenêtre du panel admin
        private Cbdd bdd = new Cbdd();
        public List<User> users = null;
        private User selectedUser = null;

        //On remplit la list users d'utilisateurs grâce à la fonction showUsers
        public Admin()
        {
            InitializeComponent();
            users = bdd.ShowUsers();
        }

        //On remplit la listview au chargement de la fenêtre
        private void Admin_Load(object sender, EventArgs e)
        {
            //Si la liste est bien remplie, on remplit la listview, sinon on affiche un message en cas d'erreur
            if (users != null)
            {
                FillListView();
            }
            else
            {
                MessageBox.Show("Impossible de récupérer les utilisateurs dans la base de données.", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        //Bouton supprimer
        private void button2_Click(object sender, EventArgs e)
        {
            //On vérifie que l'utilisateur a bien sélectionné un item de la listview
            if (listView1.SelectedItems.Count > 0)
            {
                //Si oui, on appelle la fonction DeleteUser à laquelle on renvoie l'id de l'utilisateur sélectionné
                if (bdd.DeleteUser(Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text)))
                {
                    //Si tout s'est bien passé, on prévient l'utilisateur et on met à jour la listview
                    MessageBox.Show("L'utilisateur a bien été supprimé.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listView1.Items.Clear();
                    //On n'oublie pas de mettre à jour la liste des utilisateurs
                    this.users = bdd.ShowUsers();
                    FillListView();
                }
            }
            else
            {
                //Si aucun utilisateur n'est sélectionné, on affiche un message d'erreur
                MessageBox.Show("Veuillez sélectionner un utilisateur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Fonction permettant de remplir la listview
        public void FillListView()
        {
            //Pour chaque utilisateur dans la liste users, on remplit chaque colonne de la listview
            foreach (User user in users)
            {
                //Pour chaque ligne on crée un nouvel objet ListViewItem
                ListViewItem list = new ListViewItem();

                list.Text = Convert.ToString(user.id);
                list.SubItems.Add(user.email);
                list.SubItems.Add(user.pseudo);
                list.SubItems.Add(user.isBan() ? "Oui" : "Non");
                list.SubItems.Add(user.isAdmin() ? "Oui" : "Non");

                listView1.Items.Add(list);
            }
        }

        //Bouton éditer
        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                //On affecte à la variable selectedUser un nouvel utilisateur contenant les informations de l'utilisateur sélectionné
                this.selectedUser = new User(Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text), listView1.SelectedItems[0].SubItems[1].Text, listView1.SelectedItems[0].SubItems[2].Text, (listView1.SelectedItems[0].SubItems[4].Text == "Oui" ? true : false), (listView1.SelectedItems[0].SubItems[3].Text == "Oui" ? true : false));

                //On affiche la fenêtre EditUser
                EditUser edituser = new EditUser(selectedUser, this);
                edituser.Show();
            }
            else
            {
                //Si aucun utilisateur n'est sélectionné, on affiche un message d'erreur
                MessageBox.Show("Veuillez sélectionner un utilisateur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Bouton refresh
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            this.users = bdd.ShowUsers();
            FillListView();
        }
    }
}
