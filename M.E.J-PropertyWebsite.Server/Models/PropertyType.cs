namespace M.E.J_PropertyWebsite.Server.Models
{
    public class PropertyType
    {
        public int PropertyTypeId { get; set; }
        public string PropertyTypeName { get; set; }

        public PropertyType(int propertyTypeId, string propertyTypeName)
        {
            this.PropertyTypeId = propertyTypeId;
            this.PropertyTypeName = propertyTypeName;
        }

        public PropertyType()
        {
        }
    }
}
