using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Common
{
    public interface IGoal
    {
        Guid GoalId { get; set; }

        string GoalName { get; set; }

        DateTime DateCreated { get; set; }

        DateTime DateUpdated { get; set; }

        List<IAlternative> Alternatives { get; set; }

        List<ICriterium> Criteriums { get; set; }

    }
}
