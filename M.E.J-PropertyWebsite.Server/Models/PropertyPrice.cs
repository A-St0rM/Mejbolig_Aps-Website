namespace M.E.J_PropertyWebsite.Server.Models
{
    public class PropertyPrice
    {

        public int Deposit { get; set; }
        public int RentalPrice { get; set; }
        public double Aconto { get; set; }

        public PropertyPrice(int deposit, int rentalPrice, double aconto)
        {
            this.Deposit = deposit;
            this.RentalPrice = rentalPrice;
            this.Aconto = aconto;
        }

        public PropertyPrice()
        {
        }

    }
}
