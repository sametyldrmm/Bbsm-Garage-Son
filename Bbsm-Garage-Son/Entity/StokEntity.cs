using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bbsm_Garage_Son.Entity // "Entity" yazım hatası olduğu için "Entitiy" yerine "Entity" kullanıldı.
{
    [Table(name:"StokEntity")]
    public class StokEntity
    {
        [Key]
        public int Id { get; set; }

        public  string? StokAdi { get; set; }

        public  int? Adet { get; set; }

        public DateTime ?Date { get; set; }
        public string? Aciklama { get; set; }
        // One-to-many ilişkiyi temsil eden alan
        [ForeignKey("UserEntity")]
        public int UserEntityId { get; set; }

        // İlişkiyi temsil eden navigasyon özelliği
        public UserEntity? UserEntity { get; set; }

    }


}

