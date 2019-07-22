using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class CriteriumEntity
    {
        [Key]
        public int CriteriumId { get; set; }

        public string CriteriumName { get; set; }

        public float GlobalCriteriumPriority { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public List<CriteriumAlternativeEntity> CriteriumAlternatives { get; set; }

    }
}