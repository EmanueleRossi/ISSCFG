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

            Item p04 = new Item();
            p04.producer = "SAMSUNG";
            p04.code = "WM65R";
            p04.description = "Flip 2 - SMART Signage";
            p04.url = "https://www.samsung.com/it/samsung-flip/";
            p04.imagePath = "img/Products/FLIP2_65.jpg";
            products.Add(p04);   

            Item p05 = new Item();
            p05.producer = "BARCO";
            p05.code = "VCEM";
            p05.description = "VC Studio Expansion Microphone";
            p05.url = "";
            p05.imagePath = "";
            products.Add(p05);      

            Item p06 = new Item();
            p06.producer = "POLY";
            p06.code = "STUDIO-X30";
            p06.description = "Poly Studio X30";
            p06.url = "https://www.polycom.com/content/dam/polycom/common/documents/data-sheets/studio-x30-data-sheet-enus.pdf";
            p06.imagePath = "img/Products/STUDIO-X30.jpg";
            products.Add(p06);                             

            Item p07 = new Item();
            p07.producer = "POLY";
            p07.code = "STUDIO-X50";
            p07.description = "Poly Studio X50";
            p07.url = "https://www.polycom.com/content/dam/polycom/common/documents/data-sheets/studio-x50-data-sheet-enus.pdf";
            p07.imagePath = "img/Products/STUDIO-X50.jpg";
            products.Add(p07);  

            return products.FindLast(p => p.code.Equals(code));
        }
    }
}