using System;
using System.Collections.Generic;
using System.Text;

namespace AHP_Service
{
    class ServiceCalculations
    {
        public List<float> CalculatePriorities(float[,] Matrix, int MatrixSize)
        {
            MatrixSquare(ref Matrix, MatrixSize);
            MatrixSquare(ref Matrix, MatrixSize); //Square the matrix twice for more precision((?) - Expensive operation)

            float matrixSum = MatrixSum(Matrix, MatrixSize); //Calculate the matrix sum for normalisation

            //Normalised vector

            for(int i = 0; i < MatrixSize; i++)
            {

            }

            return null;
        }

        static public float[,] MatrixInit(int[] ComparisonValues, int MatrixSize)
        ///<summary>Initialises a calculation matrix from comparison values(of alternatives or criteria) passed from the controller. </summary>
        ///<param name="ComparisonValues">Array of integers containing comparison values. The values are in the range [-4, 4], where negative numbers represent
        ///'left' priority and are mapped as |2n-1|. Positive values are mapped as 2n+1 to get the full range of values [1, 9] used in AHP.</param>
        ///<param name="MatrixSize">Number of criteria/alternatives that defines the matrix size.</param>
        ///<returns>2D array of floats that is the calculation matrix for future calculations.</returns>
        {
            float[,] Matrix = new float[MatrixSize, MatrixSize];
            int ComparisonValuesCounter = 0;

            for (int i = 0; i < MatrixSize; i++)
            {
                Matrix[i, i] = 1f;

                for (int j = i + 1; j < MatrixSize; j++)
                {

                    if (ComparisonValues[ComparisonValuesCounter] < 0)
                    {
                        float MappedValue = Math.Abs((2 * ComparisonValues[ComparisonValuesCounter]) - 1);
                        Matrix[i, j] = MappedValue;
                        Matrix[j, i] = 1 / MappedValue;
                    }

                    else
                    {
                        float MappedValue = (2 * ComparisonValues[ComparisonValuesCounter]) + 1;
                        Matrix[i, j] = 1 / MappedValue;
                        Matrix[j, i] = MappedValue;
                    }

                    ComparisonValuesCounter++;
                }

            }

            return Matrix;
        }

        public float MatrixRowSum(int RowNumber, int MatrixSize, ref List<List<float>> Matrix)
        {
            return 1f;
        }

        public float MatrixSum(float[,] Matrix, int MatrixSize)
        {
            return 1f;
        }

        public float[,] MatrixSquare(ref float[,] Matrix, int MatrixSize)
        {
            return null;
        }

    }
}
