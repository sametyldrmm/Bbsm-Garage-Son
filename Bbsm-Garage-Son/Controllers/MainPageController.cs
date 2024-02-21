using Bbsm_Garage_Son.Entity;
using Bbsm_Garage_Son.Models;
using Bbsm_Garage_Son.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;


namespace Bbsm_Garage_Son.Controllers
{
    
    public class MainPageController : Controller
    {
        private readonly KartService _kartService;

        public MainPageController(KartService kartService)
        {
            _kartService = kartService;
        }

        // [AllowAnonymous]
        [Authorize(Policy = "RequireStandartRole")]
        public ActionResult Index()
        {
            var value = Request.Cookies["id"];
            int va = int.Parse(value);
            // Burada örnek bir model oluşturuluyor, gerçek verilerle değiştirilmeli
            List<KartModel> filtrelenmisKartlar = GetSampleData(va); // Kart verilerini almak için bir metot çağırılıyor

            ViewBag.Kartlar = filtrelenmisKartlar; // Kart sayısını görünüme gönder
            // Modeli görünüme gönder
            KartEkleModel kartEkle2 = new KartEkleModel() ;
            return View();
        }

        [HttpPost]
        public ActionResult Sil(List<int> SelectedKartIds,int id)
        {
            Console.WriteLine("Silme işlemi gerçekleşti");
            Console.WriteLine(SelectedKartIds[0]);

            List<KartModel> filtrelenmisKartlar = GetSampleData(id); // Kart verilerini almak için bir metot çağırılıyor
            ViewBag.Kartlar = filtrelenmisKartlar; // Kart sayısını görünüme gönder
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Ekle(CardEntity kart)
        {
            Console.WriteLine("testttttt");
            Console.WriteLine(kart.GirisTarihi);
            // kart.GirisTarihi = DateTime.UtcNow;
            _kartService.AddCard(kart);
            return RedirectToAction("Index");
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
                if(cards[i].Teklif == false)
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

