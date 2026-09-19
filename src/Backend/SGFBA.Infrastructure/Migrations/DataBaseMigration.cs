using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SGFBA.Infrastructure.DataAccess;

namespace SGFBA.Infrastructure.Migrations;

public static class DataBaseMigration
{
    public async static Task MigrateDataBase(IServiceProvider serviceProvider)
    {
        var dbContext = serviceProvider.GetRequiredService<SGFBADbContext>();

        await dbContext.Database.MigrateAsync();
    }
}
