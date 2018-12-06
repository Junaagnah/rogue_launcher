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
    public partial class EditUser : Form
    {
        private User user;
        private Admin adminForm;
        private Cbdd bdd = new Cbdd();
        public EditUser(User user, Admin admin)
        {
            InitializeComponent();
            this.user = user;
            this.adminForm = admin;

            idlabel.Text = Convert.ToString(this.user.id);
            email.Text = this.user.email;
            username.Text = this.user.pseudo;
            ban.Checked = this.user.isBan();
            adminchk.Checked = this.user.isAdmin();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (email.Text != "" && username.Text != "")
            {
                this.user = null;
                this.user = new User(Convert.ToInt32(idlabel.Text), email.Text, username.Text, adminchk.Checked, ban.Checked);

                if ((passwd.Text != "" || confpasswd.Text != ""))
                {
                    if (passwd.Text == confpasswd.Text)
                    {
                        this.user.setPassword(passwd.Text);
                        if (bdd.UpdateUser(this.user) == true)
                        {
                            MessageBox.Show("L'utilisateur a bien été modifié !", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            adminForm.listView1.Items.Clear();
                            adminForm.users = bdd.ShowUsers();
                            adminForm.FillListView();
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Les mots de passe ne correspondent pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else
                {
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
                MessageBox.Show("Merci de remplir les champs email et nom d'utilisateur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
