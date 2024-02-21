using Bbsm_Garage_Son.Entity;
using Bbsm_Garage_Son.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Bbsm_Garage_Son.Services
{
    public class CardTwoState
    {
        private readonly IApplicationDbContext _context;

        public CardTwoState(IApplicationDbContext context)
        {
            _context = context;
        }
        
        public void AddTwoStageData(int cardId, CardTwoStageEntity twoStageData)
        {

            // card.TwoStageData.Add(twoStageData);
            _context.SaveChanges();
        }

        public List<CardTwoStageEntity>? GetTwoStageEntitiesForCard(int cardId)
        {
            var ist = _context.CardTwoStages.Where(k => k.CardEntityId == cardId).ToList();
            return ist;
        }
        public void UpdateTwoStageData(CardTwoStageEntity updatedTwoStageData)
        {
            var existingTwoStageData = _context.CardTwoStages.Find(updatedTwoStageData.Id);

            if (existingTwoStageData != null)
            {
                // Veriyi güncelle
                existingTwoStageData.birimAdedi = updatedTwoStageData.birimAdedi;
                existingTwoStageData.parcaAdi = updatedTwoStageData.parcaAdi;
                existingTwoStageData.birimFiyati = updatedTwoStageData.birimFiyati;

                _context.SaveChanges();
            }
            else
            {
                // İlgili veri bulunamadı, burada bir işlem yapılabilir.
                // Örneğin, bir hata fırlatılabilir veya bir loglama işlemi yapılabilir.
            }
        }
    }

}
