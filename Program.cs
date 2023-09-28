using ProjektArbeteFreakyFashion.Domain;
using ProjektArbeteFreakyFashion.Data;
using static System.Console;

namespace ProjektArbeteFreakyFashion;




class Program
{


    static void Main(string[] args)
    {

        CursorVisible = false;
        bool running = true;

        while (running)
        {
            Clear();

            WriteLine("1. Ny produkt");
            WriteLine("2. Sök produkt");
            WriteLine("3. Avsluta");

            ConsoleKeyInfo keyInfo = ReadKey();
            WriteLine();

            switch (keyInfo.KeyChar)
            {
                case '1':
                    RegisterProduct();
                    break;
                case '2':
                    SearchProduct();
                    break;
                case '3':
                    running = false;
                    break;
            }
        }
    }

    static void RegisterProduct()
    {
        Clear();
        WriteLine("Registrera produkt\n");

        var productName = GetUserInput("Namn");
        var stockKeepingUnit = GetUserInput("SKU");
        var description = GetUserInput("Beskrivning");
        var image = GetUserInput("Bild (URL)");
        var price = GetUserInput("Pris");

        var product = new Product
        {
            ProductName = productName,
            StockKeepingUnit = stockKeepingUnit,
            Description = description,
            Image = image,
            Price = price
        };



        WriteLine("\nÄr detta korrekt? (J)a   (N)ej");



        var key = ReadKey(true).Key;
        Clear();
        if (key == ConsoleKey.J)
        {
            SaveProduct(product);
            WriteLine("\nProdukt sparad");
            System.Threading.Thread.Sleep(2000);

        }
        else if (key == ConsoleKey.N)
        {
            WriteLine("\nProduktregistrering avbruten");
            System.Threading.Thread.Sleep(2000);

        }

    }

    private static void SearchProduct()
    {

        Clear();

        string skuNumber = GetUserInput("SKU");

        Clear();

        var product = GetProductBySkuNumber(skuNumber);

        if (product is not null)
        {
            WriteLine($"Namn: {product.ProductName}");
            WriteLine($"SKU: {product.StockKeepingUnit}");
            WriteLine($"Beskrivning: {product.Description}");
            WriteLine($"Pris: {product.Price}");

            WriteLine("\nTryck på R för att radera produkten eller Escape för att avbryta.");

            ConsoleKeyInfo keyInfo = ReadKey();
            Clear();

            if (keyInfo.Key == ConsoleKey.R)
            {
                WriteLine("Är du säker? (J)A / (N)ej");
                ConsoleKeyInfo confirmKey = ReadKey();

                if (confirmKey.Key == ConsoleKey.J)
                {
                    Clear();
                    DeleteProduct(product);
                    WriteLine("Produkt raderad");

                }
            }
            else
            {
                WriteLine("Radering avbruten");
            }

            WaitUntil(ConsoleKey.Escape);
        }
        else
        {
            WriteLine("Produkt finns ej");

            Thread.Sleep(2000);
        }

        WriteLine("\nTryck på valfri knapp för att återgå till huvudmenyn.");
        ReadKey();
    } 

    private static void DeleteProduct(Product product)
    {
        using var context = new ApplicationDbContext();

        context.Product.Remove(product);

        context.SaveChanges();
    }


    private static Product? GetProductBySkuNumber(string skuNumber)
    {
        using var context = new ApplicationDbContext();

        var product = context
            .Product
            .FirstOrDefault(product => product.StockKeepingUnit == skuNumber);

        return product;
    }

    private static void WaitUntil(ConsoleKey key)
    {
        while (ReadKey(true).Key != key) ;
    }

    private static string GetUserInput(string label)
    {
        Write($"{label}: ");

        return ReadLine() ?? "";
    }


    private static void SaveProduct(Product product)
    {
        using var context = new ApplicationDbContext();

        context.Product.Add(product);

        // Här räknar DbContext ut vad som behöver ske i databasen för att säkerställa
        // att data vi för tillfället enbart har i minnet, ska synkas med 
        context.SaveChanges();
    }


}



