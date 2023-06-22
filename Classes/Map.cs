namespace JewellNS;
/// <summary>
/// Classe reponsável pelo Mapa.
/// </summary>
public class Map
{
  public Robot robot;
  private Cell[,] arrayObj;
  private int line;
  private int column;
  private int level;

  /// <summary>
  /// Retorna o número de Colunas
  /// </summary>
  public int getColumnsNumbers() { return this.column; }
  
  /// <summary>
  /// Retorna o número de Linhas
  /// </summary>
  public int getLinesNumbers() { return this.line; }
  
  /// <summary>
  /// Método Construtor da classe Map
  /// </summary>
  public Map() { }
  
  /// <summary>
  /// Map e responsavel por definir o tamanho do mapa
  /// </summary>
  /// <param name="width">Parametro responsavel por definir a largura</param>
  /// <param name="height">Parametro responsavel por definir a altura</param>
  /// <param name="level">Parametro responsavel por definir o nível do jogo</param>
  /// </summary>
  public Map(int width, int height, int level)
  {
    this.level = level;
    this.line = width <= 30 ? width : 30;
    this.column = height <= 30 ? height : 30;
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

  /// <summary>
  /// PrintMap é responsavel por printar o tabuleiro na tela
  /// </summary>
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

  /// <summary>
  /// FindRobotPosition é responsavel por encontrar a posição do Robot no mapa
  /// </summary>
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

  /// <summary>
  /// GenerateFixed é responsavel por gerar a primeira instância da partida, fase 1.
  /// </summary>
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

  /// <summary>
  /// GenerateRandom é responsavel por gerar a aleatoriamente posições de jóias e obstáculos após a 2ª fase
  /// </summary>
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

  /// <summary>
  /// isDone é responsavel por verificar se ainda existe jóias no tabuleiro
  /// </summary>
  public bool isDone(){
    for(int c = 0; c < this.column; c++){
      for(int l = 0; l < this.line; l++){
        if(arrayObj[c,l] is Jewell){return false;}
      }
    }
    return true;
  }

  /// <summary>
  /// RemoveEnergyFromAdjacentRadioactiveCells é responsavel por verificar se ainda existe obstaculo radioativo ao redor do jogador
  /// </summary>
  public void RemoveEnergyFromAdjacentRadioactiveCells(Robot robot)
  {
    int robotLine = robot.getRobotLine();
    int robotColumn = robot.getRobotColumn();
    int captureRange = 1;

    if (IsValidCell(robotLine + captureRange, robotColumn) && 
    (this.getCell(robotLine + captureRange, robotColumn) is Obstacle obstacle3 && obstacle3.Symbol == " !! "))
    {
      robot.LevelEnergy--;
    }
    else if (IsValidCell(robotLine - captureRange, robotColumn) &&
      (this.getCell(robotLine - captureRange, robotColumn) is Obstacle obstacle2 && obstacle2.Symbol == " !! "))
    {
      robot.LevelEnergy--;
    }
    else if (IsValidCell(robotLine, robotColumn + captureRange) &&
      (this.getCell(robotLine, robotColumn + captureRange) is Obstacle obstacle1 && obstacle1.Symbol == " !! "))
    {
      robot.LevelEnergy--;
    }
    else if (IsValidCell(robotLine, robotColumn - captureRange) &&
      (this.getCell(robotLine, robotColumn - captureRange) is Obstacle obstacle && obstacle.Symbol == " !! "))
    {
      robot.LevelEnergy--;
    }
  }
  
  /// <summary>
  /// IsValidCell é responsavel por verificar se é uma posição válida
  /// </summary>
  private bool IsValidCell(int line, int column){
    int maxLine = this.getLinesNumbers();
    int maxColumn = this.getColumnsNumbers();

    return line >= 0 && line < maxLine && column >= 0 && column < maxColumn;
  }
}
