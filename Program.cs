
using System.Text.RegularExpressions;
// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace NT_D1
{
    
    class Program{

        delegate bool CheckNumberIsPrime(int number);
        static async Task Main(string[] args)
        {
            var sw = new Stopwatch();
            sw.Start();
            var primes = await GetPrimeNumber(0, 1000000, IsPrimeNumber);
            sw.Stop();
            Console.WriteLine("Total prime: {0}\nProcess time: {1}", primes.Count, sw.Elapsed.TotalSeconds);
        }

        static async Task<List<int>> GetPrimeNumber(int minimum, int maximum, CheckNumberIsPrime check){
            var result = new List<int>();
            var primeAsync = await Task.Factory.StartNew(() =>{
                for(int i = minimum; i <= maximum; i++){
                    if (check(i))
                    {
                        result.Add(i);
                    }
                }
                return result;
            });
            return primeAsync;
            
        
        }

        static void PrintNumbers(List<int> numbers){
            foreach (var number in numbers)
            {
                Console.WriteLine($"{number}");
            }
        }
            

        static bool IsPrimeNumber(int number){
            if(number <= 2) return false;
            int i;
            var boundary = (int)Math.Floor(Math.Sqrt(number));
            for (i = 2; i <= boundary; i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
}
