using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektArbeteFreakyFashion.Domain;



class Product

{
    
    public int Id { get; set;}
    public required string ProductName { get; set; }
    public required string StockKeepingUnit { get; set; }
    public required string Description { get; set; }
    public required string Image { get; set; }
    public required string Price { get; set; }

}