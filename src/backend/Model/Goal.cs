using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Goal 
    {

        public int GoalId { get; set; }

        public string GoalName { get; set; }

        public string DateCreated { get; set; }

        public string DateUpdated { get; set; }

        public List<Alternative> Alternatives { get; set; }

        public List<Criterium> Criteriums { get; set; }
    }
}
