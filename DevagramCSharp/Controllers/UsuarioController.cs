using DevagramCSharp.Dtos;
using DevagramCSharp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevagramCSharp.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class UsuarioController : BaseController
    {

        public readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger)
        {
            _logger = logger;
        }   

        [HttpGet]
        public IActionResult ObterUsuario ()
        {
            try
            {
                Usuario usuario = new Usuario()
                {
                    Email = "daniel@devaria.com.br",
                    Nome = "Daniel",
                    Id = 100
                };

                return Ok(usuario);
            }
            catch(Exception e)
            {
                _logger.LogError("Ocorreu um erro ao obter usuario");
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorRespostaDto()
                {
                    Descricao = "Ocorreu o seguinte erro: " + e.Message,
                    Status = StatusCodes.Status500InternalServerError
                });
            }
           
        }
    }   
}
