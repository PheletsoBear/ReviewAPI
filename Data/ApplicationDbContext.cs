using Microsoft.EntityFrameworkCore;
using ReviewWebAPI.Models.Domain;

namespace ReviewWebAPI.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) //Passes the configuration options that defines the how the database context should be configured
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<PokemonCategory> pokemonCategories { get; set; }
        public DbSet<PokemonOwner> pokemonOwners { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //THis is many-to-many relation entity configuration

            //This is for the primary keys
            modelBuilder.Entity<PokemonCategory>().HasKey(pc => new { pc.PokemonId, pc.CategoryId });

            //This is for the Pokemon and Conjuction table 'PokemonCategories'
            modelBuilder.Entity<PokemonCategory>().HasOne(p => p.Pokemon)
                .WithMany(pc => pc.PokemonCategories)
                .HasForeignKey(c => c.CategoryId);

            //This is for the Category and Conjuction table 'PokemonCategories'

            modelBuilder.Entity<PokemonCategory>()
                .HasOne(p => p.Category)
                .WithMany(pc => pc.PokemonCategories)
                .HasForeignKey(c => c.CategoryId);


            //This is for the primary keys
            modelBuilder.Entity<PokemonOwner>().HasKey(po => new { po.PokemonId, po.OwnerId });

            //This is for the Pokemon and Conjuction table 'PokemonOwner'
            modelBuilder.Entity<PokemonOwner>().HasOne(P => P.Pokemon)
                .WithMany(pc => pc.PokemonOwners)
                .HasForeignKey(p => p.PokemonId);


            //This is for the Owner and Conjuction table 'PokemonOwner'

            modelBuilder.Entity<PokemonOwner>()
                 .HasOne(p => p.Owner)
                 .WithMany(pc => pc.PokemonOwners)
                 .HasForeignKey(pokemon => pokemon.OwnerId);




       
        }





    }

}
