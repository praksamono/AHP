using System.Collections.Generic;

namespace Model.Common
{
    public interface ICriterium
    {
        int CriteriumId { get; set; }

        string CriteriumName { get; set; }

        float GlobalCriteriumPriority { get; set; }

        string DateCreated { get; set; }

        string DateUpdated { get; set; }

        List<ICriteriumAlternative> criteriumAlternative { get; set; }
    }
}