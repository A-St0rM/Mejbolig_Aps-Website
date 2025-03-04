namespace M.E.J_PropertyWebsite.Server.Models
{
    public class RentalHistory
    {
        public int RentalHistoryId { get; set; }
        public int RentalPropertyId { get; set; }
        public int TenantId { get; set; }
        public DateTime MoveInDate { get; set; }
        public DateTime? MoveOutDate { get; set; }

        public RentalProperty RentalProperty { get; set; }
        public Tenant Tenant { get; set; }

        public RentalHistory(int rentalHistoryId, int rentalPropertyId, int tenantId, DateTime moveInDate, DateTime? moveOutDate)
        {
            this.RentalHistoryId = rentalHistoryId;
            this.RentalPropertyId = rentalPropertyId;
            this.TenantId = tenantId;
            this.MoveInDate = moveInDate;
            this.MoveOutDate = moveOutDate;
        }

        public RentalHistory()
        {
        }
    }
}
