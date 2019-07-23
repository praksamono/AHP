using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Common
{
    public interface ICriteriumAlternative
    {
        int CriteriumId { get; set; }

        ICriterium criterium { get; set; }

        int AlternativeId { get; set; }

        IAlternative alternative { get; set; }

        float LocalPriority { get; set; }
    }
}
