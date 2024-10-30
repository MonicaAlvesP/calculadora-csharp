using Calculadora.Services;

var calculadora = new CalculadoraImplementacao();

while (true)
{
  Console.WriteLine("\nEscolha uma operação:");
  Console.WriteLine("1 - Somar");
  Console.WriteLine("2 - Subtrair");
  Console.WriteLine("3 - Multiplicar");
  Console.WriteLine("4 - Dividir");
  Console.WriteLine("5 - Ver Histórico");
  Console.WriteLine("0 - Sair");
  Console.Write("Digite o número da operação desejada: ");

  string entrada = Console.ReadLine();

  if (!int.TryParse(entrada, out int opcao))
  {
    Console.WriteLine("Erro: Por favor, digite um número inteiro válido.");
    continue;
  }

  if (opcao == 0)
  {
    Console.WriteLine("Saindo...");
    break;
  }

  if (opcao == 5)
  {
    var historico = calculadora.ObterHistorico();
    Console.WriteLine("Histórico de operações:");
    foreach (var operacao in historico)
    {
      Console.WriteLine(operacao);
    }
    continue;
  }

  if (opcao < 1 || opcao > 4)
  {
    Console.WriteLine("Opção inválida. Tente novamente.");
    continue;
  }

  int numero1 = ObterNumero("Digite o primeiro número:");
  int numero2 = ObterNumero("Digite o segundo número:");

  try
  {
    switch (opcao)
    {
      case 1:
        Console.WriteLine($"Resultado da Soma: {calculadora.Somar(numero1, numero2)}");
        break;
      case 2:
        Console.WriteLine($"Resultado da Subtração: {calculadora.Subtrair(numero1, numero2)}");
        break;
      case 3:
        Console.WriteLine($"Resultado da Multiplicação: {calculadora.Multiplicar(numero1, numero2)}");
        break;
      case 4:
        Console.WriteLine($"Resultado da Divisão: {calculadora.Dividir(numero1, numero2)}");
        break;
    }
  }
  catch (Exception ex)
  {
    Console.WriteLine("Erro: " + ex.Message);
  }
}

int ObterNumero(string mensagem)
{
  int numero;
  while (true)
  {
    Console.WriteLine(mensagem);
    if (int.TryParse(Console.ReadLine(), out numero))
      return numero;
    Console.WriteLine("Erro: O valor inserido não é um número inteiro.");
  }
}
