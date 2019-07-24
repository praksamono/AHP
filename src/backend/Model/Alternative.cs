using Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Alternative
    {
        Guid AlternativeId { get; set; }

        string AlternativeName { get; set; }

        [Range(minimum: -9.0, maximum: 9.0)]
        float GlobalPriority { get; set; }

        DateTime DateCreated { get; set; }

        DateTime DateUpdated { get; set; }

        List<ICriteriumAlternative> criteriumAlternatives { get; set; }

    }
}