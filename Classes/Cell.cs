namespace JewellNS;
/// <summary>
/// Classe responsável por definir as atributos necessários de cada célula/posição do tabuleiro
/// </summary>
public class Cell
{
  /// <summary>
  /// Atribuitos de cada célula, os objetos se diferenciarão em Nome, Pontos, Símbolos e Nível de Energia
  /// </summary>
  public string Name { get; set; }
  public int Point { get; set; }
  public string Symbol { get; set; }
  public int? LevelEnergy { get; set; }
}