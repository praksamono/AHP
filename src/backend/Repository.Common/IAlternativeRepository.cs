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

        Task<List<IAlternative>> GetAllAlternativesAsync();

        Task<IAlternative> AddAlternativeAsync(IAlternative alternative);

        Task<bool> UpdateAlternativeAsnyc(IAlternative alternativeUpdate);

        Task<bool> DeleteAlternativeAsync(Guid alternativeId);
    }
}
