namespace JewellNS;

public class Map
{
  private Cell[,] arrayObj;
  private int line;
  private int column;


  public int getColumnsNumbers() { return this.column; }
  public int getLinesNumbers() { return this.line; }
  public Map() { }
  /// <summary>
  /// Map e responsavel por definir o tamanho do mapa
  /// </summary>
  /// <param name="width">Parametro responsavel por definir a largura</param>
  /// <param name="height">Parametro responsavel por definir a altura</param>
  public Map(int width, int height)
  {
    this.line = width;
    this.column = height;
    arrayObj = new Cell[width, height];
  }
  /// <summary>
  /// 
  /// </summary>
  /// <param name="line"></param>
  /// <param name="column"></param>
  /// <returns></returns>
  public Cell getCell(int line, int column)
  {
    return arrayObj[line, column];
  }
  public void setCell(int i, int j, Cell obj)
  {
    if (obj is Jewell jewell)
    {
      arrayObj[i, j] = jewell;
    }
    else if (obj is Obstacle obstacle)
    {
      arrayObj[i, j] = obstacle;
    }
    else if (obj is Robot Robot)
    {
      arrayObj[i, j] = Robot;
    }
  }
  public void removeCell(int i, int j)
  {
    arrayObj[i, j] = null;
  }
  public void PrintMap()
  {
    Console.Clear();

    for (int i = 0; i < line; i++)
    {
      for (int j = 0; j < column; j++)
      {
        if (arrayObj[i, j] is null)
        {
          Console.Write(" -- ");
        }
        else if (arrayObj[i, j] is Jewell jewell)
        {
          Console.Write(jewell.Symbol);
        }
        else if (arrayObj[i, j] is Obstacle obstacle)
        {
          Console.Write(obstacle.Symbol);
        }
        else if (arrayObj[i, j] is Robot Robot)
        {
          Console.Write(Robot.Symbol);
        }
      }
      Console.WriteLine();
    }
  }
  public void FindRobotPosition()
  {
    for (int i = 0; i < line; i++)
    {
      for (int j = 0; j < column; j++)
      {
        if (arrayObj[i, j] is Robot Robot)
        {
          Robot.setRobotLine(i);
          Robot.setRobotColumn(j);
        }
      }
    }
  }
}
