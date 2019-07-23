using Model.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Criterium
    {
        public int CriteriumId { get; set; }

        public string CriteriumName { get; set; }

        [Range(minimum: -9.0, maximum: 9.0)]
        public float GlobalCriteriumPriority { get; set; }

        public string DateCreated { get; set; }

        public string DateUpdated { get; set; }

        public List<ICriteriumAlternative> criteriumAlternative { get; set; }
    }
}