// Задание 1. Совместная работа

// Задайте двумерный массив. Найдите элементы, у которых оба индекса чётные
// и замените эти элементы на их квадраты.

// Пример:            [0] [1]  [2] [3]
// 2 3 4 3         [0] 4   3   16   3 
// 4 3 4 1   =>    [1] 4   3    4   1  
// 2 9 5 4         [2] 4   9   25   4

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

void ElemEvenIndexesToSquare(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i += 2) // к i прибавляем только чётные индексы (через один)
    {
        for (int j = 0; j < matrix.GetLength(1); j += 2) // к j прибавляем только чётные индексы (через один)
        {
            // if (i % 2 == 0 && j % 2 == 0) так как цикл идёт только по чётным индексам, проверка не нужна
            // {
            matrix[i, j] *= matrix[i, j];
            // }
        }
    }
}

int[,] array2d = CreateMatrixRndInt(3, 4, 1, 10);
PrintMatrix(array2d);

Console.WriteLine();

ElemEvenIndexesToSquare(array2d);
PrintMatrix(array2d);
