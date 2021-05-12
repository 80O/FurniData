using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace FurniParser
{
    public static class Actions
    {
        public static void ExportTags(this FurniCache cache)
        {
            var items = new Dictionary<string, HashSet<string>>();
            foreach (var node in cache.Furniture.Values.SelectMany(v => v.Descendants()).ToList())
            {
                if (!items.ContainsKey(node.Name.LocalName))
                    items[node.Name.LocalName] = new HashSet<string>();

                foreach (var attribute in node.Attributes().Select(a => a.Name))
                    items[node.Name.LocalName].Add(attribute.LocalName);
            }

            using var streamWriter = new StreamWriter(Path.Join(cache.Output, "TagsAndAttributesList.json"));
            streamWriter.Write(JsonSerializer.Serialize(items, new() { WriteIndented = true }));
        }

        public static void ExportDrinks(this FurniCache cache)
        {
            var items = cache.Furniture
                .Where(kvp => kvp.Value.Descendants().Any(node => node.Name.LocalName.Contains("drinks"))).Select(x =>
                    new
                    {
                        Name = x.Key,
                        Drinks = x.Value.Descendants().Where(d => d.Name.LocalName.Equals("drink")).Select(drink => int.Parse(drink.Attributes().First(a => a.Name.LocalName.Equals("id")).Value)).OrderBy(d => d).ToList()
                    });

            using var streamWriter = new StreamWriter(Path.Join(cache.Output, "VendingMachineIds.json"));
            streamWriter.Write(JsonSerializer.Serialize(items, new() { WriteIndented = true }));
        }

        public static void ExportStateCount(this FurniCache cache)
        {
            var items = cache.Furniture
                .Where(kvp => kvp.Value.Descendants().Any(node => node.Name.LocalName.Contains("states"))).Select(x =>
                    new
                    {
                        name = x.Key,
                        states = x.Value.Descendants().FirstOrDefault(d => d.Name.LocalName.Equals("states"))?.Descendants("state").Count() ?? 0
                    });
            using var streamWriter = new StreamWriter(Path.Join(cache.Output, "FurnitureStateCount.json"));
            streamWriter.Write(JsonSerializer.Serialize(items, new() { WriteIndented = true }));
        }

        public static void ExportHeights(this FurniCache cache)
        {
            var items = cache.Furniture
                .Where(kvp => kvp.Value.Descendants().Any(node => node.Name.LocalName.Contains("height"))).Select(x =>
                    new
                    {
                        name = x.Key,
                        height = double.Parse(x.Value.Descendants()
                            .FirstOrDefault(d => d.Name.LocalName.Equals("height"))?.Value ?? "0", CultureInfo.InvariantCulture)
                    });

            using var streamWriter = new StreamWriter(Path.Join(cache.Output, "FurnitureHeights.json"));
            streamWriter.Write(JsonSerializer.Serialize(items, new() { WriteIndented = true }));
        }
    }
}