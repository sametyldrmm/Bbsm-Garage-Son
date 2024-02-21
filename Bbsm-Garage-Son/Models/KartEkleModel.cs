namespace Bbsm_Garage_Son.Models
{
    public class KartEkleModel
    {
        public int Id { get; set; }
        public string? AdSoyad { get; set; }
        public string? TelNo { get; set; }
        public string? MarkaModel { get; set; }
        public System.DateTime girisTarihi { get; set; }
        public string? Plaka { get; set; }
        public int Km { get; set; }
        public string? Sasi { get; set; }
        public string? ModelYili { get; set; }
        public string? Renk { get; set; }
        public string? Adres { get; set; }
        public string? Notlar { get; set; }
        
        // public string telNo {get; set; }

       /* adSoyad = "John Doe",
                markaModel = "Toyota Corolla",
                plaka = "34 ABC 123",
                km = 50000,
                sasi = "ABC123456XYZ",
                girisTarihi = DateTime.Now
         */   
    }

}
