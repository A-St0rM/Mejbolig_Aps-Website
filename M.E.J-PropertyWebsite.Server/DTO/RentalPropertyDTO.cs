namespace M.E.J_PropertyWebsite.Server.DTO
{
    public class RentalPropertyDTO
    {
        public int RentalPropertyId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyAddress { get; set; }
        public string Description { get; set; }
        public double PropertySquareFootage { get; set; }
        public bool IsAvailable { get; set; }
        public int RentalPrice { get; set; }
        public int Deposit { get; set; }
        public double Aconto { get; set; }
        public bool PetsAllowed { get; set; }
        public int PropertyRoomSize { get; set; }
        public DateTime DateAvailable { get; set; }
        public PropertyTypeDTO PropertyType { get; set; }
    }
}
