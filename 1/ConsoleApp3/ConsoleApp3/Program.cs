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

            double sum = 0;
            int maxi=0, mini=0;
              
            Random rnd = new Random();
            Console.Write("Размер массива N = ");
            
            string s = Console.ReadLine();
            while (Check(s))
            {
            Console.Write("\nОшибка. Введите число: ");
            s = Console.ReadLine();
            }
    int n = int.Parse(s);
    double[] array = new double[n];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Math.Round(rnd.NextDouble() * 200 - 100, 2);

            }
            Console.Write("Сгенерированный массив: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");

            }
            double max = array[0];
            double min = array[0];
            Console.Write("\n");
            for (int i=0; i<array.Length; i++)
            {
                if(array[i]>=0)
                {
                    sum = sum + array[i];
                }
            }
            sum = Math.Round(sum, 2);
            Console.WriteLine($"Cумма положительных элементов массива: {sum}");
            // Нахождение номера наибольшего по модулю числа.
            for (int i = 0; i < array.Length; i++)
            {
                if (Math.Abs(array[i]) >= Math.Abs(max))
                {
                    max = array[i];
                    maxi = i;   
                }
            }
            // Нахождение номера наименьшего по модулю числа.
            for (int i = 0; i < array.Length; i++)
            {
                if (Math.Abs(array[i]) <= Math.Abs(min))
                {
                    min = array[i];
                    mini = i;
                }
            }
          
            double pr = 1;
            if(maxi < mini)
            {
                for(int i = maxi+1; i<mini;i++)
                {
                    pr = pr * array[i];
                }
            }
            if(maxi>mini)
            {
                for(int i = mini+1; i < maxi; i++)
                {
                    pr = pr * array[i];
                }
            }
            pr = Math.Round(pr, 2);
            if (Math.Abs(maxi - mini) == 1)
            {
                Console.Write($"Произведение элементов массива, расположенных между максимальным по модулю и минимальным по модулю элементами: 0 \n");
            }
            else
            {
                Console.Write($"Произведение элементов массива, расположенных между максимальным по модулю и минимальным по модулю элементами: {pr} \n");
            }
            Array.Sort(array);
            Array.Reverse(array);
            Console.Write("Массив, отсортированный по убыванию: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.Write("\n");
        }
    }
}

