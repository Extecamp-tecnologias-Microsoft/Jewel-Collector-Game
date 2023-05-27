public class JewelCollector {

public class Jewel
{
private string positionJewel; //Nome da classe
private int red = 100;
private int green = 50;
private int blue = 10;
public string PositionJewel { get => positionJewel; set => positionJewel = value; } //Propriedade da classe
public int Red { get => red; set => red = value; } //Propriedade da classe
public int Green { get => green; set => green = value; } //Propriedade da classe

public int Blue { get => blue; set => blue = value; } //Propriedade da classe
}

public class Obstacle //Nome da classe
{
    private int positionObstacle; //Atributo da classe
    private string water; //Atributo da classe

    private string tree; //Atributo da classe
    public string Water { get => water; set => water = value; } //Propriedade da classe
    public string Tree { get => tree; set => tree = value; } //Propriedade da classe
 }

  public class Map //Nome da classe
{
    private int positionObstacle; //Atributo da classe
    private string water; //Atributo da classe

    private string tree; //Atributo da classe
    public string Water { get => water; set => water = value; } //Propriedade da classe
    public string Tree { get => tree; set => tree = value; } //Propriedade da classe
 }

public static void Main() {
  
      bool running = true;
        Console.WriteLine("Seja bem vindo :D");
  
      do {
          Console.WriteLine("Digite algum comando :)");
          string command = Console.ReadLine();
  
          if (command.Equals("quit") || command.Equals("exit")) {
              running = false;
              Console.WriteLine("Desligando o software :c");
          } else if (command.Equals("w")) {
              
          } else if (command.Equals("a")) {
              
          } else if (command.Equals("s")) {
            
          } else if (command.Equals("d")) {
          
          } else if (command.Equals("g")) {
              
          }
      } while (running);
  }
}