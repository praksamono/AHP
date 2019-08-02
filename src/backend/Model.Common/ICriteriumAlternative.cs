using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Common
{
    public interface ICriteriumAlternative
    {
        Guid Id { get; set; }

        Guid CriteriumId { get; set; }

        ICriterium Criterium { get; set; }

        Guid AlternativeId { get; set; }

        IAlternative Alternative { get; set; }

        float LocalPriority { get; set; }
    }
}
