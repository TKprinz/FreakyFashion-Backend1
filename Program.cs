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
                    
                    break;
                case '3':
                    
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
}

    