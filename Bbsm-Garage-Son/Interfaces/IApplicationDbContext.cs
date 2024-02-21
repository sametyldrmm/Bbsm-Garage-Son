using Bbsm_Garage_Son.Entity;
using Microsoft.EntityFrameworkCore;

namespace Bbsm_Garage_Son.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<CardEntity> Cards { get; set; }
        DbSet<CardTwoStageEntity> CardTwoStages { get; set; }
        // Diğer DbSet'ler buraya eklenebilir.
        DbSet<UserEntity> Users {get;set;}

        DbSet<StokEntity> Stoks {get; set;}
        int SaveChanges();
    }
}
