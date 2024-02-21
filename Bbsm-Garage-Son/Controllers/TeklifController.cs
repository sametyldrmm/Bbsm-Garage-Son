using Bbsm_Garage_Son.Models;
using Bbsm_Garage_Son.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bbsm_Garage_Son.Controllers
{
    public class TeklifController : Controller
    {
        private readonly KartService _kartService;

        public TeklifController(KartService kartService)
        {
            _kartService = kartService;
        }

        [Authorize(Policy = "RequireStandartRole")]
        public IActionResult Index()
        {
            var value = Request.Cookies["id"];
            int va = int.Parse(value);
            // Burada örnek bir model oluşturuluyor, gerçek verilerle değiştirilmeli
            List<KartModel> filtrelenmisKartlar = GetSampleData(va); // Kart verilerini almak için bir metot çağırılıyor

            ViewBag.Kartlar = filtrelenmisKartlar; // Kart sayısını görünüme gönder
            // Modeli görünüme gönder
            KartEkleModel kartEkle2 = new KartEkleModel() ;
            return View(kartEkle2);
        }

        // Örnek veri oluşturmak için bir metot
        private List<KartModel> GetSampleData(int id)
        {
            List<KartModel> sampleData = new List<KartModel>();
            // Örnek kart verilerini ekle
            var cards = _kartService.GetAllCardsByUserId(id);
            if(cards == null)
            {
                return sampleData;
            }
            for (int i = 0; i < cards.Count; i++)
            {
                if(cards[i].Teklif == true)
                {
                    sampleData.Add(new KartModel
                    {
                        Id = cards[i].Id,
                        adSoyad = cards[i].AdSoyad,
                        markaModel = cards[i].MarkaModel,
                        plaka = cards[i].Plaka,
                        km = cards[i].Km,
                        sasi = cards[i].Sasi,
                        girisTarihi = (DateTime)cards[i].GirisTarihi
                    });
                }

            }
            return sampleData;
        }
    }

    
}
