using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OregonHikes3.Models
{
    public class Hike
    {
        private List<Hike> hikes = new List<Hike>();
        public int HikeID { get; set; }     //creates a HikeID and maps it as the primary key
        public string TrailName { get; set; }
        public string Region { get; set; }
        public string Description { get; set; }
    }
}
