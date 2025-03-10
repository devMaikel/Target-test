using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;

// 3) Dado um vetor que guarda o valor de faturamento diário de uma distribuidora, faça um programa, na linguagem 
// que desejar, que calcule e retorne:
// • O menor valor de faturamento ocorrido em um dia do mês;
// • O maior valor de faturamento ocorrido em um dia do mês;
// • Número de dias no mês em que o valor de faturamento diário foi superior à média mensal.

// IMPORTANTE:
// a) Usar o json ou xml disponível como fonte dos dados do faturamento mensal;
// b) Podem existir dias sem faturamento, como nos finais de semana e feriados. Estes dias devem ser ignorados 
// no cálculo da média;

class Program
{
    static void Main()
    {
        try
        {
            string xml = File.ReadAllText("dados.xml");

            // Fiz isso para adicionar um elemento raiz no xml pois a ausência dele estava causando erro na leitura
            xml = $"<root>{xml}</root>";

            XDocument doc = XDocument.Parse(xml);

            var faturamentos = doc.Descendants("row")
                .Select(row => new FaturamentoDiario
                {
                    Dia = int.Parse(row.Element("dia")?.Value ?? throw new Exception("Elemento 'dia' não encontrado ou inválido.")),
                    Valor = double.Parse(
                        row.Element("valor")?.Value ?? throw new Exception("Elemento 'valor' não encontrado ou inválido."),
                        CultureInfo.InvariantCulture
                    )
                })
                .ToList();

            List<FaturamentoDiario> diasComFaturamento = faturamentos.FindAll(f => f.Valor > 0);

            double menorFaturamento = diasComFaturamento.Min(f => f.Valor);
            double maiorFaturamento = diasComFaturamento.Max(f => f.Valor);

            double mediaMensal = diasComFaturamento.Average(f => f.Valor);

            int diasAcimaDaMedia = diasComFaturamento.Count(f => f.Valor > mediaMensal);

            Console.WriteLine($"Menor faturamento: {menorFaturamento}");
            Console.WriteLine($"Maior faturamento: {maiorFaturamento}");
            Console.WriteLine($"Número de dias com faturamento acima da média: {diasAcimaDaMedia}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}

class FaturamentoDiario
{
    public int Dia { get; set; }
    public double Valor { get; set; }
}
