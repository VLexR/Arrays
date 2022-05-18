using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int plan;
                {
                    Console.Write("Введите планируемое потребление килокалорий в сутки: ");
                    plan = Convert.ToInt32(Console.ReadLine());

                   if (plan <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Не балуйся!");
                        Console.ResetColor();
                        continue;
                    }
                }
                string[] namesArray;
                {
                    Console.WriteLine("Перечислите список пользователей через запятую: ");
                    string name = Console.ReadLine();
                    namesArray = name.Split(',');

                    for (int i = 0; i < namesArray.Length; i++)
                        namesArray[i] = namesArray[i].Trim();
                }
                int[][] calloriesArray;
                {
                    calloriesArray = new int[namesArray.Length][];

                    for (int i = 0; i < namesArray.Length; i++)
                    {
                        Console.WriteLine($"Введите через запятую количество потреблённых килокалорий в течении дня для пользователя {namesArray[i]}: ");
                        string sums = Console.ReadLine();
                        string[] sumsArray = sums.Split(',');
                        calloriesArray[i] = new int[sumsArray.Length];

                        for (int j = 0; j < sumsArray.Length; j++)
                        {
                            string sum = sumsArray[j].Trim();
                            calloriesArray[i][j] = Convert.ToInt32(sum);
                        }
                    }
                }
                int[] totalSumsArray;
                {
                    totalSumsArray = new int[calloriesArray.Length];

                    for (int i = 0; i < totalSumsArray.Length; i++)
                    {
                        int totalSum = 0;

                        for (int j = 0; j < calloriesArray[i].Length; j++)
                        {
                            totalSum += calloriesArray[i][j];
                        }
                        totalSumsArray[i] = totalSum;
                    }
                }
                {
                    for (int i = 0; i < totalSumsArray.Length; i++)
                    {
                        Console.Write($"{namesArray[i]} потребил(а) {totalSumsArray[i]} ккал.");
                        double persent;

                        if (totalSumsArray[i] < plan)
                        {
                            persent = (plan - totalSumsArray[i]) / (plan / 100);
                            Console.WriteLine($" План недовыполнен на {persent}%");
                        }
                        else if (totalSumsArray[i] == plan)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(" План выполнен на 100%");
                            Console.ResetColor();
                        }
                        else if (totalSumsArray[i] > plan)
                        {
                            persent = (totalSumsArray[i] - plan) / (plan / 100);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($" План перевыполнен на {persent}%");
                            Console.ResetColor();
                        }
                    }
                }
                Console.ReadKey();
            }

        }
    }
}
