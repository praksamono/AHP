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

        public async Task<List<IAlternative>> GetAllAlternativesAsync()
        {
            return await alternativeRepository.GetAllAlternativesAsync();
        }

        public async Task<IAlternative> AddAlternativeAsync(IAlternative alternative)
        {
            return await alternativeRepository.AddAlternativeAsync(alternative);
        }

        public async Task<List<IAlternative>> AddAlternativeListAsync(List<IAlternative> alternatives)
        {
            return await alternativeRepository.AddAlternativeListAsync(alternatives);
        }

        public async Task<bool> UpdateAlternativeAsync(IAlternative updatedAlternative)
        {
            await alternativeRepository.UpdateAlternativeAsnyc(updatedAlternative);
            return true;
        }

        public async Task<bool> DeleteAlternativeAsync(Guid alternativeID)
        {
            return await alternativeRepository.DeleteAlternativeAsync(alternativeID);
        }
    }

}
