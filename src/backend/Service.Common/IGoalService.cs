using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Model.Common;

namespace AHP.Service.Common
{
    public interface IGoalService
    {
        Task<IGoal> AddGoalAsync(IGoal goal);

        Task<IGoal> GetGoalAsync(Guid goalID);

        Task<List<IGoal>> GetAllGoalsAsync(int page, int pageSize);

        Task<bool> UpdateGoalAsync(IGoal updatedGoal);

        Task<bool> DeleteGoalAsync(Guid goalID);
    }
}