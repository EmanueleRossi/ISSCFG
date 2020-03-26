using System.Collections.Generic;

namespace ISSCFG.Models.Services.Infrastructure
{
    public class ProductService : IProductService
    {
        public Product GetProduct(string code) 
        {
            List<Product> products = new List<Product>();

            Item p01 = new Item();
            p01.producer = "SAMSUNG";
            p01.code = "QM55R";
            p01.description = "Samsung Smart Signage Display";
            p01.url = "https://displaysolutions.samsung.com/digital-signage/detail/1431/QM55R";
            p01.imagePath = "img/Products/QM55R.jpg";
            products.Add(p01);
            
            Item p02 = new Item();
            p02.producer = "POLY";
            p02.code = "STUDIO";
            p02.description = "Premium USB Video Bar";
            p02.url = "https://www.polycom.com/hd-video-conferencing/room-video-systems/polycom-studio.html";
            p02.imagePath = "img/Products/STUDIO.jpg";
            products.Add(p02);

            Item p03 = new Item();
            p03.producer = "BARCO";
            p03.code = "CS_CX-20";
            p02.description = "ClickShare CX-20";
            p03.url = "https://www.barco.com/en/clickshare/wireless-conferencing/cx-20";
            p03.imagePath = "img/Products/CX-20.png";
            products.Add(p03);

            return products.FindLast(p => p.code.Equals(code));
        }
    }
}