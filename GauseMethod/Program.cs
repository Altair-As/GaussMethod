namespace GauseMethod
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Random random = new Random();
            float[,] matrix = { { 0, 0, 12, 15 }, { 3, 0, -12, 0 }, { 1, -29, -9, 11 } };

            int len = 3;

            float[] temp = new float[len + 1];

            int maxi = 0;

            for (int i = 0; i < len - 1; i++)
            {
                for (int j = i; j <= len - 1; j++)
                {
                    if (Math.Abs(matrix[j, i]) > Math.Abs(matrix[j, i + 1]))
                    {
                        maxi = i + 1;
                    }
                }
                for (int j = 0; j < len + 1; j++)
                {
                    temp[j] = matrix[i, j];
                }
                for (int j = 0; j < len + 1; j++)
                {
                    matrix[i, j] = matrix[maxi, j];
                }
                for (int j = 0; j < len + 1; j++)
                {
                    matrix[maxi, j] = temp[j];
                }
            }

            for (int iter = 0; iter < 3; iter++)
            {
                float itcoef = matrix[iter, iter];
                for (int i = 0; i < 4; i++)
                {
                    matrix[iter, i] = matrix[iter, i] / itcoef;
                }

                for (int i = 0; i < 3; i++)
                {
                    if (i != iter)
                    {
                        float coef = matrix[i, iter];
                        float[] helprow = new float[4];

                        if (coef != 0)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                helprow[j] = matrix[iter, j] * coef;
                            }

                            for (int j = 0; j < 4; j++)
                            {
                                matrix[i, j] = matrix[i, j] - helprow[j];
                            }
                        }
                    }
                }

            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(Math.Round(matrix[i, j], 3) + " ");
                }
                Console.WriteLine();
            }
        }
    }
}