namespace Atelier.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AtelierContext : DbContext
    {

        public AtelierContext()
            : base("name=AtelierContext")
        {
        }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<FinishingWork> FinishingWorks { get; set; }
        public DbSet<ListOfMaterial> ListOfMaterials { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ComplicatingElement> ComplicatingElements { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Set> Sets { get; set; }
    }
}