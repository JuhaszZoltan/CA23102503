using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA23102503
{
    internal class Program
    {
        static void Main()
        {
            var orszagok = new List<Orszag>();
            using (var sr = new StreamReader(@"..\..\src\adatok-utf8.txt", Encoding.UTF8))
            {
                _ = sr.ReadLine();
                while (!sr.EndOfStream) orszagok.Add(new Orszag(sr.ReadLine()));
            }

            Console.WriteLine("\n3.feladat:");
            Console.WriteLine($"Beolvasott országok száma: {orszagok.Count}.");

            Console.WriteLine("\n4. feladat:");
            int f4 = orszagok.Single(o => o.Orszagnev == "Kína").Nepsuruseg;
            Console.WriteLine($"Kína népsűrűsége: {f4} fő/km^2.");

            Console.WriteLine("\n5. feladat:");
            int f5 = orszagok.Single(o => o.Orszagnev == "Kína").Nepesseg
                - orszagok.Single(o => o.Orszagnev == "India").Nepesseg;
            Console.WriteLine($"Kínában a lakosság {f5} fővel volt több.");

            Console.WriteLine("\n6. feladat:");
            var f6 = orszagok.OrderByDescending(o => o.Nepesseg).ToArray()[2];
            Console.WriteLine($"A 3. legtnépesebb ország: " +
                $"{f6.Orszagnev}, a lakossága {f6.Nepesseg} fő.");

            Console.WriteLine("\n7. feladat:");
            Console.WriteLine("A következő országok több, mint 30%-a a fővárosban lakik:");
            foreach (var orszag in orszagok)
            {
                if (orszag.FovarosbaKoncentralodik)
                    Console.WriteLine($"\t{orszag.Orszagnev} ({orszag.Fovaros})");
                
            }
            
            Console.ReadKey(true);
        }
    }
}
