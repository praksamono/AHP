using Model.Common;
using System;
using System.Collections.Generic;

namespace Model
{
    public class Criterium
    {
        public Guid CriteriumId { get; set; }

        public string CriteriumName { get; set; }

        public float GlobalCriteriumPriority { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public List<ICriteriumAlternative> criteriumAlternative { get; set; }
    }
}