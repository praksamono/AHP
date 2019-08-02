using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class AlternativeEntity : BaseEntity
    {
   
        [Required]
        public string AlternativeName { get; set; }

        [Range(minimum: 0.0, maximum: 1.0)]
        public float GlobalPriority { get; set; }

        public List<CriteriumAlternativeEntity> CriteriumAlternatives { get; set; }

        public GoalEntity GoalEntity { get; set; }

        public Guid GoalId { get; set; }

    }
}