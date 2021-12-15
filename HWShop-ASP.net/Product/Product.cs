using System.Text;

namespace HW2OnlineShop
{
    public record class Product
    {
        public Product(int Id, string Name, decimal Price, string urlImage, string moreDetails)
        {
            this.Id = Id;
            this.Name = Name;
            this.Price = Price;
            this.urlImage = urlImage;
            this.moreDetails = moreDetails;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string urlImage { get; set; }
        public string moreDetails { get; set; }

        public void Deconstruct(out string Name, out decimal Price, out string urlImage, out string moreDetails)
        {
            Name = this.Name;
            Price = this.Price;
            urlImage = this.urlImage;
            moreDetails = this.moreDetails;
        }
    }
}
