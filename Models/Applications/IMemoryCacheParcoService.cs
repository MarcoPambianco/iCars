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
    public class IMemoryCacheParcoService : ICachedParcoService
    {
        private readonly IMemoryCache memoryCache;
        private readonly IParcoService parcoService;
        private readonly IOptionsMonitor<MyMemoryCacheOptions> myCacheOptions;
        public IMemoryCacheParcoService(IParcoService parcoService,
                                        IMemoryCache memoryCache,
                                        IOptionsMonitor<MyMemoryCacheOptions> myCacheOptions)
        {
            this.myCacheOptions = myCacheOptions;
            this.parcoService = parcoService;
            this.memoryCache = memoryCache;

        }
        public async Task<List<CarViewModel>> GetParcoMacchineAsync()
        {
            string strKey = "Parco";
            Task<List<CarViewModel>> lsParco = memoryCache.GetOrCreateAsync(strKey, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(myCacheOptions.CurrentValue.SecondsToExpire);
                return parcoService.GetParcoMacchineAsync();
            });

            return await lsParco;
        }
        public async Task<CarDetailsViewModel> GetDettagliMacchinaAsync(string strTarga)
        {
            string strKey = $"macchina_{strTarga}";

            Task<CarDetailsViewModel> car = memoryCache.GetOrCreateAsync(strKey, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(myCacheOptions.CurrentValue.SecondsToExpire);
                return parcoService.GetDettagliMacchinaAsync(strTarga);
            });

            return await car;
        }

    }
}