
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Model.Externals
{
    public class Addresses
    {
        [Key]
        public int Id { get; set; }

        public string? Governorate { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? BuildingNumber { get; set; }
        public string? FlatNumber { get; set; }

    }
}
