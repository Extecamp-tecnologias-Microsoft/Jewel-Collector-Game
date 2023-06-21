namespace JewellNS;
// JewelCollector é o método responsavel por iniciar a aplicacao gerando o mapa e definindo a posição das joias e chamando os metodos responsaveis pelo movimento do personagem 
public class JewelCollector
{

  /// <summary>
  /// classe que a inicia o jogo 
  /// </summary>
  /// <param name="args"></param>
  public static void Main(string[] args)
  {
    int l = 10;
    int c = 10;
    int level = 1;

    while(true){
      Map map = new Map(l, c, level);
      Console.WriteLine($"Level: {level}");

      try{
        bool result = Play(map.robot, map);
        if(result){
          l++;
          c++;
          level++;
        }else{break;}
      }catch (Exception e){
        Console.WriteLine("Suas energias acabaram");
        Environment.Exit(0);
      }
    }
  }

  public static bool Play(Robot Robot, Map map)
  {
    do
    {
      Console.WriteLine(Robot.toString());
      Console.WriteLine("Enter the command: ");
      ConsoleKeyInfo command = Console.ReadKey(true);
      
      switch(command.Key.ToString()){
        case "W": map.FindRobotPosition(); Robot.moveToTop(map); map.PrintMap(); break;
        case "D": map.FindRobotPosition(); Robot.moveToRight(map); map.PrintMap(); break;
        case "A": map.FindRobotPosition(); Robot.moveToLeft(map); map.PrintMap(); break;
        case "S": map.FindRobotPosition(); Robot.moveToBottom(map); map.PrintMap(); break;
        case "G": try {map.FindRobotPosition(); Robot.captureItem(map); map.PrintMap();}catch{
          map.PrintMap();
          Console.WriteLine("Não existe joia ou arvore ao redor\n");
        } break;
      }
    } while (!map.isDone());
    return true;
  }
}