using System;
using System.IO;
using System.Linq;

namespace FurniParser
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Furni XML Parser Tool");
            Console.WriteLine("By The General @ http://arcturus.pw");
            Console.WriteLine("Download @ https://github.com/80O/FurniData");

            if (!args.Any() || args.Any(arg => arg.Contains("help")))
            {
                DisplayHelp();
                return;
            }

            var xmlsLocation = "Data/";
            if (args.Any(arg => arg.StartsWith("--xmls=")))
                xmlsLocation = args.First(arg => arg.StartsWith("--xmls=")).Split("=")[1];

            var outputLocation = ".";
            if (args.Any(arg => arg.StartsWith("--out=")))
                outputLocation = args.First(arg => arg.StartsWith("--out=")).Split("=")[1];

            if (!Directory.Exists(xmlsLocation))
            {
                Console.Error.WriteLine($"Path {xmlsLocation} not a valid path to data directory.");
                return;
            }

            if (!Directory.Exists(outputLocation) &&
                !Directory.CreateDirectory(outputLocation).Exists)
            {
                Console.Error.WriteLine($"Failed to create missing output directory {new DirectoryInfo(outputLocation).FullName}");
                return;
            }

            var furniCache = new FurniCache { XmlLocation = xmlsLocation, Output = outputLocation };
            furniCache.Load();

            Console.WriteLine($"Loaded {furniCache.Furniture.Count} furniture!");

            var all = args.Any(arg => arg.StartsWith("--all"));

            var exportTags = all || args.Any(arg => arg.Equals("--tags"));
            if (exportTags)
            {
                Console.WriteLine("Exporting Unique Tags");
                furniCache.ExportTags();
            }

            var exportDrinks = all || args.Any(arg => arg.Equals("--drinks"));
            if (exportDrinks)
            {
                Console.WriteLine("Exporting Drink Ids");
                furniCache.ExportDrinks();
            }

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
            Console.WriteLine("Created to help export different parts of the furniture XML files into a simple format for further processing.");
            Console.WriteLine("");
            Console.WriteLine("The following arguments are available:");
            Console.WriteLine("");
            Console.WriteLine("--all = Export everything.");
            Console.WriteLine("--drinks = Export Drink Ids.");
            Console.WriteLine("--help = Show this dialog.");
            Console.WriteLine("--heights = Export Heights.");
            Console.WriteLine("--states = Export State counts.");
            Console.WriteLine("--tags = Export all unique tags.");
            Console.WriteLine("--out = Output location. (Default: --out=.)");
            Console.WriteLine("--xmls = Path to XML folder location. (Default: --xmls=Data/)");
        }
    }
}
