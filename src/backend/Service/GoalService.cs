using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using AHP.Service.Common;
using Repository.Common;

namespace AHP.Service
{
    class GoalService : IGoalService
    {
        public readonly IGoalRepository goalRepository;
        
        //Constructors
        public GoalService(IGoalRepository goalRepository)
        {
            this.goalRepository = goalRepository;
        }

        //Methods
        public async void CreateGoal(string name)
        {
            
        }

        public async void ReturnGoal()
        {

        }
    }
}
