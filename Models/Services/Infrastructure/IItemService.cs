using System.Threading.Tasks;
using ISSCFG.Models.ViewModels;

namespace ISSCFG.Models.Services.Infrastructure
{
    public interface IItemService
    {
        Task<ItemViewModel> GetItemAsync(string code);        
    }
}