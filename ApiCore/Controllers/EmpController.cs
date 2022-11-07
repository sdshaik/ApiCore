using DAL.Model;
using IObjects.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmpController : ControllerBase
    {
        private readonly IDataRepository<Tbl_Emp> _empRepository;

        public EmpController(IDataRepository<Tbl_Emp> emprepository)
        {
            _empRepository = emprepository;
        }
        [HttpGet]
        //Get All
        public IActionResult Get()
        {
            IEnumerable<Tbl_Emp> employees = _empRepository.GetAll();
            return Ok(employees);
        }
        [HttpGet("id")]
        //Get By Id
        public IActionResult Getbyid(int id)
        {
            Tbl_Emp emp = _empRepository.Getbyid(id);
            if (emp == null)
            {
                return NotFound();
            }
            return Ok(emp);
        }
        [HttpPost]
        //Add
        public IActionResult Post(Tbl_Emp emp)
        {
            _empRepository.Add(emp);
            return Ok();
        }
        [HttpPut("Id")]
        //Update
        public IActionResult Put(int id, Tbl_Emp emp)
        {
            Tbl_Emp emptoupdate = _empRepository.Getbyid(id);
            _empRepository.Update(emptoupdate, emp);
            return NoContent();
        }
        [HttpDelete("Id")]
        //Delete
        public IActionResult Delete(int id)
        {
            Tbl_Emp _Emp = _empRepository.Getbyid(id);
            _empRepository.Delete(_Emp);
            return NoContent();
        }


    }
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DeptController : ControllerBase
    {
        private readonly IDataRepository<Tbl_Dept> _DeptRepository;

        public DeptController(IDataRepository<Tbl_Dept> deptrepository)
        {
            _DeptRepository = deptrepository;
        }
        [HttpGet]
        //Get All
        public IActionResult Get()
        {
            IEnumerable<Tbl_Dept> departments = _DeptRepository.GetAll();
            return Ok(departments);
        }
        [HttpGet("id")]
        //Get By Id
        public IActionResult Getbyid(int id)
        {
            Tbl_Dept dept = _DeptRepository.Getbyid(id);
            if (dept == null)
            {
                return NotFound();
            }
            return Ok(dept);
        }
        [HttpPost]
        //Add
        public IActionResult Post(Tbl_Dept dep)
        {
            _DeptRepository.Add(dep);
            return Ok();
        }
        [HttpPut("Id")]
        //Update
        public IActionResult Put(int id, Tbl_Dept dep)
        {
            Tbl_Dept deptoupdate = _DeptRepository.Getbyid(id);
            _DeptRepository.Update(deptoupdate, dep);
            return NoContent();
        }
        [HttpDelete("Id")]
        //Delete
        public IActionResult Delete(int id)
        {
            Tbl_Dept _dep = _DeptRepository.Getbyid(id);
            _DeptRepository.Delete(_dep);
            return NoContent();
        }

    }
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController:ControllerBase
    {
        public IConfiguration _configuration;
        private readonly EmpContext _empContext;
        public AuthController(IConfiguration configuration,EmpContext context)
        {
            _configuration = configuration;
            _empContext = context;     
        }
        [HttpPost]
        public async Task<IActionResult> Post(Tbl_Emp employee)
        {
            if (employee != null && employee.EmpEmail != null && employee.Password != null)
            {
                var emp = await GetEmp(employee.EmpEmail, employee.Password);
                if (emp != null)
                {
                    var Claim = new[]
                    {
                        new Claim (JwtRegisteredClaimNames.Sub,_configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        new Claim (JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                        new Claim ("UserId",employee.Empid.ToString()),
                        new Claim ("Emp_Password",employee.Password.ToString()),
                        new Claim ("Emp_Email",employee.EmpEmail.ToString()),
                        new Claim ("Emp_Dob",employee.EmpDob.ToString())
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var SignIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                      Claim,
                       expires: DateTime.UtcNow.AddMinutes(10),
                       signingCredentials: SignIn);
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest();
                }

            }
            else
            {
                return BadRequest();
            }


        }
        private async Task<Tbl_Emp> GetEmp(string Email, string Password)
        {
            return await _empContext.Tbl_Emp.FirstOrDefaultAsync(x => x.EmpEmail == Email && x.Password == Password);
        }

    }
}