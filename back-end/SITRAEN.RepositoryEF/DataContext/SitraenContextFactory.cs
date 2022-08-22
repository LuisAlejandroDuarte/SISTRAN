using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace SITRAEN.RepositoryEF.DataContext
{
    
        public class SitraenContextFactory : IDesignTimeDbContextFactory<SitraenContext>
        {
            public SitraenContext CreateDbContext(string[] args)
            {
                var OptionsBuilder = new DbContextOptionsBuilder<SitraenContext>();

                OptionsBuilder.UseSqlServer("Data Source=DESKTOP-6LA1H4P\\SQLEXPRESS;Initial Catalog=SITRAEN;Integrated Security=true").EnableSensitiveDataLogging();

                return new SitraenContext(OptionsBuilder.Options);
            }
        }
    
}
