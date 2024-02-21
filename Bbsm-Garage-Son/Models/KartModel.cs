using Bbsm_Garage_Son.Entity;

namespace Bbsm_Garage_Son.Models
{
    public class KartModel
    {
        public int Id { get; set; }
        public string? adSoyad { get; set; }
        public string? markaModel { get; set; }
        public string? plaka { get; set; }
        public int km { get; set; }
        public string? sasi { get; set; }
        
        public System.DateTime ?girisTarihi { get; set; }

        public static implicit operator KartModel(CardEntity v)
        {
            throw new NotImplementedException();
        }
    }

    
}
