﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCadUsuario.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Documento { get; private set; }

        public Usuario(string nome, string email, string documento)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            Documento = documento;
        }
        public Usuario(Guid id, string nome, string email, string documento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Documento = documento;
        }
    }

}
