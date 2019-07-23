using System;
using System.Collections.Generic;
using System.Text;
using Repository.Common;
using DAL;
using Model.Common;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Repository 
{
    public class GoalRepository : IGoalRepository
    {

        public GoalRepository(AHPContext context)
        {
            this.Context = context;
        }

        protected AHPContext Context { get; private set; }

        public async Task<IGoal> GetGoalAsync(int goalId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<IGoal>> GetAllGoalsAsync()
        {

            throw new NotImplementedException();

            //return await Context.Goals.ToListAsync();

            //var goals = Context.Goals;
            //return await goals.ToListAsync();

            //return await new List<IGoal>(AutoMapper.Mapper.Map<List<Goal>>(Context.Goals));

        }

        public async Task<IGoal> AddGoalAsync(IGoal goal)
        {
            throw new NotImplementedException();

        }
    
        public async Task<IGoal> UpdateGoalAsnyc(IGoal goalUpdates)
        {
            throw new NotImplementedException();
        }

        public async Task<IGoal> DeleteGoalAsync(int goalId)
        {
            throw new NotImplementedException();
        }
    }
}
