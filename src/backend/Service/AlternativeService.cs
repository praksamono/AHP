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
    public class AlternativeService : IAlternativeService
    {
        public readonly IAlternativeRepository alternativeRepository;

        public AlternativeService(IAlternativeRepository alternativeRepository)
        {
            this.alternativeRepository = alternativeRepository;
        }

        public async Task<IAlternative> GetAlternativeAsync(Guid alternativeID)
        {
            return await alternativeRepository.GetAlternativeAsync(alternativeID);
        }

        public async Task<List<IAlternative>> GetAllAlternativesAsync(Guid goalId)
        {
            return await alternativeRepository.GetAllAlternativesAsync(goalId);
        }

        public async Task<IAlternative> AddAlternativeAsync(IAlternative alternative, Guid goalId)
        {
            return await alternativeRepository.AddAlternativeAsync(alternative, goalId);
        }

        public async Task<List<IAlternative>> AddAlternativeListAsync(List<IAlternative> alternatives, Guid goalId)
        {
            return await alternativeRepository.AddAlternativeListAsync(alternatives, goalId);
        }

        public async Task<bool> UpdateAlternativeAsync(IAlternative updatedAlternative, float valueInCriterium)
        {
            await alternativeRepository.UpdateAlternativeAsync(updatedAlternative, valueInCriterium);
            return true;
        }

        public async Task<bool> DeleteAlternativeAsync(Guid alternativeID)
        {
            return await alternativeRepository.DeleteAlternativeAsync(alternativeID);
        }
    }

}
