using RSA;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var bits = new[] { 8, 16, 48, 512, 1024 };

            foreach (var b in bits)
            {
                var rsa = new Rsa(b);

                var watch = new Stopwatch();
                watch.Start();
                var prime = rsa.GenerateRandomPrime(b);
                watch.Stop();

                Console.WriteLine(watch.Elapsed);
                Console.WriteLine(prime);
            }
            Console.ReadKey();
        }
    }
}
