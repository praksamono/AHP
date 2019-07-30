using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Model.Common;

namespace AHP.Service.Common
{
    public interface ICriteriumService
    {
        Task<ICriterium> AddCriteriumAsync(ICriterium criterium);

        Task<List<ICriterium>> AddCriteriumListAsync(List<ICriterium> criteriumList, Guid goalId);

        Task<bool> DeleteCriteriumAsync(Guid criteriumID);

        Task<List<ICriterium>> GetAllCriteriumsAsync(Guid goalId);

        Task<ICriterium> GetCriteriumAsync(Guid criteriumID);

        Task<bool> UpdateCriteriumAsync(ICriterium updatedCriterium, Guid goalId);
    }
}
