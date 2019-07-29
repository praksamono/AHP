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

        [Range(minimum: -9.0, maximum: 9.0)]
        public float GlobalCriteriumPriority { get; set; }

        public List<CriteriumAlternativeEntity> CriteriumAlternatives { get; set; }

        public GoalEntity GoalEntity{ get; set;}

        public Guid GoalId { get; set; }
    }
}