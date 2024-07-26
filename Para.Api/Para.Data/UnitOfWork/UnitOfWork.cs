using Para.Base.Entity;
using Para.Data.Context;
using Para.Data.Domain;
using Para.Data.GenericRepository;

namespace Para.Data.UnitOfWork;

public class UnitOfWork<T> : IDisposable, IUnitOfWork<T> where T : BaseEntity
{
    private readonly ParaDbContext dbContext;

    public IGenericRepository<T> Repository { get; }

    public UnitOfWork(ParaDbContext dbContext)
    {
        this.dbContext = dbContext;

        Repository = new GenericRepository<T>(this.dbContext);
    }

    public void Dispose()
    {
    }

    public async Task Complete()
    {
        await dbContext.SaveChangesAsync();
    }

    public async Task CompleteWithTransaction()
    {
        using (var dbTransaction = await dbContext.Database.BeginTransactionAsync())
        {
            try
            {
                await dbContext.SaveChangesAsync();
                await dbTransaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await dbTransaction.RollbackAsync();
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}