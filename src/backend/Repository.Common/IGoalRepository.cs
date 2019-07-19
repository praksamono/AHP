using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model.Common;

namespace Repository.Common
{
    public interface IGoalRepository
    {
        Task<IGoal> GetGoalAsync(int goalId);

        Task<List<IGoal>> GetAllGoalsAsync();

        Task<IGoal> AddGoalAsync(IGoal goal);

        Task<IGoal> UpdateGoalAsnyc(IGoal goalUpdates);

        Task<IGoal> DeleteGoalAsync(int goalId);

    }
}
