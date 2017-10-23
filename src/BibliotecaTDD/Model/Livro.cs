using BibliotecaTDD.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaTDD.Domain.Model
{
    public class Livro : BaseModel
    {
        private string _nome;
        private string _descricao;
        private string _edicao;
        private decimal _preco;

        public Livro(string nome, string descricao, string edicao, decimal preco)
        {
            _nome = nome;
            _descricao = descricao;
            _edicao = edicao;
            _preco = preco;
        }

        public string Nome { get { return _nome; } }
        public string Descricao { get { return _descricao; } }
        public string Edicao { get { return _edicao; } }
        public decimal Preco { get { return _preco; } }
    }
}
