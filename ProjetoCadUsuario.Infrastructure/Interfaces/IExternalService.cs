using ProjetoCadUsuario.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCadUsuario.Infrastructure.Interfaces
{
    public interface IExternalService
    {
        Task<bool> EnviarDadosCadastraisAsync(UsuarioDTO usuarioDto);
    }
}
