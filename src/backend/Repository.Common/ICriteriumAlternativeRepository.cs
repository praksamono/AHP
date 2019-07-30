using Model.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common
{
    public interface ICriteriumAlternativeRepository
    {
        Task<ICriteriumAlternative> AddCriteriumAlternativeAsync(ICriteriumAlternative criteriumAlternative, ICriterium criterium, IAlternative alternative, Guid criteriumID, Guid alternativeID, float priorityValue);

        Task<ICriteriumAlternative> GetCriteriumAlternativeAsync(Guid criteriumAlternativeId);

        Task<List<ICriteriumAlternative>> GetAllCriteriumAlternativeAsync();

        Task<bool> DeleteCriteriumAlternativeAsync(Guid criteriumAlternativeId);
    }
}
