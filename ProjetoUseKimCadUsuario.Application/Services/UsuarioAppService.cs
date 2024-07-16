﻿using ProjetoUseKimCadUsuario.Application.DTOs;
using ProjetoUseKimCadUsuario.Application.Interfaces;
using ProjetoUseKimCadUsuario.Domain.Entities;
using ProjetoUseKimCadUsuario.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUseKimCadUsuario.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioAppService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioDTO> ObterPorIdAsync(Guid id)
        {
            var usuario = await _usuarioRepository.ObterPorIdAsync(id);
            return new UsuarioDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Documento = usuario.Documento
            };
        }

        public async Task<IEnumerable<UsuarioDTO>> ObterTodosAsync()
        {
            var usuarios = await _usuarioRepository.ObterTodosAsync();
            return usuarios.Select(u => new UsuarioDTO
            {
                Id = u.Id,
                Nome = u.Nome,
                Email = u.Email,
                Documento = u.Documento
            });
        }

        public async Task AdicionarAsync(UsuarioDTO usuarioDto)
        {
            var usuario = new Usuario(usuarioDto.Nome, usuarioDto.Email, usuarioDto.Documento);
            await _usuarioRepository.AdicionarAsync(usuario);
        }

        public async Task AtualizarAsync(UsuarioDTO usuarioDto)
        {
            var usuario = await _usuarioRepository.ObterPorIdAsync(usuarioDto.Id);
            if (usuario == null) throw new Exception("Usuário não encontrado");

            usuario = new Usuario(usuarioDto.Nome, usuarioDto.Email, usuarioDto.Documento);
            await _usuarioRepository.AtualizarAsync(usuario);
        }

        public async Task RemoverAsync(Guid id)
        {
            await _usuarioRepository.RemoverAsync(id);
        }
    }

}
