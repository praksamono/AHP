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
        Task<float[]> AHPMethod(int[] ComparisonValues, int NumOfElements);
        Task<float[]> CalculatePriorities(float[,] Matrix);
        Task<float[,]> MatrixInit(int[] ComparisonValues, int NumOfElements);
        Task<float> MatrixRowSum(float[,] Matrix, int MatrixSize, int RowNumber);
        Task<float> MatrixSum(float[,] Matrix, int MatrixSize);
        Task<float[,]> MatrixSquare(float[,] Matrix, int MatrixSize);

    }
}
