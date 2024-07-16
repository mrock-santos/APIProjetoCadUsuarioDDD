using ProjetoUseKimCadUsuario.Application.DTOs;
using ProjetoUseKimCadUsuario.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUseKimCadUsuario.Infrastructure.Services
{
    public class ExternalService : IExternalService
    {
        public async Task<bool> EnviarDadosCadastraisAsync(UsuarioDTO usuarioDto)
        {
            // Lógica de integração com o serviço externo
            // Exemplo: usar HttpClient para enviar uma solicitação HTTP
            return true;
        }
    }

}
