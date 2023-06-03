namespace JewellNS;

public class Map
{
    private Cell[,] arrayObj;
    private int linha;
    private int coluna;

    public int getNumberOfColunas() { return this.coluna; }
    public int getNumberOfLinhas() { return this.linha; }
    public Map() { }
    public Map(int width, int height)
    {
        this.linha = width;
        this.coluna = height;
        arrayObj = new Cell[width, height];
    }
    public Cell getCell(int linha, int coluna)
    {
        return arrayObj[linha, coluna];
    }
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
    public void removeCell(int i, int j)
    {
        arrayObj[i, j] = null;
    }
    public void PrintMap()
    {
        Console.Clear();

        for (int i = 0; i < linha; i++)
        {
            for (int j = 0; j < coluna; j++)
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
        for (int i = 0; i < linha; i++)
        {
            for (int j = 0; j < coluna; j++)
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
