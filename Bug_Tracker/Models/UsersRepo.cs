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
            _conn.Execute("DELETE FROM users username like @username; ",
                   new { username = users.UserName });
        }

        public Users GetUsers(string UserName)
        {
            
                return _conn.QuerySingle<Users>("SELECT * FROM users WHERE username like @username;",
                   new { username = UserName });
            
        }

        public void InsertUser(Users users)
        {
            _conn.Execute("Insert Into users(username, password) Values(@username,@passwrod);",
                new { username = users.UserName, password = users.Password });
        }

        public void UpdateUser(Users users)
        {
            _conn.Execute("UPDATE users SET username = @username, password = @password",
                 new { username = users.UserName, password = users.Password });
        }
    }
}
