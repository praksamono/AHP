using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using AHP.Service.Common;
using Repository.Common;

namespace AHP.Service
{
    public class CriteriumAlternativeService : ICriteriumAlternativeService
    {
        public readonly ICriteriumAlternativeRepository criteriumAlternativeRepository;

        public CriteriumAlternativeService(ICriteriumAlternativeRepository criteriumAlternativeRepository)
        {
            this.criteriumAlternativeRepository = criteriumAlternativeRepository;
        }
    }
}
