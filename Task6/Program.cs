// Необходимо разделить логику алгоритмов на функции

// Задайте двумерный массив.
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.

// Пример:

// 4 3 1 
// 2 6 9
// 4 6 2
// => Строка с индексом "0"

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

int FindRowWithMinSum(int[,] matrix)
{
    int minSum = int.MaxValue;
    int minSumRowIndex = -1;

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        int rowSum = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            rowSum += matrix[i, j];
        }
        if (rowSum < minSum)
        {
            minSum = rowSum;
            minSumRowIndex = i;
        }
    }

    return minSumRowIndex;
}

int[,] array2d = CreateMatrixRndInt(3, 3, 1, 10);
PrintMatrix(array2d);

int minSumRowIndex = FindRowWithMinSum(array2d);
Console.WriteLine($"Строка с индексом \"{minSumRowIndex}\" имеет наименьшую сумму элементов.");


// Мы вызываем FindRowWithMinSum, передавая ему массив, чтобы найти индекс строки 
// с наименьшей суммой элементов. 

// Функция FindRowWithMinSum проходит по всем строкам массива, вычисляя сумму элементов 
// каждой строки и сравнивая их, чтобы найти наименьшую.

// int.MaxValue - это константа в C#, представляющая максимально возможное значение для типа int. 
// В данном контексте она используется для инициализации переменной minSum, которая будет 
// содержать наименьшую сумму элементов строки.

// Использование int.MaxValue в данном случае гарантирует, что переменная minSum будет 
// инициализирована значением, которое гарантированно будет больше любой возможной 
// суммы элементов в матрице. Это делается, чтобы первая строка матрицы сразу была 
// выбрана в качестве строки с наименьшей суммой элементов, и затем она будет заменена, 
// если будет найдена строка с меньшей суммой элементов.

// Это также помогает в том случае, если матрица состоит из отрицательных чисел, 
// иначе использование 0 как инициализацию minSum не сработает корректно.