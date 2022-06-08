using FurniParser.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FurniParser
{
    public class FurniCache
    {
        private readonly Dictionary<string, FurnitureModel> _furnitureJsons = new();

        public IReadOnlyDictionary<string, FurnitureModel> Furniture => _furnitureJsons;

        public string JsonLocation { get; init; }
        public string Output { get; init; }

        private readonly JsonSerializerOptions _options = new()
        {
            NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals,
            WriteIndented = true
        };

        public void Load()
        {
            foreach (var file in Directory.GetFiles(JsonLocation))
            {
                try
                {
                    _furnitureJsons[Path.GetFileNameWithoutExtension(file)] = JsonSerializer.Deserialize<FurnitureModel>(File.ReadAllText(file), _options);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Failed to read {file}");
                }
            }
        }
    }
}