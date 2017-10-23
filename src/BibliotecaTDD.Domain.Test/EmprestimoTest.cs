using BibliotecaTDD.Domain.Model;
using System;
using Xunit;

namespace BibliotecaTDD.Domain.Test
{
    public class EmprestimoTest
    {
        public EmprestimoTest()
        {

        }

        [Fact]
        public void MultaSobEntrega()
        {
            var emprestimo = new Emprestimo(
                            new Livro("As Cronicas de Narnia", "Livro muito bom.", "1.0", 10), 
                            new Pessoa("Cliente", "12345678910"), 
                            new Pessoa("Atendente", "10987654321"),
                            DateTime.Now.AddDays(-9));

            Assert.Equal(2, emprestimo.Multa);
        }
    }
}
