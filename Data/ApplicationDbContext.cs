using BulkyWebMVCProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWebMVCProject.Data
//This file will show basic configuration for entity framework
{
    public class ApplicationDbContext : DbContext
    /*
    dbcontext class is basically the root class of entity framework core.
    Using which we will be accessing entity framework
    */
    {
        //in the constructor we must pass the connection string
        //When registering dbcontext we will be adding some configuration.
        //One of the configurations, we want to pass to the dbcontext class -> base(options)
        //Where will be register this applicationdbcontext? Answer -> program.cs (must do whenever we are registering something)
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        //When creating a table we have to create a Db set within Db context.
        //within <...> we define an entity class, the 'Categories' is the table name
        // 
        public DbSet<Category> Categories { get; set; }

        //override the db function, default function that is already in db context
        //this overrides the default behavior.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //building a model, the entity is we want to work on
            modelBuilder.Entity<Category>().HasData(
                new Category {Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category {Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category {Id = 3, Name = "History", DisplayOrder = 3 }
            );
        }
    }
}