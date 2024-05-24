// Необходимо разделить логику алгоритмов на функции

// Напишите программу, которая на вход принимает позиции элемента в двумерном массиве
// и возвращает значение этого элемента или же указание, что такого элемента нет: 
// "Позиция по рядам выходит за пределы массива" или
// "Позиция по колонкам выходит за пределы массива".

// Пример 1:
// 4 3 1 (1,2)
// 2 6 9 
// => 9

// Пример 2:
// 4 3 1 (2,2)
// 2 6 9
// => "Позиция по рядам выходит за пределы массива"

// Пример 3:
// 4 3 1 (1,3)  
// 2 6 9 
// => "Позиция по колонкам выходит за пределы массива"

int[,] CreateMatrixRndInt(int rows, int columns, int min, int max)
{
    int[,] matrix = new int[rows, columns];
    Random rnd = new Random();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
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
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j],4} ");
        }
        Console.WriteLine();
    }
}

string GetElementAtPosition(int[,] matrix, int row, int column)
{
    if (row < 0 || row >= matrix.GetLength(0))
    {
        return "Позиция по рядам выходит за пределы массива";
    }
    if (column < 0 || column >= matrix.GetLength(1))
    {
        return "Позиция по колонкам выходит за пределы массива";
    }
    return matrix[row, column].ToString();
}

Console.WriteLine("Введите количество строк:");
int rows = int.Parse(Console.ReadLine());

Console.WriteLine("Введите количество столбцов:");
int columns = int.Parse(Console.ReadLine());

int[,] array2d = CreateMatrixRndInt(rows, columns, 1, 10);
PrintMatrix(array2d);

Console.WriteLine("Введите номер строки для поиска элемента:");
int row = int.Parse(Console.ReadLine());

Console.WriteLine("Введите номер столбца для поиска элемента:");
int column = int.Parse(Console.ReadLine());

Console.WriteLine($"=> {GetElementAtPosition(array2d, row, column)}");


// Этот код работает следующим образом:

// Пользователь вводит количество строк и столбцов для создания массива.

// Метод CreateMatrixRndInt создает массив указанного размера и заполняет его 
// случайными числами в диапазоне от 1 до 10.

// Метод PrintMatrix выводит массив на консоль.
// Пользователь вводит позиции (строку и столбец) для поиска элемента.

// Метод GetElementAtPosition проверяет границы массива и возвращает либо значение элемента, 
// либо соответствующее сообщение об ошибке.

// Программа будет работать с любым размером двумерного массива и любой позицией, 
// введенной пользователем.