using Model.Common;
using System.Collections.Generic;

namespace Model
{
    public class Criterium
    {
        public int CriteriumId { get; set; }

        public string CriteriumName { get; set; }

        public float GlobalCriteriumPriority { get; set; }

        public string DateCreated { get; set; }

        public string DateUpdated { get; set; }

        public List<ICriteriumAlternative> criteriumAlternative { get; set; }
    }
}