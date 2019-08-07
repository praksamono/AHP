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

        public Task<ICriteriumAlternative> AddCriteriumAlternativeAsync(ICriteriumAlternative criteriumAlternative)
        {
            return criteriumAlternativeRepository.AddCriteriumAlternativeAsync(criteriumAlternative);
        }

        public Task<ICriteriumAlternative> GetCriteriumAlternativeAsync(Guid criteriumAlternativeId)
        {
            return criteriumAlternativeRepository.GetCriteriumAlternativeAsync(criteriumAlternativeId);
        }

        public Task<List<ICriteriumAlternative>> GetAllCriteriumAlternativeAsync(Guid criteriumId)
        {
            return criteriumAlternativeRepository.GetAllCriteriumAlternativeAsync(criteriumId);
        }

        public Task<bool> DeleteCriteriumAlternativeAsync(Guid criteriumAlternativeID)
        {
            return criteriumAlternativeRepository.DeleteCriteriumAlternativeAsync(criteriumAlternativeID);
        }
    }
}
