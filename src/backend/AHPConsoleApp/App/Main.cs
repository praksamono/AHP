using System;
using System.Collections.Generic;

namespace AHP_Console
{
    class Program
    {
        public int CriteriaNumber;
        public int AlternativesNumber;
        public List<Criterion> CriterionList;
        public List<Alternative> AlternativesList;
        public List<List<float>> Matrix; //(One) Matrix used for calculations in the program

        public static void Main()
        {
            Program AHP = new Program();

            Console.WriteLine("Specify the goal name:");
            String GoalName = (Console.ReadLine());

            Goal goal = new Goal(GoalName);

            //---------- CRITERIA INPUT AND CALCULATION -----------

            Console.WriteLine("Specify the amount of criteria:");
            AHP.CriteriaNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(AHP.CriteriaNumber);

            AHP.CriterionList = new List<Criterion>();  //Initialise the list of criteria for this AHP instance

            for (int i = 0; i < AHP.CriteriaNumber; i++) //Handles the input of criteria and their addition to the AHP instance criteria list
            {
                Console.WriteLine("Type the name of the " + (i + 1) + ". criteria");
                string CriterionName = Console.ReadLine();
                AHP.CriterionList.Add(new Criterion(CriterionName)); 
            }

            AHP.Matrix = new List<List<float>>();
            AHP.CalculateCriteriaPriorities(); //Calculate criterion priorities

            //---------- ALTERNATIVES INPUT AND CALCULATION -----------

            Console.WriteLine("Specify the amount of alternatives:");
            AHP.AlternativesNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(AHP.AlternativesNumber);

            AHP.AlternativesList = new List<Alternative>();

            for (int i = 0; i < AHP.AlternativesNumber; i++) //Handles the input of alternatives and their addition to the program instance alternatives list
            {
                Console.WriteLine("Type the name of the " + (i + 1) + ". alternative");
                string AlternativeName = Console.ReadLine();
                AHP.AlternativesList.Add(new Alternative(AlternativeName));
            }

            for(int i = 0; i < AHP.CriteriaNumber; i++) //Calculate alternative local priorities by every criteria
            {
                Console.WriteLine("Current criteria: " + AHP.CriterionList[i]._name);
                AHP.CalculateAlternativePriorities(i);
            }

            for(int i = 0; i < AHP.AlternativesNumber; i++) //Display the final priorities of alternatives
            {
                Console.WriteLine(AHP.AlternativesList[i]._name + " has total priority: " + AHP.AlternativesList[i]._goalPriority);
            }
        }

        public void CalculateCriteriaPriorities()
        {
            MatrixInit(CriteriaNumber); //Delete previous matrix, make a new one with size of CriteriaNumber
            Console.WriteLine("Rate the priority of criteria A over criteria B [-9, 9]");

            for (int i = 0; i < this.CriteriaNumber - 1; i++) //Handles the user rating of criteria priority
            {
                
                for (int j = i + 1; j < this.CriteriaNumber; j++)
                {
                    Console.WriteLine(this.CriterionList[i]._name + "  " + this.CriterionList[j]._name);
                    float rating = Convert.ToInt32(Console.ReadLine());
                    if (rating < 0)
                    {
                        rating = Math.Abs(rating);
                        Matrix[i][j] = rating;
                        Matrix[j][i] = 1 / rating;
                    }
                    else
                    {
                        Matrix[i][j] = 1 / rating;
                        Matrix[j][i] = rating; 
                    }                          
                }

            }

            MatrixSquare(CriteriaNumber); //Double squaring for precision
            MatrixSquare(CriteriaNumber);

            //Calculate final priority values for each criterion(Matrix row)
            float matrixSum = MatrixSum(CriteriaNumber); //Calculate the sum of all matrix elements for normalisation
            for(int i = 0; i < CriteriaNumber; i++)
            {
                this.CriterionList[i]._priority = MatrixRowSum(i, CriteriaNumber)/matrixSum; //Divide the row sum for each criterion with the matrix sum, normalisation
                //DEBUG output Console.WriteLine(this.CriterionList[i]._name + " has priority: " + this.CriterionList[i]._priority);
            }

        }

