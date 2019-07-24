using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using AHP.Service.Common;
using Repository.Common;
using Model.Common;

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
        public async void AddGoalAsync(IGoal goal)
        {
            //add exception handling

            await goalRepository.AddGoalAsync(goal);
        }

        public async Task<IGoal> GetGoalAsync(Guid goalID)
        {
            //add exception handling

            return await goalRepository.GetGoalAsync(goalID);
        }

        public async Task<List<IGoal>> GetAllGoalsAsync()
        {
            //add exception handling

            return await goalRepository.GetAllGoalsAsync();
        }

        public async void UpdateGoalAsync()
        {
            //add exception handling
 
        }

        public async void DeleteGoalAsync(Guid goalID)
        {
            //add exception handling

            await goalRepository.DeleteGoalAsync(goalID);
        }
    }
}
