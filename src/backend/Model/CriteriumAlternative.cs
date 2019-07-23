using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    class CriteriumAlternative
    {
        public int CriteriumId { get; set; }

        public Criterium criterium { get; set; }

        public int AlternativeId { get; set; }

        public Alternative alternative { get; set; }

        [Range(minimum: -9.0, maximum: 9.0)]
        public float LocalPriority { get; set; }
    }
}
