using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class CriteriumAlternativeEntity {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CriteriumAlternativeId { get; set;}
    
        public Guid CriteriumId { get; set; }

        public CriteriumEntity CriteriumEntity { get; set; }

        [Key]
        public Guid AlternativeId { get; set; }

        public AlternativeEntity AlternativeEntity { get; set; }

        [Range(minimum: -9.0, maximum: 9.0)]
        public float LocalPriority { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}