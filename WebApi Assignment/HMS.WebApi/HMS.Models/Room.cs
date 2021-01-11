using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class Room
    {
        public int rID { get; set; }
        public string rName { get; set; }
        public string rCategory { get; set; }
        public double rPrice { get; set; }
        public bool rIsActive { get; set; }
        public System.DateTime rCreatedDate { get; set; }
        public string rCreatedBy { get; set; }
        public System.DateTime rUpdatedDate { get; set; }
        public string rUpdatedBy { get; set; }
        public Nullable<int> hID { get; set; }
    }
}
