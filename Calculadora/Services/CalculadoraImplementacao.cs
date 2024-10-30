namespace Calculadora.Services
{
  public class CalculadoraImplementacao
  {
    private readonly List<string> _historico;

    public CalculadoraImplementacao()
    {
      _historico = new List<string>();
    }

    public int Somar(int numero1, int numero2)
    {
      var resultado = numero1 + numero2;
      _historico.Add($"Soma: {numero1} + {numero2} = {resultado}");
      return resultado;
    }

    public int Subtrair(int numero1, int numero2)
    {
      var resultado = numero1 - numero2;
      _historico.Add($"Subtração: {numero1} - {numero2} = {resultado}");
      return resultado;
    }

    public int Multiplicar(int numero1, int numero2)
    {
      var resultado = numero1 * numero2;
      _historico.Add($"Multiplicação: {numero1} * {numero2} = {resultado}");
      return resultado;
    }

    public int Dividir(int numero1, int numero2)
    {
      if (numero2 == 0)
        throw new DivideByZeroException("Erro: Não é possível dividir por zero.");

      var resultado = numero1 / numero2;
      _historico.Add($"Divisão: {numero1} / {numero2} = {resultado}");
      return resultado;
    }

    public List<string> ObterHistorico()
    {
      return _historico.Skip(Math.Max(0, _historico.Count - 3)).ToList();
    }
  }
}
