using Model.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common
{
    public interface ICriteriumAlternativeRepository
    {
        Task<ICriteriumAlternative> AddCriteriumAlternativeAsync(ICriteriumAlternative criteriumAlternative);

        Task<ICriteriumAlternative> GetCriteriumAlternativeAsync(Guid criteriumAlternativeId);

        Task<List<ICriteriumAlternative>> GetAllCriteriumAlternativeAsync(Guid criteriumId);

        Task<bool> DeleteCriteriumAlternativeAsync(Guid criteriumAlternativeId);
    }
}
