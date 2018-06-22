using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

public class OrderDbContext : DbContext
{
    public OrderDbContext()
    {
    }

    // Needed, is used via Activator.CreateInstance
    public OrderDbContext(IDbConnection connection) : base((DbConnection)connection, false)
    {
        TurnOffAutomaticDatabaseCreationAndSchemaUpdates();
    }

    public IDbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        base.OnModelCreating(modelBuilder);
    }
    void TurnOffAutomaticDatabaseCreationAndSchemaUpdates()
    {
        Database.SetInitializer<OrderDbContext>(null);
    }
}
