using System;
using System.Collections.Generic;
using System.Text;

using Model.Common;

using System.ComponentModel.DataAnnotations;


namespace Model
{
    public class CriteriumAlternative : ICriteriumAlternative
    {
        public Guid CriteriumAlternativeId { get; set; }

        public Guid CriteriumId { get; set; }

        public ICriterium criterium { get; set; }

        public Guid AlternativeId { get; set; }

        public IAlternative alternative { get; set; }

        [Range(minimum: -9.0, maximum: 9.0)]
        public float LocalPriority { get; set; }
    
    }
}
