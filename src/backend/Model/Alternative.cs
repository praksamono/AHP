using Model.Common;
using System.Collections.Generic;

namespace Model
{
    public class Alternative
    {
        int AlternativeId { get; set; }

        string AlternativeName { get; set; }

        float GlobalPriority { get; set; }

        string DateCreated { get; set; }

        string DateUpdated { get; set; }

        List<ICriteriumAlternative> criteriumAlternatives { get; set; }

    }
}