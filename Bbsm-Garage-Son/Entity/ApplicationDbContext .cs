using Bbsm_Garage_Son.Entity;
using Bbsm_Garage_Son.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bbsm_Garage_Son.Entitiy
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<CardEntity> Cards { get; set; }
        
        public DbSet<CardTwoStageEntity> CardTwoStages { get; set; }
        
        public DbSet<UserEntity> Users {get;set;}
        
        public DbSet<StokEntity> Stoks {get; set;}
        // Diğer DbSet'ler buraya eklenebilir.
        
    }
}
