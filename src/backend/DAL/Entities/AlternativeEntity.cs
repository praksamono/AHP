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

        [Range(minimum: -9.0, maximum: 9.0)]
        public float GlobalPriority { get; set; }

        public List<CriteriumAlternativeEntity> CriteriumAlternatives { get; set; }

        public GoalEntity GoalEntity { get; set; }

        public Guid GoalId { get; set; }

    }
}