namespace JewellNS;
public class Player
{
    private int bagValue = 0;
    private int energy = 5;
    private Object[] bagItems = new Object[] { };
    private string name;
    private int playerLine;
    private int playerColumn;
    public Player(string name) { this.name = name; }
    public string getName() { return this.name; }
    public int getEnergy() { return this.energy; }
    public int getPlayerLine() { return this.playerLine; }
    public int getColumnPlayer() { return this.playerColumn; }
    public void setplayerLine(int linha) { this.playerLine = linha; }
    public void setplayerColumn(int coluna) { this.playerColumn = coluna; }

    public string toString() { return $"Bag total items: {this.bagItems.Length} | Bag total value: {this.bagValue} | Energy: {this.energy}"; }
    public void verifyEnergyLevel()
    {
        Console.Clear();
        if (getEnergy() <= 0)
        {
            Console.WriteLine("Suas energias acabaram");
            Environment.Exit(0);
        }
    }
    public void moveToLeft(Map map)
    {
        if (this.getColumnPlayer() > 0)
        {
            if (map.getObject(getPlayerLine(), getColumnPlayer() - 1) is not Jewell or Obstacle)
            {
                energy--;
                map.removeCell(getPlayerLine(), getColumnPlayer());
                map.setCell(getPlayerLine(), getColumnPlayer() - 1, this);
                verifyEnergyLevel();
            }
        }
    }
    public void moveToRight(Map map)
    {
        if (this.getColumnPlayer() <= map.getNumberOfColunas())
        {
            if (map.getObject(getPlayerLine(), getColumnPlayer() + 1) is not Jewell or Obstacle)
            {
                energy--;
                map.removeCell(getPlayerLine(), getColumnPlayer());
                map.setCell(getPlayerLine(), getColumnPlayer() + 1, this);
                verifyEnergyLevel();
            }
        }
    }
    public void moveToTop(Map map)
    {
        if (this.getPlayerLine() > 0)
        {
            if (map.getObject(getPlayerLine() - 1, getColumnPlayer()) is not Jewell or Obstacle)
            {
                energy--;
                map.removeCell(getPlayerLine(), getColumnPlayer());
                map.setCell(getPlayerLine() - 1, getColumnPlayer(), this);
                verifyEnergyLevel();
            }
        }
    }
    public void moveToBottom(Map map)
    {
        if (this.getPlayerLine() <= map.getNumberOfLinhas())
        {
            if (map.getObject(getPlayerLine() + 1, getColumnPlayer()) is not Jewell or Obstacle)
            {
                energy--;
                map.removeCell(getPlayerLine(), getColumnPlayer());
                map.setCell(getPlayerLine() + 1, getColumnPlayer(), this);
                verifyEnergyLevel();
            }
        }
    }

    public void captureItem(Map map)
    {
        map.FindPlayerPosition();
        int linhaDoJogador = getPlayerLine();
        int colunaDoJogador = getColumnPlayer();
        int captureRange = 1;

        if (map.getObject(linhaDoJogador + captureRange, colunaDoJogador) is Jewell or Obstacle)
        {
            updateEnergy(map.getObject(linhaDoJogador + captureRange, colunaDoJogador));
            updateBag(map.getObject(linhaDoJogador + captureRange, colunaDoJogador));
            map.removeCell(linhaDoJogador + captureRange, colunaDoJogador);
        }
        else if (map.getObject(linhaDoJogador - captureRange, colunaDoJogador) is Jewell or Obstacle)
        {
            updateEnergy(map.getObject(linhaDoJogador - captureRange, colunaDoJogador));
            updateBag(map.getObject(linhaDoJogador - captureRange, colunaDoJogador));
            map.removeCell(linhaDoJogador - captureRange, colunaDoJogador);
        }
        else if (map.getObject(linhaDoJogador, colunaDoJogador + captureRange) is Jewell or Obstacle)
        {
            updateEnergy(map.getObject(linhaDoJogador, colunaDoJogador + captureRange));
            updateBag(map.getObject(linhaDoJogador, colunaDoJogador + captureRange));
            map.removeCell(linhaDoJogador, colunaDoJogador + captureRange);
        }
        else if (map.getObject(linhaDoJogador, colunaDoJogador - captureRange) is Jewell or Obstacle)
        {
            updateEnergy(map.getObject(linhaDoJogador, colunaDoJogador - captureRange));
            updateBag(map.getObject(linhaDoJogador, colunaDoJogador - captureRange));
            map.removeCell(linhaDoJogador, colunaDoJogador - captureRange);
        }
    }

    private void updateBag(Object objeto)
    {
        if (objeto is Jewell jewell)
        {
            this.bagValue = this.bagValue + jewell.getPoint();
            Array.Resize(ref bagItems, bagItems.Length + 1);
            bagItems[bagItems.Length - 1] = jewell;
        }
    }

    private void updateEnergy(Object objeto)
    {
        if (objeto is Jewell jewell)
        {
            energy = energy + jewell.getLevelEnergy();
        }
        else if (objeto is Obstacle Obstacle)
        {
            energy = energy + Obstacle.getLevelEnergy();
        }
    }
}