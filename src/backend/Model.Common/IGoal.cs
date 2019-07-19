using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Common
{
    public interface IGoal
    {
        int GoalId { get; set; }

        string GoalName { get; set; }

        string DateCreated { get; set; }

        string DateUpdated { get; set; }

        List<IAlternative> Alternatives { get; set; }

        List<ICriterium> Criteriums { get; set; }

    }
}
