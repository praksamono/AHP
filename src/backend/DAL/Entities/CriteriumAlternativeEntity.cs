using System;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class CriteriumAlternativeEntity {

        [Key]
        CriteriumAlternativeEntity CriteriumAlternativeId { get; set;}
    
        public int CriteriumId { get; set; }

        public CriteriumEntity Criterium { get; set; }

        [Key]
        public int AlternativeId { get; set; }

        public AlternativeEntity Alternative { get; set; }

        public float LocalPriority { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}