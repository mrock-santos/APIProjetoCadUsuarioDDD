using Moq;
using ProjetoCadUsuario.Application.DTOs;
using ProjetoCadUsuario.Application.Interfaces;
using ProjetoCadUsuario.Application.Services;
using ProjetoCadUsuario.Domain.Entities;
using ProjetoCadUsuario.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCadUsuario.Tests.Application
{
    /// <summary>
    /// 
    /// </summary>
    public class UsuarioAppServiceTests
    {
        private readonly Mock<IUsuarioRepository> _usuarioRepositoryMock;
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuarioAppServiceTests()
        {
            _usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            _usuarioAppService = new UsuarioAppService(_usuarioRepositoryMock.Object);
        }

        [Fact]
        public async Task AdicionarAsync_DeveAdicionarUsuario()
        {
            var usuarioDto = new UsuarioDTO { Nome = "Marcio Teste", Email = "mrock@teste.com", Documento = "12345678900" };
            await _usuarioAppService.AdicionarAsync(usuarioDto);
            _usuarioRepositoryMock.Verify(r => r.AdicionarAsync(It.IsAny<Usuario>()), Times.Once);
        }
    }

}
