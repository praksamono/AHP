using System;
using System.Collections.Generic;
using System.Text;
using Model.Common;

namespace Model
{
    public class Goal : IGoal
    {

        public int GoalId { get; set; }

        public string GoalName { get; set; }

        public string DateCreated { get; set; }

        public string DateUpdated { get; set; }

        public List<IAlternative> Alternatives { get; set; }

        public List<ICriterium> Criteriums { get; set; }
    }
}
