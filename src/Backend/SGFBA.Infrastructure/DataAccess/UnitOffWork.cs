using SGFBA.Domain.Repositories;

namespace SGFBA.Infrastructure.DataAccess;

internal class UnitOffWork : IUnitOffWork
{
    private readonly SGFBADbContext _dbContext;

    public UnitOffWork(SGFBADbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Commit() => await _dbContext.SaveChangesAsync();
}
