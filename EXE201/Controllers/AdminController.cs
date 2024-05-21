using JwtTokenAuthorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Repository;
using Utils.PasswordHasher;

namespace EXE201.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _adminRepository;
        private readonly ITokenHelper _jwtHelper;
        private readonly IPasswordHasher _passwordHasher;

        public AdminController(IAdminRepository adminRepository, ITokenHelper tokenHelper, IPasswordHasher passwordHasher)
        {
            _adminRepository = adminRepository;
            _jwtHelper = tokenHelper;
            _passwordHasher = passwordHasher;
        }

        [HttpPost("Login", Name = "Login")]
        public IActionResult Login(LoginRequest request)
        {
            try
            {
                Admin admin = _adminRepository.Login(request.Username, request.Password);
                if (admin != null)
                {
                    string token = _jwtHelper.GenerateToken(admin);
                    return Ok(token);
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
