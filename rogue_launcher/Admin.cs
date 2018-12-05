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
    public partial class Admin : Form
    {
        private Cbdd bdd = new Cbdd();
        private List<User> users = null;
        public Admin()
        {
            InitializeComponent();
            users = bdd.ShowUsers();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

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

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                if (bdd.DeleteUser(Convert.ToInt32(listView1.SelectedItems[0].Text)))
                {
                    MessageBox.Show("L'utilisateur a bien été supprimé.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listView1.Items.Clear();
                    this.users = bdd.ShowUsers();
                    FillListView();
                }
            }
        }

        private void FillListView()
        {
            foreach (User user in users)
            {
                ListViewItem list = new ListViewItem();

                list.UseItemStyleForSubItems = false;

                list.Text = Convert.ToString(user.id);
                list.SubItems.Add(user.email);
                list.SubItems.Add(user.pseudo);
                list.SubItems.Add(user.isBan() ? "Oui" : "Non");
                list.SubItems.Add(user.isAdmin() ? "Oui" : "Non");

                listView1.Items.Add(list);
            }
        }
    }
}
