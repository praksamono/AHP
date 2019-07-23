using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model.Common;
using Repository.Common;

namespace Repository
{
    public class CriteriumRepository : ICriteriumRepository
    {
        public async Task<ICriterium> AddCriteriumAsync(ICriterium criterium)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteCriteriumAsync(Guid criteriumId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ICriterium>> GetAllCriteriumsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ICriterium> GetCriteriumAsync(Guid criteriumId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateCriteriumAsnyc(ICriterium criteriumUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
