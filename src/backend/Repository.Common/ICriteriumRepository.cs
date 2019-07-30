using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model.Common;

namespace Repository.Common
{
    public interface ICriteriumRepository
    {
        Task<ICriterium> GetCriteriumAsync(Guid criteriumId);

        Task<List<ICriterium>> GetAllCriteriumsAsync(Guid goalId);

        Task<ICriterium> AddCriteriumAsync(ICriterium criterium, Guid goalId );

        Task<List<ICriterium>> AddCriteriumListAsync(List<ICriterium> criteriumList, Guid goalId);

        Task<bool> UpdateCriteriumAsync(ICriterium criteriumUpdate, Guid goalId);

        Task<bool> DeleteCriteriumAsync(Guid criteriumId);

    }
}
