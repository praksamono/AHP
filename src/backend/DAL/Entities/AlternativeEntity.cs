using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class AlternativeEntity
    {
        [Key]
        public Guid AlternativeId { get; set; }

        public string AlternativeName { get; set; }

        public float GlobalPriority { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public List<CriteriumAlternativeEntity> CriteriumAlternatives { get; set; }

    }
}