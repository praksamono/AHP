using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    class CriteriumAlternative
    {
        public int CriteriumId { get; set; }

        public Criterium criterium { get; set; }

        public int AlternativeId { get; set; }

        public Alternative alternative { get; set; }

        public float LocalPriority { get; set; }
    }
}
