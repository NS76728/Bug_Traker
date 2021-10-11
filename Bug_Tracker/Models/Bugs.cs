using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bug_Tracker.Models
{
    public class Bugs
    {
        public int ID { get; set; }
        public string Project { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public string Status { get; set; }

        public int Date { get; set; }
        public string AssignedUser { get; set; }
        //public string Image { get; set; }


    }
}
