using Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Criterium : ICriterium
    {
        public Guid Id { get; set; }

        public string CriteriumName { get; set; }

        [Range(minimum: 0.0, maximum: 1.0)]
        public float GlobalCriteriumPriority { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public List<ICriteriumAlternative> criteriumAlternative { get; set; }

        public Guid GoalId { get; set; }

        public IGoal Goal { get; set; }
    }
}