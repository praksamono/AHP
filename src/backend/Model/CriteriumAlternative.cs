using System;
using System.Collections.Generic;
using System.Text;
using Model.Common;

namespace Model
{
    public class CriteriumAlternative : ICriteriumAlternative
    {
        public Guid CriteriumId { get; set; }

        public ICriterium criterium { get; set; }

        public Guid AlternativeId { get; set; }

        public IAlternative alternative { get; set; }

        public float LocalPriority { get; set; }
    
    }
}
