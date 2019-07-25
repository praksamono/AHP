using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Model.Common;

namespace AHP.Service.Common
{
    public interface IAlternativeService
    {
        Task<IAlternative> GetAlternativeAsync(Guid alternativeID);

        Task<List<IAlternative>> GetAllAlternativesAsync();

        Task<IAlternative> AddAlternativeAsync(IAlternative alternative);

        Task<bool> UpdateAlternativeAsync(IAlternative updatedAlternative);

        Task<bool> DeleteAlternativeAsync(Guid alternativeID);
    }
}
