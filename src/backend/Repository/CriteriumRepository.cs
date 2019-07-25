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
    public class CriteriumRepository : ICriteriumRepository
    {
        private readonly IMapper Mapper;

        IUnitOfWorkFactory UowFactory;

        public CriteriumRepository(IUnitOfWorkFactory uowFactory, IMapper mapper, AHPContext context)
        {
            this.UowFactory = uowFactory;
            this.Mapper = mapper;
            this.Context = context;
        }

        protected AHPContext Context { get; private set; }
        public async Task<ICriterium> AddCriteriumAsync(ICriterium criterium)
        {
            criterium.DateCreated = DateTime.UtcNow;

            Context.Criteriums.Add(Mapper.Map<ICriterium, CriteriumEntity>(criterium));
            await Context.SaveChangesAsync();
            return criterium;
        }

        public async Task<bool> DeleteCriteriumAsync(Guid criteriumId)
        {
            var deleteCriterium = await Context.Criteriums.SingleOrDefaultAsync(x => x.CriteriumId == criteriumId);
            if (deleteCriterium != null)
            {
                Context.Criteriums.Remove(deleteCriterium);
                await Context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<List<ICriterium>> GetAllCriteriumsAsync()
        {
            var allCriteriums = await Context.Criteriums.ToListAsync();
            return Mapper.Map<List<ICriterium>>(allCriteriums);
        }

        public async Task<ICriterium> GetCriteriumAsync(Guid criteriumId)
        {
            var getCriterium = await Context.Criteriums.SingleOrDefaultAsync(x => x.CriteriumId == criteriumId);
            return Mapper.Map<ICriterium>(getCriterium);
        }

        public async Task<bool> UpdateCriteriumAsync(ICriterium criteriumUpdate)
        {
            criteriumUpdate.DateUpdated = DateTime.UtcNow;

            if (Context != null)
            {
                Context.Criteriums.Update(Mapper.Map<ICriterium, CriteriumEntity>(criteriumUpdate));
                await Context.SaveChangesAsync();
            }
            return true;
        }
    }
}
