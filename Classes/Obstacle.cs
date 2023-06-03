namespace JewellNS;
public class Obstacle
{
    private string name;
    private string symbol;
    private int levelEnergy;

    public Obstacle(string name, string symbol, int levelEnergy)
    {
        this.name = name;
        this.symbol = symbol;
        this.levelEnergy = levelEnergy;
    }
    public string getName() { return this.name; }
    public string getSymbol() { return this.symbol; }
    public int getLevelEnergy() { return this.levelEnergy; }

    public string toString() { return $"Obstaculo : {this.name}, Nível de energia: {this.levelEnergy}"; }
}