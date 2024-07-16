using ProjetoUseKimCadUsuario.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUseKimCadUsuario.Infrastructure.Interfaces
{
    public interface IExternalService
    {
        Task<bool> EnviarDadosCadastraisAsync(UsuarioDTO usuarioDto);
    }
}
