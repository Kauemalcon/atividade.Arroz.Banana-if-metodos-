using System;

namespace Pratica_avaliação

// Faça um algoritmo que solicite a digitação de um produto.
//  Se este produto for "Arroz", verifique as seguintes regras:
// Se o dia atual for Segunda ou dia 10 , desconte 18 centavos do valor unitário.
// Se o dia atual for Domingo, acresca 15 centavos ao valor unitário
// Por fim, solicite a quantidade e caso seja de 15 de outubro 2023,
// de desconto de 10% ao valor total.
//  * Considere que o valor unitário do arroz é 5,19 Se o produto for banana, verifique as seguintes regras:
// Se o dia atual for o primeiro dia do mês (desde que não seja domingo)
// acresca 1,16 ao kilo da banana
// Se o dia atual for Terças e Quintas do mês dezembro e a quantidade solicitada for
//  superior a 8kg, conceda um desconto de 7,5% ao valor final
// * Considere que o kilo da banana está em 2,84
// Se for outro produto
// Escreva "Produto não localizado
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite um produto!");
            string nomeProduto = Console.ReadLine();
            decimal valorProduto1 = 5.19m;
            decimal valorProduto2 = 2.84m;
            
            if (nomeProduto.ToUpper() == "ARROZ")
            {
                valorProduto1 = 5.19m;
                if (DateTime.Today.DayOfWeek == DayOfWeek.Monday || DateTime.Today.Day == 10)
                {
                    valorProduto1 -= 0.18m;

                }
                else if ( DateTime.Today.DayOfWeek == DayOfWeek.Sunday)
                {
                    valorProduto1 += 0.15m;
                }
                Console.WriteLine("Digite a quantidade que voce deseja");
                int quantidade = int.Parse(Console.ReadLine());
                decimal valorTotal = quantidade * valorProduto1;

                if (DateTime.Today == DateTime.Parse("15/10/2023"))
                {
                    valorTotal = AplicarDesconto(valorTotal, 10m);
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Voce comprou " + quantidade + " unidades de arroz no valor de:" + valorTotal + " reais");
                Console.ResetColor();
            }

            else if (nomeProduto.ToUpper() == "BANANA")
            {
                valorProduto2 = 2.84m;
                if (DateTime.Today.Month ==1 && DateTime.Today.DayOfWeek != DayOfWeek.Sunday)
                {
                    valorProduto2 += 1.16m;
                }
                Console.WriteLine("Digite a quantidade em kilos que voce deseja");
                decimal quantidadekg = decimal.Parse(Console.ReadLine());
                decimal valorTotal = quantidadekg * valorProduto2;
                               
                if ((DateTime.Today.DayOfWeek == DayOfWeek.Tuesday || DateTime.Today.DayOfWeek == DayOfWeek.Thursday)
                    && DateTime.Today.Month == 12 && quantidadekg > 8m)
                {
                    valorTotal = AplicarDesconto(valorTotal, 7.5m);
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nVoce comprou " + quantidadekg + "kg de banana no valor de:"  + valorTotal + " reais");
                Console.ResetColor();
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nProduto nao localizado");
                Console.ResetColor();
            }
        }
        static decimal AplicarDesconto(decimal valorTotal, decimal percentualDesconto)
        {
            const decimal percentual = 100m;
            percentualDesconto = valorTotal * (percentualDesconto / percentual);
            valorTotal -= percentualDesconto;
            return valorTotal;
            

        }
    }
}
