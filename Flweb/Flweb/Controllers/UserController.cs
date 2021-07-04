using Flweb.Business.Interface;
using Flweb.Data.VO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flweb.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Authorize("Bearer")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class UserController : Controller
    {
        private IUserBusiness _userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<UserRegisterVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [AllowAnonymous]
        public IActionResult FindAll()
        {
            return Ok(_userBusiness.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(UserRegisterVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult FindById(long id)
        {
            var atualizacao = _userBusiness.FindById(id);
            if (atualizacao == null) return NotFound();

            return Ok(atualizacao);
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(UserRegisterVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [AllowAnonymous]
        public async Task<IActionResult> Update([FromBody] UserRegisterVO user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            var userAlter = await _userBusiness.Update(user);
            return new OkObjectResult(userAlter);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(UserRegisterVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        //[Authorize(Roles = "Admin")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserRegisterVO user)
        {
            if (user == null) return BadRequest("Requisicao do client invalida");
            var newUser = await _userBusiness.NewUser(user);
            if (newUser == null) return Unauthorized();
            return new OkObjectResult(newUser);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            if (_userBusiness.FindById(id) != null)
            {
                _userBusiness.Delete(id);
                return NoContent();
            }

            return NotFound();

        }
    }
}
