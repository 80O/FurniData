using System.IO;

namespace FurniParser
{
    public static class Actions
    {
        public static void ExportStateCount(this FurniCache cache)
        {
            using var streamWriter = new StreamWriter(Path.Join(cache.Output, "FurnitureStateCount.txt"));
            foreach (var furniture in cache.Furniture.Values)
            {
                streamWriter.WriteLine($"{furniture.MName} => {furniture.Main.RoomItemData.States.Count}");
            }
        }

        public static void ExportHeights(this FurniCache cache)
        {
            using var streamWriter = new StreamWriter(Path.Join(cache.Output, "FurnitureHeights.txt"));
            foreach (var furniture in cache.Furniture.Values)
            {
                streamWriter.WriteLine($"{furniture.MName} => {furniture.Main.RoomItemData.Dimensions.Height}");
            }
        }
    }
}