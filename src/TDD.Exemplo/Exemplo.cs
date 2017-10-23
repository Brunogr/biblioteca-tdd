using System;

namespace TDD.Exemplo
{
    public class CalculadoraDeDatas : ICalculadoraDeDatas
    {
        public int DiferencaDeDias(DateTime dataInicial, DateTime dataFinal)
        {
            return (int)(dataFinal - dataInicial).TotalDays;
        }

        //public int DiferencaDeDias(DateTime dataInicial, DateTime dataFinal)
        //{
        //    throw new NotImplementedException();
        //}
    }

    public interface ICalculadoraDeDatas
    {
        int DiferencaDeDias(DateTime dataInicial, DateTime dataFinal);
    }
}
