using registracia.model;
using registracia.viev;
using System;

namespace registracia.controler
{
    class UserGetSet
    {

        public static string[] SetNewUser(string name, string email, string pass)
        {
            string[] st = { name, email, pass };
            string user = DataBase.CreateUser(st);

            string[] userField = user.Split('&');
            for (int i = 0; i < userField.Length; i++)
            {
                string[] temp = userField[i].Split('=');
                userField[i] = temp[1];
            }

            return userField;
        }

        public static string[] GetUser(string email, string pass)
        {
            return GetUserInDataBase(email, pass);
        }


        private static string[] GetUserInDataBase(int id) {

            string userSt = DataBase.GetUser(id);

            string[] userField = userSt.Split('&');
            for (int i = 0; i < userField.Length; i++) {
                userField[i] = userField[i].TrimStart('=');
            }
            return userField;
        }

        private static string[] GetUserInDataBase(string email, string pass)
        {
            string userSt = DataBase.GetUser(email, pass);
            try
            {
                string[] userField = userSt.Split('&');
                for (int i = 0; i < userField.Length; i++)
                {
                    string[] temp = userField[i].Split('=');
                    userField[i] = temp[1];
                }
                return userField;
            }
            catch 
            {
                throw new Exception($"{userSt}");
            }
        }
    }
}
