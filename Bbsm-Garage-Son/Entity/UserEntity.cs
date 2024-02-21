using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bbsm_Garage_Son.Entity // "Entity" yazım hatası olduğu için "Entitiy" yerine "Entity" kullanıldı.
{
    [Table(name:"UserEntity")]
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }

        public  string? username { get; set; }

        public string? Password { get; set; }

        // One-to-many ilişkiyi temsil eden alan
        public List<CardEntity>? CardEntities { get; set; }

        public List<StokEntity> ?Stoks {get; set;}
    }
}
