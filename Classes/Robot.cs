namespace JewellNS;
public class Robot : Cell
{
    private int bagValue = 0;
    private Cell[] bagItems = new Cell[] { };
    private int RobotLine;
    private int RobotColumn;
  // Metodo usado para retornar a linha do robo
    public int getRobotLine() { return this.RobotLine; }  // Metodo usado para retornar a  coluna do robo
    public int getRobotColumn() { return this.RobotColumn; }  // Metodo usado para setar a linha do robo 
    public void setRobotLine(int linha) { this.RobotLine = linha; } // Metodo usado para setar a coluna do robo 
    public void setRobotColumn(int coluna) { this.RobotColumn = coluna; }

    public string toString() { return $"Bag total items: {this.bagItems.Length} | Bag total value: {this.bagValue} | Energy: {this.LevelEnergy}"; }
  // metodo responsável por verigicar se o robo ainda tem energia 
    public void verifyEnergyLevel()
    {
        Console.Clear();
        if (LevelEnergy <= 0)
        {
            Console.WriteLine("Suas energias acabaram");
            Environment.Exit(0);
        }
    }
    public void moveToLeft(Map map)
    {
        if (this.getRobotColumn() > 0)
        {
            if (map.getCell(getRobotLine(), getRobotColumn() - 1) is not Jewell or Obstacle)
            {
                LevelEnergy--;
                map.removeCell(getRobotLine(), getRobotColumn());
                map.setCell(getRobotLine(), getRobotColumn() - 1, this);
                verifyEnergyLevel();
            }
        }
    }
    public void moveToRight(Map map)
    {
        if (this.getRobotColumn() <= map.getNumberOfColunas())
        {
            if (map.getCell(getRobotLine(), getRobotColumn() + 1) is not Jewell or Obstacle)
            {
                LevelEnergy--;
                map.removeCell(getRobotLine(), getRobotColumn());
                map.setCell(getRobotLine(), getRobotColumn() + 1, this);
                verifyEnergyLevel();
            }
        }
    }
    public void moveToTop(Map map)
    {
        if (this.getRobotLine() > 0)
        {
            if (map.getCell(getRobotLine() - 1, getRobotColumn()) is not Jewell or Obstacle)
            {
                LevelEnergy--;
                map.removeCell(getRobotLine(), getRobotColumn());
                map.setCell(getRobotLine() - 1, getRobotColumn(), this);
                verifyEnergyLevel();
            }
        }
    }
    public void moveToBottom(Map map)
    {
        if (this.getRobotLine() <= map.getNumberOfLinhas())
        {
            if (map.getCell(getRobotLine() + 1, getRobotColumn()) is not Jewell or Obstacle)
            {
                LevelEnergy--;
                map.removeCell(getRobotLine(), getRobotColumn());
                map.setCell(getRobotLine() + 1, getRobotColumn(), this);
                verifyEnergyLevel();
            }
        }
    }

    public void captureItem(Map map)
    {
        int linhaDoJogador = getRobotLine();
        int colunaDoJogador = getRobotColumn();
        int captureRange = 1;

        if ((map.getCell(linhaDoJogador + captureRange, colunaDoJogador) is Jewell) ||
            (map.getCell(linhaDoJogador + captureRange, colunaDoJogador) is Obstacle obstacle3) && obstacle3.Symbol == " $$ ")
        {
            updateEnergy(map.getCell(linhaDoJogador + captureRange, colunaDoJogador));
            updateBag(map.getCell(linhaDoJogador + captureRange, colunaDoJogador));
            map.removeCell(linhaDoJogador + captureRange, colunaDoJogador);
        }
        else if ((map.getCell(linhaDoJogador - captureRange, colunaDoJogador) is Jewell) ||
        (map.getCell(linhaDoJogador - captureRange, colunaDoJogador) is Obstacle obstacle2) && obstacle2.Symbol == " $$ ")
        {
            updateEnergy(map.getCell(linhaDoJogador - captureRange, colunaDoJogador));
            updateBag(map.getCell(linhaDoJogador - captureRange, colunaDoJogador));
            map.removeCell(linhaDoJogador - captureRange, colunaDoJogador);
        }
        else if ((map.getCell(linhaDoJogador, colunaDoJogador + captureRange) is Jewell) ||
        (map.getCell(linhaDoJogador, colunaDoJogador + captureRange) is Obstacle obstacle1) && obstacle1.Symbol == " $$ ")
        {
            updateEnergy(map.getCell(linhaDoJogador, colunaDoJogador + captureRange));
            updateBag(map.getCell(linhaDoJogador, colunaDoJogador + captureRange));
            map.removeCell(linhaDoJogador, colunaDoJogador + captureRange);
        }
        else if ((map.getCell(linhaDoJogador, colunaDoJogador - captureRange) is Jewell) ||
        (map.getCell(linhaDoJogador, colunaDoJogador - captureRange) is Obstacle obstacle) && obstacle.Symbol == " $$ ")
        {
            updateEnergy(map.getCell(linhaDoJogador, colunaDoJogador - captureRange));
            updateBag(map.getCell(linhaDoJogador, colunaDoJogador - captureRange));
            map.removeCell(linhaDoJogador, colunaDoJogador - captureRange);
        }
    }

    private void updateBag(Object objeto)
    {
        if (objeto is Jewell jewell)
        {
            this.bagValue = this.bagValue + jewell.Point;
            Array.Resize(ref bagItems, bagItems.Length + 1);
            bagItems[bagItems.Length - 1] = jewell;
        }
    }

    private void updateEnergy(Cell objeto)
    {
        LevelEnergy = LevelEnergy + objeto.LevelEnergy;
    }
}