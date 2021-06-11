using registracia.controler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace registracia.viev
{
    public class User
    {
        private string email;
        private string name;
        private string pass;
        private int id;

        public string Email
        {
            get
            {
                return email;
            }
        }
        public string Pass { get { return pass; } }
        public int Id { get { return id; } }
        public string Name { get { return name; } }

        public User()
        {
        }
        public User(int id, string name, string email, string pass)
        {
            this.email = email;
            this.id = id;
            this.pass = pass;
            this.name = name;
        }

        public User NewUser(string name, string email, string pass)
        {
            try
            {
                UserGetSet.GetUser(email, pass);
                throw new Exception("Email in Base");
            }
            catch (Exception ex) {
                if(ex.Message == "Email in Base" || ex.Message == "Error: Password non correct")+096jh6
                     throw new Exception("Такой пользователь есть");
            }


            string[] userField = UserGetSet.SetNewUser(name, email, pass);
            User user = new User(id = Convert.ToInt32(userField[0]), name = userField[1], email = userField[2], pass = userField[3]);
            return user;
        }

        public User CheckUser(string email, string pass)
        {
            string[] userField = UserGetSet.GetUser(email, pass);
            return new User(id = Convert.ToInt32(userField[0]), name = userField[1], email = userField[2], pass = userField[3]);
        }
    }
}
