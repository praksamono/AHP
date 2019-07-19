using System;
using System.Collections.Generic;
using System.Text;
using Model.Common;

namespace Repository.Common
{
    public interface IGoalRepository
    {
        IGoal GetGoal(int goalId);

        List<IGoal> GetAllGoals();

        IGoal Add(IGoal goal);

        IGoal Update(IGoal goalUpdates);

        IGoal Delete(int goalId);


    }
}
