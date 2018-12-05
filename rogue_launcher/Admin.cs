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
                foreach (User user in users)
                {
                    ListViewItem list = new ListViewItem();

                    list.UseItemStyleForSubItems = false;

                    list.Text = Convert.ToString(user.id);

                    listView1.Items.Add(list);
                }
            }
            else
            {
                MessageBox.Show("Impossible de récupérer les utilisateurs dans la base de données.", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
