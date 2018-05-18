using System.Data.Entity;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Infra.NServiceBus.Persistence
{
    public class DataContextPersistence
    {
        private static StringBuilder logger = new StringBuilder();
        public static async Task SaveChangesAsync(DbContext dataContext)
        {
            await dataContext.SaveChangesAsync().ConfigureAwait(false);

            Debug.Write(logger);
        }
    }
}
