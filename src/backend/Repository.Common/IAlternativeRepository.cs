using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model.Common;

namespace Repository.Common
{
    public interface IAlternativeRepository
    {
        Task<IAlternative> GetAlternativeAsync(Guid alternativeId);

        Task<List<IAlternative>> GetAllAlternativesAsync(Guid goalId);

        Task<IAlternative> AddAlternativeAsync(IAlternative alternative, Guid goalId);

        Task<List<IAlternative>> AddAlternativeListAsync(List<IAlternative> alternativesList, Guid goalId);

        Task<bool> UpdateAlternativeAsync(IAlternative alternativeUpdate, float valueInCriterium);
        Task<bool> DeleteAlternativeAsync(Guid alternativeId);
    }
}
