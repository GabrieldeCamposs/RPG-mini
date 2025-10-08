using System;

public class GameController
{
    private Heroi heroi;

    public void Iniciar()
    {
        Console.WriteLine("Bem-vindo ao RPG!");
        Console.Write("Digite o nome do seu herói: ");
        string nome = Console.ReadLine();
        heroi = new Heroi(nome, 1, 100, 10);

        bool jogando = true;
        while (jogando)
        {
            Console.WriteLine("\nMenu Principal:");
            Console.WriteLine("1 - Batalha");
            Console.WriteLine("2 - Loja");
            Console.WriteLine("3 - Inventário");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");
            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    IniciarBatalha();
                    break;
                case "2":
                    AbrirLoja();
                    break;
                case "3":
                    MostrarInventario();
                    break;
                case "0":
                    jogando = false;
                    Console.WriteLine("Saindo do jogo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }

    private void IniciarBatalha()
    {
        Console.WriteLine("Você entrou em uma batalha!");
        Inimigo inimigo = new Inimigo("Goblin", 1, 50, 5);

        while (heroi.vida > 0 && inimigo.vida > 0)
        {
            heroi.atacar(inimigo);
            Console.WriteLine($"Herói atacou! Vida do inimigo: {inimigo.vida}");

            if (inimigo.vida <= 0)
            {
                Console.WriteLine("Você venceu a batalha!");
                break;
            }

            inimigo.atacar(heroi);
            Console.WriteLine($"Inimigo atacou! Vida do herói: {heroi.vida}");

            if (heroi.vida <= 0)
            {
                Console.WriteLine("Você foi derrotado!");
                break;
            }
        }
    }

    private void AbrirLoja()
    {
        Loja loja = new Loja(); 
        loja.Entrar(heroi);
    }

    private void MostrarInventario()
    {
        Inventario inventario = new Inventario();
        inventario.Entrar(heroi);
    }
}