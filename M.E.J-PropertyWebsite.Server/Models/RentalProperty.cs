namespace M.E.J_PropertyWebsite.Server.Models
{
	public class RentalProperty
	{
		public int RentalPropertyId { get; set; }
		public string PropertyName { get; set; }
		public string PropertyAddress { get; set; }
		public string Description { get; set; }
		public double PropertySquareFootage { get; set; }
		public bool IsAvailable { get; set; }
		public bool PetsAllowed { get; set; }
		public int PropertyRoomSize { get; set; }
		public DateTime DateAvailable { get; set; }
		public PropertyType PropertyType { get; set; }

		public RentalProperty(int rentalPropertyId, string propertyName, string propertyAddress, string description, double propertySquareFootage, bool isAvailable, bool petsAllowed, int propertyRoomSize, DateTime dateAvailable, PropertyType propertyType)
		{
			this.RentalPropertyId = rentalPropertyId;
			this.PropertyName = propertyName;
			this.PropertyAddress = propertyAddress;
			this.Description = description;
			this.PropertySquareFootage = propertySquareFootage;
			this.IsAvailable = isAvailable;
			this.PetsAllowed = petsAllowed;
			this.PropertyRoomSize = propertyRoomSize;
			this.DateAvailable = dateAvailable;
			this.PropertyType = propertyType;
		}
	}
}
