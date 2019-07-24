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
    public class CriteriumAlternativeRepository : ICriteriumAlternativeRepository
    {

        private readonly IMapper Mapper;

        IUnitOfWorkFactory UowFactory;

        public CriteriumAlternativeRepository(IUnitOfWorkFactory uowFactory, IMapper mapper, AHPContext context)
        {
            this.UowFactory = uowFactory;
            this.Mapper = mapper;
            this.Context = context;
        }

        protected AHPContext Context { get; private set; }
        public async Task<bool> DeleteCriteriumAlternativeAsync(Guid criteriumAlternativeId)
        {
            var deleteCriteriumAlternative = await Context.CriteriumAlternatives.SingleOrDefaultAsync(x => x.CriteriumAlternativeId == criteriumAlternativeId);
            if (deleteCriteriumAlternative != null)
            {
                Context.CriteriumAlternatives.Remove(deleteCriteriumAlternative);
                await Context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<List<ICriteriumAlternative>> GetAllCriteriumAlternativeAsync()
        {
            var allCriteriumAlternatives = await Context.CriteriumAlternatives.ToListAsync();
            return Mapper.Map<List<ICriteriumAlternative>>(allCriteriumAlternatives);
        }

        public async Task<ICriteriumAlternative> GetCriteriumAlternativeAsync(Guid criteriumAlternativeId)
        {
            var getCriteriumAlternative = await Context.CriteriumAlternatives.SingleOrDefaultAsync(x => x.CriteriumAlternativeId == criteriumAlternativeId);
            return Mapper.Map<ICriteriumAlternative>(getCriteriumAlternative);
        }
    }
}
