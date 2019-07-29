using System;
using System.Collections.Generic;
using System.Text;

using Model.Common;

using System.ComponentModel.DataAnnotations;


namespace Model
{
    public class CriteriumAlternative : ICriteriumAlternative
    {
        public Guid Id { get; set; }

        public Guid CriteriumId { get; set; }

        public ICriterium Criterium { get; set; }

        public Guid AlternativeId { get; set; }

        public IAlternative Alternative { get; set; }

        [Range(minimum: -9.0, maximum: 9.0)]
        public float LocalPriority { get; set; }
    
    }
}
