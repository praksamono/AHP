using System;
using System.Collections.Generic;

namespace DAL
{
    public class Goal
    {
       /// <summary>
       /// 
       /// </summary>
        public int GoalId { get; set; }

        public string GoalName { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public List<Alternative> Alternatives { get; set; }

        public List<Criterium> Criteriums { get; set; }

    }
}