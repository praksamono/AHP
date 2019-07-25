using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model.Common;

namespace Repository.Common
{
    public interface IGoalRepository
    {
        Task<IGoal> GetGoalAsync(Guid goalId);

        Task<List<IGoal>> GetAllGoalsAsync();

        Task<IGoal> AddGoalAsync(IGoal goal);

        Task<bool> UpdateGoalAsync(IGoal goalUpdate);

        Task<bool> DeleteGoalAsync(Guid goalId);
    }
}
