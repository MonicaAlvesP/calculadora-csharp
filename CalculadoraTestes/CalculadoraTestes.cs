using Calculadora.Services;
namespace CalculadoraTestes;

public class CalculadoraTestes
{
  private readonly CalculadoraImplementacao _calculadora;
  public CalculadoraTestes()
  {
    _calculadora = new CalculadoraImplementacao();
  }

  [Theory]
  [InlineData(230, 65, 295)]
  [InlineData(100, 50, 150)]
  public void TestSoma(int numero1, int numero2, int resultadoEsperado)
  {
    // Act
    var resultado = _calculadora.Somar(numero1, numero2);
    // Assert
    Assert.Equal(resultadoEsperado, resultado);
  }

  [Theory]
  [InlineData(25, 13, 12)]
  [InlineData(50, 25, 25)]
  public void TestSubtracao(int numero1, int numero2, int resultadoEsperado)
  {
    // Act
    var resultado = _calculadora.Subtrair(numero1, numero2);
    // Assert
    Assert.Equal(resultadoEsperado, resultado);
  }

  [Theory]
  [InlineData(10, 5, 50)]
  [InlineData(20, 5, 100)]
  public void TestMultiplicacao(int numero1, int numero2, int resultadoEsperado)
  {
    // Act
    var resultado = _calculadora.Multiplicar(numero1, numero2);
    // Assert
    Assert.Equal(resultadoEsperado, resultado);
  }

  [Theory]
  [InlineData(10, 2, 5)]
  [InlineData(20, 4, 5)]
  public void TestDivisao(int numero1, int numero2, int resultadoEsperado)
  {
    // Act
    var resultado = _calculadora.Dividir(numero1, numero2);
    // Assert
    Assert.Equal(resultadoEsperado, resultado);
  }

  [Theory]
  [InlineData(10, 0)]
  [InlineData(20, 0)]
  [InlineData(30, 0)]
  public void TestDivisaoPorZero(int numero1, int numero2)
  {
    // Act e Assert
    var exception = Assert.Throws<DivideByZeroException>(() => _calculadora.Dividir(numero1, numero2));
    Assert.Equal("Erro: Não é possível dividir por zero.", exception.Message);
  }

  [Fact]

  public void TestHistoricoAdicionaOperacao()
  {
    // Arrange
    _calculadora.Multiplicar(120, 7);

    // Act
    var historico = _calculadora.ObterHistorico();

    // Assert
    Assert.Single(historico);
    Assert.Contains("Multiplicação: 120 * 7 = 840", historico);
  }
}