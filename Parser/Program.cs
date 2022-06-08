using System;
using System.IO;
using System.Linq;

namespace FurniParser
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Furni JSON Parser Tool v2.0.0");
            Console.WriteLine("By The General @ http://arcturus.pw");
            Console.WriteLine("Download @ https://github.com/80O/FurniData");

            if (!args.Any() || args.Any(arg => arg.Contains("help")))
            {
                DisplayHelp();
                return;
            }

            var jsonLocation = "DataJson/";
            if (args.Any(arg => arg.StartsWith("--json=")))
                jsonLocation = args.First(arg => arg.StartsWith("--json=")).Split("=")[1];

            var outputLocation = ".";
            if (args.Any(arg => arg.StartsWith("--out=")))
                outputLocation = args.First(arg => arg.StartsWith("--out=")).Split("=")[1];

            if (!Directory.Exists(jsonLocation))
            {
                Console.Error.WriteLine($"Path {jsonLocation} not a valid path to data directory.");
                return;
            }

            if (!Directory.Exists(outputLocation) &&
                !Directory.CreateDirectory(outputLocation).Exists)
            {
                Console.Error.WriteLine($"Failed to create missing output directory {new DirectoryInfo(outputLocation).FullName}");
                return;
            }

            Console.WriteLine("Loading data... This might take a while...");

            var furniCache = new FurniCache { JsonLocation = jsonLocation, Output = outputLocation };
            furniCache.Load();

            Console.WriteLine($"Loaded {furniCache.Furniture.Count} furniture!");

            var all = args.Any(arg => arg.StartsWith("--all"));

            var exportStateCount = all || args.Any(arg => arg.Equals("--states"));
            if (exportStateCount)
            {
                Console.WriteLine("Exporting Furniture State Count");
                furniCache.ExportStateCount();
            }

            var exportHeights = all || args.Any(arg => arg.Equals("--heights"));
            if (exportHeights)
            {
                Console.WriteLine("Exporting Furniture Height");
                furniCache.ExportHeights();
            }

            Console.WriteLine("Done! See you again :)");
        }

        private static void DisplayHelp()
        {
            Console.WriteLine("Created to help export different parts of the furniture JSON files into a simple format for further processing.");
            Console.WriteLine("Some information has recently been removed. If you want to extract data from XMLs, use version 1.0.0");
            Console.WriteLine("");
            Console.WriteLine("The following arguments are available:");
            Console.WriteLine("");
            Console.WriteLine("--all = Export everything.");
            Console.WriteLine("--drinks = Export Drink Ids.");
            Console.WriteLine("--help = Show this dialog.");
            Console.WriteLine("--heights = Export Heights.");
            Console.WriteLine("--states = Export State counts.");
            Console.WriteLine("--out = Output location. (Default: --out=.)");
            Console.WriteLine("--json = Path to JSON folder location. (Default: --json=DataJson/)");
        }
    }
}
