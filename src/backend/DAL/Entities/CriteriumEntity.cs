using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class CriteriumEntity : BaseEntity
    {

        [Required]
        public string CriteriumName { get; set; }

        [Range(minimum: 0.0, maximum: 1.0)]
        public float GlobalCriteriumPriority { get; set; }

        public List<CriteriumAlternativeEntity> CriteriumAlternatives { get; set; }

        public GoalEntity GoalEntity{ get; set;}

        public Guid GoalId { get; set; }

        public int Order { get; set; }
    }
}