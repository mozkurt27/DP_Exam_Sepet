using DP_Exam_Sepet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Exam_Sepet.Managers
{
    class UserManager
    {
        public bool CheckCredentials(string username, string password, List<AppUser> users)
        {
            foreach (var user in users)
            {
                if (user.Username == username && user.Password == password)
                    return true;
            }

            return false;
        }
        public bool CheckByUsername(string username,List<AppUser> users)
        {
            foreach (var user in users)
            {
                if (user.Username == username)
                    return true;
            }

            return false;
        }

        public AppUser FindByUsername(string username, DataHolder data)
        {
            foreach (AppUser user in data.Users)
            {
                if (user.Username == username)
                    return user;
            }

            return null;
        }

        public bool ExistingUser(string username, DataHolder data)
        {
            foreach (AppUser user in data.Users)
            {
                if (user.Username == username)
                    return true;
            }

            return false;
        }
    }
}