        public void CalculateAlternativePriorities(int CriteriaNumber)
        {
            MatrixInit(AlternativesNumber); //Delete previous matrix, make a new one with size of CriteriaNumber            
            Console.WriteLine("Rate the priority of alternative A over alternative B [-9, 9]");

            for (int i = 0; i < this.AlternativesNumber - 1; i++) //Handles the user rating of alternative priority
            {

                for (int j = i + 1; j < this.AlternativesNumber; j++)
                {
                    Console.WriteLine(this.AlternativesList[i]._name + "  " + this.AlternativesList[j]._name);
                    float rating = Convert.ToInt32(Console.ReadLine());
                    if (rating < 0)
                    {
                        rating = Math.Abs(rating);
                        Matrix[i][j] = rating;
                        Matrix[j][i] = 1 / rating;
                    }

                    else
                    {
                        Matrix[i][j] = 1 / rating;
                        Matrix[j][i] = rating;
                    }
                }

            }

            MatrixSquare(AlternativesNumber); //Double squaring for precision
            MatrixSquare(AlternativesNumber);
            
            //Calculate final priority values for each alternative in respect to current criterion(Matrix row)
            float matrixSum = MatrixSum(AlternativesNumber); //Calculate the sum of all matrix elements for normalisation
            for (int i = 0; i < AlternativesNumber; i++)
            {   
                float Value = MatrixRowSum(i, AlternativesNumber) / matrixSum; //Divide the row sum for each alternative with the matrix sum, normalisation
                this.AlternativesList[i]._priorities.Add(Value); 
                this.AlternativesList[i]._goalPriority += Value * this.CriterionList[CriteriaNumber]._priority;
                //DEBUG output Console.WriteLine(this.AlternativesList[i]._name + " has priority: " + this.AlternativesList[i]._priorities[CriteriaNumber] + " in " + this.CriterionList[CriteriaNumber]._name);
            }

        }

        public void MatrixInit(int MatrixSize) //This method reinitializes and cleans up a matrix before any calculation
        {
            Matrix.Clear(); //Delete all elements
            Matrix.TrimExcess(); //Trim matrix element count

            for(int i = 0; i < MatrixSize; i++)
            {
                Matrix.Add(new List<float>(MatrixSize));

                for(int j = 0; j < MatrixSize; j++)
                {
                    Matrix[i].Add(1f);
                }
            }
        }
        public void MatrixSquare(int MatrixSize) //This method squares a matrix
        {
            List<List<float>> MatrixOld = new List<List<float>>(MatrixSize);  //Create a copy of the matrix that is to be squared

            for (int i = 0; i < MatrixSize; i++) //Deep copy the values of the matrix for squaring
            {
                MatrixOld.Add(new List<float>(MatrixSize)); 

                for (int j = 0; j < MatrixSize; j++)
                {
                    float CopyValue = Matrix[i][j];
                    MatrixOld[i].Add(CopyValue);
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
                        sum += MatrixOld[i][k] * MatrixOld[k][j]; 
                    } 

                    Matrix[i][j] = sum;                    
                }
            }
        }
        public float MatrixRowSum(int rowNumber, int MatrixSize) //Calculate the sum of the object's matrix row 
        {
            float RowSum = 0;
            for(int i = 0; i < MatrixSize; i++)
            {
                RowSum += Matrix[rowNumber][i];   
            }

            return RowSum;
        }

        public float MatrixSum(int MatrixSize) //Calculate the sum of all matrix elements
        {
            float MatrixSum = 0;
            for(int i = 0; i < MatrixSize; i++)
            {
                for(int j = 0; j < MatrixSize; j++)
                {
                    MatrixSum += Matrix[i][j];
                }                  
            }

            return MatrixSum;
        }

        public void MatrixPrint(int MatrixSize)
        {
            for (int i = 0; i < MatrixSize; i++)
            {
                Console.Write("| ");
                for (int j = 0; j < MatrixSize; j++)
                {
                    Console.Write(" " + Matrix[i][j]);
                }
                Console.WriteLine(" |");
            }

            Console.WriteLine();
        }
    }
    
}
