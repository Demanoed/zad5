using System;
using DemanT_Library;

namespace Find_max_in_lower_triangle
{
    class Program
    {
        #region Матрица
        private static double[,] matr;
        #endregion
        #region Создает матрицу
        public static void CreateMatrix(int x)
        {
            int k = Message.HowAdd();
            if (k == 1)
            {
                for (int i = 0; i < x; i++)
                    for (int j = 0; j < x; j++)
                    {
                        ColorMess.Cyan("\n Введите [" + i + "," + j + "] элемент матрицы: ");
                        matr[i, j] = Input.Check(double.MinValue, double.MaxValue);
                    }
            }
            else
            {
                for (int i = 0; i < x; i++)
                    for (int j = 0; j < x; j++)
                        matr[i, j] = RandomMy.NumberDiap(-100, 100);
            }
        }
        #endregion
        #region Печатает матрицу
        public static void PrintMatrix(int x)
        {
            ColorMess.Yellow("\n Ваша матрица выглядит так: \n");
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    ColorMess.Cyan("\t" + matr[i, j]);
                }
                Console.WriteLine();
            }
        }
        #endregion
        #region Поиск максимума
        private static double FindMax(int x)
        {
            int k = 0;
            double max = matr[x-1, x-1];
            for (int i = x-1; i > -1; i--)
            {
                for (int j = k; j < x - k; j++)
                    if (max < matr[i, j])
                        max = matr[i, j];
                k++;
            }
                return max;
        }
        #endregion
        #region Запрос на ввод значений и вывод результата
        static void Main()
        {
            ColorMess.Yellow("\n Введите количество строк и столбцов (одно число в диапазоне от 2 до 10): ");
            int x = Input.Check(2, 10);
            matr = new double[x, x];
            CreateMatrix(x);
            Console.Clear();
            PrintMatrix(x);
            ColorMess.Yellow("\n Максимальное число, находящееся в нижнем треугольнике равно: " + FindMax(x));
            Message.GoToBack();
        }
        #endregion
    }
}
