using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace ContosoUniversity.EntityFramework.Repositories
{
    public abstract class ContosoUniversityRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<ContosoUniversityDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected ContosoUniversityRepositoryBase(IDbContextProvider<ContosoUniversityDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class ContosoUniversityRepositoryBase<TEntity> : ContosoUniversityRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected ContosoUniversityRepositoryBase(IDbContextProvider<ContosoUniversityDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
