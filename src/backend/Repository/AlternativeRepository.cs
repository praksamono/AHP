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

        private readonly IUnitOfWorkFactory uowFactory;

        public AlternativeRepository(AHPContext context, IMapper mapper, IUnitOfWorkFactory uowFactory)
        {
            this.Context = context;
            this.Mapper = mapper;
            this.uowFactory = uowFactory;
        }

        protected AHPContext Context { get; private set; }

        public async Task<IAlternative> AddAlternativeAsync(IAlternative newAlternative)
        {

            newAlternative.Id = Guid.NewGuid();
            newAlternative.DateCreated = DateTime.UtcNow;
            newAlternative.DateUpdated = DateTime.UtcNow;

            Context.Alternatives.Add(Mapper.Map<IAlternative, AlternativeEntity>(newAlternative));
            await Context.SaveChangesAsync();
            return newAlternative;


            //newAlternative.Id = Guid.NewGuid();
            //newAlternative.DateCreated = DateTime.UtcNow;
            //newAlternative.DateUpdated = DateTime.UtcNow;

            //var unitOfWork = uowFactory.CreateUnitOfWork();
            //var entity = Mapper.Map<AlternativeEntity>(newAlternative);
            //await unitOfWork.AddAsync(entity);
            //await unitOfWork.CommitAsync();
            //return newAlternative;
        }

        public async Task<List<IAlternative>> AddAlternativeListAsync(List<IAlternative> alternativesList)
        {
            foreach (IAlternative alternative in alternativesList)
            {
                alternative.Id = Guid.NewGuid();
                alternative.DateCreated = DateTime.UtcNow;
                alternative.DateUpdated = DateTime.UtcNow;

                Context.Alternatives.Add(Mapper.Map<IAlternative, AlternativeEntity>(alternative));
                await Context.SaveChangesAsync();
            }

            return alternativesList;

            //var unitOfWork = uowFactory.CreateUnitOfWork();

            //foreach (IAlternative alternative in alternativesList)
            //{
            //    alternative.Id = Guid.NewGuid();
            //    alternative.DateCreated = DateTime.UtcNow;
            //    alternative.DateUpdated = DateTime.UtcNow;

            //    var entity = Mapper.Map<IAlternative, AlternativeEntity>(alternative);
            //    await unitOfWork.AddAsync(entity);
            //    await unitOfWork.CommitAsync();
            //}

            //return alternativesList;
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


            //var unitOfWork = uowFactory.CreateUnitOfWork();
            //await unitOfWork.DeleteAsync<AlternativeEntity>(alternativeId);
            //await unitOfWork.CommitAsync();
            //return true;
        }

        public async Task<List<IAlternative>> GetAllAlternativesAsync()
        {
            var allAlternatives = await Context.Alternatives.ToListAsync();
            return Mapper.Map<List<IAlternative>>(allAlternatives);

            //var unitOfWork = uowFactory.CreateUnitOfWork();
            //var getAlternative = await unitOfWork.GetAllAsync<AlternativeEntity>();
            //return Mapper.Map<List<IAlternative>>(getAlternative);
        }
        
        public async Task<IAlternative> GetAlternativeAsync(Guid alternativeId)
        {
            var getAlternative = await Context.Alternatives.SingleOrDefaultAsync(x => x.Id == alternativeId);
            return Mapper.Map<IAlternative>(getAlternative);


            //var unitOfWork = uowFactory.CreateUnitOfWork();
            //var getAlternative = await unitOfWork.GetAsync<AlternativeEntity>(alternativeId);
            //return Mapper.Map<IAlternative>(getAlternative);
        }

        public async Task<bool> UpdateAlternativeAsnyc(IAlternative alternativeUpdate)
        {
            alternativeUpdate.DateUpdated = DateTime.UtcNow;
            var unitOfWork = uowFactory.CreateUnitOfWork();
            var entity = Mapper.Map<AlternativeEntity>(alternativeUpdate);
            await unitOfWork.UpdateAsync(entity);
            await unitOfWork.CommitAsync();
            return true;
        }
    }
}
