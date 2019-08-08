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

        public Task<ICriterium> AddCriteriumAsync(ICriterium criterium, Guid goalId)
        {
            return criteriumRepository.AddCriteriumAsync(criterium, goalId);
        }

        public Task<List<ICriterium>> AddCriteriumListAsync(List<ICriterium> criteriumList, Guid goalId)
        {
            int orderIndex = 0; 
            foreach(ICriterium criterium in criteriumList) //Add order numbers to a finite list of criteria
            {
                criterium.Order = orderIndex;
            }
            return criteriumRepository.AddCriteriumListAsync(criteriumList, goalId);
        }

        public Task<bool> DeleteCriteriumAsync(Guid criteriumID)
        {
            return criteriumRepository.DeleteCriteriumAsync(criteriumID);
        }

        public Task<List<ICriterium>> GetAllCriteriumsAsync(Guid goalId)
        {
            return criteriumRepository.GetAllCriteriumsAsync(goalId);
        }

        public Task<ICriterium> GetCriteriumAsync(Guid criteriumID)
        {
            return criteriumRepository.GetCriteriumAsync(criteriumID);
        }

        public Task<bool> UpdateCriteriumAsync(ICriterium updatedCriterium)
        {
           return criteriumRepository.UpdateCriteriumAsync(updatedCriterium);
        }
    }
}
