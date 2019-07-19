using System;
using System.Collections.Generic;
using System.Text;

namespace Goal.Repository.Common
{
    public interface IGoalRepository
    {
        Goal GetGoal(int id);

        List<IGoal> GetAllGoals();

        Goal Add(Goal goal);

        Goal Update(Goal goalUpdates);

        Goal Delte(int id);


    }
}
