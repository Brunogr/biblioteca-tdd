using BibliotecaTDD.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaTDD.Domain.Model
{
    public class Pessoa : BaseModel
    {
        private string _nome;
        private string _cpf;

        public Pessoa(string nome, string cpf)
        {
            _nome = nome;
            _cpf = cpf;
        }

        public string Nome { get { return _nome; } }
        public string Cpf { get { return _cpf; } }
    }
}
