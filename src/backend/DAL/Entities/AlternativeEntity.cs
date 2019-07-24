using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class AlternativeEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AlternativeId { get; set; }

        [Required]
        public string AlternativeName { get; set; }

        [Range(minimum: -9.0, maximum: 9.0)]
        public float GlobalPriority { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public List<CriteriumAlternativeEntity> CriteriumAlternatives { get; set; }

        public GoalEntity goalEntity { get; set; }

    }
}