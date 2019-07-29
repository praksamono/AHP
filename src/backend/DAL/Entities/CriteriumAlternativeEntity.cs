using DAL.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class CriteriumAlternativeEntity : BaseEntity
    {

        [Key]
        public Guid CriteriumId { get; set; }

        public CriteriumEntity CriteriumEntity { get; set; }

        [Key]
        public Guid AlternativeId { get; set; }

        public AlternativeEntity AlternativeEntity { get; set; }

        [Range(minimum: -9.0, maximum: 9.0)]
        public float LocalPriority { get; set; }
    }
}