
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Model.Externals;

namespace WebApplication1.Model.Domain
{

    public class Users
    {

        [Key]
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
