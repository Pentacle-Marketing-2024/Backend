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
    public class FormController : ControllerBase
    {
        private readonly IFormRepository _formRepository;
        private readonly ITokenHelper _jwtHelper;
        private readonly IPasswordHasher _passwordHasher;

        public FormController(IFormRepository formRepository, ITokenHelper tokenHelper, IPasswordHasher passwordHasher)
        {
            _formRepository = formRepository;
            _jwtHelper = tokenHelper;
            _passwordHasher = passwordHasher;
        }

        [Authorize]
        [HttpGet("GetAll", Name = "GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_formRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [Authorize]
        [HttpGet("GetById", Name = "GetById")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_formRepository.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Authorize]
        [HttpGet("GetByFullName", Name = "GetByFullName")]
        public IActionResult GetByFullName(string fullName)
        {
            try
            {
                return Ok(_formRepository.GetByFullName(fullName));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Authorize]
        [HttpGet("GetByEmail", Name = "GetByEmail")]
        public IActionResult GetByEmail(string email)
        {
            try
            {
                return Ok(_formRepository.GetByEmail(email));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("Create", Name = "Create")]
        public IActionResult Create(FormRequest request)
        {
            try
            {
                Form form = new Form
                {
                    FullName = request.FullName,
                    Email = request.Email,
                    Description = request.Description,
                    CreateDate = DateTime.Now,
                    Method = request.Method,
                };
                _formRepository.Create(form);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
