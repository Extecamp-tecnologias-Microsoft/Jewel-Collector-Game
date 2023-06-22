namespace JewellNS;
// JewelCollector é o método responsavel por iniciar a aplicacao gerando o mapa e definindo a posição das joias e chamando os metodos responsaveis pelo movimento do personagem 
public class JewelCollector
{

  /// <summary>
  /// Método que a inicia o jogo 
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
      }catch (RanOutOfEnergyException e){
        Console.WriteLine("Suas energias acabaram");
        Environment.Exit(0);
      }
    }
  }

  /// <summary>
  /// Método responsável pela jogabilidade
  /// </summary>
  /// <param name="Robot">Instância do Robot</param>
  /// <param name="map">Instância do Map</param>
  public static bool Play(Robot Robot, Map map)
  {
    do
    {
      Console.WriteLine(Robot.toString());
      Console.WriteLine("Enter the command: ");
      ConsoleKeyInfo command = Console.ReadKey(true);
      
      switch(command.Key.ToString()){
        case "W": try{map.FindRobotPosition(); Robot.moveToTop(map); map.PrintMap();}catch(OutOfMapException e){
          Console.WriteLine("\nA posicao quer você quer ir está fora do mapa...\n");
        }catch(OccupiedPositionException e){
          Console.WriteLine("\nA posicao quer você quer ir está ocupada...\n");
        }break;
        case "D": try{map.FindRobotPosition(); Robot.moveToRight(map); map.PrintMap();}catch(OutOfMapException e){
          Console.WriteLine("\nA posicao quer você quer ir está fora do mapa...\n");
        }catch(OccupiedPositionException e){
          Console.WriteLine("\nA posicao quer você quer ir está ocupada...\n");
        }break;
        case "A": try{map.FindRobotPosition(); Robot.moveToLeft(map); map.PrintMap();}catch(OutOfMapException e){
          Console.WriteLine("\nA posicao quer você quer ir está fora do mapa...\n");
        }catch(OccupiedPositionException e){
          Console.WriteLine("\nA posicao quer você quer ir está ocupada...\n");
        }break;
        case "S": try{map.FindRobotPosition(); Robot.moveToBottom(map); map.PrintMap();}catch(OutOfMapException e){
          Console.WriteLine("\nA posicao quer você quer ir está fora do mapa...\n");
        }catch(OccupiedPositionException e){
          Console.WriteLine("\nA posicao quer você quer ir está ocupada...\n");
        }break;
        case "G": try{map.FindRobotPosition(); Robot.captureItem(map); map.PrintMap();}catch(DontExistItemToCapture e){
          Console.WriteLine("\nNão Existe joia ou arvore ao redor\n");
        }break;
      }
    } while (!map.isDone());
    return true;
  }
}