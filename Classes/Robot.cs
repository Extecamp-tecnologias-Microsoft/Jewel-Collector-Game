namespace JewellNS;
/// <summary>
/// Classe responsável pelo robo
/// </summary>
public class Robot : Cell
{
  private Map map;
  private int bagValue = 0;
  private Cell[] bagItems = new Cell[] { };
  private int RobotLine;
  private int RobotColumn;
  
  /// <summary>
  /// Retorna o número da Coluna do Robot
  /// </summary>
  public int getRobotLine() { return this.RobotLine; }
  
  /// <summary>
  /// Retorna o número da Linha do Robot
  /// </summary>
  public int getRobotColumn() { return this.RobotColumn; }
  
  /// <summary>
  /// Define o número da Linha do Robot
  /// <param name="line">Parametro responsavel por definir a linha do robot</param>
  /// </summary>
  public void setRobotLine(int line) { this.RobotLine = line; }
  
  /// <summary>
  /// Define o número da Coluna do Robot
  /// <param name="column">Parametro responsavel por definir a coluna do robot</param>
  /// </summary>
  public void setRobotColumn(int column) { this.RobotColumn = column; }

  /// <summary>
  /// Printa as infos do Robot
  /// </summary>
  public string toString() { return $"Bag total items: {this.bagItems.Length} | Bag total value: {this.bagValue} | Energy: {this.LevelEnergy}"; }
  
  /// <summary>
  /// Verifica nível de energia do Robot
  /// </summary>
  public void verifyEnergyLevel()
  {
    Console.Clear();
    if (LevelEnergy <= 0)
    {
      throw new RanOutOfEnergyException();
    }
  }

  /// <summary>
  /// Movimenta o robot para a esquerda
  /// <param name="map">Recebe o map instanciado</param>
  /// </summary>
  public void moveToLeft(Map map)
  {
    if (this.getRobotColumn() > 0)
    {
      int targetLine = getRobotLine();
      int targetColumn = getRobotColumn() - 1;
      Cell targetCell = map.getCell(targetLine, targetColumn);

      if (!(targetCell is Jewell or Obstacle) || (targetCell.Symbol == " !! "))
      {
          // Remove energia das células adjacentes a obstáculos radioativos
          map.RemoveEnergyFromAdjacentRadioactiveCells(this);
          LevelEnergy--;
          map.removeCell(getRobotLine(), getRobotColumn());
          map.setCell(targetLine, targetColumn, this);
          verifyEnergyLevel();
      }else{
        throw new OccupiedPositionException();
      }
    }else{
      throw new OutOfMapException();
    }
  }

  /// <summary>
  /// Movimenta o robot para a direita
  /// <param name="map">Recebe o map instanciado</param>
  /// </summary>
  public void moveToRight(Map map)
  {
    if (this.getRobotColumn() <= map.getColumnsNumbers())
    {
      int targetLine = getRobotLine();
      int targetColumn = getRobotColumn() + 1;
      Cell targetCell = map.getCell(targetLine, targetColumn);

      if (!(targetCell is Jewell or Obstacle) || (targetCell.Symbol == " !! "))
      {
        LevelEnergy--;
        // Remove energia das células adjacentes a obstáculos radioativos
        map.RemoveEnergyFromAdjacentRadioactiveCells(this);
        map.removeCell(getRobotLine(), getRobotColumn());
        map.setCell(getRobotLine(), getRobotColumn() + 1, this);
        verifyEnergyLevel();
      }else{
        throw new OccupiedPositionException();
      }
    }else{
      throw new OutOfMapException();
    }
  }

  /// <summary>
  /// Movimenta o robot para cima
  /// <param name="map">Recebe o map instanciado</param>
  /// </summary>
  public void moveToTop(Map map)
  {
    if (this.getRobotLine() > 0)
    {
      int targetLine = getRobotLine() - 1;
      int targetColumn = getRobotColumn();
      Cell targetCell = map.getCell(targetLine, targetColumn);

      if (!(targetCell is Jewell or Obstacle) || (targetCell.Symbol == " !! "))
      {
        // Remove energia das células adjacentes a obstáculos radioativos
        map.RemoveEnergyFromAdjacentRadioactiveCells(this);
        LevelEnergy--;
        map.removeCell(getRobotLine(), getRobotColumn());
        map.setCell(getRobotLine() - 1, getRobotColumn(), this);
        verifyEnergyLevel();
      }else{
        throw new OccupiedPositionException();
      }
    }else{
      throw new OutOfMapException();
    }
  }

