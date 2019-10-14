using AuthApi.Domain.Contracts.Repositories;
using AuthApi.Domain.Entities;
using AuthApi.Domain.ValueTypes;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AuthApi.Tests.Repositories
{
    public class UsuarioRepositoryTests
    {
        private readonly Usuario usuario;
        private readonly Telefone telefone;

        public UsuarioRepositoryTests()
        {
            usuario = new Usuario("Rodrigo", "rodrigodosanjosoliveira@gmail.com", "secret", new List<Telefone>());
            telefone = new Telefone("21", "979075829", usuario.Id);
            usuario.Telefones.Add(telefone);
        }

        [Fact]
        public void Signup_Create_UsuarioRepository()
        {
            var mockUsuarioRepository = new Mock<IUsuarioRepository>();
            mockUsuarioRepository.Setup(x => x.Create(usuario));
            mockUsuarioRepository.Object.Create(usuario);
            mockUsuarioRepository.Verify(x => x.Create(usuario), Times.Once());
        }

        [Fact]
        public void Profile_GetById_UsuarioRepository()
        {
            var mockUsuarioRepository = new Mock<IUsuarioRepository>();
            mockUsuarioRepository.Setup(x => x.GetById(usuario.Id)).Returns(Task.FromResult(usuario));
            mockUsuarioRepository.Object.GetById(usuario.Id).Result.ShouldBe(usuario);
            mockUsuarioRepository.Verify(x => x.GetById(usuario.Id), Times.Once());
        }
    }
}
