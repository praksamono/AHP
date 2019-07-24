using System;
using System.Collections.Generic;
using System.Text;
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

        public async Task<IAlternative> AddAlternativeAsync(IAlternative newAlternative)
        {
            newAlternative.DateCreated = DateTime.UtcNow;

            Context.Alternatives.Add(Mapper.Map<IAlternative, AlternativeEntity>(newAlternative));
            await Context.SaveChangesAsync();
            return newAlternative;
        }

        public async Task<bool> DeleteAlternativeAsync(Guid alternativeId)
        {
            var deleteAlternative = await Context.Alternatives.SingleOrDefaultAsync(x => x.AlternativeId == alternativeId);
            if (deleteAlternative != null)
            {
                Context.Alternatives.Remove(deleteAlternative);
                await Context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<List<IAlternative>> GetAllAlternativesAsync()
        {
            var allAlternatives = await Context.Alternatives.ToListAsync();
            return Mapper.Map<List<IAlternative>>(allAlternatives);
        }
        
        public async Task<IAlternative> GetAlternativeAsync(Guid alternativeId)
        {
            var getAlternative = await Context.Alternatives.SingleOrDefaultAsync(x => x.AlternativeId == alternativeId);
            return Mapper.Map<IAlternative>(getAlternative);
        }

        public async Task<bool> UpdateAlternativeAsnyc(IAlternative alternativeUpdate)
        {
            alternativeUpdate.DateUpdated = DateTime.UtcNow;

            if (Context != null)
            {
                Context.Alternatives.Update(Mapper.Map<IAlternative, AlternativeEntity>(alternativeUpdate));
                await Context.SaveChangesAsync();
            }
            return true;
        }
    }
}
