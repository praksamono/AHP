using System;
using System.Collections.Generic;
using System.Text;
using Model.Common;

namespace Model
{
    public class Goal : IGoal
    {
  
        public Guid GoalId { get; set; }

        public string GoalName { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public List<IAlternative> Alternatives { get; set; }

        public List<ICriterium> Criteriums { get; set; }

        public Goal(string name) {
            this.GoalId = new Guid();
            this.GoalName = name;
        }
    }
}
