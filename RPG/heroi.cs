using System;
using System.Collections.Generic;

public class Heroi : Personagem
{
    public string nome;
    public int nivel;
    public int ouro = 0;
    public List<string> inventario = new List<string>();
    public string espada;
    public string armadura;

    public Heroi(string nome, int nivel, float vida, float dano)
    {
        this.nome = nome;
        this.nivel = nivel;
        this.vida = vida;
        this.dano = dano;
    }

    public override void atacar(Personagem alvo)
    {
        alvo.receberDano(this.dano);
    }

    public override void receberDano(float quantidade)
    {
        this.vida -= quantidade;
        if (this.vida < 0)
        {
            this.vida = 0;
        }
    }
    public bool PossuiItem(string item)
    {
        return inventario.Contains(item);
    }
    public bool AdicionarItem(string item)
    {
        if (!PossuiItem(item))
        {
            inventario.Add(item);
            return true;
        }
        return false;
    }

}