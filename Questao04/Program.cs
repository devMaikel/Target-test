using System;

// 4) Dado o valor de faturamento mensal de uma distribuidora, detalhado por estado:
// • SP – R$67.836,43
// • RJ – R$36.678,66
// • MG – R$29.229,88
// • ES – R$27.165,48
// • Outros – R$19.849,53
// Escreva um programa na linguagem que desejar onde calcule o percentual de representação 
// que cada estado teve dentro do valor total mensal da distribuidora. 

class Program
{
    static void Main()
    {
        decimal sp = 67836.43m;
        decimal rj = 36678.66m;
        decimal mg = 29229.88m;
        decimal es = 27165.48m;
        decimal outros = 19849.53m;

        decimal faturamentoTotal = sp + rj + mg + es + outros;

        Console.WriteLine("Percentual de representação de cada estado:");
        Console.WriteLine($"SP: {(sp / faturamentoTotal * 100).ToString("N2")}%");
        Console.WriteLine($"RJ: {(rj / faturamentoTotal * 100).ToString("N2")}%");
        Console.WriteLine($"MG: {(mg / faturamentoTotal * 100).ToString("N2")}%");
        Console.WriteLine($"ES: {(es / faturamentoTotal * 100).ToString("N2")}%");
        Console.WriteLine($"Outros: {(outros / faturamentoTotal * 100).ToString("N2")}%");
    }
}
