namespace JewellNS;
public class Player
{
    private int bagValue = 0;
    private int energy = 5;
    private Object[] bagItems = new Object[] { };
    private string name;
    private int linhaPlayer;
    private int colunaPlayer;
    public Player(string name)
    {
        this.name = name;
    }
    public string getName() { return this.name; }
    public int getEnergy() { return this.energy; }
    public int getLinhaPlayer() { return this.linhaPlayer; }
    public int getColunaPlayer() { return this.colunaPlayer; }
    public void setLinhaPlayer(int linha)
    {
        this.linhaPlayer = linha;
    }
    public void setColunaPlayer(int coluna)
    {
        this.colunaPlayer = coluna;
    }

    public string toString()
    {
        return $"Bag total items: {this.bagItems.Length} | Bag total value: {this.bagValue} | Energy: {this.energy}";
    }
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
        if (this.getColunaPlayer() > 0)
        {
            if (existsJewellOrObstacle(getLinhaPlayer(), getColunaPlayer() - 1, map) == false)
            {
                energy--;
                map.removeCell(getLinhaPlayer(), getColunaPlayer());
                map.setCell(getLinhaPlayer(), getColunaPlayer() - 1, this);
                verifyEnergyLevel();
            }
        }
    }
    public void moveToRight(Map map)
    {
        if (this.getColunaPlayer() < map.getNumberOfColunas())
        {
            if (existsJewellOrObstacle(getLinhaPlayer(), getColunaPlayer() + 1, map) == false)
            {
                energy--;
                map.removeCell(getLinhaPlayer(), getColunaPlayer());
                map.setCell(getLinhaPlayer(), getColunaPlayer() + 1, this);
                verifyEnergyLevel();
            }
        }
    }
    public void moveToTop(Map map)
    {
        if (this.getLinhaPlayer() > 0)
        {
            if (existsJewellOrObstacle(getLinhaPlayer() - 1, getColunaPlayer(), map) == false)
            {
                energy--;
                map.removeCell(getLinhaPlayer(), getColunaPlayer());
                map.setCell(getLinhaPlayer() - 1, getColunaPlayer(), this);
                verifyEnergyLevel();
            }
        }
    }
    public void moveToBottom(Map map)
    {
        if (this.getLinhaPlayer() < map.getNumberOfLinhas())
        {
            if (existsJewellOrObstacle(getLinhaPlayer() + 1, getColunaPlayer(), map) == false)
            {
                energy--;
                map.removeCell(getLinhaPlayer(), getColunaPlayer());
                map.setCell(getLinhaPlayer() + 1, getColunaPlayer(), this);
                verifyEnergyLevel();
            }
        }
    }
    public bool existsJewellOrObstacle(int proximaLinha, int proximaColuna, Map map)
    {
        Object posicao = map.getObject(proximaLinha, proximaColuna);
        if (posicao is Jewell jewell || posicao is Obstacle obstacle)
        {
            return true;
        }
        return false;
    }

    public void captureItem(Map map)
    {
        map.FindPlayerPosition();
        int linhaDoJogador = getLinhaPlayer();
        int colunaDoJogador = getColunaPlayer();

        if (map.getObject(linhaDoJogador + 1, colunaDoJogador) is Jewell or Obstacle)
        {
            updateEnergy(map.getObject(linhaDoJogador + 1, colunaDoJogador));
            updateBag(map.getObject(linhaDoJogador + 1, colunaDoJogador));
            map.removeCell(linhaDoJogador + 1, colunaDoJogador);
        }
        else if (map.getObject(linhaDoJogador - 1, colunaDoJogador) is Jewell or Obstacle)
        {
            updateEnergy(map.getObject(linhaDoJogador - 1, colunaDoJogador));
            updateBag(map.getObject(linhaDoJogador - 1, colunaDoJogador));
            map.removeCell(linhaDoJogador - 1, colunaDoJogador);
        }
        else if (map.getObject(linhaDoJogador, colunaDoJogador + 1) is Jewell or Obstacle)
        {
            updateEnergy(map.getObject(linhaDoJogador, colunaDoJogador + 1));
            updateBag(map.getObject(linhaDoJogador, colunaDoJogador + 1));
            map.removeCell(linhaDoJogador, colunaDoJogador + 1);
        }
        else if (map.getObject(linhaDoJogador, colunaDoJogador - 1) is Jewell or Obstacle)
        {
            updateEnergy(map.getObject(linhaDoJogador, colunaDoJogador - 1));
            updateBag(map.getObject(linhaDoJogador, colunaDoJogador - 1));
            map.removeCell(linhaDoJogador, colunaDoJogador - 1);
        }
    }

    public void updateBag(Object objeto)
    {
        if (objeto is Jewell jewell)
        {
            this.bagValue = this.bagValue + jewell.getPoint();
            Array.Resize(ref bagItems, bagItems.Length + 1);
            bagItems[bagItems.Length - 1] = jewell;
        }
    }

    public void updateEnergy(Object objeto)
    {
        if (objeto is Jewell jewell)
            {
                Console.WriteLine(jewell.getLevelEnergy());
                energy = energy + jewell.getLevelEnergy();
            }
        else if(objeto is Obstacle Obstacle){
                Console.WriteLine(Obstacle.getLevelEnergy());
                energy = energy + Obstacle.getLevelEnergy();
        }
    }
    
}