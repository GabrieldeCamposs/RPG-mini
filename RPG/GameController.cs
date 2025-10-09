using System;

public class GameController
{
    private Heroi heroi;
    public Loja loja = new Loja(); 
    public int nivelInimigo = 1;
    public Inventario inventario = new Inventario();

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
        Console.WriteLine($"Escolha o nível do inimigo (1 até {nivelInimigo}):");
        int nivelEscolhido = 1;
        while (true)
        {
            Console.Write("Nível: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out nivelEscolhido) && nivelEscolhido >= 1 && nivelEscolhido <= nivelInimigo)
            {
                break;
            }
            Console.WriteLine("Nível inválido! Tente novamente.");
        }

        Inimigo inimigo = new Inimigo("Goblin", nivelEscolhido, 50 + 10 * nivelEscolhido, 5 + 2 * nivelEscolhido);

        while (heroi.vida > 0 && inimigo.vida > 0)
        {
            Console.WriteLine($"\nSua vida: {heroi.vida} | Vida do inimigo: {inimigo.vida}");
            Console.WriteLine("Seu turno! Escolha uma ação:");
            Console.WriteLine("1 - Atacar");
            Console.WriteLine("2 - Usar item (não implementado)");
            Console.WriteLine("3 - Fugir");
            Console.Write("Opção: ");
            string escolha = Console.ReadLine();

            if (escolha == "1")
            {
                heroi.atacar(inimigo);
                Console.WriteLine($"Você atacou! Vida do inimigo: {inimigo.vida}");
            }
            else if (escolha == "2")
            {
                Console.WriteLine("Usar item ainda não está implementado.");
            }
            else if (escolha == "3")
            {
                Console.WriteLine("Você fugiu da batalha!");
                inimigo = null; // remove referência ao inimigo gerado
                heroi.vida = 100 + 10 * heroi.nivel; // reseta a vida do herói
                Console.WriteLine($"Sua vida foi restaurada para {heroi.vida}!");
                break;
            }
            else
            {
                Console.WriteLine("Opção inválida! Você perdeu o turno.");
            }

            if (inimigo.vida <= 0)
            {
                Console.WriteLine("Você venceu a batalha!");
                int ouroGanho = 20 * nivelEscolhido;
                heroi.ouro += ouroGanho;
                Console.WriteLine($"Você ganhou {ouroGanho} de ouro!");

                // Só ganha nível se derrotar o inimigo de maior nível possível
                if (nivelEscolhido == nivelInimigo)
                {
                    heroi.nivel += 1;
                    nivelInimigo += 1;
                    Console.WriteLine($"Você subiu para o nível {heroi.nivel}!");
                    Console.WriteLine("O nível máximo dos inimigos aumentou!");
                }

                // Resetar vida do herói após vitória
                heroi.vida = 100 + 10 * heroi.nivel;
                Console.WriteLine($"Sua vida foi restaurada para {heroi.vida}!");
                break;
            }

            // Turno do inimigo
            inimigo.atacar(heroi);
            Console.WriteLine($"O inimigo atacou! Sua vida: {heroi.vida}");

            if (heroi.vida <= 0)
            {
                Console.WriteLine("Você foi derrotado!");
                break;
            }
        }
    }

    private void AbrirLoja()
    {
        loja.Entrar(heroi);
    }

    private void MostrarInventario()
    {
        inventario.Entrar();
    }
}