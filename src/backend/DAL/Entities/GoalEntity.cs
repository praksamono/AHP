using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class GoalEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// 
        [Key]
        public int GoalId { get; set; }

        public string GoalName { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public List<AlternativeEntity> Alternatives { get; set; }

        public List<CriteriumEntity> Criteriums { get; set; }

    }
}