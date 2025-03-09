namespace M.E.J_PropertyWebsite.Server.Models
{
    public class PropertyPrice
    {

        public int Deposit { get; set; }
        public int RentalPrice { get; set; }
        public double Aconto { get; set; }
        public int RentalPropertyId { get; set; }
        public int PropertyPriceId { get; set; }

        public PropertyPrice(int RentalPropertyId, int deposit, int rentalPrice, double aconto)
        {
            this.RentalPropertyId = RentalPropertyId;
            this.Deposit = deposit;
            this.RentalPrice = rentalPrice;
            this.Aconto = aconto;
        }

        public PropertyPrice()
        {
        }

    }
}
