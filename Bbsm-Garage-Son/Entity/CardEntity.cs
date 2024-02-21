using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bbsm_Garage_Son.Entity // "Entity" yazım hatası olduğu için "Entitiy" yerine "Entity" kullanıldı.
{
    [Table(name:"CardEntity")]
    public class CardEntity
    {
        [Key]
        public int Id { get; set; }
        public string? AdSoyad { get; set; }
        public string? TelNo { get; set; }
        public string? MarkaModel { get; set; }
        public Nullable<DateTime> GirisTarihi { get; set; }
        public string? Plaka { get; set; }
        public int Km { get; set; }
        public string? Sasi { get; set; }
        public string? ModelYili { get; set; }
        public string? Renk { get; set; }
        public string? Adres { get; set; }
        public string? Notlar { get; set; }

        public bool Teklif {get; set;}
        // One-to-many ilişkiyi temsil eden alan
        public List<CardTwoStageEntity>? TwoStageEntities { get; set; }

        [ForeignKey("UserEntity")]
        public int UserEntityId { get; set; }

        // İlişkiyi temsil eden navigasyon özelliği
        public UserEntity? UserEntity { get; set; }
    }


}

