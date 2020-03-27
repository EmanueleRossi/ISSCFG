namespace ISSCFG.Models
{
    public class Product 
    {
        public string code { get; set; }        
        public string description { get; set; }
        public string imagePath { get; set; }
        public string url { get; set; }          

        public override string ToString()
        {
            return $"code=|{code}|, description=|{description}|, imagePath=|{imagePath}|, url=|{url}|";
        }        
    }
}