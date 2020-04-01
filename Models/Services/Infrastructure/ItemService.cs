using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ISSCFG.Models.ViewModels;

namespace ISSCFG.Models.Services.Infrastructure
{
    public class ItemService : IItemService
    {
        private readonly AppDbContext dbContext;

        public ItemService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        async Task<ItemViewModel> IItemService.GetItemAsync(string code)
        {
            IQueryable<ItemViewModel> queryLinq = dbContext.Items
                .Where(item => string.Equals(item.Code, code))                
                .Select(item => ItemViewModel.FromEntity(item)); 
            
            ItemViewModel viewModel = await queryLinq.SingleAsync();
            return viewModel;
        }
    }
}