namespace JewellNS;
/// <summary>
/// Classe Map para adicionar/remover obstaculos e joias pelo mapa, além de definir a posição do Robot
/// </summary>
public class Map
{
  private Cell[,] arrayObj;
  private int line;
  private int column;
  private int numberItems;
  public bool changeMap = false;

  public int getColumnsNumbers() { return this.column; }
  public int getLinesNumbers() { return this.line; }
  public int getNumberItems() { return this.numberItems; }
  public Map() { }
  /// <summary>
  /// Map e responsavel por definir o tamanho do mapa
  /// </summary>
  /// <param name="width">Parametro responsavel por definir a largura</param>
  /// <param name="height">Parametro responsavel por definir a altura</param>
  /// </summary>

  public Map(int width, int height)
  {
    this.line = width;
    this.column = height;
    arrayObj = new Cell[width, height];
  }
  /// <summary>
  /// getCell é responsavel por retornar o objeto que é contido através dos parametros enviados
  /// </summary>
  /// <param name="line"> variavel que determina a linha da Cell</param>
  /// <param name="column"> variavel que determina a coluna da Cell</param>
  /// <returns> retorna o objeto da Cell</returns>

  public Cell getCell(int line, int column)
  {
    return arrayObj[line, column];

  }

  public void setCell(int i, int j, Cell obj)
  {
    if (obj is Jewell jewell)
    {
      numberItems ++;
      arrayObj[i, j] = jewell;
    }
    else if (obj is Obstacle obstacle)
    {
        if(obstacle.Name == "tree"){
            numberItems ++;
        }
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
    if(changeMap){
        Console.WriteLine("teste");
        // a partir daqui, será criado um novo mapa aleatorio
        // map.makeRandomMap();
        // return;
    }
    else{
    Console.Clear();
    }

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
