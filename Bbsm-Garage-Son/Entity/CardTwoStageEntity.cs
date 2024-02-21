using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bbsm_Garage_Son.Entity
{
    [Table(name:"CardTwoStageEntity")]
    public class CardTwoStageEntity
    {
        [Key]
        public int Id { get; set; }
        public int ?birimAdedi {get; set;}
        public string? parcaAdi {get; set;}
        public int? birimFiyati {get; set;}

        [ForeignKey("CardEntity")]
        public int CardEntityId { get; set; }

        // İlişkiyi temsil eden navigasyon özelliği
        public CardEntity? CardEntity { get; set; }
    }
}

