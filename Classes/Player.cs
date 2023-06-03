namespace JewellNS;
public class Robot : Cell
{
    private Cell[] bagItems = new Cell[] { };
    private int bagValue = 0;
    private int RobotLine;
    private int RobotColumn;
    public int getRobotLine() { return this.RobotLine; }
    public int getColumnRobot() { return this.RobotColumn; }
    public void setRobotLine(int linha) { this.RobotLine = linha; }
    public void setColumnRobot(int coluna) { this.RobotColumn = coluna; }

    public string toString()
    {
        return $"Bag total items: {this.bagItems.Length} | Bag total value: {this.bagValue} | Energy: {this.LevelEnergy}";
    }

    public void moveToLeft(Map map)
    {
        if (this.getColumnRobot() > 0)
        {
            if (map.getCell(getRobotLine(), getColumnRobot() - 1) is not Jewell or Obstacle)
            {
                LevelEnergy--;
                map.removeCell(getRobotLine(), getColumnRobot());
                map.setCell(getRobotLine(), getColumnRobot() - 1, this);
                verifyEnergyLevel();
            }
        }
    }
    public void moveToRight(Map map)
    {
        if (this.getColumnRobot() <= map.getNumberOfColunas())
        {
            if (map.getCell(getRobotLine(), getColumnRobot() + 1) is not Jewell or Obstacle)
            {
                LevelEnergy--;
                map.removeCell(getRobotLine(), getColumnRobot());
                map.setCell(getRobotLine(), getColumnRobot() + 1, this);
                verifyEnergyLevel();
            }
        }
    }
    public void moveToTop(Map map)
    {
        if (this.getRobotLine() > 0)
        {
            if (map.getCell(getRobotLine() - 1, getColumnRobot()) is not Jewell or Obstacle)
            {
                LevelEnergy--;
                map.removeCell(getRobotLine(), getColumnRobot());
                map.setCell(getRobotLine() - 1, getColumnRobot(), this);
                verifyEnergyLevel();
            }
        }
    }
    public void moveToBottom(Map map)
    {
        if (this.getRobotLine() <= map.getNumberOfLinhas())
        {
            if (map.getCell(getRobotLine() + 1, getColumnRobot()) is not Jewell or Obstacle)
            {
                LevelEnergy--;
                map.removeCell(getRobotLine(), getColumnRobot());
                map.setCell(getRobotLine() + 1, getColumnRobot(), this);
                verifyEnergyLevel();
            }
        }
    }

    public void captureItem(Map map)
    {
        map.FindRobotPosition();
        int linhaDoJogador = getRobotLine();
        int colunaDoJogador = getColumnRobot();
        int captureRange = 1;

        if (map.getCell(linhaDoJogador + captureRange, colunaDoJogador) is Jewell or Obstacle)
        {
            updateBag(map.getCell(linhaDoJogador + captureRange, colunaDoJogador));
            map.removeCell(linhaDoJogador + captureRange, colunaDoJogador);
        }
        else if (map.getCell(linhaDoJogador - captureRange, colunaDoJogador) is Jewell or Obstacle)
        {
            updateBag(map.getCell(linhaDoJogador - captureRange, colunaDoJogador));
            map.removeCell(linhaDoJogador - captureRange, colunaDoJogador);
        }
        else if (map.getCell(linhaDoJogador, colunaDoJogador + captureRange) is Jewell or Obstacle)
        {
            updateBag(map.getCell(linhaDoJogador, colunaDoJogador + captureRange));
            map.removeCell(linhaDoJogador, colunaDoJogador + captureRange);
        }
        else if (map.getCell(linhaDoJogador, colunaDoJogador - captureRange) is Jewell or Obstacle)
        {
            updateBag(map.getCell(linhaDoJogador, colunaDoJogador - captureRange));
            map.removeCell(linhaDoJogador, colunaDoJogador - captureRange);
        }
    }

    private void updateBag(Cell objeto)
    {
        if (objeto is Jewell jewell)
        {
            this.bagValue = this.bagValue + jewell.Point;
            Array.Resize(ref bagItems, bagItems.Length + 1);
            bagItems[bagItems.Length - 1] = jewell;
        }
    }
    private void verifyEnergyLevel()
    {
        Console.Clear();
        if (LevelEnergy <= 0)
        {
            Console.WriteLine("Suas energias acabaram");
            Environment.Exit(0);
        }
    }
}