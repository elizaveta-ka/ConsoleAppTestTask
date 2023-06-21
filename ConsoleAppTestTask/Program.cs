using System.Text.Json;
using ConsoleAppTestTask;
using Newtonsoft.Json;


public class Program
{
    public static void Main()

    {
        
        List<Pallet> ReadPalletsFromFile(string filePath)
        {
            string json = File.ReadAllText(filePath);
            WareHouse warehouse = JsonConvert.DeserializeObject<WareHouse>(json);
            List<Pallet> pallets = warehouse.Pallets;
            return pallets;
        }

        List<Pallet> pallets = ReadPalletsFromFile("/Users/elizavetakabak/Projects/ConsoleApp/ConsoleAppTestTask/text.json");

  

        // Вывод на экран сгруппированных и отсортированных паллет по сроку годности и весу
        var groupedPallets = pallets
            .GroupBy(p => p.ExpirationDate)
            .OrderBy(g => g.Key)
            .SelectMany(g => g.OrderBy(p => p.TotalWeight))
            .ToList();

        Console.WriteLine("Сгруппированные паллеты по сроку годности, отсортированные по возрастанию срока годности и весу:");
        foreach (var pallet in groupedPallets)
        {
            Console.WriteLine($"ID: {pallet.ID}, Expiration Date: {pallet.ExpirationDate}, Total Weight: {pallet.TotalWeight}");
        }

        // Вывод на экран 3 паллет с наибольшим сроком годности, отсортированных по возрастанию объема
        var sortedPalletsByVolume = pallets
            .OrderByDescending(p => p.ExpirationDate)
            .Take(3)
            .OrderBy(p => p.TotalVolume)
            .ToList();

        Console.WriteLine("\n3 паллеты с наибольшим сроком годности, отсортированные по возрастанию объема:");

        foreach (var pallet in sortedPalletsByVolume)
        {
            Console.WriteLine($"ID: {pallet.ID}, Expiration Date: {pallet.ExpirationDate}, Total Weight: {pallet.TotalWeight}");
        }
    }
}

