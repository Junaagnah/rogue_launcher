using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rogue_launcher
{
    //Classe permettant d'effectuer des opérations sur les mots de passe
    public static class Password
    {
        private static string errorMsg;

        public static string ErrorMsg { get => errorMsg; set => errorMsg = value; }

        //Vérifie si le mot de passe est valide
        public static bool checkPasswd(string password)
        {
            bool isPasswd = false;
            bool upperCase = false;
            bool lowerCase = false;
            bool number = false;
            ErrorMsg = "";

            if (password.Length >= 7 && password.Length <= 20)
            {
                for (int i = 0; i < password.Length; i++)
                {
                    if (password[i] == ' ')
                    {
                        ErrorMsg = "Votre mot de passe ne peut pas contenir d'espace.";
                        break;
                    }
                }

                if (ErrorMsg == "")
                {
                    for (int i = 0; i < password.Length; i++)
                    {
                        if (Char.IsUpper(password[i]))
                        {
                            upperCase = true;
                        }

                        if (Char.IsLower(password[i]))
                        {
                            lowerCase = true;
                        }

                        if (Char.IsNumber(password[i]))
                        {
                            number = true;
                        }
                    }

                    if (!upperCase || !lowerCase || !number)
                    {
                        ErrorMsg = "Votre mot de passe doit contenir au moins une lettre minuscule, une lettre majuscule et un chiffre.";
                    }
                    else
                    {
                        isPasswd = true;
                    }
                }
            }
            else
            {
                ErrorMsg = "Votre mot de passe doit être compris entre 7 et 20 caractères inclus.";
            }

            if (!isPasswd)
            {
                MessageBox.Show(ErrorMsg, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isPasswd;
        }
    }
}
