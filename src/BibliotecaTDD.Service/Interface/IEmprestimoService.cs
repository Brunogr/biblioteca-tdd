using BibliotecaTDD.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaTDD.Service.Interface
{
    public interface IEmprestimoService
    {
        Emprestimo EfetuarEmprestimo(Livro livro, Pessoa cliente, Pessoa atendente, DateTime? dataEmprestimo = null);
        Emprestimo FinalizarEmprestimo(Guid IdEmprestimo);
        Emprestimo BuscarEmprestimo(Guid IdEmprestimo);
        IEnumerable<Emprestimo> BuscarTodosOsEmprestimosAtivos();
    }
}
