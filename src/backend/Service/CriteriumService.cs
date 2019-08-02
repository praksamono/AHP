using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using AHP.Service.Common;
using Repository.Common;
using Model.Common;

namespace AHP.Service
{
    public class CriteriumService : ICriteriumService
    {
        public readonly ICriteriumRepository criteriumRepository;

        public CriteriumService(ICriteriumRepository criteriumRepository)
        {
            this.criteriumRepository = criteriumRepository;
        }

        public async Task<ICriterium> AddCriteriumAsync(ICriterium criterium, Guid goalId)
        {
            return await criteriumRepository.AddCriteriumAsync(criterium, goalId);
        }

        public async Task<List<ICriterium>> AddCriteriumListAsync(List<ICriterium> criteriumList, Guid goalId)
        {
            return await criteriumRepository.AddCriteriumListAsync(criteriumList, goalId);
        }

        public async Task<bool> DeleteCriteriumAsync(Guid criteriumID)
        {
            await criteriumRepository.DeleteCriteriumAsync(criteriumID);
            return true;
        }

        public async Task<List<ICriterium>> GetAllCriteriumsAsync(Guid goalId)
        {
            return await criteriumRepository.GetAllCriteriumsAsync(goalId);
        }

        public async Task<ICriterium> GetCriteriumAsync(Guid criteriumID)
        {
            return await criteriumRepository.GetCriteriumAsync(criteriumID);
        }

        public async Task<bool> UpdateCriteriumAsync(ICriterium updatedCriterium)
        {
           return await criteriumRepository.UpdateCriteriumAsync(updatedCriterium);
        }
    }
}
