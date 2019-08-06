using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using AHP.Service.Common;
using Repository.Common;
using Model.Common;

namespace AHP.Service
{
    public class AlternativeService : IAlternativeService
    {
        public readonly IAlternativeRepository alternativeRepository;

        public AlternativeService(IAlternativeRepository alternativeRepository)
        {
            this.alternativeRepository = alternativeRepository;
        }

        public async Task<IAlternative> GetAlternativeAsync(Guid alternativeID)
        {
            return await alternativeRepository.GetAlternativeAsync(alternativeID);
        }

        public async Task<List<IAlternative>> GetAllAlternativesAsync(Guid goalId)
        {
            return await alternativeRepository.GetAllAlternativesAsync(goalId);
        }

        public async Task<IAlternative> AddAlternativeAsync(IAlternative alternative, Guid goalId)
        {
            return await alternativeRepository.AddAlternativeAsync(alternative, goalId);
        }

        public async Task<List<IAlternative>> AddAlternativeListAsync(List<IAlternative> alternatives, Guid goalId)
        {
            return await alternativeRepository.AddAlternativeListAsync(alternatives, goalId);
        }

        public async Task<bool> UpdateAlternativeAsync(IAlternative updatedAlternative, float valueInCriterium)
        {
            await alternativeRepository.UpdateAlternativeAsync(updatedAlternative, valueInCriterium);
            return true;
        }

        public async Task<bool> DeleteAlternativeAsync(Guid alternativeID)
        {
            return await alternativeRepository.DeleteAlternativeAsync(alternativeID);
        }
        /// <summary>
        /// Sorts a list of alternatives, the comparison value is their global priority.
        /// </summary>
        /// <param name="alternatives">List of IAlternative objects</param>
        /// <returns></returns>
        public async Task<List<IAlternative>> SortAlternativesByPriorityAsync(List<IAlternative> alternatives)
        {
            alternatives.Sort(CompareAlternativesByGlobalPriorityDescending);

            return alternatives;
        }
        /// <summary>
        /// Custom comparison method comparing the global priorities of alternatives and sorting in descending order.
        /// </summary>
        /// <param name="x">IAlternative object</param>
        /// <param name="y">IAlternative object</param>
        /// <returns></returns>
        private int CompareAlternativesByGlobalPriorityDescending(IAlternative x, IAlternative y) 
        {   
            if(x == null)
            {
                if (y == null)
                    return 0; //If x is null and y is null they are equal
                else
                    return 1; //If x is null and y is not null, y is larger, return 1 instead of -1 because of descending order;
            }
            else //x is not null
            {
                if (x.GlobalPriority > y.GlobalPriority)
                    return -1; //x is larger than y, return -1 instead of 1 because of descending order
                else if (x.GlobalPriority == y.GlobalPriority)
                    return 0; //x is equal to y, return 0;
                else
                    return 1; //y is larger than x, return 1 instead because of descending order
            }
        }
    }

}
