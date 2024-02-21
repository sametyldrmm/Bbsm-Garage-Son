using Bbsm_Garage_Son.Entity;
using Bbsm_Garage_Son.Models;
using Bbsm_Garage_Son.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

    namespace Bbsm_Garage_Son.Controllers
    {
        public class DetayController : Controller
        {
            private readonly KartService _kartService;
            private readonly CardTwoState _CardTwoState;

            public DetayController(KartService kartService,CardTwoState cardTwoState)
            {
                _kartService = kartService;
                _CardTwoState = cardTwoState;
            }

            [Authorize(Policy = "RequireStandartRole")]
            public IActionResult Index(int id)
            {
                DetayModel detay = new DetayModel {};
                detay.Kartlar = _kartService.GetCardById(id);
                detay.KartAsama2List = new List<KartAsama2ModelEkle> {};
                List<CardTwoStageEntity> ?sampleData = _CardTwoState.GetTwoStageEntitiesForCard(id);
                for (int i = 0; i < sampleData.Count; i++)
                {
                    detay.KartAsama2List.Add(new KartAsama2ModelEkle {
                        id = sampleData[i].Id,
                        birimAdedi = sampleData[i].birimAdedi,
                        birimFiyati = sampleData[i].birimFiyati,
                        parcaAdi = sampleData[i].parcaAdi
                    });
                }

                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };
                ViewBag.detay = Newtonsoft.Json.JsonConvert.SerializeObject( detay,settings);
                return View();
            }



        }
    }
