//  بسم الله الرحمن الرحيم

using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Model.Domain;
using WebApplication1.Repository.Interface;
using WebApplication1.Model.Externals;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WebApplication1.Repository.Implementation
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext dbContext;

        public UsersRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Users> CreateAsync(Users users)
        {
            await dbContext.Users.AddAsync(users);
            await dbContext.SaveChangesAsync();

            return users;
        }

       

        public async Task<IEnumerable<Governorate>> GetGovernorate()
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            List<Governorate> response = await dbContext.Governorates
                .FromSql($"SELECT Gov FROM Governorates S")
                .ToListAsync().WaitAsync(token);

            return response;
        }
        
        public async Task<IEnumerable<City>> GetCityByGov(string gov)
        {

            var query = $"SELECT City FROM City C JOIN Governorates g ON g.Gov_Key = C.Gov_Key WHERE Gov = '{gov}'";

            var queryFmt = FormattableStringFactory.Create(query);

            List<City> response = await dbContext.Cities
                .FromSql(queryFmt)
                .ToListAsync();
            return response;
        }
        
    }
}
