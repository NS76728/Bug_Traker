using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bug_Tracker.Models
{
    public interface IUsersRepo
    {
        public Users GetUsers(int ID,string username, string password);
        public Users GetUser1(int ID);

        public void InsertUser(Users users);
        void Updateuser(Users users);
        public void Deleteuser(Users users);
        public IEnumerable<Bugs> Assignedbugs(int ID);

    }
}
