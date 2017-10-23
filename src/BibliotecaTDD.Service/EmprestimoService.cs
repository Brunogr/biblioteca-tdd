using BibliotecaTDD.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using BibliotecaTDD.Domain.Model;
using LivrariaTDD.Infra.Data.Repository.Interface;
using System.Linq;

namespace BibliotecaTDD.Service
{
    public class EmprestimoService : IEmprestimoService
    {
        private IEmprestimoRepository _emprestimoRepository;
        private IEstoqueRepository _estoqueRepository;
        private ILivroRepository _livroRepository;

        public EmprestimoService(IEmprestimoRepository emprestimoRepository, 
            IEstoqueRepository estoqueRepository,
            ILivroRepository livroRepository)
        {
            _emprestimoRepository = emprestimoRepository;
            _estoqueRepository = estoqueRepository;
            _livroRepository = livroRepository;
        }

        public Emprestimo EfetuarEmprestimo(Livro livro, Pessoa cliente, Pessoa atendente, DateTime? dataEmprestimo = null)
        {
            var estoque = _estoqueRepository.GetByFilter(est => est.Livro.Id == livro.Id).FirstOrDefault();

            estoque.RemoverDoEstoque(1);

            var emprestimo = new Emprestimo(livro, cliente, atendente, dataEmprestimo);
                        

            return emprestimo;
        }

        public Emprestimo FinalizarEmprestimo(Guid IdEmprestimo)
        {
            throw new NotImplementedException();
        }

        public Emprestimo BuscarEmprestimo(Guid IdEmprestimo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Emprestimo> BuscarTodosOsEmprestimosAtivos()
        {
            throw new NotImplementedException();
        }

    }
}
