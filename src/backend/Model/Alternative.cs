using Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Alternative : IAlternative
    {
        public Guid AlternativeId { get; set; }

        public string AlternativeName { get; set; }

        [Range(minimum: -9.0, maximum: 9.0)]
        public float GlobalPriority { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public List<ICriteriumAlternative> CriteriumAlternatives { get; set; }

        public IGoal Goal { get; set; }

        public Guid GoalId { get; set; }
    }
}