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
        public async Task<IGoal> AddGoalAsync(IGoal goal)
        {
            //add exception handling

            return await goalRepository.AddGoalAsync(goal);
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

        public async Task<bool> UpdateGoalAsync(IGoal updatedGoal)
        {
            //add exception handling
            await goalRepository.UpdateGoalAsync(updatedGoal);
            return true;
        }

        public async Task<bool> DeleteGoalAsync(Guid goalID)
        {
            //add exception handling

            return await goalRepository.DeleteGoalAsync(goalID);
        }
    }
}
