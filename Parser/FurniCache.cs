using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace FurniParser
{
    public class FurniCache
    {
        private readonly Dictionary<string, XDocument> _furnitureXmls = new();

        public IReadOnlyDictionary<string, XDocument> Furniture => _furnitureXmls;

        public string XmlLocation { get; init; }
        public string Output { get; init; }

        public void Load()
        {
            foreach (var file in Directory.GetFiles(XmlLocation))
            {
                try
                {
                    using var fileStream = File.OpenRead(file);
                    var doc = XDocument.Load(fileStream);
                    _furnitureXmls[Path.GetFileNameWithoutExtension(file)] = doc;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Failed to read {file}");
                }
            }
        }
    }
}