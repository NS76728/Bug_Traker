using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Bug_Tracker.Models
{
    public class UsersRepo : IUsersRepo
    {
        private readonly IDbConnection _conn;
        public UsersRepo(IDbConnection conn)
        {
            _conn = conn;
        }

        public void Deleteuser(Users users)
        {
            _conn.Execute("DELETE FROM users where username like @username ;",
                   new { username = users.UserName });
        }
        
        public Users GetUser1(int ID)
        {
            return _conn.QuerySingle<Users>("SELECT * FROM users WHERE ID = @id;",
                   new { id = ID});
        }

        public Users GetUsers(int ID, string Username,string Password)
        {
            
                return _conn.QuerySingle<Users>("SELECT * FROM users WHERE ID = @id && username = @username && password = @password;",
                   new {id=ID, username=Username, password=Password});
            
        }

        public void InsertUser(Users users)
        {
            _conn.Execute("Insert Into users(username, password,id) Values(@username,@password,@id);",
                new { username = users.UserName, password = users.Password, id = users.ID });
        }

        public void Updateuser(Users users)
        {
            _conn.Execute("UPDATE users SET username = @username, password = @password where id = @id",
                 new { username = users.UserName, password = users.Password, id = users.ID });
        }

        public IEnumerable<Bugs> Assignedbugs(int ID)
        {
            return _conn.Query<Bugs>("SELECT * FROM Bugs WHERE assigneduserid = @id;",
                 new { id=ID});
        }


    }
}
