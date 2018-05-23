using System;
using System.Data.Entity;

namespace Domain
{
    public interface IOrderDbContext : IDisposable
    {
        IDbSet<Order> Orders { get; set; }
    }
}
