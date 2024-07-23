using ProjetoCadUsuario.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCadUsuario.Tests.Domain
{
    public class UsuarioTests
    {
        [Fact]
        public void Usuario_Construtor_DeveCriarUsuarioCorretamente()
        {
            var usuario = new Usuario("Nome Teste", "email@teste.com", "12345678900");
            Assert.NotNull(usuario);
            Assert.Equal("Nome Teste", usuario.Nome);
            Assert.Equal("email@teste.com", usuario.Email);
            Assert.Equal("12345678900", usuario.Documento);
        }
    }

}
