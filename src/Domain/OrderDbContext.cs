using System.Data;
using System.Data.Common;
using System.Data.Entity;

public class OrderDbContext : DbContext
{
    public IDbSet<Order> Orders { get; set; }

    public OrderDbContext()
    {
    }

    // Needed, is used via Activator.CreateInstance
    public OrderDbContext(IDbConnection connection) : base((DbConnection)connection, false)
    {
    }
}
