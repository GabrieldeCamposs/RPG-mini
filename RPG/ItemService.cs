using System;

public class ItemService
{
    public void UsarItem(Heroi heroi)
    {
        if (heroi.inventario.Count == 0)
        {
            Console.WriteLine("Seu inventário está vazio!");
            return;
        }

        Console.WriteLine("\n=== USAR ITEM ===");
        for (int i = 0; i < heroi.inventario.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {heroi.inventario[i]}");
        }

        Console.Write("Escolha o item que deseja usar: ");
        if (int.TryParse(Console.ReadLine(), out int indice) && indice >= 1 && indice <= heroi.inventario.Count)
        {
            string item = heroi.inventario[indice - 1];
            Console.WriteLine($"Você usou {item}!");

            AplicarEfeito(heroi, item);

            // Remove o item após usar
            heroi.inventario.RemoveAt(indice - 1);
        }
        else
        {
            Console.WriteLine("Escolha inválida!");
        }
    }

    private void AplicarEfeito(Heroi heroi, string item)
    {
        switch (item)
        {
            case "Poção de Vida":
                float cura = 30;
                heroi.vida += cura;
                Console.WriteLine($"Você recuperou {cura} de vida! Vida atual: {heroi.vida}");
                break;

            case "Poção de Força":
                heroi.dano += 5;
                Console.WriteLine("Seu dano aumentou em +5!");
                break;

            default:
                Console.WriteLine("Este item não tem efeito definido.");
                break;
        }
    }
}
