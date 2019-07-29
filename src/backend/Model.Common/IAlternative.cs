using System;
using System.Collections.Generic;

namespace Model.Common
{
    public interface IAlternative
    {
        Guid Id { get; set; }

        string AlternativeName { get; set; }

        float GlobalPriority { get; set; }

        DateTime DateCreated { get; set; }

        DateTime DateUpdated { get; set; }

        List<ICriteriumAlternative> CriteriumAlternatives { get; set; }

        Guid GoalId { get; set; }

        IGoal Goal { get; set; }

    }
}