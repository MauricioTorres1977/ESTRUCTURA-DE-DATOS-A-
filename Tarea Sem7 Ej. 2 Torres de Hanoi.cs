using System;
using System.Collections.Generic;
using System.Linq;

public static class Hanoi
{
    // Definición de las pilas para las tres torres
    static Stack<int> torreA = new Stack<int>();
    static Stack<int> torreB = new Stack<int>();
    static Stack<int> torreC = new Stack<int>();

    /// <summary>
    /// Método principal que ejecuta la solución del problema de las torres de Hanoi.
    /// </summary>
    public static void Run()
    {
        // Inicializa las torres eliminando cualquier dato previo
        InicializarPila();

        // Solicita al usuario la cantidad de discos
        Console.Write("Cuantos discos contiene la torre: ");
        if (!int.TryParse(Console.ReadLine(), out int NumDiscos) || NumDiscos <= 0)
        {
            Console.WriteLine("Por favor, ingrese un número válido de discos.");
            return;
        }

        // Llena la torre A con discos, del mayor al menor
        for (int i = NumDiscos; i >= 1; i--)
        {
            torreA.Push(i);
        }

        // Dibuja el estado inicial de las torres
        DibujarTorres();

        // Resuelve el problema de las torres de Hanoi
        Resolver(NumDiscos, torreA, torreC, torreB);
    }

    /// <summary>
    /// Método recursivo para resolver el problema de las torres de Hanoi.
    /// </summary>
    static void Resolver(int n, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar)
    {
        if (n == 1)
        {
            // Mueve un solo disco del origen al destino
            MoverDisco(origen, destino);
            DibujarTorres();
        }
        else
        {
            // Mueve n-1 discos del origen al auxiliar
            Resolver(n - 1, origen, auxiliar, destino);
            // Mueve el disco restante del origen al destino
            MoverDisco(origen, destino);
            DibujarTorres();
            // Mueve los n-1 discos del auxiliar al destino
            Resolver(n - 1, auxiliar, destino, origen);
        }
    }

    /// <summary>
    /// Mueve un disco desde la torre de origen hacia la torre de destino.
    /// </summary>
    static void MoverDisco(Stack<int> origen, Stack<int> destino)
    {
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
    static void InicializarPila()
    {
        torreA.Clear();
        torreB.Clear();
        torreC.Clear();
    }
}

public static class Balanceo
{
    /// <summary>
    /// Ejecuta la verificación de balanceo de una fórmula matemática.
    /// </summary>
    public static void Run()
    {
        Console.WriteLine("Ingrese una ecuacion:");
        string formula = Console.ReadLine();

        if (EstaBalanceada(formula))
        {
            Console.WriteLine("Ecuacion Balanceada");
        }
        else
        {
            Console.WriteLine("Ecuacion NO balanceada");
        }
    }

    /// <summary>
    /// Verifica si una fórmula está balanceada en términos de paréntesis, corchetes y llaves.
    /// </summary>
    public static bool EstaBalanceada(string formula)
    {
        Stack<char> pila = new Stack<char>();

        foreach (char c in formula)
        {
            // Si se encuentra un paréntesis de apertura, se agrega a la pila
            if (c == '(' || c == '[' || c == '{')
            {
                pila.Push(c);
            }
            // Si se encuentra un paréntesis de cierre, se verifica si corresponde al de apertura
            else if (c == ')' || c == ']' || c == '}')
            {
                if (pila.Count == 0) return false;
                char ultimo = pila.Pop();
                if (!Coinciden(ultimo, c)) return false;
            }
        }

        // Si la pila está vacía al finalizar, los paréntesis están balanceados
        return pila.Count == 0;
    }

    /// <summary>
    /// Verifica si los caracteres de apertura y cierre coinciden.
    /// </summary>
    public static bool Coinciden(char apertura, char cierre)
    {
        return (apertura == '(' && cierre == ')') ||
               (apertura == '[' && cierre == ']') ||
               (apertura == '{' && cierre == '}');
    }
}

class Program
{
    static void Main()
    {
        // Ejecutar el problema de las torres de Hanoi
        Hanoi.Run();
        
        // Ejecutar la verificación de balanceo
        Balanceo.Run();
    }
}
