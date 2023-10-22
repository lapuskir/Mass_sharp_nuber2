using System.ComponentModel.DataAnnotations;

class ZD2
{
    /*В массиве X=(x1,x2,…,xn) определить количество элементов, меньших среднего
    арифметического значения. Не упорядочивая массив, удалить из него элементы,
    расположенные между максимальным и минимальным.*/
    static void Main(string[] args)
    {
        float arithmetic_mean = 0;
        int []array = {1,4,6,9,3,5};
        int max_element = array[0];
        int min_element = array[0];
        for (int i = 0; i < array.Length; i++)
        {
            arithmetic_mean += array[i];
        }
        Console.WriteLine($"среднее арифметическое значение равно: {arithmetic_mean / array.Length}");

        for (int i = 0; i < array.Length; i++)
        {   
            if (max_element < array[i])
            {
                max_element = array[i];
            }
            if (min_element > array[i])
            {
                min_element = array[i];
            }
        }
        Console.WriteLine($"максимальный элемент: {max_element}\nминимальный элемент: {min_element}");

        int countBelowAverage = 0;
        float average = arithmetic_mean / array.Length;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < average)
            {
                countBelowAverage++;
            }
        }

        Console.WriteLine($"Количество элементов, меньших среднего: {countBelowAverage}");

        // Удалим элементы между максимальным и минимальным

        int startIndex = Array.IndexOf(array, min_element) + 1;
        int endIndex = Array.LastIndexOf(array, max_element) - 1;

        if (startIndex < endIndex)
        {
            array = DeleteRange(array, startIndex, endIndex);
        }

        // Выведем результат после удаления
        Console.WriteLine("Массив после удаления элементов между максимальным и минимальным:");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
    }
    static int[] DeleteRange(int[] array, int startIndex, int endIndex)
    {
        int[] newArray = new int[array.Length - (endIndex - startIndex + 1)];
        for (int i = 0, j = 0; i < array.Length; i++)
        {
            if (i < startIndex || i > endIndex)
            {
                newArray[j] = array[i];
                j++;
            }
        }
        return newArray;
    }
} 
