using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class GoalEntity : BaseEntity
    {


        [Required]
        public string GoalName { get; set; }

        public List<AlternativeEntity> Alternatives { get; set; }

        public List<CriteriumEntity> Criteriums { get; set; }
    }
}