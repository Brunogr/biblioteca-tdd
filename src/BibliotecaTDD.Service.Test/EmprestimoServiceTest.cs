using BibliotecaTDD.Domain.Core.Exception;
using BibliotecaTDD.Domain.Model;
using BibliotecaTDD.Service.Interface;
using BibliotecaTDD.Service.Test.Mock;
using LivrariaTDD.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using Xunit;

namespace BibliotecaTDD.Service.Test
{
    public class EmprestimoServiceTest : IDisposable
    {
        private IEmprestimoService _emprestimoService;
        private List<Livro>_livros = new List<Livro>();
        public EmprestimoServiceTest()
        {
            //Criando listas utilizando fake data generator para popular nosso repositório mockado
            _livros = new List<Livro>() 
            {
                DomainMock.Livro("TDD Desenvolvimento Guiado por Testes"),
                DomainMock.Livro("C# 7.0 in a Nutshell"),
                DomainMock.Livro("Design Patterns")
            };

            var estoques = new List<Estoque>()
            {
                DomainMock.Estoque(_livros[0], 5),
                DomainMock.Estoque(_livros[1], 3),
                DomainMock.Estoque(_livros[2], 1)
            };

            //Criando mocks e populando eles com as listas criadas.
            var emprestimoRepository = FakeRepository<Emprestimo>.GetMock<EmprestimoRepository>();
            var livroRepository = FakeRepository<Livro>.GetMock<LivroRepository>(_livros);
            var estoqueRepository = FakeRepository<Estoque>.GetMock<EstoqueRepository>(estoques);

            _emprestimoService = new EmprestimoService(emprestimoRepository.Object, 
                estoqueRepository.Object, 
                livroRepository.Object);
        }
        
        #region [ Testes ]
        [Fact]
        public void TesteEfetuarEmprestimo()
        {
            var emprestimo = _emprestimoService.EfetuarEmprestimo(_livros[2], DomainMock.Pessoa("teste","1234567"), DomainMock.Pessoa("atendente", "123456"));
                        
            Assert.NotEqual(DateTime.MinValue, emprestimo.DataDevolucao);
            
            Assert.Throws<DomainException>(() => _emprestimoService.EfetuarEmprestimo(_livros[2], DomainMock.Pessoa("teste", "1234567"), DomainMock.Pessoa("atendente", "123456")));
        }

        [Fact]
        public void TesteException_EfetuarEmprestimo()
        {
            _emprestimoService.EfetuarEmprestimo(_livros[2], DomainMock.Pessoa("teste", "1234567"), DomainMock.Pessoa("atendente", "123456"));
            
            Assert.Throws<DomainException>(() => _emprestimoService.EfetuarEmprestimo(_livros[2], DomainMock.Pessoa("teste", "1234567"), DomainMock.Pessoa("atendente", "123456")));
        }

        #endregion

        #region [ Dispose ]

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
