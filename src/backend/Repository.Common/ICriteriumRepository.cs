﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model.Common;

namespace Repository.Common
{
    public interface ICriteriumRepository
    {
        Task<ICriterium> GetCriteriumAsync(int criteriumId);

        Task<List<ICriterium>> GetAllCriteriumsAsync();

        Task<ICriterium> AddCriteriumAsync(ICriterium criterium );

        Task<bool> UpdateCriteriumAsnyc(ICriterium criteriumUpdate);

        Task<bool> DeleteCriteriumAsync(int criteriumId);
    }
}
