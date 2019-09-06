using System;
using System.Globalization;

namespace PrimeiroProjeto
{
    class Program
    {
        static void Main(string[] args)
        {
            string produto1 = "Computador";
            string produto2 = "Mesa de escritório";

            byte idade = 30;
            int codigo = 5290;
            char genero = 'M';

            double preco1 = 2100.0;
            double preco2 = 650.50;
            double medida = 53.234567;
            Console.WriteLine("Produtos:\n " +produto1+ "Computador, cujo preço é $" +preco1+ "\n\nRegitro: " +idade+
                " de idade, código " +codigo+ " e gênero: " +genero+
                "\n\nMedida com oito  casas decimais: " +medida.ToString("F8")+ "\nArredondando (três casas decimais): "
                +medida.ToString("F3")+ "\nSeparador decimal invariant culture: " +medida.ToString("F3",CultureInfo.InvariantCulture));
        }
    }
}
