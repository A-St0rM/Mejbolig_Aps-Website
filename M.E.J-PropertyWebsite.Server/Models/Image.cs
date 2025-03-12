using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace M.E.J_PropertyWebsite.Server.Models
{
    public class Image
    {
        [Key]
        public int Image_id { get; set; }
        public string Name { get; set; }
        public string Image_data { get; set; }

        [ForeignKey("RentalProperty")]
        public int RentalProperty_id { get; set; }

        public RentalProperty RentalProperty { get; set; }

        public Image(int image_id, string name, string image_data, int rentalProperty_id)
        {
            this.Image_id = Image_id;
            this.Name = name;
            this.Image_data = image_data;
            this.RentalProperty_id = rentalProperty_id;
        }

        public Image()
        {
        }

    }
}
