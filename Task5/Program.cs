// Необходимо разделить логику алгоритмов на функции

// Задайте двумерный массив. 
// Напишите программу, которая поменяет местами первую и последнюю строку массива.

// Предполагается, что строки разделены запятой и пробелом,
// а элементы внутри строк разделены табуляцией.

// Пример:

// Вход:
// int[,] numbers = new int[,] {
//     {1, 2, 3, 4},
//     {5, 6, 7, 8},
//     {9, 10, 11, 12}
// };

// Вывод:
// 9   10  11  12
// 5   6   7   8
// 1   2   3   4

// Чтобы поменять местами первую и последнюю строки массива, добавим функцию 
// SwapFirstAndLastRows, которая будет принимать двумерный массив и менять местами 
// первую и последнюю строки. Затем вызовем эту функцию в основном коде после 
// создания и вывода массива.

int[,] CreateMatrixRndInt(int rows, int columns, int min, int max)
{
    int[,] matrix = new int[rows, columns]; // размер матрицы: 3x4
    Random rnd = new Random();

    for (int i = 0; i < matrix.GetLength(0); i++) // for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++) // for (int j = 0; j < columns; j++)
        {
            matrix[i, j] = rnd.Next(min, max);
        }
    }

    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        // Console.Write("|");
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j],4} "); // ],4} - размер выводимой строки (соответствует максимальному количеству символов элемента)
        }
        // Console.WriteLine(" |");
        Console.WriteLine();
    }
}

void SwapFirstAndLastRows(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);

    // Проверка, что матрица имеет хотя бы две строки
    if (rows < 2)
    {
        Console.WriteLine("Matrix has less than two rows. Cannot perform swap.");
        return;
    }

    // Сохраняем первую строку во временном массиве
    int[] tempRow = new int[columns];
    for (int j = 0; j < columns; j++)
    {
        tempRow[j] = matrix[0, j];
    }

    // Копируем последнюю строку в первую
    for (int j = 0; j < columns; j++)
    {
        matrix[0, j] = matrix[rows - 1, j];
    }

    // Копируем сохраненную первую строку в последнюю
    for (int j = 0; j < columns; j++)
    {
        matrix[rows - 1, j] = tempRow[j];
    }
}

int[,] array2d = CreateMatrixRndInt(3, 4, 1, 20);
Console.WriteLine("Original matrix:");
PrintMatrix(array2d);

SwapFirstAndLastRows(array2d);
Console.WriteLine("\nMatrix after swapping first and last rows:");
PrintMatrix(array2d);

// Теперь после создания матрицы вызывается функция SwapFirstAndLastRows, 
// а затем выводится измененная матрица.
