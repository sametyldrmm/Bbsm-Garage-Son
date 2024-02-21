namespace Bbsm_Garage_Son.Models
{
    public class KartAsama2ModelEkle
    {
        public int ?id {get; set;}
        public int ?birimAdedi {get; set;}
        public string? parcaAdi {get; set;}
        public int? birimFiyati {get; set;}        
    }

    public class KartAsama2ModelListe
    {
        public int ?birimAdedi {get; set;}
        public string? parcaAdi {get; set;}
        public int? birimFiyati {get; set;}
        public int? toplamFiyat {get; set;}   
    }

}
