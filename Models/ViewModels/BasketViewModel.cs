using System.Collections;
using System.Collections.Generic;

namespace ISSCFG.Models.ViewModels
{
    public class BasketViewModel : IEnumerable
    {
        private List<ItemViewModel> Items;

        public int UserInputId { get; set; }

        public int PerPageLimit { get; set; }

        public int TotalCount { get; set; }

        public int CurrentPage { get; set; }
    
        public void setItems(List<ItemViewModel> items)
        {
            if (items == null)
                Items = new List<ItemViewModel>();
            else
                Items = items;
        }

        public override string ToString()
        {
            return $"UserInputId=|{UserInputId}| -> Items=|{string.Join( ",", Items)}|";
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items.GetEnumerator();
        }
    }
}