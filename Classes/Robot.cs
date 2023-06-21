namespace JewellNS;
/// <summary>
/// Classe responsável pelo robo, sua interação com o mapa e os itens.
/// </summary>
public class Robot : Cell
{
  private Map map;
  private int bagValue = 0;
  private Cell[] bagItems = new Cell[] { };
  private int RobotLine;
  private int RobotColumn;
  public int getRobotLine() { return this.RobotLine; }
  public int getRobotColumn() { return this.RobotColumn; }
  public void setRobotLine(int line) { this.RobotLine = line; }
  public void setRobotColumn(int column) { this.RobotColumn = column; }

  public string toString() { return $"Bag total items: {this.bagItems.Length} | Bag total value: {this.bagValue} | Energy: {this.LevelEnergy}"; }
  public void verifyEnergyLevel()
  {
    Console.Clear();
    if (LevelEnergy <= 0)
    {
      throw new Exception();
    }
  }
  public void moveToLeft(Map map)
  {
    if (this.getRobotColumn() > 0)
    {
      if (!(map.getCell(getRobotLine(), getRobotColumn() - 1) is  Jewell or Obstacle))
      {
        LevelEnergy--;
        map.removeCell(getRobotLine(), getRobotColumn());
        map.setCell(getRobotLine(), getRobotColumn() - 1, this);
        verifyEnergyLevel();
      }
    }
  }
  public void moveToRight(Map map)
  {
    if (this.getRobotColumn() <= map.getColumnsNumbers())
    {
      if (!(map.getCell(getRobotLine(), getRobotColumn() + 1) is Jewell or Obstacle))
      {
        LevelEnergy--;
        map.removeCell(getRobotLine(), getRobotColumn());
        map.setCell(getRobotLine(), getRobotColumn() + 1, this);
        verifyEnergyLevel();
      }
    }
  }
  public void moveToTop(Map map)
  {
    if (this.getRobotLine() > 0)
    {
      if (!(map.getCell(getRobotLine() - 1, getRobotColumn()) is Jewell or Obstacle))
      {
        LevelEnergy--;
        map.removeCell(getRobotLine(), getRobotColumn());
        map.setCell(getRobotLine() - 1, getRobotColumn(), this);
        verifyEnergyLevel();
      }
    }
  }
  public void moveToBottom(Map map)
  {
    if (this.getRobotLine() <= map.getLinesNumbers())
    {
      if (!(map.getCell(getRobotLine() + 1, getRobotColumn()) is Jewell or Obstacle))
      {
        LevelEnergy--;
        map.removeCell(getRobotLine(), getRobotColumn());
        map.setCell(getRobotLine() + 1, getRobotColumn(), this);
        verifyEnergyLevel();
      }
    }
  }

  public void captureItem(Map map)
  {
    int playerLine = getRobotLine();
    int columnPlayer = getRobotColumn();
    int captureRange = 1;

    if ((map.getCell(playerLine + captureRange, columnPlayer) is Jewell) ||
        (map.getCell(playerLine + captureRange, columnPlayer) is Obstacle obstacle3) && obstacle3.Symbol == " $$ ")
    {
      updateEnergy(map.getCell(playerLine + captureRange, columnPlayer));
      updateBag(map.getCell(playerLine + captureRange, columnPlayer));
      map.removeCell(playerLine + captureRange, columnPlayer);
    }
    else if ((map.getCell(playerLine - captureRange, columnPlayer) is Jewell) ||
    (map.getCell(playerLine - captureRange, columnPlayer) is Obstacle obstacle2) && obstacle2.Symbol == " $$ ")
    {
      updateEnergy(map.getCell(playerLine - captureRange, columnPlayer));
      updateBag(map.getCell(playerLine - captureRange, columnPlayer));
      map.removeCell(playerLine - captureRange, columnPlayer);
    }
    else if ((map.getCell(playerLine, columnPlayer + captureRange) is Jewell) ||
    (map.getCell(playerLine, columnPlayer + captureRange) is Obstacle obstacle1) && obstacle1.Symbol == " $$ ")
    {
      updateEnergy(map.getCell(playerLine, columnPlayer + captureRange));
      updateBag(map.getCell(playerLine, columnPlayer + captureRange));
      map.removeCell(playerLine, columnPlayer + captureRange);
    }
    else if ((map.getCell(playerLine, columnPlayer - captureRange) is Jewell) ||
    (map.getCell(playerLine, columnPlayer - captureRange) is Obstacle obstacle) && obstacle.Symbol == " $$ ")
    {
      updateEnergy(map.getCell(playerLine, columnPlayer - captureRange));
      updateBag(map.getCell(playerLine, columnPlayer - captureRange));
      map.removeCell(playerLine, columnPlayer - captureRange);
    }
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

  private void updateEnergy(Cell cellObject)
  {
    LevelEnergy = LevelEnergy + cellObject.LevelEnergy;
  }
}