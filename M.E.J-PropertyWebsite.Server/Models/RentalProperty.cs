using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace M.E.J_PropertyWebsite.Server.Models
{
	public class RentalProperty
	{
		[Key]
		public int RentalProperty_id { get; set; }
		public string PropertyName { get; set; }
		public string PropertyAddress { get; set; }
		public string Description { get; set; }
		public double PropertySquareFootage { get; set; }
		public bool IsAvailable { get; set; }
		public bool PetsAllowed { get; set; }
		public int PropertyRoomSize { get; set; }
		public DateTime DateAvailable { get; set; }

		public PropertyPrice PropertyPrice { get; set; }

		public RentalProperty(int RentalProperty_id, string propertyName, string propertyAddress, string description, double propertySquareFootage, bool isAvailable, bool petsAllowed, int propertyRoomSize, DateTime dateAvailable)
		{
			this.RentalProperty_id = RentalProperty_id;
			this.PropertyName = propertyName;
			this.PropertyAddress = propertyAddress;
			this.Description = description;
			this.PropertySquareFootage = propertySquareFootage;
			this.IsAvailable = isAvailable;
			this.PetsAllowed = petsAllowed;
			this.PropertyRoomSize = propertyRoomSize;
			this.DateAvailable = dateAvailable;
		}

		public RentalProperty()
        {
        }
	}
}
