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

        Task<bool> UpdateGoalAsnyc(IGoal goalUpdate);

        Task<bool> DeleteGoalAsync(int goalId);
    }
}
