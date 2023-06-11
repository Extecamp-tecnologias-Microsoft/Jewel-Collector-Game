namespace JewellNS;
/// <summary>
/// Classe responsavel por adicionar/remover obstaculos e joias pelo mapa, além de definir a posição do Robot
/// </summary>
public class Map
{
  private Cell[,] arrayObj;
  private int line;
  private int column;
  private int numberItems;
  public bool changeMap = false;
  private bool phase1Completed = false;
  private char[,] matrix;
  private char[,] teste;
  private Random random;

  public bool getphase1Completed() { return this.phase1Completed; }
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

  /// <summary>
  ///  setCell seta um novo objeto dentro da linha e coluna passada no parâmetro
  /// </summary>
  /// <param name="i">Posicao Y</param>
  /// <param name="j">posicao X</param>
  /// <param name="obj">objeto contendo a celula do mapa</param>
  public void setCell(int i, int j, Cell obj)
  {
    if (obj is Jewell jewell)
    {
      numberItems++;
      arrayObj[i, j] = jewell;
    }
    else if (obj is Obstacle obstacle)
    {
      if (obstacle.Name == "tree")
      {
        numberItems++;
      }
      arrayObj[i, j] = obstacle;
    }
    else if (obj is Robot Robot)
    {
      arrayObj[i, j] = Robot;
    }
  }

  /// <summary>
  /// removeCell é responsavel por remover o objeto da celula
  /// </summary>
  /// <param name="i"> </param>
  /// <param name="j"></param>
  public void removeCell(int i, int j)
  {
    arrayObj[i, j] = null;
  }
  public void PrintMap()
  {
    if (changeMap)
    {
      this.phase1Completed = true;
      makeRandomMap(this.numberItems);
    }
    else
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

  public void makeRandomMap(int numberItems)
  {
    Console.WriteLine("novo mapa aleatorio", numberItems);
    this.line = numberItems;
    this.column = numberItems;
    matrix = new char[this.line, this.column];
    random = new Random();
    initializeRandomMap();
  }

  private void initializeRandomMap()
  {
    for (int i = 0; i < this.column; i++)
    {
      for (int j = 0; j < this.line; j++)
      {
        matrix[i, j] = '-';
      }
      printRandomMap();
    }
  }
  public void AddObject()
  {
    Jewell jr = new Jewell { Name = "red", Symbol = " JR ", Point = 100, LevelEnergy = 0 };
    Jewell jg = new Jewell { Name = "green", Symbol = " JG ", Point = 50, LevelEnergy = 0 };
    Jewell jb = new Jewell { Name = "blue", Symbol = " JB ", Point = 10, LevelEnergy = 5 };
    Obstacle water = new Obstacle { Name = "water", Symbol = " ## ", LevelEnergy = 0 };
    Obstacle tree = new Obstacle { Name = "tree", Symbol = " $$ ", LevelEnergy = 3 };
    string[] listItem = { jr.Symbol, jg.Symbol, jb.Symbol, water.Symbol, tree.Symbol };
    for (double i = 0; i < 0.1; i = i + 0.1)
    {
      int itemRandom = random.Next(0, listItem.Length);
      char[] chosedItem = listItem[itemRandom].ToCharArray();
      int x = random.Next(0, this.column);
      int y = random.Next(0, this.line);
      matrix[x, y] = chosedItem[2];
    }
  }
  public void printRandomMap()
  {
    Console.Clear();
    for (int i = 0; i < this.column; i++)
    {
      for (int j = 0; j < this.line; j++)
      {
        if (matrix[i, j] != '-')
        {
          switch (matrix[i, j])
          {
            case 'R':
              Console.Write(" " + "JR" + " ");
              break;
            case 'G':
              Console.Write(" " + "JG" + " ");
              break;
            case 'B':
              Console.Write(" " + "JB" + " ");
              break;
            case '#':
              Console.Write(" " + "##" + " ");
              break;
            case '$':
              Console.Write(" " + "$$" + " ");
              break;
          }
        }
        else
        {
          Console.Write(" " + matrix[i, j] + matrix[i, j] + " ");
        }
      }
      Console.WriteLine();
      AddObject();
    }
  }
  public void PrintObjectLocations()
  {
    Console.WriteLine("Object Locations:");
    for (int i = 0; i < this.column; i++)
    {
      for (int j = 0; j < this.line; j++)
      {
        if (matrix[i, j] != '-')
        {
          Console.WriteLine($"Object '{matrix[i, j]}' at position ({i}, {j})");
        }
      }
    }
  }
}
