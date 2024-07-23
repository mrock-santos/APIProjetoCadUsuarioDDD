using ProjetoCadUsuario.Application.DTOs;
using ProjetoCadUsuario.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCadUsuario.Infrastructure.Services
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
