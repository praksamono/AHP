using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class GoalEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid GoalId { get; set; }

        [Required]
        public string GoalName { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public List<AlternativeEntity> Alternatives { get; set; }

        public List<CriteriumEntity> Criteriums { get; set; }

    }
}