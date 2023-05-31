namespace JewellNS;
public class Player
{
    private int bag = 5;
    public string Name { get; set; }
    private int linhaPlayer;
    private int colunaPlayer;
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
        return $"Name {this.Name}";
    }

    public void moveToLeft(Map map)
    {
        if (this.getColunaPlayer() > 0)
        {
            map.removeCell(getLinhaPlayer(), getColunaPlayer());
            map.setCell(getLinhaPlayer(), getColunaPlayer() - 1, this);
        }
    }
    public void moveToRight(Map map)
    {
        if (this.getColunaPlayer() < map.getNumberOfColunas())
        {
            map.removeCell(getLinhaPlayer(), getColunaPlayer());
            map.setCell(getLinhaPlayer(), getColunaPlayer() + 1, this);
        }
    }
    public void moveToTop(Map map)
    {
        if (this.getLinhaPlayer() > 0)
        {
            map.removeCell(getLinhaPlayer(), getColunaPlayer());
            map.setCell(getLinhaPlayer() - 1, getColunaPlayer(), this);
        }
    }
    public void moveToBottom(Map map)
    {
        if (this.getLinhaPlayer() < map.getNumberOfLinhas())
        {
            map.removeCell(getLinhaPlayer(), getColunaPlayer());
            map.setCell(getLinhaPlayer() + 1, getColunaPlayer(), this);
        }
    }
    public Boolean existsJewellOrObstacle(int proximaCasa)
    {
        // TO DO
        return false;
    }
}