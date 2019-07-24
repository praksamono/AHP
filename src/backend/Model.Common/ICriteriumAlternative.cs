using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Common
{
    public interface ICriteriumAlternative
    {
        Guid CriteriumId { get; set; }

        ICriterium criterium { get; set; }

        Guid AlternativeId { get; set; }

        IAlternative alternative { get; set; }

        float LocalPriority { get; set; }
    }
}
