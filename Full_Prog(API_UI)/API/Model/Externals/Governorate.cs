

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Model.Externals
{
    [Keyless]
    public class Governorate
    {
        public string? Governorates { get; set; }
    }
}
