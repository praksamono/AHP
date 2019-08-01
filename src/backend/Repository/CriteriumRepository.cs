using System;
using System.Collections.Generic;
using System.Linq;
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

        IUnitOfWorkFactory uowFactory;

        public CriteriumRepository(IUnitOfWorkFactory uowFactory, IMapper mapper, AHPContext context)
        {
            this.uowFactory = uowFactory;
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


            //criterium.Id = Guid.NewGuid();
            //criterium.DateCreated = DateTime.UtcNow;
            //criterium.DateUpdated = DateTime.UtcNow;

            //var unitOfWork = uowFactory.CreateUnitOfWork();
            //var entity = Mapper.Map<CriteriumEntity>(criterium);
            //await unitOfWork.AddAsync(entity);
            //await unitOfWork.CommitAsync();
            //return criterium;
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

            //var unitOfWork = uowFactory.CreateUnitOfWork();

            //foreach (ICriterium criterium in criteriumList)
            //{
            //    criterium.Id = Guid.NewGuid();
            //    criterium.DateCreated = DateTime.UtcNow;
            //    criterium.DateUpdated = DateTime.UtcNow;

            //    var entity = Mapper.Map<ICriterium, CriteriumEntity>(criterium);
            //    await unitOfWork.AddAsync(entity);
            //    await unitOfWork.CommitAsync();
            //}

            //return criteriumList;
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

            //var unitOfWork = uowFactory.CreateUnitOfWork();
            //await unitOfWork.DeleteAsync<CriteriumEntity>(criteriumId);
            //await unitOfWork.CommitAsync();
            //return true;
        }

        public async Task<List<ICriterium>> GetAllCriteriumsAsync(Guid goalId)
        {
            //var allCriteriums = await Context.Criteriums.ToListAsync();
            //return Mapper.Map<List<ICriterium>>(allCriteriums);

            var criteriums = await Context.Criteriums.Where(criterium => criterium != null
                && criterium.GoalId == goalId).ToListAsync();
            // // DEBUG
            // foreach (var crit in criteriums) {
            //     Console.WriteLine(crit.GlobalCriteriumPriority);
            // }
            // // End DEBUG
            return Mapper.Map<List<ICriterium>>(criteriums);

            //var unitOfWork = uowFactory.CreateUnitOfWork();
            //var getCriterium = await unitOfWork.GetAllAsync<CriteriumEntity>();
            //return Mapper.Map<List<ICriterium>>(getCriterium);
        }

        public async Task<ICriterium> GetCriteriumAsync(Guid criteriumId)
        {
            var getCriterium = await Context.Criteriums.SingleOrDefaultAsync(x => x.Id == criteriumId);
            return Mapper.Map<ICriterium>(getCriterium);

            //var unitOfWork = uowFactory.CreateUnitOfWork();
            //var getCriterium = await unitOfWork.GetAsync<CriteriumEntity>(criteriumId);
            //return Mapper.Map<ICriterium>(getCriterium);
        }

        public async Task<bool> UpdateCriteriumAsync(ICriterium criteriumUpdate, Guid goalId)
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
