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
    public partial class AccountSettings : Form
    {
        MainScreen form;
        User user;
        Cbdd bdd = new Cbdd();

        public AccountSettings(MainScreen f, User user)
        {
            InitializeComponent();
            this.form = f;
            this.user = user;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (passwd.Text != "" && confpasswd.Text != "")
            {
                if (passwd.Text == confpasswd.Text)
                {
                    this.user.Password = passwd.Text;

                    if (bdd.UpdateUser(this.user))
                    {
                        MessageBox.Show("Votre mot de passe a bien été modifié.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Les mots de passe ne correspondent pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Merci de remplir tous les champs.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer votre compte ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                if (bdd.DeleteUser(this.user.Id))
                {
                    MessageBox.Show("Votre compte a bien été supprimé.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (File.Exists("user"))
                    {
                        File.Delete("user");
                    }

                    this.form.user = null;
                    this.form.ButtonPlay.Hide();
                    this.form.Settingspic.Hide();
                    this.form.ButtonConnect.Show();
                    this.form.ButtonSignup.Show();
                    this.Close();
                }
            }
        }
    }
}
