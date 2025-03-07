namespace M.E.J_PropertyWebsite.Server.Models
{
    public class Image
    {

        public int ImageId { get; set; }
        public string ImageUrl { get; set; }
        public int RentalPropertyId { get; set; }

        public RentalProperty RentalProperty { get; set; }

        public Image(int imageId, string imageUrl, int rentalPropertyId)
        {
            this.ImageId = imageId;
            this.ImageUrl = imageUrl;
            this.RentalPropertyId = rentalPropertyId;
        }

        public Image()
        {
        }

    }
}
