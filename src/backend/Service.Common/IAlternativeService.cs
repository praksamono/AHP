﻿using System;
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

        Task<List<IAlternative>> GetAllAlternativesAsync(Guid goalId);

        Task<IAlternative> AddAlternativeAsync(IAlternative alternative, Guid goalId);

        Task<List<IAlternative>> AddAlternativeListAsync(List<IAlternative> alternatives, Guid goalId);

        Task<bool> UpdateAlternativeAsync(IAlternative updatedAlternative, float valueInCriterium);

        Task<bool> DeleteAlternativeAsync(Guid alternativeID);

        Task<List<IAlternative>> SortAlternativesByPriorityAsync(List<IAlternative> alternatives);

        Task<List<IAlternative>> SortAlternativesByOrder(List<IAlternative> alternativesList);
    }
}
