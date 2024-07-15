using System;
using System.Collections.Generic;
using System.Linq;

public static class Hanoi
{
    // Pilas que representan las torres A, B y C
    static Stack<int> torreA = new Stack<int>();
    static Stack<int> torreB = new Stack<int>();
    static Stack<int> torreC = new Stack<int>();

    /// <summary>
    /// Método principal que ejecuta la solución del problema de las torres de Hanoi.
    /// </summary>
    public static void Run()
    {
        InicializarPilas(); // Elimina datos o residuos en las torres
        Console.Write("¿Cuántos discos contiene la torre?: ");
        int numDiscos = int.Parse(Console.ReadLine());

        // Inicializa la torre A con los discos en orden descendente
        for (int i = numDiscos; i >= 1; i--)
        {
            torreA.Push(i);
        }
        DibujarTorres();

        // Resuelve el problema de las torres de Hanoi
        Resolver(numDiscos, torreA, torreC, torreB);
    }

    /// <summary>
    /// Método recursivo para resolver el problema de las torres de Hanoi.
    /// </summary>
    /// <param name="n">Número de discos a mover</param>
    /// <param name="origen">Torre de origen</param>
    /// <param name="destino">Torre de destino</param>
    /// <param name="auxiliar">Torre auxiliar</param>
    static void Resolver(int n, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar)
    {
        if (n == 1)
        {
            MoverDisco(origen, destino);
            DibujarTorres();
        }
        else
        {
            // Mueve n-1 discos de origen a auxiliar, usando destino como auxiliar
            Resolver(n - 1, origen, auxiliar, destino);
            // Mueve el disco restante de origen a destino
            MoverDisco(origen, destino);
            DibujarTorres();
            // Mueve los n-1 discos de auxiliar a destino, usando origen como auxiliar
            Resolver(n - 1, auxiliar, destino, origen);
        }
    }

    /// <summary>
    /// Mueve un disco desde la torre de origen hacia la torre de destino.
    /// </summary>
    /// <param name="origen">Torre de origen</param>
    /// <param name="destino">Torre de destino</param>
    static void MoverDisco(Stack<int> origen, Stack<int> destino)
    {
        // En destino se coloca un nuevo elemento que es el que se elimina en el origen
        destino.Push(origen.Pop());
    }

    /// <summary>
    /// Dibuja el estado actual de las torres.
    /// </summary>
    static void DibujarTorres()
    {
        Console.WriteLine("Estado de las Torres:");
        Console.WriteLine("Torre A: {0}", string.Join(", ", torreA.Reverse()));
        Console.WriteLine("Torre B: {0}", string.Join(", ", torreB.Reverse()));
        Console.WriteLine("Torre C: {0}", string.Join(", ", torreC.Reverse()));
        Console.WriteLine(new string('*', 30));
    }

    /// <summary>
    /// Inicializa las pilas de las torres eliminando cualquier contenido previo.
    /// </summary>
    static void InicializarPilas()
    {
        // Utilizamos el método Clear para borrar el contenido de las pilas
        torreA.Clear();
        torreB.Clear();
        torreC.Clear();
    }
}

class Program
{
    static void Main()
    {
        Hanoi.Run();
    }
}
