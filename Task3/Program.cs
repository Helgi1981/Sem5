// Задание 3. Совместная работа

// Задайте двумерный массив из целых чисел. Сформируйте новый одномерный массив,
// состоящий из средних арифметических значений по строкам двумерного массива.

// Пример:

// 2 3 4 3
// 4 3 4 1   =>   [3 3 5]
// 2 9 5 4

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

void PrintArray(double[] array)
{
    Console.Write("[");
    for (int i = 0; i < array.Length; i++)
    {
        if (i < array.Length - 1)
        {
            Console.Write($"{array[i]:F2}, "); // :F2 - округление
        }
        else
        {
            Console.Write($"{array[i]:F2}"); // :F2 - округление
        }
    }
    Console.Write("]");
}

double[] GetAverageArrayRows(int[,] matrix)
{
    double[] array = new double[matrix.GetLength(0)];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        int sum = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            sum += matrix[i, j];
        }
        array[i] = (double)sum / matrix.GetLength(1);
    }
    return array;
}

int[,] array2d = CreateMatrixRndInt(3, 4, 1, 10);
PrintMatrix(array2d);

Console.WriteLine();

double[] result = GetAverageArrayRows(array2d);
PrintArray(result);