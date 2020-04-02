using System.Collections;
using System.Collections.Generic;

namespace ISSCFG.Models.ViewModels
{
    public class BasketViewModel : IEnumerable
    {
        private List<ItemViewModel> Items;
        
        public BasketViewModel(List<ItemViewModel> items)
        {
            if (items == null)
            {
                Items = new List<ItemViewModel>();
            }
            else
            {
                Items = items;
            }
        }

        public override string ToString()
        {
            return $"{string.Join( ",", Items)}";
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items.GetEnumerator();
        }
    }
}