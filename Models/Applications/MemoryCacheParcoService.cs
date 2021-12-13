using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iCars.Models.Interfaces;
using iCars.Models.Options;
using iCars.ViewModels;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace iCars.Models.Applications
{
    public class MemoryCacheParcoService : ICachedParcoService
    {
        private readonly IMemoryCache memoryCache;
        private readonly IParcoService parcoService;
        private readonly IOptionsMonitor<MyMemoryCacheOptions> myCacheOptions;
        private readonly IOptionsMonitor<MemoryCacheOptions> memoryCacheOptions;

        public MemoryCacheParcoService(IParcoService parcoService,
                                        IMemoryCache memoryCache,
                                        IOptionsMonitor<MyMemoryCacheOptions> myCacheOptions,
                                        IOptionsMonitor<MemoryCacheOptions> memoryCacheOptions)
        {
            this.myCacheOptions = myCacheOptions;
            this.memoryCacheOptions = memoryCacheOptions;
            this.parcoService = parcoService;
            this.memoryCache = memoryCache;

        }
        public async Task<List<CarViewModel>> GetParcoMacchineAsync()
        {
            string strKey = "Parco";
            Task<List<CarViewModel>> lsParco = memoryCache.GetOrCreateAsync(strKey, cacheEntry =>
            {
                cacheEntry.SetSize(1);
                cacheEntry.SetAbsoluteExpiration(TimeSpan.FromSeconds(myCacheOptions.CurrentValue.SecondsToExpire));
                return parcoService.GetParcoMacchineAsync();
            });

            return await lsParco;
        }
        public async Task<CarDetailsViewModel> GetDettagliMacchinaAsync(string strTarga)
        {
            string strKey = $"macchina_{strTarga}";

            Task<CarDetailsViewModel> car = memoryCache.GetOrCreateAsync(strKey, cacheEntry =>
            {
                cacheEntry.SetSize(1);
                cacheEntry.SetAbsoluteExpiration(TimeSpan.FromSeconds(myCacheOptions.CurrentValue.SecondsToExpire));
                return parcoService.GetDettagliMacchinaAsync(strTarga);
            });

            return await car;
        }

    }
}