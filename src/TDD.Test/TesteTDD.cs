using System;
using TDD.Exemplo;
using Xunit;

namespace TDD.Test
{
    public class TesteTDD
    {
        ICalculadoraDeDatas _calculadoraDeDatas;
        public TesteTDD()
        {
            _calculadoraDeDatas = new CalculadoraDeDatas();
        }

        [Fact]
        public void TesteCalculoDiferencaDeDias()
        {
            var dataInicial = DateTime.Now;
            var dataFinal = DateTime.Now.AddDays(3);

            Assert.Equal(3, _calculadoraDeDatas.DiferencaDeDias(dataInicial, dataFinal));
        }
    }

}
