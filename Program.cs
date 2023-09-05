class Product

{
    public string ProductName { get; set; }
    public string StockKeepingUnit { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public string Price { get; set; }



}
class Program
{
    static List<Product> Products = new List<Product>();

    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.Clear();

            Console.WriteLine("1. Ny produkt");
            Console.WriteLine("2. Sök produkt");
            Console.WriteLine("3. Lista produkter");
            Console.WriteLine("4. Avsluta");

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Console.WriteLine();

            switch (keyInfo.KeyChar)
            {
                case '1':
                    RegisterProduct();
                    break;
                case '2':
                    SearchProduct();
                    break;
                case '3':
                    ListProducts();
                    break;
                case '4':
                    running = false;
                    break;
            }
        }
    }

    static void RegisterProduct()
    {
        Console.Clear();
        Console.WriteLine("Registrera produkt\n");

        Product product = new Product();

        Console.Write("Namn: ");
        product.ProductName = Console.ReadLine();

        Console.Write("SKU: ");
        product.StockKeepingUnit = Console.ReadLine();

        Console.Write("Beskrivning: ");
        product.Description = Console.ReadLine();

        Console.Write("Bild (URL): ");
        product.Image = Console.ReadLine();

        Console.Write("Pris: ");
        product.Price = Console.ReadLine();

        Console.WriteLine("\nÄr detta korrekt? (J)a   (N)ej");

        while (true)
        {
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.J)
            {
                Products.Add(product);
                Console.WriteLine("\nProdukt sparad");
                System.Threading.Thread.Sleep(2000);
                break;
            }
            else if (key == ConsoleKey.N)
            {
                Console.WriteLine("\nProduktregistrering avbruten");
                System.Threading.Thread.Sleep(2000);
                break;
            }
        }
    }

    static void SearchProduct()
    {
        Console.Clear();
        Console.WriteLine("Sök produkt\n");

        Console.Write("SKU: ");
        string stockKeepingUnit = Console.ReadLine();

        Product foundProduct = Products.Find(v => v.StockKeepingUnit == stockKeepingUnit);

        Console.WriteLine("\n");

        if (foundProduct != null)
        {
            Console.WriteLine($"Namn: {foundProduct.ProductName}");
            Console.WriteLine($"SKU: {foundProduct.StockKeepingUnit}");
            Console.WriteLine($"Beskrivning: {foundProduct.Description}");
            Console.WriteLine($"Bild (URL): {foundProduct.Image}");
            Console.WriteLine($"Pris: {foundProduct.Price}");

            Console.WriteLine("\n(R)adera produkt?");
            var key = Console.ReadKey().Key;
            Console.SetCursorPosition(0, Console.CursorTop - 2);
            if (key == ConsoleKey.R)
            {
                Console.WriteLine("\nRadera produkt? (J)a  (N)ej");
                var confirmationKey = Console.ReadKey().Key;
                if (confirmationKey == ConsoleKey.J)
                {
                    Products.Remove(foundProduct);
                    Console.WriteLine("\nProdukt raderad");
                    System.Threading.Thread.Sleep(2000);
                }
                else
                {
                    Console.WriteLine("\nProdukten har inte raderats");
                    System.Threading.Thread.Sleep(2000);
                }
            }
        }
        else
        {
            Console.WriteLine("\nProdukt finns ej");
            System.Threading.Thread.Sleep(2000);
        }

        Console.WriteLine("\nTryck på valfri knapp för att återgå till huvudmenyn.");
        Console.ReadKey();
    }

    static void ListProducts()
    {
        Console.Clear();
        Console.WriteLine("Lista produkter\n");
        Console.WriteLine("Namn\t SKU");
        Console.WriteLine("----------------------------------------");

        foreach (Product Product in Products)
        {
            Console.WriteLine($"{Product.ProductName}\t{Product.StockKeepingUnit}");
        }

        Console.WriteLine("\nTryck på valfri knapp för att återgå till huvudmenyn.");
        Console.ReadKey();
    }
}

    