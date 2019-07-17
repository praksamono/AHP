using System;
using System.Collections.Generic;

namespace DAL
{
    public class Alternative
    {
        public int AlternativeId { get; set; }

        public string AlternativeName { get; set; }

        public float GlobalPriority { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public List<Criterium_Alternative> criterium_alternatives { get; set; }

    }
}