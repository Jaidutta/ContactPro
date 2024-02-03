using ContactPro.Data;
using Microsoft.EntityFrameworkCore;

namespace ContactPro.Helpers

{
    public class DataHelper
    {
        public static async Task ManageDataAsync(IServiceProvider svcProvider)
        {
            // get an instance of the db application context
            var dbContextSvc = svcProvider.GetRequiredService<ApplicationDbContext>();

            // migration: This is equivalent to update-database
            await dbContextSvc.Database.MigrateAsync();
        }
    }
}
