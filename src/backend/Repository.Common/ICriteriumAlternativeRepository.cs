using Model.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common
{
    public interface ICriteriumAlternativeRepository
    {
        Task<ICriteriumAlternative> GetCriteriumAlternativeAsync(Guid criteriumAlternativeId);

        Task<List<ICriteriumAlternative>> GetAllCriteriumAlternativeAsync();

        Task<bool> DeleteCriteriumAlternativeAsync(Guid criteriumAlternativeId);
    }
}
