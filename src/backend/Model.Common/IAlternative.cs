using System;
using System.Collections.Generic;

namespace Model.Common
{
    public interface IAlternative
    {
        Guid AlternativeId { get; set; }

        string AlternativeName { get; set; }

        float GlobalPriority { get; set; }

        DateTime DateCreated { get; set; }

        DateTime DateUpdated { get; set; }

        List<ICriteriumAlternative> criteriumAlternatives { get; set; }

    }
}