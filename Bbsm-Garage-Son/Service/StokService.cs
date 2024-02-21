using Bbsm_Garage_Son.Entity;
using Bbsm_Garage_Son.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using System.Collections.Generic;
using System.Linq;

namespace Bbsm_Garage_Son.Services
{
    public class StokService
    {
        private readonly IApplicationDbContext _context;

        public StokService(IApplicationDbContext context)
        {
            _context = context;
        }

        public int AddStok(StokEntity stok)
        {
            _context.Stoks.Add(stok);
            _context.SaveChanges();
            return stok.Id;
        }

        public List<StokEntity> GetStokById(int id)
        {
            var ist = _context.Stoks.Where(k => k.UserEntityId == id).ToList();
            return ist;
        }

        public void DeleteStok(int id)
        {
            var stok = _context.Stoks.FirstOrDefault(k => k.Id == id);
            if (stok != null)
            {
                _context.Stoks.Remove(stok);
                _context.SaveChanges();
            }
        }

        public void UpdateStok(StokEntity updatedStok)
        {
            var existingStok = _context.Stoks.FirstOrDefault(k => k.Id == updatedStok.Id);
            if (existingStok != null)
            {
                existingStok.Aciklama = updatedStok.Aciklama; // Update the properties accordingly
                existingStok.Adet = updatedStok.Adet; // Update the properties accordingly
                existingStok.StokAdi = updatedStok.StokAdi; // Update the properties accordingly
                // Update other properties as needed
                _context.SaveChanges();
            }
        }

        public void UpdateOrAdd(int id, StokEntity stok)
        {
            var existingStok = _context.Stoks.FirstOrDefault(k => k.Id == stok.Id);
            if (existingStok == null)
            {
                AddStok(stok);
            }
            else
            {
                UpdateStok(stok);
            }
        }

    }
}
