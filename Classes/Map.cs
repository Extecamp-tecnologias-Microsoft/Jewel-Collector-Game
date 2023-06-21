namespace JewellNS;
/// <summary>
/// Classe responsavel por adicionar/remover obstaculos e joias pelo mapa, além de definir a posição do Robot
/// </summary>
public class Map
{
  public Robot robot;
  private Cell[,] arrayObj;
  private int line;
  private int column;
  private int level;

  public int getColumnsNumbers() { return this.column; }
  public int getLinesNumbers() { return this.line; }
  public Map() { }
  /// <summary>
  /// Map e responsavel por definir o tamanho do mapa
  /// </summary>
  /// <param name="width">Parametro responsavel por definir a largura</param>
  /// <param name="height">Parametro responsavel por definir a altura</param>
  /// </summary>

  public Map(int width, int height, int level)
  {
    this.level = level;
    this.line = width;
    this.column = height;
    arrayObj = new Cell[width, height];
    if(level==1){
      generateFixed();
    }else{
      GenerateRandom();
    }
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

  /// <summary>
  /// removeCell é responsavel por remover o objeto da celula
  /// </summary>
  /// <param name="i"> </param>
  /// <param name="j"></param>
  public void removeCell(int i, int j)
  {
    if(getCell(i, j) is Obstacle obstacle && obstacle.Symbol == " $$ "){
      return;
    }
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

 private void generateFixed(){
    Jewell jr = new Jewell { Name = "red", Symbol = " JR ", Point = 100, LevelEnergy = 0 };
    Jewell jg = new Jewell { Name = "green", Symbol = " JG ", Point = 50, LevelEnergy = 0 };
    Jewell jb = new Jewell { Name = "blue", Symbol = " JB ", Point = 10, LevelEnergy = 5 };
    Obstacle water = new Obstacle { Name = "water", Symbol = " ## ", LevelEnergy = 0 };
    Obstacle tree = new Obstacle { Name = "tree", Symbol = " $$ ", LevelEnergy = 3 };
    Robot robot = new Robot { Name = "robot", Symbol = " ME ", Point = 0, LevelEnergy = 5 };
    this.robot = robot;
    this.setCell(0, 0, robot);
    this.setCell(1, 9, jr);
    this.setCell(8, 8, jr);
    this.setCell(9, 1, jg);
    this.setCell(7, 6, jg);
    this.setCell(3, 4, jb);
    this.setCell(2, 1, jb);
    this.setCell(5, 0, water);
    this.setCell(5, 1, water);
    this.setCell(5, 2, water);
    this.setCell(5, 3, water);
    this.setCell(5, 4, water);
    this.setCell(5, 5, water);
    this.setCell(5, 6, water);
    this.setCell(5, 9, tree);
    this.setCell(3, 9, tree);
    this.setCell(8, 3, tree);
    this.setCell(2, 5, tree);
    this.setCell(1, 4, tree);
    this.PrintMap();
    this.FindRobotPosition();
 }

  public void GenerateRandom(){
    Random random = new Random(1);

    for(int blueJewell = 0; blueJewell < 3; blueJewell++){
      int xRandom = random.Next(0, this.line);
      int yRandom = random.Next(0, this.column);
      this.setCell(xRandom,yRandom, new Jewell { Name = "blue", Symbol = " JB ", Point = 10, LevelEnergy = 5 });
    }
    for(int greenJewell = 0; greenJewell < 3; greenJewell++){
      int xRandom = random.Next(0, this.line);
      int yRandom = random.Next(0, this.column);
      this.setCell(xRandom,yRandom,new Jewell { Name = "green", Symbol = " JG ", Point = 50, LevelEnergy = 0 });
    }
    for(int redJewell = 0; redJewell < 3; redJewell++){
      int xRandom = random.Next(0, this.line);
      int yRandom = random.Next(0, this.column);
      this.setCell(xRandom, yRandom, new Jewell { Name = "red", Symbol = " JR ", Point = 100, LevelEnergy = 0 });
    }
    for(int water = 0; water < 10; water++){
      int xRandom = random.Next(0, this.line);
      int yRandom = random.Next(0, this.column);
      this.setCell(xRandom,yRandom,new Obstacle { Name = "water", Symbol = " ## ", LevelEnergy = 0 });
    }
    for(int tree = 0; tree < 10; tree++){
      int xRandom = random.Next(0, this.line);
      int yRandom = random.Next(0, this.column);
      this.setCell(xRandom,yRandom,new Obstacle { Name = "tree", Symbol = " $$ ", LevelEnergy = 3 });
    }
    for(int radioactive = 0; radioactive < 10; radioactive++){
      int xRandom = random.Next(0, this.line);
      int yRandom = random.Next(0, this.column);
      this.setCell(xRandom,yRandom,new Obstacle { Name = "radioactive", Symbol = " !! ", LevelEnergy = -5 });
    }

    Robot robot = new Robot { Name = "robot", Symbol = " ME ", Point = 0, LevelEnergy = 5 };
    this.robot = robot;
    this.setCell(0, 0, robot);
    this.PrintMap();
  }

  public bool isDone(){
    for(int c = 0; c < this.column; c++){
      for(int l = 0; l < this.line; l++){
        if(arrayObj[c,l] is Jewell){return false;}
      }
    }
    return true;
  }
}
