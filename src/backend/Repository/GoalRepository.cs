using System;
using System.Collections.Generic;
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
        private readonly IMapper Mapper;

        public GoalRepository(IMapper mapper, AHPContext context)
        {
            this.Mapper = mapper;
            this.Context = context;
        }

        protected AHPContext Context { get; private set; }

        public async Task<IGoal> GetGoalAsync(Guid goalId)
        {
            var getGoal = await Context.Goals.SingleOrDefaultAsync(x => x.Id == goalId);
            return Mapper.Map<IGoal>(getGoal);
        }

        public async Task<List<IGoal>> GetAllGoalsAsync(int page, int pageSize)
        {
            var allGoals = await Context.Goals.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return Mapper.Map<List<IGoal>>(allGoals);
        }

        public async Task<IGoal> AddGoalAsync(IGoal goal)
        {
            goal.Id = Guid.NewGuid();
            goal.DateCreated = DateTime.UtcNow;
            goal.DateUpdated = DateTime.UtcNow;

            Context.Goals.Add(Mapper.Map<IGoal, GoalEntity>(goal));
            await Context.SaveChangesAsync();
            return goal;
        }
        /// <summary>
        /// Updates a goal name.
        /// </summary>
        /// <param name="goalUpdate">Updated IGoal object with the new name.</param>
        /// <returns></returns>
        public async Task<bool> UpdateGoalAsync(IGoal goalUpdate)
        {
            Guid id = goalUpdate.Id;
            string newName = goalUpdate.GoalName;

            // Retrieve entity by id
            var entity = await Context.Goals.SingleOrDefaultAsync(item => item.Id == id);

            // Validate entity is not null and update
            if (entity != null)
            {
                entity.DateUpdated = DateTime.UtcNow;
                entity.GoalName = newName;

                Context.Goals.Update(entity);
                Context.SaveChanges();
            }
            return true;
        }

        public async Task<bool> DeleteGoalAsync(Guid goalId)
        {
            var deleteGoal = await Context.Goals.SingleOrDefaultAsync(x => x.Id == goalId);
            if (deleteGoal != null)
            {
                Context.Goals.Remove(deleteGoal);
                await Context.SaveChangesAsync();
            }
            return true;
        }
    }
}
