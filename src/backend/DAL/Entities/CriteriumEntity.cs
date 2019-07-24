using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class CriteriumEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CriteriumId { get; set; }

        [Required]
        public string CriteriumName { get; set; }

        [Range(minimum: -9.0, maximum: 9.0)]
        public float GlobalCriteriumPriority { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public List<CriteriumAlternativeEntity> CriteriumAlternatives { get; set; }

        public GoalEntity goalEntity{ get; set;}

    }
}