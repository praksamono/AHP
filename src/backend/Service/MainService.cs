using System;
using System.Collections.Generic;
using System.Text;
using Repository.Common;
using Model.Common;
using AHP.Service.Common;
using System.Threading.Tasks;

//The controller sends an array of comparison values.

namespace AHP.Service
{
    class MainService : IMainService
    {
        #region  Calculation

        public async Task<float[]> AHPMethod(int[] ComparisonValues, int NumOfElements)
        {
            float[,] Matrix = await MatrixInit(ComparisonValues, NumOfElements);
            float[] NormalisedVector = await CalculatePriorities(Matrix);

            return NormalisedVector;
        }

        ///<summary>Calculates a vector of priorities from the comparison matrix</summary>
        ///<returns>Float array of priorities</returns>
        public async Task<float[]> CalculatePriorities(float[,] Matrix)
        {
            int MatrixSize = Matrix.GetLength(0); //Gets the length of the first dimension in the matrix, since the matrix is always square it does not matter which dimension's length we take

            await MatrixSquare(Matrix, MatrixSize);
            await MatrixSquare(Matrix, MatrixSize); //Square the matrix twice for more precision((?) - Expensive operation)

            float matrixSum = await MatrixSum(Matrix, MatrixSize); //Calculate the matrix sum for normalisation

            //Normalised vector
            float[] NormalisedVector = new float[MatrixSize];

            for (int i = 0; i < MatrixSize; i++)
            {
                NormalisedVector[i] = await MatrixRowSum(Matrix, MatrixSize, i) / matrixSum;
            }

            return NormalisedVector;
        }
        #endregion

        ///<summary>Initialises a calculation matrix from comparison values(of alternatives or criteria) passed from the controller. </summary>
        ///<param name="ComparisonValues">Array of integers containing comparison values. The values are in the range [-4, 4], where negative numbers represent
        ///'left' priority and are mapped as |2n-1|. Positive values are mapped as 2n+1 to get the full range of values [1, 9] used in AHP.</param>
        ///<returns>2D array of floats that is the calculation matrix for future calculations.</returns>
        #region MatrixOperations
        public async Task<float[,]> MatrixInit(int[] ComparisonValues, int NumOfElements)
        {
            int MatrixSize = NumOfElements;
            float[,] Matrix = new float[MatrixSize, MatrixSize];
            int Position = 0;

            for (int i = 0; i < MatrixSize; i++)
            {
                Matrix[i, i] = 1f;

                for (int j = i + 1; j < MatrixSize; j++)
                {

                    if (ComparisonValues[Position] < 0)
                    {
                        float MappedValue = Math.Abs((2 * ComparisonValues[Position]) - 1);
                        Matrix[i, j] = MappedValue;
                        Matrix[j, i] = 1 / MappedValue;
                    }

                    else
                    {
                        float MappedValue = (2 * ComparisonValues[Position]) + 1;
                        Matrix[i, j] = 1 / MappedValue;
                        Matrix[j, i] = MappedValue;
                    }

                    Position++;
                }

            }

            return Matrix;
        }

        ///<summary>Sums up the elements in the RowNumber row of a Matrix</summary>
        public async Task<float> MatrixRowSum(float[,] Matrix, int MatrixSize, int RowNumber)
        {
            float sum = 0;
            for (int i = 0; i < MatrixSize; i++)
            {
                sum += Matrix[RowNumber, i];
            }

            return sum;
        }

        ///<summary>Sums up all the elements of a matrix. It only traverses the upper triangle of a matrix since we know the matrix has a property of reciprocal values.</summary>
        ///<returns>Float representing the sum of all matrix elements</returns>
        public async Task<float> MatrixSum(float[,] Matrix, int MatrixSize)
        {
            float sum = 0f;

            for (int i = 0; i < MatrixSize; i++)
            {
                // sum += 1f; //For each new row add the 1.0 that is located on the main diagonal
                // for (int j = i + 1; j < MatrixSize; j++)
                // {
                //     sum += Matrix[i, j]; //Add the element on position i,j and also it's reciprocal element on j,i
                //     sum += Matrix[j, i];
                // }
                for (int j = 0; j < MatrixSize; j++) {
                    sum += Matrix[i,j];
                }
            }
            return sum;
        }

        ///<summary>Squares a quadratic matrix</summary>
        ///<param name="Matrix">2D array of floats passed by reference</param>
        public async Task<float[,]> MatrixSquare(float[,] Matrix, int MatrixSize)
        {
            float[,] MatrixCopy = new float[MatrixSize, MatrixSize];

            for (int i = 0; i < MatrixSize; i++) //Copy the original matrix
            {
                for (int j = 0; j < MatrixSize; j++)
                {
                    float CopyValue = Matrix[i, j];
                    MatrixCopy[i, j] = CopyValue;
                }
            }

            float sum = 0;

            for (int i = 0; i < MatrixSize; i++)
            {
                for (int j = 0; j < MatrixSize; j++)
                {
                    sum = 0;

                    for (int k = 0; k < MatrixSize; k++)
                    {
                        sum += MatrixCopy[i, k] * MatrixCopy[k, j];
                    }

                    Matrix[i, j] = sum;
                }
            }

            return Matrix;
        }
        #endregion

    }
}
