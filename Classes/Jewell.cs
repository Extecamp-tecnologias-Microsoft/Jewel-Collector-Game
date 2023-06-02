namespace JewellNS;
public class Jewell
{
    private string name;
    private string color;
    private int point;
    private int levelEnergy;

    public Jewell(string color, string name, int point, int levelEnergy)
    {
        this.name = name;
        this.color = color;
        this.point = point;
        this.levelEnergy = levelEnergy;
    }
    public string getName() { return this.name; }
    public string getColor() { return this.color; }
    public int getPoint() { return this.point; }
    public int getLevelEnergy() { return this.levelEnergy; }

    public string toString()
    {
        return $"Cor: {this.color}, Point: {this.point}, Name: {this.name}, Nível de Energia: {this.levelEnergy}";
    }
}
