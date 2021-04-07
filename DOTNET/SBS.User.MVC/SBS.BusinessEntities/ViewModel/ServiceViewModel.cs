using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BusinessEntities.ViewModel
{
    public class ServiceViewModel
    {
        public int ID { get; set; }
        public string ServiceName { get; set; }
        public double Price { get; set; }
        public string Duration { get; set; }
        public bool IsActive { get; set; }
        public int mechanicID { get; set; }
    }
}
