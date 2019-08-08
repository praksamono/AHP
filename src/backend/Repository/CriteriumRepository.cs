using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL;
using Microsoft.EntityFrameworkCore;
using Model.Common;
using Repository.Common;

namespace Repository
{
    public class CriteriumRepository : ICriteriumRepository
    {
        private readonly IMapper Mapper;

        public CriteriumRepository(IMapper mapper, AHPContext context)
        {
            this.Mapper = mapper;
            this.Context = context;
        }

        protected AHPContext Context { get; private set; }
        public async Task<ICriterium> AddCriteriumAsync(ICriterium criterium, Guid goalId)
        {
            criterium.Id = Guid.NewGuid();
            criterium.DateCreated = DateTime.UtcNow;
            criterium.DateUpdated = DateTime.UtcNow;
            criterium.GoalId = goalId;

            Context.Criteriums.Add(Mapper.Map<ICriterium, CriteriumEntity>(criterium));
            await Context.SaveChangesAsync();
            return criterium;
        }

        public async Task<List<ICriterium>> AddCriteriumListAsync(List<ICriterium> criteriumList, Guid goalId)
        {

            foreach (ICriterium criterium in criteriumList)
            {
                criterium.Id = Guid.NewGuid();
                criterium.DateCreated = DateTime.UtcNow;
                criterium.DateUpdated = DateTime.UtcNow;
                criterium.GoalId = goalId;

                Context.Criteriums.Add(Mapper.Map<ICriterium, CriteriumEntity>(criterium));
                await Context.SaveChangesAsync();
            }

            return criteriumList;
        }

        public async Task<bool> DeleteCriteriumAsync(Guid criteriumId)
        {
            var deleteCriterium = await Context.Criteriums.SingleOrDefaultAsync(x => x.Id == criteriumId);
            if (deleteCriterium != null)
            {
                Context.Criteriums.Remove(deleteCriterium);
                await Context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<List<ICriterium>> GetAllCriteriumsAsync(Guid goalId)
        {
            var criteriums = await Context.Criteriums.Where(criterium => criterium != null
                && criterium.GoalId == goalId).ToListAsync();

            return Mapper.Map<List<ICriterium>>(criteriums);
        }

        public async Task<ICriterium> GetCriteriumAsync(Guid criteriumId)
        {
            var getCriterium = await Context.Criteriums.SingleOrDefaultAsync(x => x.Id == criteriumId);
            return Mapper.Map<ICriterium>(getCriterium);
        }

        public async Task<bool> UpdateCriteriumAsync(ICriterium criteriumUpdate)
        {
            Guid id = criteriumUpdate.Id;
            float value = criteriumUpdate.GlobalCriteriumPriority;

            // Retrieve entity by id
            var entity = await Context.Criteriums.SingleOrDefaultAsync(item => item.Id == id);

            // Validate entity is not null and update
            if (entity != null)
            {
                entity.DateUpdated = DateTime.UtcNow;
                entity.GlobalCriteriumPriority = value;

                Context.Criteriums.Update(entity);
                Context.SaveChanges();
            }
            return true;
        }
    }
}
