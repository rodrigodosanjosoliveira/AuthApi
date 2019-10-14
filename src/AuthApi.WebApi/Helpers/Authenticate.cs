using AuthApi.Domain.Contracts.Services;
using AuthApi.Domain.Dto;
using AuthApi.Domain.Entities;
using AuthApi.Domain.ValueTypes;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace AuthApi.WebApi.Helpers
{

    public interface IAuthenticate
    {
        Usuario Login(string email, string senha, Erro erro);
        string GerarToken(Guid usuarioId, Erro erro);
    }

    public class Authenticate : IAuthenticate
    {
        private readonly AppSettings _appSettings;
        private readonly IUsuarioService _usuarioService;

        public Authenticate(IUsuarioService usuarioService, IOptions<AppSettings> appSettings)
        {
            _usuarioService = usuarioService;
            _appSettings = appSettings.Value;
        }

        public Usuario Login(string email, string senha, Erro erro)
        {
            var usuario = _usuarioService.GetAll().SingleOrDefault(u => u.Email == email && Hashing.ValidatePassword(senha,u.Senha));

            if(email == null || senha == null)
                erro = new Erro { StatusCode = "401", Mensagem = "Usuário e/ou senha inválidos" };
            if (usuario == null)
                erro = new Erro { StatusCode = "400", Mensagem = "Usuário e/ou senha inválidos" };

            usuario.UltimoLogin = DateTime.Now;
            usuario.Token = GerarToken(usuario.Id,erro);
            return usuario;
        }

        public string GerarToken(Guid usuarioId, Erro erro)
        {
            if (usuarioId == Guid.Empty)
                erro = new Erro { StatusCode = "400", Mensagem = "Parâmetros inválidos" };

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuarioId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
