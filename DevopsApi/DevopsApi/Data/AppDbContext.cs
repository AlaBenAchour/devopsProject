using Microsoft.EntityFrameworkCore;
using DevopsApi.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;  // Remplacez par l'emplacement réel de vos modèles

namespace DevopsApi.Data  // Assurez-vous que le namespace correspond à celui dans votre Program.cs
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(){


        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            try{
                var databaseCreater = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if(databaseCreater != null){
                    if(!databaseCreater.CanConnect()){
                        databaseCreater.Create();
                    }
                    if(!databaseCreater.HasTables()){
                        databaseCreater.CreateTables();
                    }
                }
            }
            catch(Exception ex){
                Console.WriteLine(ex.Message);
            }
        }

        // DbSet pour vos modèles, par exemple :
        public DbSet<Book> books { get; set; }
    }
}
