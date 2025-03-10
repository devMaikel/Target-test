using System;

// 5) Escreva um programa que inverta os caracteres de um string.

// IMPORTANTE:
// a) Essa string pode ser informada através de qualquer entrada de sua preferência ou pode ser 
// previamente definida no código;
// b) Evite usar funções prontas, como, por exemplo, reverse;

class Program
{
    static void Main()
    {
        Console.Write("Digite uma string para inverter: ");
        string? input = Console.ReadLine(); 
        // Usei "string?" para indicar que o valor de entrada pode ser nulo

        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Entrada inválida. A string não pode ser nula ou vazia.");
            return;
        }

        string invertedString = InverterString(input);

        Console.WriteLine($"String invertida: {invertedString}");
    }

    static string InverterString(string str)
    {
        char[] caracteres = str.ToCharArray();

        int inicio = 0;
        int fim = caracteres.Length - 1;

        while (inicio < fim)
        {
            char temp = caracteres[inicio];
            caracteres[inicio] = caracteres[fim];
            caracteres[fim] = temp;

            inicio++;
            fim--;
        }

        return new string(caracteres);
    }
}
