using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FurniParser
{
    public static class Actions
    {
        public static void ExportTags(this FurniCache cache)
        {
            var dict = new Dictionary<string, HashSet<string>>();
            foreach (var node in cache.Furniture.Values.SelectMany(v => v.Descendants()).ToList())
            {
                if (!dict.ContainsKey(node.Name.LocalName))
                    dict[node.Name.LocalName] = new HashSet<string>();

                foreach (var attribute in node.Attributes().Select(a => a.Name))
                    dict[node.Name.LocalName].Add(attribute.LocalName);
            }

            using var streamWriter = new StreamWriter(Path.Join(cache.Output, "TagsAndAttributesList.txt"));
            foreach (var (node, attributes) in dict.OrderBy(kvp => kvp.Key))
            {
                streamWriter.WriteLine(node);
                foreach (var attribute in attributes.OrderBy(d => d))
                    streamWriter.WriteLine($"\t{attribute}");
            }
        }

        public static void ExportDrinks(this FurniCache cache)
        {
            using var streamWriter = new StreamWriter(Path.Join(cache.Output, "VendingMachineIds.txt"));
            foreach (var (name, doc) in cache.Furniture.Where(kvp => kvp.Value.Descendants().Any(node => node.Name.LocalName.Contains("drinks"))))
            {
                var drinks = doc.Descendants().Where(d => d.Name.LocalName.Equals("drink")).ToList();
                if (drinks.Any())
                {
                    streamWriter.WriteLine($"{name} => {string.Join("\t", drinks.Select(drink => drink.Attributes().First(a => a.Name.LocalName.Equals("id")).Value).OrderBy(d => d).ToList())}");
                }
            }
        }

        public static void ExportStateCount(this FurniCache cache)
        {
            using var streamWriter = new StreamWriter(Path.Join(cache.Output, "FurnitureStateCount.txt"));
            foreach (var (name, doc) in cache.Furniture.Where(kvp => kvp.Value.Descendants().Any(node => node.Name.LocalName.Contains("states"))))
            {
                var states = doc.Descendants().FirstOrDefault(d => d.Name.LocalName.Equals("states"));
                if (states != null)
                {
                    streamWriter.WriteLine($"{name} => {states.Descendants("state").Count()}");
                }
            }
        }

        public static void ExportHeights(this FurniCache cache)
        {
            using var streamWriter = new StreamWriter(Path.Join(cache.Output, "FurnitureHeights.txt"));
            foreach (var (name, doc) in cache.Furniture.Where(kvp => kvp.Value.Descendants().Any(node => node.Name.LocalName.Contains("height"))))
            {
                var height = doc.Descendants().FirstOrDefault(d => d.Name.LocalName.Equals("height"));
                if (height != null)
                {
                    streamWriter.WriteLine($"{name} => {height.Value}");
                }
            }
        }
    }
}