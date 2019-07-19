using System;
using System.Collections.Generic;

namespace DAL
{
    public class Criterium
    {
        public int CriteriumId { get; set; }

        public string CriteriumName { get; set; }

        public float GlobalCriteriumPriority { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public List<Criterium_Alternative> criterium_alternatives { get; set; }

    }
}