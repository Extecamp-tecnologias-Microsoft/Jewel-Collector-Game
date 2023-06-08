namespace JewellNS;
public class JewelCollector
{
  public static void Main(string[] args)
  {
    Map map = new Map(10, 10);
    Jewell jr = new Jewell { Name = "red", Symbol = " JR ", Point = 100, LevelEnergy = 0 };
    Jewell jg = new Jewell { Name = "green", Symbol = " JG ", Point = 50, LevelEnergy = 0 };
    Jewell jb = new Jewell { Name = "blue", Symbol = " JB ", Point = 10, LevelEnergy = 5 };
    Obstacle water = new Obstacle { Name = "water", Symbol = " ## ", LevelEnergy = 0 };
    Obstacle tree = new Obstacle { Name = "tree", Symbol = " $$ ", LevelEnergy = 3 };
    Robot Robot = new Robot { Name = "robot", Symbol = " ME ", Point = 0, LevelEnergy = 5 };
    map.setCell(0, 0, Robot);
    map.setCell(1, 9, jr);
    map.setCell(8, 8, jr);
    map.setCell(9, 1, jg);
    map.setCell(7, 6, jg);
    map.setCell(3, 4, jb);
    map.setCell(2, 1, jb);
    map.setCell(5, 0, water);
    map.setCell(5, 1, water);
    map.setCell(5, 2, water);
    map.setCell(5, 3, water);
    map.setCell(5, 4, water);
    map.setCell(5, 5, water);
    map.setCell(5, 6, water);
    map.setCell(5, 9, tree);
    map.setCell(3, 9, tree);
    map.setCell(8, 3, tree);
    map.setCell(2, 5, tree);
    map.setCell(1, 4, tree);
    map.PrintMap();
    map.FindRobotPosition();
    Play(Robot, tree, water, jr, jb, jg, map);
  }

  public static void Play(Robot Robot, Obstacle tree, Obstacle water, Jewell jr, Jewell jb, Jewell jg, Map map)
  {
    bool running = true;
    do
    {
      Console.WriteLine(Robot.toString());
      Console.WriteLine("Enter the command: ");
      string command = Console.ReadLine()!;

      if (command.Equals("quit"))
      {
        running = false;
      }
      else if (command.Equals("w"))
      {
        try
        {
          map.FindRobotPosition();
          Robot.moveToTop(map);
          map.PrintMap();
        }
        catch (Exception e)
        {
          Console.WriteLine(e);
        }
      }
      else if (command.Equals("a"))
      {
        try
        {
          map.FindRobotPosition();
          Robot.moveToLeft(map);
          map.PrintMap();
        }
        catch (Exception e)
        {
          Console.WriteLine(e);
        }
      }
      else if (command.Equals("s"))
      {
        try
        {
          map.FindRobotPosition();
          Robot.moveToBottom(map);
          map.PrintMap();
        }
        catch (Exception e)
        {
          Console.WriteLine(e);
        }
      }
      else if (command.Equals("d"))
      {
        try
        {
          map.FindRobotPosition();
          Robot.moveToRight(map);
          map.PrintMap();
        }
        catch (Exception e)
        {
          Console.WriteLine(e);
        }
      }
      else if (command.Equals("g"))
      {
        try
        {
          map.FindRobotPosition();
          Robot.captureItem(map);
          map.PrintMap();
        }
        catch
        {
          map.PrintMap();
          Console.WriteLine("Não existe joia ou arvore ao redor");
        }
      }
    } while (running);
  }
  public static void endPhase(int itemsOnMap){
    // Console.WriteLine("teste");
  }
  public static void nextPhase(){

  }
}