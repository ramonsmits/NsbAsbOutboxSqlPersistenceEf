using System;
using NServiceBus;

public class PlaceOrderCommand: ICommand
{
    public Guid OrderId { get; set; }
    public DateTime PlacedAtDate { get; set; }
    public int OrderNumber { get; set; }
}
