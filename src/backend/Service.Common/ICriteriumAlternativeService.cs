using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Model.Common;

namespace AHP.Service.Common
{
    public interface ICriteriumAlternativeService
    {
        Task<ICriteriumAlternative> GetCriteriumAlternativeAsync(Guid criteriumAlternativeId);

        Task<ICriteriumAlternative> AddCriteriumAlternativeAsync(ICriteriumAlternative criteriumAlternative, ICriterium criterium, IAlternative alternative, Guid criteriumID, Guid alternativeID, float priorityValue);

        Task<List<ICriteriumAlternative>> GetAllCriteriumAlternativeAsync();

        Task<bool> DeleteCriteriumAlternativeAsync(Guid criteriumAlternativeID);
    }
}
