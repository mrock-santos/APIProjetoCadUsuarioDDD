using ProjetoCadUsuario.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCadUsuario.Application.Interfaces
{
    public interface IUsuarioAppService
    {
        Task<UsuarioDTO> ObterPorIdAsync(Guid id);
        Task<IEnumerable<UsuarioDTO>> ObterTodosAsync();
        Task AdicionarAsync(UsuarioDTO usuarioDto);
        Task AtualizarAsync(UsuarioDTO usuarioDto);
        Task RemoverAsync(Guid id);
    }

}
