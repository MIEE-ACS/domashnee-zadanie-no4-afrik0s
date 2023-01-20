using System;

namespace ConsoleApp3
{
    class Program
    {
        static bool Check(string s)
        {
            foreach (char item in s)
            {
                if (item != ',')
                {
                    if (char.IsDigit(item) == false)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Console.Write("Количество cтолбцов: ");

            string s = Console.ReadLine();
            while (Check(s))
            {
                Console.Write("\nОшибка. Введите число: ");
                s = Console.ReadLine();
            }
            int n = int.Parse(s);
            Console.Write("Количество строк:  ");

            string s1 = Console.ReadLine();
            while (Check(s))
            {
                Console.Write("\nОшибка. Введите число: ");
                s1 = Console.ReadLine();
            }
            int m = int.Parse(s1);
            int[,] mass = new int[n, m];
            int n2 = n + 1;
            int[,] mass2 = new int[n2, m];
            for (int y = 0; y < m; y++)
            {
                for (int x = 0; x < n; x++)
                {
                    mass[x, y] = rnd.Next(-10, 10);
                }
            }
            Console.Write("\n Сгенерированный массив: \n");
            for (int y = 0; y < m; y++)
            {
                for (int x = 0; x < n; x++)
                {
                    Console.Write(mass[x, y] + "\t");
                }
                Console.Write("\n");
            }
            
            int count = 0;
            for (int x = 0; x < n; x++)
            {
                for (int y = 0; y < m; y++)
                {
                    if (mass[x, y] == 0)
                    {
                        count++;
                        break;
                    }
                }
            }
            count = n - count;
            Console.Write($"Количество столбцов, не содержащих ни одного нулевого элемента: {count}");
            // Вторая часть задания:
            for (int y = 0; y < m; y++)
            {
                for (int x = 0; x < n; x++)
                {
                    mass2[x, y] = mass[x, y];
                }
            }            
            int sum = 0;
            for (int y = 0; y < m; y++)
            {
                for (int x = 0; x < n; x++)
                {
                    if (mass2[x, y] >= 0 && mass2[x, y] % 2 == 0)
                    {
                        sum = sum + mass2[x, y];
                    }
                   
                }
                mass2[n, y] = sum;
                sum = 0;
            } 
            /*Console.Write($"\n Второй массив: \n");
            for (int y = 0; y < m; y++)
            {
                for (int x = 0; x < n2; x++)
                {
                    Console.Write(mass2[x, y] + "\t");
                }
                Console.Write("\n");
                
            } */
            // Сортировка второго массива
            int tmp; 
            for (int i = 0; i < mass2.GetLength(1) - 1; i++)
            {
                for (int j = i; j < mass2.GetLength(1); j++)
                {
                    if (mass2[n, i] > mass2[n, j])
                        for (int k = 0; k < mass2.GetLength(0); k++)
                        {
                            tmp = mass2[k, i];
                            mass2[k, i] = mass2[k, j];
                            mass2[k, j] = tmp;
                        }
                }
            }
            Console.Write($"\n Осортированный массив \n");
            for (int y = 0; y < m; y++)
            {
                for (int x = 0; x < n; x++)
                {
                    Console.Write(mass2[x, y] + "\t");
                }
                Console.Write("\n");

            }

        }
    }
}