  /// <summary>
  /// Movimenta o robot para a baixo
  /// <param name="map">Recebe o map instanciado</param>
  /// </summary>
  public void moveToBottom(Map map)
  {
    if (this.getRobotLine() <= map.getLinesNumbers())
    {
      int targetLine = getRobotLine() + 1;
      int targetColumn = getRobotColumn();
      Cell targetCell = map.getCell(targetLine, targetColumn);

      if (!(targetCell is Jewell or Obstacle) || (targetCell.Symbol == " !! "))
      {
        // Remove energia das células adjacentes a obstáculos radioativos
        map.RemoveEnergyFromAdjacentRadioactiveCells(this);
        LevelEnergy--;
        map.removeCell(getRobotLine(), getRobotColumn());
        map.setCell(getRobotLine() + 1, getRobotColumn(), this);
        verifyEnergyLevel();
      }else{
        throw new OccupiedPositionException();
      }
    }else{
      throw new OutOfMapException();
    }
  }

  /// <summary>
  ///  Captura o item, se existir
  /// <param name="map">Recebe o map instanciado</param>
  /// </summary>
  public void captureItem(Map map)
{
    int playerLine = getRobotLine();
    int columnPlayer = getRobotColumn();
    int captureRange = 1;

    if (isValidPosition(playerLine + captureRange, columnPlayer, map) && 
      (map.getCell(playerLine + captureRange, columnPlayer) is Jewell ||
      (map.getCell(playerLine + captureRange, columnPlayer) is Obstacle obstacle3 && obstacle3.Symbol == " $$ ")))
    {
      updateEnergy(map.getCell(playerLine + captureRange, columnPlayer));
      updateBag(map.getCell(playerLine + captureRange, columnPlayer));
      map.removeCell(playerLine + captureRange, columnPlayer);
    }
    else if (isValidPosition(playerLine - captureRange, columnPlayer, map) &&
      (map.getCell(playerLine - captureRange, columnPlayer) is Jewell ||
      (map.getCell(playerLine - captureRange, columnPlayer) is Obstacle obstacle2 && obstacle2.Symbol == " $$ ")))
    {
      updateEnergy(map.getCell(playerLine - captureRange, columnPlayer));
      updateBag(map.getCell(playerLine - captureRange, columnPlayer));
      map.removeCell(playerLine - captureRange, columnPlayer);
    }
    else if (isValidPosition(playerLine, columnPlayer + captureRange, map) &&
      (map.getCell(playerLine, columnPlayer + captureRange) is Jewell ||
      (map.getCell(playerLine, columnPlayer + captureRange) is Obstacle obstacle1 && obstacle1.Symbol == " $$ ")))
    {
      updateEnergy(map.getCell(playerLine, columnPlayer + captureRange));
      updateBag(map.getCell(playerLine, columnPlayer + captureRange));
      map.removeCell(playerLine, columnPlayer + captureRange);
    }
    else if (isValidPosition(playerLine, columnPlayer - captureRange, map) &&
      (map.getCell(playerLine, columnPlayer - captureRange) is Jewell ||
      (map.getCell(playerLine, columnPlayer - captureRange) is Obstacle obstacle && obstacle.Symbol == " $$ ")))
    {
      updateEnergy(map.getCell(playerLine, columnPlayer - captureRange));
      updateBag(map.getCell(playerLine, columnPlayer - captureRange));
      map.removeCell(playerLine, columnPlayer - captureRange);
    }
    else
    {
        throw new DontExistItemToCapture();
    }
}

  /// <summary>
  /// Verifica se a posição a ser conferida, é válida
  /// </summary>
  /// <param name="line">Celula atual do jogador</param>
  /// <param name="column">Celula atual do jogador</param>
  /// <param name="map">Celula atual do jogador</param>
private bool isValidPosition(int line, int column, Map map)
{
  int maxLine = map.getLinesNumbers();
  int maxColumn = map.getColumnsNumbers();

  return line >= 0 && line < maxLine && column >= 0 && column < maxColumn;
}

  /// <summary>
  /// Atualiza a quantidade de itens na bolsa e o valor da mesma 
  /// </summary>
  /// <param name="cellObject">Celula atual do jogador</param>
  private void updateBag(Object cellObject)
  {
    if (cellObject is Jewell jewell)
    {
      this.bagValue = this.bagValue + jewell.Point;
      Array.Resize(ref bagItems, bagItems.Length + 1);
      bagItems[bagItems.Length - 1] = jewell;
    }
  }

  /// <summary>
  /// Atualiza o nível de Energia
  /// <param name="cellObject">Celula atual do jogador</param>
  /// </summary>
  private void updateEnergy(Cell cellObject)
  {
    LevelEnergy = LevelEnergy + cellObject.LevelEnergy;
  }
}