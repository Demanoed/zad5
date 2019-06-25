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
        #region Обработка части над побочной диагонали
        public static void ZeroLeftCorner(int x)
        {
            int k = x-1;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    matr[i, j] = 0;
                }
                k--;
            }
        }
        #endregion
        #region Обработка части над главной диагонали
        public static void ZeroRightCorner(int x)
        {
            int z = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = x-1; j > z; j--)
                {
                    matr[i, j] = 0;
                }
                z++;
            }
        }
        #endregion
        #region Поиск максимума
        private static double FindMax(int x)
        {
            double max = matr[0, 0];
            for (int i = 0; i < x; i++)
                for (int j = 0; j < x; j++)
                    if (max < matr[i, j])
                        max = matr[i, j];
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
            ZeroLeftCorner(x);
            ZeroRightCorner(x);
            ColorMess.Yellow("\n Максимальное число, находящееся в нижнем треугольнике равно: " + FindMax(x));
            Message.GoToBack();
        }
        #endregion
    }
}
