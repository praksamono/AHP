using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Model.Common;

namespace AHP.Service.Common
{
    public interface IMainService
    {
        Task<float[]> AHPMethod(int[] ComparisonValues);
    }
}
