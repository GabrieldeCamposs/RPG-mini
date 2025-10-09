using System;

public class Loja
{
    public void Entrar(Heroi heroi)
    {
        bool comprando = true;

        while (comprando)
        {
            Console.WriteLine("\n=== LOJA ===");
            Console.WriteLine($"Ouro atual: {heroi.ouro}");
            Console.WriteLine("Escolha o que deseja comprar:");
            Console.WriteLine("1 - Poção de Vida (20 de ouro)");
            Console.WriteLine("2 - Espada de Ferro (50 de ouro)");
            Console.WriteLine("3 - Armadura de Couro (40 de ouro)");
            Console.WriteLine("0 - Sair da loja");
            Console.Write("Opção: ");
            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    ComprarItem(heroi, "Poção de Vida", 20);
                    break;
                case "2":
                    ComprarEspadaDeFerro(heroi);
                    break;
                case "3":
                    ComprarArmaduraDeCouro(heroi);
                    break;
                case "0":
                    Console.WriteLine("Saindo da loja...");
                    comprando = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }

    private void ComprarItem(Heroi heroi, string item, int preco)
    {
        if (heroi.ouro >= preco)
        {
            heroi.ouro -= preco;
            heroi.AdicionarItem(item);
            Console.WriteLine($"Você comprou: {item} por {preco} de ouro!");
        }
        else
        {
            Console.WriteLine("Ouro insuficiente!");
        }
    }

    private void ComprarEspadaDeFerro(Heroi heroi)
    {
        string item = "Espada de Ferro";
        int preco = 50;

        if (heroi.PossuiItem(item))
        {
            Console.WriteLine("Você já possui uma Espada de Ferro!");
            return;
        }

        if (heroi.ouro < preco)
        {
            Console.WriteLine("Ouro insuficiente!");
            return;
        }

        heroi.ouro -= preco;
        heroi.AdicionarItem(item);
        heroi.dano += 10;
        heroi.espada = item;
        Console.WriteLine($"Você comprou uma {item}! Seu dano aumentou em 50!");
    }

    private void ComprarArmaduraDeCouro(Heroi heroi)
    {
        string item = "Armadura de Couro";
        int preco = 40;

        if (heroi.PossuiItem(item))
        {
            Console.WriteLine("Você já possui uma Armadura de Couro!");
            return;
        }

        if (heroi.ouro < preco)
        {
            Console.WriteLine("Ouro insuficiente!");
            return;
        }

        heroi.ouro -= preco;
        heroi.AdicionarItem(item);
        heroi.vida += 50;
        heroi.armadura = item;
        Console.WriteLine($"Você comprou uma {item}! Sua vida aumentou em 50!");
    }
}
