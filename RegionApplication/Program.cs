using System;
using System.Threading.Tasks;

namespace RegionApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            SomeAsyncCode();

            Console.ReadKey();
        }
        private static void SomeAsyncCode()
        {
            var fileop = new FileOperation();
            var unparsed = fileop.ReadLines(Console.ReadLine());
            var parser = new Parser();
            var regions = parser.RawRegionsToLocations(unparsed);
            
            RegionService regionService = new RegionService("mongo");
            regionService.ReigionsToDatabase(regions);
        }
    }
}
