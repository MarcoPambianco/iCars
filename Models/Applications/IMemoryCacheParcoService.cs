using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iCars.Models.Interfaces;
using iCars.ViewModels;
using Microsoft.Extensions.Caching.Memory;

namespace iCars.Models.Applications
{
    public class IMemoryCacheParcoService : ICachedParcoService
    {
        private readonly IMemoryCache memoryCache;
        private readonly IParcoService parcoService;
        public IMemoryCacheParcoService(IParcoService parcoService, IMemoryCache memoryCache)
        {
            this.parcoService = parcoService;
            this.memoryCache = memoryCache;

        }
        public async Task<List<CarViewModel>> GetParcoMacchineAsync()
        {
            string strKey = "Parco";
            Task<List<CarViewModel>> lsParco = memoryCache.GetOrCreateAsync(strKey, entry => 
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60);
                return parcoService.GetParcoMacchineAsync();
            });

            return await lsParco;
        }
        public async Task<CarDetailsViewModel> GetDettagliMacchinaAsync(string strTarga)
        {
            string strKey = $"macchina_{strTarga}";
            
            Task<CarDetailsViewModel> car = memoryCache.GetOrCreateAsync(strKey, entry => {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60);
                return parcoService.GetDettagliMacchinaAsync(strTarga);
            });

            return await car;
        }

    }
}