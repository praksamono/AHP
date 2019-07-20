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
            this.Context = context;
            _mapper = mapper;
        }

        protected AHPContext Context { get; private set; }

        public async Task<IGoal> GetGoalAsync(int goalId)
        {
            throw new NotImplementedException();
        }

 

        public async Task<List<IGoal>> GetAllGoalsAsync()
        {

            var goals = await Context.Goals.ToListAsync();
            //var list = _mapper.Map<Goal>(goals);

            var listGoals = Mapper.Map<List<DAL.Goal>, List<Model.Common.IGoal>>(goals);
            System.Diagnostics.Debug.WriteLine("OVDJE JE BATA");
            System.Diagnostics.Debug.WriteLine("OVDJE JE BATA" + goals);
            System.Diagnostics.Debug.WriteLine("Debug message");



            return listGoals;
          

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
