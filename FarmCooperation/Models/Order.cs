using System.ComponentModel.DataAnnotations.Schema;

namespace FarmCooperation.Models;

public class Order
{
    public int Id { get; set; }
    
    public string ClientId { get; set; }
    public string Status { get; set; }

    public List<OrderItem> OrderItems { get; set; }
}