using System;
using System.Collections.Generic;

namespace Model.Common
{
    public interface ICriterium
    {
        Guid CriteriumId { get; set; }

        string CriteriumName { get; set; }

        float GlobalCriteriumPriority { get; set; }

        DateTime DateCreated { get; set; }

        DateTime DateUpdated { get; set; }

        List<ICriteriumAlternative> criteriumAlternative { get; set; }
    }
}