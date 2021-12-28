﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Collections.Concurrent;

namespace _16_лаба
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===============================   TASK 1   ===============================");

            Task Eratos = new Task(() => ErSieve(300));                           
            Console.WriteLine($"Task ID:              {Eratos.Id}");              
            Console.WriteLine($"Status when created:  {Eratos.Status}");        
            Eratos.Start();                                                       
            Console.WriteLine($"Status when started:  {Eratos.Status}\n");        
            Eratos.Wait();                                                        // здесь Main ждет, пока не 
            Console.WriteLine($"Status when ended:    {Eratos.Status}");          // отработает Task Eratos




            Console.WriteLine("===============================   TASK 2   ===============================");

            Task Eratos2 = new Task(() => EratosSieve2(400));                           /// во втором методе реализован токен отмены
            Console.WriteLine($"Task #{Eratos2.Id} status:       {Eratos2.Status}");
            Eratos2.Start();

            Console.WriteLine("Enter 0 to stop the process:\n");                       
            string s = Console.ReadLine();                                            
            if (s == "0")                                                                
                tokenSource.Cancel();                                                  
            Console.WriteLine($"Task #{Eratos2.Id} status:       Completed");




            Console.WriteLine("===============================   TASK 3   ===============================");
            Task<int> task3_1 = new Task<int>(() =>               // здесь просто 3 рандомных формулы
            {
                int x = 2;
                for (int i = 1; i < 7; i++)
                    x *= i;
                Console.WriteLine($"Result #1:            {x}");
                return x;
            });

            Task<int> task3_2 = new Task<int>(() =>
            {
                int x = 1;
                for (int i = 1; i < 4; i++)
                {
                    x++;
                    x *= x;
                }
                Console.WriteLine($"Result #2:            {x}");
                return x;
            });

            Task<int> task3_3 = new Task<int>(() =>
            {
                int z = -300;
                for (int i = 0; i < 54; i++)
                    z += i;
                Console.WriteLine($"Result #3:            {z}");
                return z;
            });

            Task[] tasks = { task3_1, task3_2, task3_3 };
            foreach (Task task in tasks)
                task.Start();              
            Task.WaitAll(tasks);            
            Console.WriteLine("Sum of all results:   " + (task3_1.Result + task3_2.Result + task3_3.Result));




            Console.WriteLine("===============================   TASK 4   ===============================");
            Task<int> task1 = new Task<int>(() => Sum(42, 53));            
            Task task2 = task1.ContinueWith(sum => Display(sum.Result));    // эта задача запускается после завершения первой
            task1.Start();                                                  // запускаем первую задачу
            task2.Wait();                                                   // и ждем окончания второй



            Console.WriteLine("===============================   TASK 5   ===============================");
            List<long> list = new List<long>() { 8, 10, 7, 12 };                // "большой массив"

            Console.WriteLine("Parallel cycle:\n");
            ParallelLoopResult result = Parallel.ForEach<long>(list, Factorial);// с помощью паралелльно форича считаем факториалы

            Console.WriteLine("\nDefault cycle:\n");                            // то же самое с дефолтным форичем
            foreach (long l in list)                                            
            {                                                                   // и тот и тот процесс выполняются за 0.01 сек
                long result1 = 1;                                               
                for (int i = 1; i <= l; i++)
                    result1 *= i;
                Console.WriteLine($"Factorial of {l} is {result1}.");
            }




            Console.WriteLine("===============================   TASK 6   ===============================");
            Console.WriteLine("Using Invoke():");                               // вывызваем параллельно через Invoke()
            Parallel.Invoke(Display,                                            // три метода и тот кто пошустрее 
            () =>
            {                                                             // выполнится первый
                Console.WriteLine($"Completing Task #{Task.CurrentId}");
            },
            () => Factorial(5));




            Console.WriteLine("===============================   TASK 8   ===============================");
            FactorialAsync();                               /// асинхронная функция факториала
            Console.WriteLine("Main is still running.");
            Console.ReadKey();
        }                              
           



        

        // Поле с соусом для токенов (юзается в функциях Ератосфена ниже)
        public static CancellationTokenSource tokenSource = new CancellationTokenSource();



        public static void Factorial()
        {
            int result = 1;
            for (int i = 1; i <= 6; i++)
            {
                result *= i;
            }
            Thread.Sleep(1000);
            Console.WriteLine($"Factorial equals {result}");
        }


        public static async void FactorialAsync()
        {
            Console.WriteLine("Start of FactorialAsync");
            await Task.Run(() => Factorial());
            Console.WriteLine("End of FactorialAsync");
        }


        static void Display()
        {
            Console.WriteLine($"Display: Running Task #{Task.CurrentId}");
        }


        public static void Factorial(long x)
        {
            long result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            Console.WriteLine($"Completing Task #{Task.CurrentId}...");
            Console.WriteLine($"Factorial of {x} is {result}.");
        }


        public static int Sum(int a, int b)
        {
            Console.WriteLine($"Input A:              {a}\nInput B:              {b}");
            return (a + b);
        }


        public static void Display(int sum)
        {
            Console.WriteLine($"Sum of A+B:           {sum}");
        }


        public static void ErSieve(int n)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            bool[] flags = new bool[n];

            for (int i = 0; i < flags.Length; i++)
                flags[i] = true;

            flags[1] = false;
            for (int i = 2, j = 0; i < n;)
            {
                if (flags[i])
                {
                    j = i * 2;
                    while (j < n)
                    {
                        flags[j] = false;
                        j += i;
                    }
                }
                i++;
            }

            Console.WriteLine($"All simple numbers from 1 to {n}:");
            for (int i = 2; i < flags.Length; i++)
            {
                if (flags[i])
                {
                    Thread.Sleep(1);
                    Console.Write($"{i} ");
                }
            }
            Console.WriteLine();

            stopWatch.Stop();                                                     // останавливаем StopWatch 
            TimeSpan ts = stopWatch.Elapsed;                                      // и выводим,сколько времени 
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",     // заняла наша задача
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("\nTotal runtime:        " + elapsedTime);
        }


        public static void EratosSieve2(int n)
        {
            CancellationToken tokenForEr = tokenSource.Token;

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            bool[] flags = new bool[n];

            for (int i = 0; i < flags.Length; i++)
                flags[i] = true;

            flags[1] = false;
            for (int i = 2, j = 0; i < n;)
            {
                Console.WriteLine($"Running task #{Task.CurrentId}...");
                System.Threading.Thread.Sleep(3000);
                if (flags[i])
                {
                    j = i * 2;
                    while (j < n)
                    {
                        flags[j] = false;
                        j += i;
                    }
                }
                i++;

                if (tokenSource.Token.IsCancellationRequested)
                    return;

                if (tokenForEr.IsCancellationRequested)                         
                {                                                               
                    Console.WriteLine("\nThe process was stopped.");            
                    break;
                    return;
                }
            }
            Console.WriteLine($"All simple numbers from 1 to {n}:  ");
            for (int i = 2; i < flags.Length; i++)
            {
                if (flags[i])
                {
                    Console.Write($"{i} ");
                }
            }

            Console.WriteLine();
            stopWatch.Stop();                                                     
            TimeSpan ts = stopWatch.Elapsed;                                      
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",     
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("\nTotal runtime:        " + elapsedTime);
        }

    }
}