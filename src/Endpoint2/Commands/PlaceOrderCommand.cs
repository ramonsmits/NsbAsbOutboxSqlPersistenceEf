﻿using System;

namespace Endpoint2.Commands
{
    public class PlaceOrderCommand  
    {
        public Guid OrderId { get; set; }
        public DateTime PlacedAtDate { get; set; }
        public int OrderNumber { get; set; }
    }
}