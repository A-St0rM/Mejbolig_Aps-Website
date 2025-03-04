namespace M.E.J_PropertyWebsite.Server.DTO
{
    public class RentalHistoryDTO
    {
        public int RentalHistoryId { get; set; }
        public int RentalPropertyId { get; set; }
        public int TenantId { get; set; }
        public DateTime MoveInDate { get; set; }
        public DateTime? MoveOutDate { get; set; }

    }
}
