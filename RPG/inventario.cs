using System;

public class Inventario
{
    public void Entrar(Heroi heroi)
    {
        Console.WriteLine("\n=== INVENTÁRIO ===");

        if (heroi.inventario.Count == 0)
        {
            Console.WriteLine("Seu inventário está vazio.");
        }
        else
        {
            Console.WriteLine("Seus itens:");
            for (int i = 0; i < heroi.inventario.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {heroi.inventario[i]}");
            }
        }

        Console.WriteLine($"Ouro atual: {heroi.ouro}");
    }
}
