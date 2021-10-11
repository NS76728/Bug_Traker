using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Bug_Tracker.Models
{
    public class BugsRepo : IBugsRepo
    {
        private readonly IDbConnection _conn;
        public BugsRepo(IDbConnection conn)
        {
            _conn = conn;
        }
        public void DeleteBug(Bugs bugs)
        {
            _conn.Execute("DELETE FROM Bugs where ID = @ID; ",
                                       new { ID = bugs.ID });
        }

        public IEnumerable<Bugs> GetAllBugs()
        {
            return _conn.Query<Bugs>("SELECT * FROM Bugs;");
        }

        public Bugs GetBug(int ID)
        {
            return _conn.QuerySingle<Bugs>("SELECT * FROM Bugs WHERE ID = @id;",
               new { id = ID });
        }

        public void InsertBug(Bugs bugsToInsert)
        {
            _conn.Execute("INSERT INTO bugs (ID, Project, Description, Type, Status, Date, Assigneduser) VALUES (@id, @project, @description, @type, @status, @date, @assigneduser);",
                new { id = bugsToInsert.ID, project = bugsToInsert.Project, description = bugsToInsert.Description, type = bugsToInsert.Type, status = bugsToInsert.Status, date = bugsToInsert.Date, assigneduser = bugsToInsert.AssignedUser });
        }

       

        public void UpdateBug(Bugs bugs)
        {
            _conn.Execute("UPDATE bugs SET ID = @id, Project = @project, Description =@description, Type=@type, Status=@status, Date=@date, Assigneduser=@assigneduser WHERE ID = @id",
                 new { id=bugs.ID, project=bugs.Project, description =bugs.Description, type=bugs.Type, status=bugs.Status, date=bugs.Date, assigneduser = bugs.AssignedUser });
        }


        public IEnumerable<Bugs> SearchBug(string searchString)
        {
            return _conn.Query<Bugs>("SELECT * FROM Bugs WHERE Project Like @project;",
                new { project = "%" + searchString + "%" });
        }

        //public void InsertImage(Bugs bugs)
        //{
        //    _conn.Execute("UPDATE bugs SET Image = @image WHERE ID = @id;",
        //        new { id = bugs.ID, image = bugs.Image });
        //}




    }
}
