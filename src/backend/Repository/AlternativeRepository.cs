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
    public class AlternativeRepository : IAlternativeRepository
    {

        private readonly IMapper Mapper;

        public AlternativeRepository(AHPContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        protected AHPContext Context { get; private set; }

        public async Task<IAlternative> AddAlternativeAsync(IAlternative newAlternative, Guid goalId)
        {

            newAlternative.Id = Guid.NewGuid();
            newAlternative.DateCreated = DateTime.UtcNow;
            newAlternative.DateUpdated = DateTime.UtcNow;
            newAlternative.GoalId = goalId;
            newAlternative.GlobalPriority = 0;

            Context.Alternatives.Add(Mapper.Map<IAlternative, AlternativeEntity>(newAlternative));
            await Context.SaveChangesAsync();
            return newAlternative;
        }

        public async Task<List<IAlternative>> AddAlternativeListAsync(List<IAlternative> alternativesList, Guid goalId)
        {
            foreach (IAlternative alternative in alternativesList)
            {
                alternative.Id = Guid.NewGuid();
                alternative.DateCreated = DateTime.UtcNow;
                alternative.DateUpdated = DateTime.UtcNow;
                alternative.GoalId = goalId;
                alternative.GlobalPriority = 0;

                Context.Alternatives.Add(Mapper.Map<IAlternative, AlternativeEntity>(alternative));
                await Context.SaveChangesAsync();
            }

            return alternativesList;
        }

        public async Task<bool> DeleteAlternativeAsync(Guid alternativeId)
        {
            var deleteAlternative = await Context.Alternatives.SingleOrDefaultAsync(x => x.Id == alternativeId);
            if (deleteAlternative != null)
            {
                Context.Alternatives.Remove(deleteAlternative);
                await Context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<List<IAlternative>> GetAllAlternativesAsync(Guid goalId)
        {
            var allAlternatives = await Context.Alternatives.Where(alternative => alternative != null
                && alternative.GoalId == goalId).ToListAsync();
            return Mapper.Map<List<IAlternative>>(allAlternatives);
        }

        public async Task<IAlternative> GetAlternativeAsync(Guid alternativeId)
        {
            var getAlternative = await Context.Alternatives.SingleOrDefaultAsync(x => x.Id == alternativeId);
            return Mapper.Map<IAlternative>(getAlternative);
        }

        public async Task<bool> UpdateAlternativeAsync(IAlternative alternativeUpdate, float valueInCriterium)
        {
            Guid id = alternativeUpdate.Id;

            // Retrieve entity by id
            var entity = await Context.Alternatives.SingleOrDefaultAsync(item => item.Id == id);

            // Validate entity is not null and update
            if (entity != null)
            {
                entity.DateUpdated = DateTime.UtcNow;
                float currentValue = entity.GlobalPriority;
                currentValue += valueInCriterium;
                entity.GlobalPriority = currentValue;

                Context.Alternatives.Update(entity);
                await Context.SaveChangesAsync();
            }
            return true;
        }
    }
}
