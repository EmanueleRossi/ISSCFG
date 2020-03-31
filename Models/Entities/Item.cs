using System;

namespace ISSCFG.Models
{
    public class Item
    {        
        public int Id { get; private set; }
        public string Code { get; private set; }        
        public string Producer { get; private set; }        
        public string Description { get; private set; }
        public string ImagePath { get; private set; }
        public string Url { get; private set; }      

        public Item(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentException("Item must have a code!");
            }
            this.Code = code;
        }

        public override string ToString()
        {
            return $"id=|{Id}|, code=|{Code}|, producer=|{Producer}|, description=|{Description}|, imagePath=|{ImagePath}|, url=|{Url}|";
        }              
    }
}
