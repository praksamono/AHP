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
    public class CriteriumAlternativeService : ICriteriumAlternativeService
    {
        public readonly ICriteriumAlternativeRepository criteriumAlternativeRepository;

        public CriteriumAlternativeService(ICriteriumAlternativeRepository criteriumAlternativeRepository)
        {
            this.criteriumAlternativeRepository = criteriumAlternativeRepository;
        }

        public async Task<ICriteriumAlternative> AddCriteriumAlternativeAsync(ICriteriumAlternative criteriumAlternative)
        {
            return await criteriumAlternativeRepository.AddCriteriumAlternativeAsync(criteriumAlternative);
        }

        public async Task<ICriteriumAlternative> GetCriteriumAlternativeAsync(Guid criteriumAlternativeId)
        {
            return await criteriumAlternativeRepository.GetCriteriumAlternativeAsync(criteriumAlternativeId);
        }

        public async Task<List<ICriteriumAlternative>> GetAllCriteriumAlternativeAsync(Guid criteriumId)
        {
            return await criteriumAlternativeRepository.GetAllCriteriumAlternativeAsync(criteriumId);
        }

        public async Task<bool> DeleteCriteriumAlternativeAsync(Guid criteriumAlternativeID)
        {
            return await criteriumAlternativeRepository.DeleteCriteriumAlternativeAsync(criteriumAlternativeID);
        }
    }
}
