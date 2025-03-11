using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M.E.J_PropertyWebsite.Server.Models
{
    public class PropertyPrice
    {
        [Key]
        public int Price_Id { get; set; }
        public double Deposit { get; set; }
        public double RentalPrice { get; set; }
        public double Aconto { get; set; }

        [ForeignKey("RentalProperty")]
        public int RentalProperty_id { get; set; }

        public RentalProperty RentalProperty { get; set; }

        public PropertyPrice(int RentalProperty_id, int deposit, int rentalPrice, double aconto)
        {
            this.RentalProperty_id = RentalProperty_id;
            this.Deposit = deposit;
            this.RentalPrice = rentalPrice;
            this.Aconto = aconto;
        }

        public PropertyPrice()
        {
        }

    }
}
