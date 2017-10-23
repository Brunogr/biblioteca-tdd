using BibliotecaTDD.Domain.Core.Exception;
using BibliotecaTDD.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaTDD.Domain.Model
{
    public class Emprestimo : BaseModel
    {
        private Livro _livro;
        private Pessoa _cliente;
        private Pessoa _atendente;
        private DateTime _dataEmprestimo;
        private DateTime _dataDevolucao;
        private decimal _multa;
        private DateTime? _dataEntregue;
        private DateTime _dataRenovacao;

        public Emprestimo(Livro livro, Pessoa cliente, Pessoa atendente, DateTime? dataEmprestimo = null)
        {
            _livro = livro;
            _cliente = cliente;
            _atendente = atendente;
            _dataEmprestimo = dataEmprestimo ?? DateTime.Now;
            _dataDevolucao = _dataEmprestimo.AddDays(7);
        }

        #region [ Propriedades ]

        public Livro Livro { get { return _livro; } }
        public Pessoa Cliente { get { return _cliente; } }
        public Pessoa Atendente { get { return _atendente; } }
        public DateTime DataEmprestimo { get { return _dataEmprestimo; } }
        public DateTime DataDevolucao { get { return _dataDevolucao; } }
        public DateTime? DataEntregue { get { return _dataEntregue; } }
        public DateTime? DataRenovacao { get { return _dataRenovacao; } }
        public decimal Multa
        {
            get
            {
                double diasAtraso = 0;

                //Se a data de devolução for menor que a data atual, calcular multa.
                if (_dataDevolucao < DateTime.Now)
                    diasAtraso = (DateTime.Now - _dataDevolucao).TotalDays;

                //A multa é 10% do valor do livro por dia.
                var multa = _livro.Preco * (decimal)(diasAtraso * 0.1);

                return Math.Round(multa,2);
            }
        }

        #endregion

        #region [ Métodos ]

        public void RenovarEmprestimo(DateTime? dataRenovacao = null)
        {
            _dataRenovacao = dataRenovacao ?? DateTime.Now;

            _dataDevolucao = _dataRenovacao.AddDays(7);
        }

        public void FinalizarEmprestimo(DateTime? dataEntregue = null)
        {
            _dataEntregue = dataEntregue ?? DateTime.Now;            
        }

        #endregion
    }
}
