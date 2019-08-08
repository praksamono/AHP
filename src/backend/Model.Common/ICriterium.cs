﻿using System;
using System.Collections.Generic;

namespace Model.Common
{
    public interface ICriterium
    {
        Guid Id { get; set; }

        string CriteriumName { get; set; }

        float GlobalCriteriumPriority { get; set; }

        DateTime DateCreated { get; set; }

        DateTime DateUpdated { get; set; }

        List<ICriteriumAlternative> criteriumAlternative { get; set; }

        Guid GoalId { get; set; }

        IGoal Goal { get; set; }

        int Order { get; set; }
    }
}