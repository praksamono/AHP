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
        private readonly IMapper _mapper;

        IUnitOfWorkFactory _uowFactory;

        public GoalRepository(IUnitOfWorkFactory uowFactory, IMapper mapper, AHPContext context)
        {
            this._uowFactory = uowFactory;
            this._mapper = mapper;
            this._context = context;
        }

        protected AHPContext _context { get; private set; }

        public async Task<IGoal> GetGoalAsync(Guid goalId)
        {
            var getGoal = await _context.Goals.SingleOrDefaultAsync(x => x.GoalId == goalId);
            return _mapper.Map<IGoal>(getGoal);
        }

        public async Task<List<IGoal>> GetAllGoalsAsync()
        {
            var allGoals = await _context.Goals.ToListAsync();
            return _mapper.Map<List<IGoal>>(allGoals);
        }

        public async Task<IGoal> AddGoalAsync(IGoal goal)
        {
            goal.DateCreated = DateTime.UtcNow;

            //_context.Goals.Add(_mapper.Map<IGoal, GoalEntity>(newGoal));
            //await _context.SaveChangesAsync();
            //return newGoal;

            var unitOfWork = _uowFactory.CreateUnitOfWork();

            var newGoal = await unitOfWork.AddAsync(goal);

            await unitOfWork.CommitAsync();

            return _mapper.Map<IGoal>(newGoal);
        }

        public async Task<bool> UpdateGoalAsnyc(IGoal goalUpdate)
        {
            goalUpdate.DateCreated = DateTime.UtcNow;

            if (_context != null)
            {
                _context.Goals.Update(_mapper.Map<IGoal, GoalEntity>(goalUpdate));
                await _context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> DeleteGoalAsync(Guid goalId)
        {
            var deleteGoal = await _context.Goals.SingleOrDefaultAsync(x => x.GoalId == goalId);
            if (deleteGoal != null)
            {
                _context.Goals.Remove(deleteGoal);
                await _context.SaveChangesAsync();
            }
            return true;
        }
    }
}
