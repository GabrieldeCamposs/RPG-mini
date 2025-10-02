public class Inimigo : Personagem{
    public string tipo;
    public int nivel;

    public Inimigo(string tipo, int nivel, float vida, float dano){
        this.tipo = tipo;
        this.nivel = nivel;
        this.vida = vida;
        this.dano = dano;
    }

    public override void atacar(Personagem alvo){
        alvo.receberDano(this.dano);
    }

    public override void receberDano(float quantidade){
        this.vida -= quantidade;
        if(this.vida < 0){
            this.vida = 0;
        }
    }
}