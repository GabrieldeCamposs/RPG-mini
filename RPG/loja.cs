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
                    ComprarItem(heroi, "Espada de Ferro", 50);
                    break;
                case "3":
                    ComprarItem(heroi, "Armadura de Couro", 40);
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
            heroi.inventario.Add(item);
            Console.WriteLine($"Você comprou: {item} por {preco} de ouro!");
        }
        else
        {
            Console.WriteLine("Ouro insuficiente!");
        }
    }
}
