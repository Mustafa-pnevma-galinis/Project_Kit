using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repository.Implementation;
using WebApplication1.Repository.Interface;

namespace WebApplication1.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class FetchExternalController : ControllerBase
    {
        private readonly IUsersRepository usersRepository;

        public FetchExternalController(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        [HttpGet]
        [Route("{gov}")]
        public async Task<IActionResult> GetCity([FromRoute] string gov)
        {
            var cityBygov = await usersRepository.GetCityByGov(gov);

            return Ok(cityBygov);
        }
    }
}
