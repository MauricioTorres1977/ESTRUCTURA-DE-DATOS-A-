using System;

namespace LinkedListExample
{
    // Clase Node que representa un nodo en la lista enlazada.
    public class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }

        public Node(int data)
        {
            Data = data;
            Next = null;
        }
    }

    // Clase LinkedList que representa la lista enlazada.
    public class LinkedList
    {
        private Node head;

        public LinkedList()
        {
            head = null;
        }

        // Método para agregar un nuevo nodo al final de la lista.
        public void Add(int data)
        {
            Node newNode = new Node(data);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        // Método para eliminar nodos fuera del rango especificado.
        public void RemoveOutsideRange(int min, int max)
        {
            // Eliminar nodos al principio de la lista que están fuera del rango.
            while (head != null && (head.Data < min || head.Data > max))
            {
                head = head.Next;
            }

            Node current = head;

            // Recorrer la lista y eliminar nodos fuera del rango.
            while (current != null && current.Next != null)
            {
                if (current.Next.Data < min || current.Next.Data > max)
                {
                    current.Next = current.Next.Next;
                }
                else
                {
                    current = current.Next;
                }
            }
        }

        // Método para imprimir los elementos de la lista.
        public void PrintList()
        {
            Node current = head;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }

    // Clase principal con un ejemplo de uso.
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            Random random = new Random();

            // Agregar 50 números aleatorios a la lista.
            for (int i = 0; i < 50; i++)
            {
                int number = random.Next(1, 1000); // Generar un número entre 1 y 999.
                list.Add(number);
            }

            Console.WriteLine("Lista de numeros generados aleatoriamente (Total 50 numeros):");
            list.PrintList();

            // Leer rango desde el teclado.
            int min, max;

            while (true)
            {
                Console.Write("Ingrese el valor minimo del rango en numeros enteros (mayor a 1 y menor a 900: ");
                if (int.TryParse(Console.ReadLine(), out min))
                {
                    break;
                }
                Console.WriteLine("Numero ingresado no valido. Por favor, ingrese un numero entero.");
            }

            while (true)
            {
                Console.Write("Ingrese el valor maximo del rango en numeros enteros (mayor a 1 y menor a 900: ");
                if (int.TryParse(Console.ReadLine(), out max))
                {
                    break;
                }
                Console.WriteLine("Numero ingresado no valido. Por favor, ingrese un numero entero.");
            }

            // Asegurarse de que min es menor o igual a max.
            if (min > max)
            {
                int temp = min;
                min = max;
                max = temp;
            }

            // Eliminar nodos fuera del rango.
            list.RemoveOutsideRange(min, max);

            Console.WriteLine("Listado de numeros despues de eliminar los nodos fuera del rango:");
            list.PrintList();
        }
    }
}
