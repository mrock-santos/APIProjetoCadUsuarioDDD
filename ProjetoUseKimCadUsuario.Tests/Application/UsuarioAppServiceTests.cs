using Moq;
using ProjetoUseKimCadUsuario.Application.DTOs;
using ProjetoUseKimCadUsuario.Application.Interfaces;
using ProjetoUseKimCadUsuario.Application.Services;
using ProjetoUseKimCadUsuario.Domain.Entities;
using ProjetoUseKimCadUsuario.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUseKimCadUsuario.Tests.Application
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
