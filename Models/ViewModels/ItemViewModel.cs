namespace ISSCFG.Models.ViewModels
{
    public class ItemViewModel
    {
        public int Id { get; private set; }
        public string Code { get; private set; }        
        public string Producer { get; private set; }        
        public string Description { get; private set; }
        public string ImagePath { get; private set; }
        public string Url { get; private set; }

        public static ItemViewModel FromEntity(Item item) => new ItemViewModel
        {
            Id = item.Id,
            Code = item.Code,
            Producer = item.Producer,
            Description = item.Description,
            ImagePath = item.ImagePath,
            Url = item.Url
        };

        public override string ToString()
        {
            return $"id=|{Id}|, code=|{Code}|, producer=|{Producer}|, description=|{Description}|, imagePath=|{ImagePath}|, url=|{Url}|";
        }          
    }
}