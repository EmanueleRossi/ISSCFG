namespace ISSCFG.Models
{
    public class Item : Product
    {
        public string producer { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}, producer=|{producer}|";
        }          
    }
}