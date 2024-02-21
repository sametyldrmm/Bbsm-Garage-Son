using Bbsm_Garage_Son.Entity;
using Bbsm_Garage_Son.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using NuGet.Protocol;
using System.Collections.Generic;
using System.Linq;

namespace Bbsm_Garage_Son.Services
{
    public class UserService
    {
        private readonly IApplicationDbContext _context;

        public UserService(IApplicationDbContext context)
        {
            _context = context;
        }

        // CRUD metotları buraya gelir...
        // Create işlemi
        public int AddUser(UserEntity card)
        {
            _context.Users.Add(card);
            _context.SaveChanges();
            return card.Id;
        }

        // Read işlemleri
        public List<UserEntity> GetAllUsers()
        {
            var users = _context.Users.ToList();;

            // foreach (var card in cards)
            // {
            //     card.TwoStageEntities = _context.CardTwoStages;
            //         .Where(d => d.CardId == card.Id)
            //         .ToList(); // Bağımlılıkları doldur
            // }
            return users;
        }

        public UserEntity GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(c => c.Id == id);
        }

        // Update işlemi
        public void UpdateUser(UserEntity user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        // Delete işlemi
        public void DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(c => c.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
        // public void AddTwoStageData(int cardId, CardTwoStageEntity twoStageData)
        // {
        //     Console.WriteLine("testt");
        //     Console.WriteLine("testt");
        //     Console.WriteLine("testt");
        //     Console.WriteLine("testt");
        //     Console.WriteLine("testt");
        //     var card = _context.Cards.FirstOrDefault(c => c.Id == cardId);
        //     Console.WriteLine(card);
        //     if (card == null)
        //     {
        //         throw new ArgumentException("Card not found", nameof(cardId));
        //     }

        //     try
        //     {

        //         Console.WriteLine(twoStageData.ToJson());
        //         if (card.TwoStageEntities == null)
        //         {
        //             card.TwoStageEntities = new List<CardTwoStageEntity> {};
        //         }
        //         card.TwoStageEntities.Add(new CardTwoStageEntity { birimAdedi =twoStageData.birimAdedi,
        //                                                              parcaAdi= twoStageData.parcaAdi,
        //                                                               birimFiyati= twoStageData.birimFiyati,
        //                                                                CardEntity =card,
        //                                                                CardEntityId=card.Id
        //                                                              } );
        //         _context.SaveChanges();
        //     }
        //     catch (Exception ex)
        //     {
        //         // Hata durumunda işlemler burada yapılır
        //         Console.WriteLine($"Error adding two stage data: {ex.Message}");
        //         // Opsiyonel olarak hata loglama veya başka işlemler yapılabilir
        //         throw; // Hatanın dışarıya fırlatılması
        //     }
        // }
    }
}
