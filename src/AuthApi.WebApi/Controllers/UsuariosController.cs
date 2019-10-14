using AuthApi.Domain.Contracts.Services;
using AuthApi.Domain.Dto;
using AuthApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;
using System.Net.Mime;
using AuthApi.Domain.ValueTypes;
using AuthApi.WebApi.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace AuthApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IAuthenticate _authenticate;

        public UsuariosController(IUsuarioService usuarioService, IAuthenticate authenticate)
        {
            _usuarioService = usuarioService;
            _authenticate = authenticate;
        }

        [AllowAnonymous]
        [HttpPost("/signup")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UsuarioDto>> Signup([FromBody]UsuarioInputDto usuarioInput)
        {
            if (usuarioInput == null || !ModelState.IsValid)
                return BadRequest(new Erro { StatusCode = "400", Mensagem = "Parâmetros inválidos." });

            var erro = _usuarioService.EmailJaExiste(usuarioInput);
            if (erro != null)
                return BadRequest(erro);
            try
            {
                usuarioInput.Senha = Hashing.HashPassword(usuarioInput.Senha);
                usuarioInput.Token = _authenticate.GerarToken(usuarioInput.Id, erro);
                if (erro != null)
                    return BadRequest(erro);
                
                
                Usuario novoUsuario = await _usuarioService.Create(usuarioInput).ConfigureAwait(true);
                // ADO Method
                //Usuario novoUsuario = _usuarioService.CreateWithAdo(usuarioInput);
                return CreatedAtAction(nameof(Get), new { id = novoUsuario.Id }, new UsuarioDto(novoUsuario));
            }
            catch (Exception ex)
            {
                return BadRequest(new Erro { StatusCode = "400", Mensagem = ex.Message });
            }
                        
        }


        [AllowAnonymous]
        [HttpPost("/login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UsuarioDto> Authenticate([FromBody]LoginDto login)
        {
            var erro = new Erro();
            var usuario = _authenticate.Login(login.Login, login.Password, erro);

            if (usuario == null)
                return BadRequest(new Erro { Mensagem = "Usuário e/ou senha inválidos." });

            return Ok(new UsuarioDto(usuario));
        }

        
        [HttpGet("/profile/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<UsuarioDto> Get(Guid id)
        {
            Erro erro = null;

            if(id == Guid.Empty)
            {
                erro = new Erro
                {
                    Mensagem = "Parâmetro inválido",
                    StatusCode = "400"
                };
                return BadRequest(erro);
            }

            var usuario = _usuarioService.GetById(id);
            
            if(usuario == null)
            {
                erro = new Erro
                {
                    Mensagem = "Usuário não encontrado",
                    StatusCode = "404"
                };
                return NotFound(erro);
            }


            return Ok(new UsuarioDto(usuario.Result));
        }
    }
}