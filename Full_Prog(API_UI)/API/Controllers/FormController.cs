// بسم الله الرحمن الرحيم

using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Model.DTO;
using WebApplication1.Model.Externals;
using WebApplication1.Model.Domain;
using WebApplication1.Repository.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Azure.Core;
using WebApplication1.Model.DTO.StudentsDTO;
using System.Runtime.CompilerServices;


namespace WebApplication1.Controllers
{

    [Route("/api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly IUsersRepository usersRepository;

        public FormController(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        [HttpPost]
        public async Task<IActionResult> DefineUser(DefineUserRequestDTO request)
        {
            // Request
            var user = new Users
            {
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                BirthDate = request.BirthDate,
                MobileNumber = request.MobileNumber,
                Email = request.Email,
                Addresses = request.Addresses
            };

            await usersRepository.CreateAsync(user);


            // Response
            var response = new UsersDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                MobileNumber = user.MobileNumber,
                Email = user.Email,
                Addresses = user.Addresses
            };

            return Ok(response);
        }

        
        
        [HttpGet]

        public async Task<IActionResult> GetGov()
        {
            var data = await usersRepository.GetGovernorate();
            
            return Ok(data);
        }
        
        
     
    }
}
