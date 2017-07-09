using System;

// Задание №8 практики 2017г.
// Задание 8.7, стр. 3: 7. Граф задан матрицей смежности. Выяснить, является ли он деревом. Для тестирования программы разработать генератор тестов, который позволит сгенерировать набор входных данных, используемых при тестировании.
// Задания по учебной практике

namespace Practice_2017_8
{
    class Program
    {
        static bool IsTree(bool[,] adjacencyMatr)
        {                   // Матрица смежности
            int edges = 0, n = adjacencyMatr.GetLength(0);      // edges - количество рёбер и n - размерность матрицы и количество вершин

            for (int i = 0; i < n; i++)                         // Проходимся повсем рядам
            {
                bool onlyZeroes = true;                         // Маркер того, что в ряду нет единиц
                for (int j = 0; j < n; j++)                     // По всем столбцам
                {
                    if (!adjacencyMatr[i, j]) continue;         // Пропускаем нули
                    onlyZeroes = false;                         // Если 1, то меняем маркер и прибавляем рёбра
                    edges++;
                }
                if (onlyZeroes | edges / 2 >= n) return false;  // Если в ряду одни нули (значит граф не связный) или кол-во рёбер больше n-1 (у деревьев кол-во рёбер на 1 меньше, чем вершин), то граф не является деревом
            }
            return true;
        }    // Проверяет является ли граф заданный матрицей смежности деревом

        static bool[,] ReadAdjacencyMatr()
        {
            Console.Write("Введите размерность матрицы смежности: ");
            int n = int.Parse(Console.ReadLine());

            bool[,] adjacencyMatr = new bool[n, n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите " + (i + 1) + "-ую строку элементов (через пробел, единицы или нули):");
                string row = Console.ReadLine();
                for (int j = 0; j < n; j++)
                    adjacencyMatr[i, j] = int.Parse(row.Split(' ')[j]) == 1;
            }
            return adjacencyMatr;
        }           // Ввод матрицы смежности вручную

        static void Main(string[] args)
        {
            Console.WriteLine(IsTree(ReadAdjacencyMatr()) ? "Заданный граф является деревом"
                                                          : "Заданный граф не является деревом");
            
            Console.ReadKey();
        }
    }
}
