using System;

// Задание №8 практики 2017г.
// Задание 8.7, стр. 3: 7. Граф задан матрицей смежности. Выяснить, является ли он деревом. Для тестирования программы разработать генератор тестов, который позволит сгенерировать набор входных данных, используемых при тестировании.
// Задания по учебной практике

namespace Practice_2017_8
{
    class Program
    {
        static Random Rnd=new Random();

        static bool[,] GenerateAdjacencyMatr()
        {
            int n = Rnd.Next(2, 7); // Размерность матрицы
            bool[,] adjacencyMatr = new bool[n,n];

            for (int i = 0; i < n; i++)
                for (int j = i+1; j < n; j++)
                    adjacencyMatr[i, j] = adjacencyMatr[j, i] = Rnd.Next(2) == 0; // Симметричное заполнение

            return adjacencyMatr;
        }    // Генерирует матрицу размернотси от 2 до 6 включительно

        static void PrintMatr(bool[,] matr)
        {
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.GetLength(1); j++)
                    Console.Write((matr[i,j] ? 1 : 0)+" ");
                
                Console.WriteLine();
            }
        }       // Вывод матрицы на экран

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
        } // Проверяет является ли граф заданный матрицей смежности деревом

        static void StartTesting()
        {
            Console.Write("Введите количество генерируемых тестов (размерность матриц от 2 до 6 включительно): ");
            int testsAmount = Read.Natural();

            for (int i = 0; i < testsAmount; i++)
            {
                bool[,] adjacencyMatr = GenerateAdjacencyMatr();
                PrintMatr(adjacencyMatr);
                Console.WriteLine(IsTree(adjacencyMatr) ? "Заданный граф является деревом\n"
                                                        : "Заданный граф не является деревом\n");
            }
            Console.ReadKey();
        }                // Генерирует заданное кол-во тестов
    
        static void Main(string[] args)
        {
            StartTesting();
        }           // Вызывает функции по тестированию
    }
}
