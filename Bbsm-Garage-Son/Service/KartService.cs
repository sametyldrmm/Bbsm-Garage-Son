using Bbsm_Garage_Son.Entity;
using Bbsm_Garage_Son.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using System.Collections.Generic;
using System.Linq;

namespace Bbsm_Garage_Son.Services
{
    public class KartService
    {
        private readonly IApplicationDbContext _context;

        public KartService(IApplicationDbContext context)
        {
            _context = context;
        }

        // CRUD metotları buraya gelir...
        // Create işlemi
        public int AddCard(CardEntity card)
        {
            _context.Cards.Add(card);
            _context.SaveChanges();
            return card.Id;
        }

        // Read işlemleri
        public List<CardEntity> GetAllCards()
        {
            var cards = _context.Cards.ToList();
            return cards; 
        }

        public List<CardEntity> GetAllCardsByUserId(int id)
        {
            var cards = _context.Cards.Where(k => k.UserEntityId == id).ToList();
            
            return cards; 
        }
        public CardEntity GetCardById(int id)
        {
            return _context.Cards.FirstOrDefault(c => c.Id == id);
        }

        // Update işlemi
        public void UpdateCard(CardEntity card)
        {
            var existingStok = _context.Cards.FirstOrDefault(k => k.Id == card.Id);
            if (existingStok != null)
            {
                existingStok.Adres =        card.Adres; // Update the properties accordingly
                existingStok.AdSoyad =      card.AdSoyad; // Update the properties accordingly
                existingStok.GirisTarihi =  card.GirisTarihi; // Update the properties accordingly
                existingStok.Id =           card.Id; // Update the properties accordingly
                existingStok.Km =           card.Km; // Update the properties accordingly
                existingStok.ModelYili =    card.ModelYili; // Update the properties accordingly
                existingStok.MarkaModel =   card.MarkaModel; // Update the properties accordingly
                existingStok.Notlar =       card.Notlar; // Update the properties accordingly
                existingStok.TelNo =        card.TelNo; // Update the properties accordingly
                existingStok.Teklif =        card.Teklif; // Update the properties accordingly
                
                // Update other properties as needed
                _context.SaveChanges();
            }
        }

        // Delete işlemi
        public void DeleteCard(int id)
        {
            var card = _context.Cards.FirstOrDefault(c => c.Id == id);
            if (card != null)
            {
                _context.Cards.Remove(card);
                _context.SaveChanges();
            }
        }
        public void AddTwoStageData(int cardId, CardTwoStageEntity twoStageData)
        {
            var card = _context.Cards.FirstOrDefault(c => c.Id == cardId);
            Console.WriteLine(card);
            if (card == null)
            {
                throw new ArgumentException("Card not found", nameof(cardId));
            }

            try
            {
                
                Console.WriteLine(twoStageData.ToJson());
                if (card.TwoStageEntities == null)
                {
                    card.TwoStageEntities = new List<CardTwoStageEntity> {};
                }
                card.TwoStageEntities.Add(new CardTwoStageEntity { birimAdedi =twoStageData.birimAdedi,
                                                                     parcaAdi= twoStageData.parcaAdi,
                                                                      birimFiyati= twoStageData.birimFiyati,
                                                                       CardEntity =card,
                                                                       CardEntityId=card.Id
                                                                     } );
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Hata durumunda işlemler burada yapılır
                Console.WriteLine($"Error adding two stage data: {ex.Message}");
                // Opsiyonel olarak hata loglama veya başka işlemler yapılabilir
                throw; // Hatanın dışarıya fırlatılması
            }
        }
    }
}
