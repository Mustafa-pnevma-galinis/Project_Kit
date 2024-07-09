
using System.ComponentModel.DataAnnotations;
using WebApplication1.Model.Externals;

namespace WebApplication1.Model.DTO
{
    public class UsersDTO
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
        public string? MobileNumber { get; set; }
        public string? Email { get; set; }

        public List<Addresses>? Addresses { get; set; }

    }
}
