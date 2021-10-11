using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bug_Tracker.Models
{
    public interface IBugsRepo
    {
        public IEnumerable<Bugs> GetAllBugs();
        public Bugs GetBug(int ID);
        void UpdateBug(Bugs bugs);
        public void InsertBug(Bugs bugsToInsert);
        public void DeleteBug(Bugs bugs);

        public IEnumerable<Bugs> SearchBug(string searchString);


        //public void InsertImage(Bugs bugs);
    }
}
