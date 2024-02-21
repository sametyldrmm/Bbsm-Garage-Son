namespace Bbsm_Garage_Son.Models
{
    public class MainPageViewModel
    {
        public KartModel? Kartlar { get; set; }

        public KartEkleModel? KartEkle { get; set; }

        public  List<KartAsama2ModelListe>? KartAsama2List {get; set;}

        KartAsama2ModelEkle? KartAsama2ModelEkle {get; set;}
    }
}
