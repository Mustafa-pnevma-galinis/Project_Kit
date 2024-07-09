using WebApplication1.Model.Domain;
using WebApplication1.Model.Externals;

namespace WebApplication1.Repository.Interface
{
    public interface IUsersRepository
    {
        Task<Users> CreateAsync(Users users);

        Task <IEnumerable<Governorate>> GetGovernorate();

        Task<IEnumerable<City>> GetCityByGov(string gov);
    }
}
