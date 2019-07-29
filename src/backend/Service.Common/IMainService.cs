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
        float[] CalculatePriorities(float[,] Matrix);
        float[,] MatrixInit(int[] ComparisonValues);
        float MatrixRowSum(float[,] Matrix, int MatrixSize, int RowNumber);
        float MatrixSum(float[,] Matrix, int MatrixSize);
        void MatrixSquare(ref float[,] Matrix, int MatrixSize);

    }
}
