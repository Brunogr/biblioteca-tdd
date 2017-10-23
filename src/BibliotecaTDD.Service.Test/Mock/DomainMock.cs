using BibliotecaTDD.Domain.Model;
using Bogus;
using Bogus.Extensions.Brazil;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaTDD.Service.Test.Mock
{
    public class DomainMock
    {
        public static Pessoa Pessoa(string nome = null, string cpf = null)
        {
            return new Faker<Pessoa>()
                .CustomInstantiator(f =>
                    new Pessoa(
                        !string.IsNullOrEmpty(nome) ?
                            nome :
                            $"{f.Person.FirstName} {f.Person.LastName}",
                        !string.IsNullOrWhiteSpace(cpf) ?
                            cpf :
                            f.Person.Cpf())
                        );
        }

        public static Estoque Estoque(Livro livro = null, int? quantidade = null)
        {
            return new Faker<Estoque>()
                .CustomInstantiator(f =>
                    new Estoque(
                        livro != null ?
                            livro :
                            DomainMock.Livro(),
                        quantidade.HasValue ?
                            quantidade.Value :
                            f.Random.Int())
                    );
        }

        public static Livro Livro(string nome = null)
        {
            return new Faker<Livro>()
                .CustomInstantiator(f =>
                    new Livro(
                        !string.IsNullOrWhiteSpace(nome) ?
                            nome :
                        f.Name.Random.Word(),
                        f.Lorem.Sentence(),
                        f.Lorem.Word(),
                        Convert.ToDecimal(f.Commerce.Price()))
                    );
        }
    }
}
