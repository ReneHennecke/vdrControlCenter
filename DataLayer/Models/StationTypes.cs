using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class StationTypes
    {
        public StationTypes()
        {
            Stations = new HashSet<Stations>();
        }

        public int RecId { get; set; }
        public string StationType { get; set; }

        public virtual ICollection<Stations> Stations { get; set; }
    }
}
