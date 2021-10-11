using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bug_Tracker.Models
{
    public interface IUsersRepo
    {
        public Users GetUsers(string UserName);
        public void InsertUser(Users users);
        void UpdateUser(Users users);
        public void Deleteuser(Users users);
    }
}
