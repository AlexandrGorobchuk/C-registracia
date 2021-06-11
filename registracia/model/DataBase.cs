using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace registracia.model
{
    class DataBase
    {
        private static string url = @"c:\users\user\source\repos\registracia\registracia\model\UserDB.txt";

        // Создаем User. Возвращаем Id
        public static string CreateUser(string[] newUser)
        {
            int userId;
            string line;
            List<string> listIds = new List<string>();
            using (StreamReader sr = new StreamReader(url))
            {
                //string idDB = sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    listIds.Add(line);
                }
            }
            userId = Convert.ToInt32(listIds[0]);
            ++userId;
            listIds.RemoveAt(0);

            string user = $"id={userId}&name={newUser[0]}&email={newUser[1]}&pass={newUser[2]}";

            using (StreamWriter sw = new StreamWriter(url, false))
            {
                sw.WriteLine(userId);
            }

            using (StreamWriter sw = new StreamWriter(url, true))
            {
                listIds.ForEach((string line1) =>
                {
                    sw.WriteLine(line1);
                });
                sw.WriteLine(user);
            }

            return user;
        }

        public static string GetUser(int userId)
        {
            List<string> lineUser = new List<string>();
            string line;
            using (StreamReader sw = new StreamReader(url))
            {
                while ((line = sw.ReadLine()) != null)
                {
                    lineUser.Add(line);
                }
            }
            lineUser.RemoveAt(0);
            for (int i = 0; i < lineUser.Count; i++)
            {
                string[] user = lineUser[i].Split('&');
                if (user[0].Contains(Convert.ToString(userId)) == true)
                {
                    return lineUser[i];
                }
            }
            return null;
        }

        public static string GetUser(string email, string pass)
        {
            List<string> lineUser = new List<string>();
            string line;
            using (StreamReader sw = new StreamReader(url))
            {
                while ((line = sw.ReadLine()) != null)
                {
                    lineUser.Add(line);
                }
            }
            lineUser.RemoveAt(0);

            for (int i = 0; i < lineUser.Count; i++)
            {
                string[] user = lineUser[i].Split('&');

                if (user[2].Contains(email) == true)
                {
                    if (user[3].Contains(pass) == true)
                        return lineUser[i];
                    else
                        return "Error: Password non correct";
                }
            }
            return "Error: Email non found";
        }

    }
}
