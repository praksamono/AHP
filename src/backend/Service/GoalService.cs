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
        
        public GoalService(IGoalRepository goalRepository)
        {
            this.goalRepository = goalRepository;
        }

        public Task<IGoal> AddGoalAsync(IGoal goal)
        {
            return goalRepository.AddGoalAsync(goal);
        }

        public Task<IGoal> GetGoalAsync(Guid goalID)
        {
            return goalRepository.GetGoalAsync(goalID);
        }

        public Task<List<IGoal>> GetAllGoalsAsync(int page, int pageSize)
        {
            return goalRepository.GetAllGoalsAsync(page, pageSize);
        }

        public Task<bool> UpdateGoalAsync(IGoal updatedGoal)
        {
            return goalRepository.UpdateGoalAsync(updatedGoal);
        }

        public Task<bool> DeleteGoalAsync(Guid goalID)
        {
            return goalRepository.DeleteGoalAsync(goalID);
        }
    }
}
