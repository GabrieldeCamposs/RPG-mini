public class Heroi : Personagem{
    public string nome;
    public int nivel;

    public Heroi(string nome, int nivel, float vida, float dano){
        this.nome = nome;
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