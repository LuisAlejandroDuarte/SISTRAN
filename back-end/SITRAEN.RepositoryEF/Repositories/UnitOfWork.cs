using SITRAEN.Entities.Interfaces;
using SITRAEN.RepositoryEF.DataContext;

namespace SITRAEN.RepositoryEF.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        readonly SitraenContext Context;

        public UnitOfWork(SitraenContext context)
        {
            Context = context;
        }

        public Task<int> SaveChanges()
        {
            //Crear Excepciones
            return Context.SaveChangesAsync();
        }
    }
}
