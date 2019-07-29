﻿using System;
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
        private readonly IMapper Mapper;

        IUnitOfWorkFactory uowFactory;

        public GoalRepository(IUnitOfWorkFactory uowFactory, IMapper mapper, AHPContext context)
        {
            this.uowFactory = uowFactory;
            this.Mapper = mapper;
            this.Context = context;
        }

        protected AHPContext Context { get; private set; }

        public async Task<IGoal> GetGoalAsync(Guid goalId)
        {
            //var getGoal = await Context.Goals.SingleOrDefaultAsync(x => x.Id == goalId);
            //return Mapper.Map<IGoal>(getGoal);

            var unitOfWork = uowFactory.CreateUnitOfWork();
            var getGoal = await unitOfWork.GetAsync<GoalEntity>(goalId);
            return Mapper.Map<IGoal>(getGoal);
        }

        public async Task<List<IGoal>> GetAllGoalsAsync()
        {
            var allGoals = await Context.Goals.ToListAsync();
            return Mapper.Map<List<IGoal>>(allGoals);
        }

        public async Task<IGoal> AddGoalAsync(IGoal goal)
        {

            //Context.Goals.Add(Mapper.Map<IGoal, GoalEntity>(goal));
            //await Context.SaveChangesAsync();
            //return goal;

            goal.Id = Guid.NewGuid();
            goal.DateCreated = DateTime.UtcNow;
            goal.DateUpdated = DateTime.UtcNow;

            var unitOfWork = uowFactory.CreateUnitOfWork();
            var entity = Mapper.Map<GoalEntity>(goal);
            await unitOfWork.AddAsync(entity);
            await unitOfWork.CommitAsync();
            return goal;
        }

        public async Task<bool> UpdateGoalAsync(IGoal goalUpdate)
        {
            goalUpdate.DateUpdated = DateTime.UtcNow;
            var unitOfWork = uowFactory.CreateUnitOfWork();
            var entity = Mapper.Map<GoalEntity>(goalUpdate);
            await unitOfWork.UpdateAsync(entity);
            await unitOfWork.CommitAsync();
            return true;
        }

        public async Task<bool> DeleteGoalAsync(Guid goalId)
        {
            //var deleteGoal = await Context.Goals.SingleOrDefaultAsync(x => x.Id == goalId);
            //if (deleteGoal != null)
            //{
            //    Context.Goals.Remove(deleteGoal);
            //    await Context.SaveChangesAsync();
            //}
            //return true;

            var unitOfWork = uowFactory.CreateUnitOfWork();
            await unitOfWork.DeleteAsync<GoalEntity>(goalId);
            await unitOfWork.CommitAsync();
            return true;
        }
    }
}
