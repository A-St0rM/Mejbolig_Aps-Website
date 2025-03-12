namespace M.E.J_PropertyWebsite.Server.DTO
{
    public class RentalPropertyDTO
    {
        public int RentalProperty_id { get; set; }
        public string PropertyName { get; set; }
        public string PropertyAddress { get; set; }
        public string Description { get; set; }
        public double PropertySquareFootage { get; set; }
        public bool IsAvailable { get; set; }
        public bool PetsAllowed { get; set; }
        public int PropertyRoomSize { get; set; }
        public DateTime DateAvailable { get; set; }
      
        public PropertyPriceDTO PropertyPrice { get; set; }

    }
}
