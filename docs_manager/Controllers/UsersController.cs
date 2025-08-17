using docs_manager.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using docs_manager.Models.Dtos;
using docs_manager.Models.Entities;

namespace docs_manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public UsersController(ApplicationDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            var allUsers = dbContext.Users.ToList();

            return Ok(allUsers);
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserDto createUserDto)
        {
            var userEntity = new User()
            {
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
                Email = createUserDto.Email,
                Phone = createUserDto.Phone,
                PasswordHash = createUserDto.PasswordHash,
                CompanyId = createUserDto.CompanyId,
                DepartmentId = createUserDto.DepartmentId
            };

            dbContext.Users.Add(userEntity);
            dbContext.SaveChanges();

            return Ok(userEntity);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetUserById(int id)
        {
            var user = dbContext.Users.Find(id);

            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateUser(int id, UpdateUserDto updateUserDto)
        {
            var user = dbContext.Users.Find(id);

            if (user is null)
            {
                return NotFound();
            }

            if (updateUserDto.FirstName is not null)
            {
                user.FirstName = updateUserDto.FirstName;
            }

            if (updateUserDto.LastName is not null)
            {
                user.LastName = updateUserDto.LastName;
            }

            if (updateUserDto.Phone is not null)
            {
                user.Phone = updateUserDto.Phone;
            }

            if (updateUserDto.PasswordHash is not null)
            {
                user.PasswordHash = updateUserDto.PasswordHash;
            }

            dbContext.SaveChanges();

            return Ok(user);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteUser(int id)
        {
            var user = dbContext.Users.Find(id);

            if (user is null)
            {
                return NotFound();
            }

            dbContext.Users.Remove(user);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
