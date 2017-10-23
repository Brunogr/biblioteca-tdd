using BibliotecaTDD.Domain.Core.Exception;
using BibliotecaTDD.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaTDD.Domain.Model
{
    public class Estoque : BaseModel
    {
        private Livro _livro;
        private int _quantidade;
        private int _quantidadeDisponivel;

        public Estoque(Livro livro, int quantidade)
        {
            _livro = livro;
            _quantidade = quantidade;
            _quantidadeDisponivel = quantidade;
        }

        #region [ Propriedades ]
        public Livro Livro { get { return _livro; } }
        public int Quantidade { get { return _quantidade; } }
        public int QuantidadeDisponivel { get { return _quantidadeDisponivel; } }
        public int QuantidadeEmprestado { get { return _quantidade - _quantidadeDisponivel; } }

        #endregion

        #region [ Métodos ] 

        public void RemoverDoEstoque(int quantidade)
        {
            if (_quantidadeDisponivel == 0)
                throw new DomainException("Não há livro no estoque");

            _quantidadeDisponivel -= quantidade;
        }

        public void AdicionarAoEstoque(int quantidade)
        {
            _quantidadeDisponivel += quantidade;
        }

        #endregion
    }
}
