// Необходимо разделить логику алгоритмов на функции

// Задайте двумерный массив из целых чисел. 
// Напишите программу, которая удалит строку и столбец, на пересечении которых расположен
// наименьший элемент массива. 
// Под удалением понимается создание нового двумерного массива без
// строки и столбца.

// Пример:

// 4 3 1 
// 2 6 9    
// 4 6 2

// => 2 6
//    4 6

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

(int, int) FindMinElementIndex(int[,] matrix)
{
    int minRow = 0;
    int minCol = 0;
    int minValue = matrix[0, 0];

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] < minValue)
            {
                minValue = matrix[i, j];
                minRow = i;
                minCol = j;
            }
        }
    }

    return (minRow, minCol);
}

int[,] RemoveRowAndColumn(int[,] matrix, int rowToRemove, int colToRemove)
{
    int rows = matrix.GetLength(0);
    int cols = matrix.GetLength(1);
    int[,] newMatrix = new int[rows - 1, cols - 1];

    int newRow = 0, newCol;
    for (int i = 0; i < rows; i++)
    {
        if (i == rowToRemove) continue;
        newCol = 0;
        for (int j = 0; j < cols; j++)
        {
            if (j == colToRemove) continue;
            newMatrix[newRow, newCol] = matrix[i, j];
            newCol++;
        }
        newRow++;
    }

    return newMatrix;
}

int[,] array2d = CreateMatrixRndInt(3, 3, 1, 10);
Console.WriteLine("Original Matrix:");
PrintMatrix(array2d);

(int minRow, int minCol) = FindMinElementIndex(array2d);
int[,] newArray2d = RemoveRowAndColumn(array2d, minRow, minCol);

Console.WriteLine("Modified Matrix:");
PrintMatrix(newArray2d);



// В этой программе:

// 1.Создается случайный двумерный массив.
// 2. Находится индекс минимального элемента.
// 3. Удаляются строка и столбец с минимальным элементом.
// 4. Выводится измененный массив.


// Метод FindMinElementIndex
// Этот метод находит индекс минимального элемента в двумерном массиве.

// Параметры:
// - int[,] matrix: двумерный массив целых чисел, в котором нужно найти минимальный элемент.

// Возвращаемое значение:
// - Кортеж (int, int): индекс строки и столбца минимального элемента.

// Логика работы:

// 1. Инициализируем переменные:

// - minRow и minCol задаем начальные значения 0. 
// Эти переменные будут хранить индексы строки и столбца минимального элемента.
// - minValue задаем начальное значение как первый элемент массива matrix[0, 0]. 
// Эта переменная будет хранить значение минимального элемента.

// 2. Проходим по всем элементам массива:

// - Внешний цикл for (int i = 0; i < matrix.GetLength(0); i++) проходит по строкам массива.
// - Внутренний цикл for (int j = 0; j < matrix.GetLength(1); j++) проходит по столбцам массива.
// - Для каждого элемента массива проверяем, меньше ли он текущего значения minValue.
// - Если да, обновляем minValue и сохраняем индексы текущего элемента в minRow и minCol.

// 3. Возвращаем кортеж (minRow, minCol), содержащий индексы строки и столбца минимального элемента.

// Метод RemoveRowAndColumn
// Этот метод создает новый двумерный массив, исключая заданные строку и столбец.

// Параметры:
// - int[,] matrix: исходный двумерный массив.
// - int rowToRemove: индекс строки, которую нужно удалить.
// - int colToRemove: индекс столбца, который нужно удалить.

// Возвращаемое значение:
// - int[,]: новый двумерный массив без указанной строки и столбца.

// Логика работы:

// 1. Определяем размеры исходного массива:
// - rows и cols - количество строк и столбцов в исходном массиве.

// 2. Создаем новый массив размером (rows - 1, cols - 1):
// - Новый массив будет содержать на одну строку и один столбец меньше, чем исходный.

// 3. Инициализируем переменные для новых индексов:
// - newRow и newCol будут отслеживать текущие индексы в новом массиве.

// 4. Проходим по всем элементам исходного массива:
// - Внешний цикл for (int i = 0; i < rows; i++) проходит по строкам.
// - Внутренний цикл for (int j = 0; j < cols; j++) проходит по столбцам.
// - Пропускаем строки и столбцы, которые нужно удалить:
//   - Если i равно rowToRemove, пропускаем итерацию внешнего цикла.
//   - Если j равно colToRemove, пропускаем итерацию внутреннего цикла.
// - Копируем элементы из исходного массива в новый массив, увеличивая newRow и newCol 
// только если текущая строка и столбец не равны rowToRemove и colToRemove.

// 5. Возвращаем новый массив.