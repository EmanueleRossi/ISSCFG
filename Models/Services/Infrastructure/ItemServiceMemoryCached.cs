using System.Threading.Tasks;
using ISSCFG.Models.ViewModels;
using Microsoft.Extensions.Caching.Memory;
using System;
using Microsoft.Extensions.Configuration;

namespace ISSCFG.Models.Services.Infrastructure
{
    public class ItemServiceMemoryCached : IItemServiceMemoryCached
    {
        private readonly IConfiguration Configuration;

        private readonly IItemService ItemService;

        private IMemoryCache MemoryCache { get; }        

        public ItemServiceMemoryCached(IItemService itemService, IMemoryCache memoryCache, IConfiguration configuration)
        {
            ItemService = itemService;
            MemoryCache = memoryCache;
            Configuration = configuration;
        }

        public async Task<ItemViewModel> GetItemAsync(string code)
        {
            return await MemoryCache.GetOrCreateAsync($"Item-{code}", cacheEntry =>
            {
                int memoryCacheAbsoluteExpirationMinutes = Configuration.GetSection("MemoryCache").GetValue<int>("MemoryCacheAbsoluteExpirationMinutes", 2);
                int memoryCacheObjectSize = Configuration.GetSection("MemoryCache").GetValue<int>("Size", 1);                                
                cacheEntry.SetAbsoluteExpiration(TimeSpan.FromMinutes(memoryCacheAbsoluteExpirationMinutes));
                cacheEntry.SetSize(memoryCacheObjectSize);
                return ItemService.GetItemAsync(code);
             });
        }
    }
}