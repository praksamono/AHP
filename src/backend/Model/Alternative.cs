using Model.Common;
using System;
using System.Collections.Generic;

namespace Model
{
    public class Alternative
    {
        Guid AlternativeId { get; set; }

        string AlternativeName { get; set; }

        float GlobalPriority { get; set; }

        DateTime DateCreated { get; set; }

        DateTime DateUpdated { get; set; }

        List<ICriteriumAlternative> criteriumAlternatives { get; set; }

    }
}