using System;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using rogue_launcher;

//Tester c'est douter

namespace UnitTestLauncher
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPasswordMin7Chars()
        {
            string password = "12345";
            Password.checkPasswd(password);
            Assert.AreEqual(Password.ErrorMsg, "Votre mot de passe doit être compris entre 7 et 20 caractères inclus.");
        }

        [TestMethod]
        public void TestPasswordSup20Chars()
        {
            string password = "822383281234567873498379487398479347";
            Password.checkPasswd(password);
            Assert.AreEqual(Password.ErrorMsg, "Votre mot de passe doit être compris entre 7 et 20 caractères inclus.");
        }

        [TestMethod]
        public void TestPasswordNoSpaces()
        {
            string password = "1234 567";
            Password.checkPasswd(password);
            Assert.AreEqual(Password.ErrorMsg, "Votre mot de passe ne peut pas contenir d'espace.");
        }

        [TestMethod]
        public void TestPasswordMajAndNumbers()
        {
            string password = "822383281234567";
            Password.checkPasswd(password);
            Assert.AreEqual(Password.ErrorMsg, "Votre mot de passe doit contenir au moins une lettre minuscule, une lettre majuscule et un chiffre.");
        }

        [TestMethod]
        public void TestPasswordIsOK()
        {
            string password = "Gh6836kfohd849d";
            Password.checkPasswd(password);
            Assert.AreEqual(Password.ErrorMsg, "");
        }

        [TestMethod]
        public void TestInscriptionEmail()
        {
            Signup signup = new Signup();
            signup.Inscription("tatatatatatatatata", "tatatata", "tatatata", "tatatata");
            Assert.AreEqual(false, signup.IsEmail);
        }

        [TestMethod]
        public void CheckPseudoErreur()
        {
            Signup signup = new Signup();
            signup.checkPseudo("coucou coucou");
            Assert.AreEqual("Votre pseudo ne peut pas contenir d'espace.", signup.ErrorMsg);
        }

        [TestMethod]
        public void CheckPseudoFalse()
        {
            Signup signup = new Signup();
            bool result = signup.checkPseudo("coucou coucou");
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void CheckPseudoTrue()
        {
            Signup signup = new Signup();
            bool result = signup.checkPseudo("coucoucoucou");
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void CheckPasswordsAreNotSame()
        {
            Signup signup = new Signup();

            Assert.ThrowsException<ArgumentException>(
                () => signup.CheckPasswordEquals("1234Checklol", "4567Checklol")
                );
        }
    }
}
