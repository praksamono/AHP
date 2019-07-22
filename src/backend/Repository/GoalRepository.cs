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
        public GoalRepository(AHPContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        protected AHPContext _context { get; private set; }

        public async Task<IGoal> GetGoalAsync(int goalId)
        {
            var getGoal = await _context.Goals.SingleOrDefaultAsync(x => x.GoalId == goalId);
            return _mapper.Map<IGoal>(getGoal);
        }

        public async Task<List<IGoal>> GetAllGoalsAsync()
        {
            var allGoals = await _context.Goals.ToListAsync();
            return _mapper.Map<List<IGoal>>(allGoals);
        }

        public async Task<IGoal> AddGoalAsync(IGoal newGoal)
        {
            newGoal.DateCreated = DateTime.UtcNow;

            _context.Goals.Add(_mapper.Map<IGoal, Goal>(newGoal));
            await _context.SaveChangesAsync();
            return newGoal;

        }
    
        public async Task<bool> UpdateGoalAsnyc(IGoal goalUpdate)
        {
            if (_context != null)
            {
                _context.Goals.Update(_mapper.Map<IGoal, Goal>(goalUpdate));
                await _context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> DeleteGoalAsync(int goalId)
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
