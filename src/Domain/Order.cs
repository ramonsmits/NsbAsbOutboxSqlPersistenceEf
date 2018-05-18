using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Order
{
    Order()
    {
    }

    [Key, Column(Order = 0)]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid OrderId { get; set; }
    public int OrderNumber { get; set; }
    public DateTime PlacedAtDate { get; set; }

    public static Order Create(Guid orderId, int orderNumber)
    {
        return new Order
        {
            OrderId = orderId,
            OrderNumber = orderNumber
        };
    }

    public void PlaceOrder(DateTime placedAtDate)
    {
        PlacedAtDate = placedAtDate;
    }
}
