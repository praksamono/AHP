using Model.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Alternative
    {
        int AlternativeId { get; set; }

        string AlternativeName { get; set; }

        [Range(minimum: -9.0, maximum: 9.0)]
        float GlobalPriority { get; set; }

        string DateCreated { get; set; }

        string DateUpdated { get; set; }

        List<ICriteriumAlternative> criteriumAlternatives { get; set; }

    }
}