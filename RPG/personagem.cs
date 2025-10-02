public abstract class Personagem{
    public float vida;
    public float dano;

    public abstract void atacar(Personagem alvo);

    public abstract void receberDano(float quantidade);
}