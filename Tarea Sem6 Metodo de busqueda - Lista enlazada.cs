using System;

namespace LinkedListExample
{
    // Clase Node que representa un nodo en la lista enlazada.
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    // Clase LinkedList que representa la lista enlazada.
    public class LinkedList<T>
    {
        private Node<T> head;

        public LinkedList()
        {
            head = null;
        }

        // Método para agregar un nuevo nodo al final de la lista.
        public void Add(T data)
        {
            Node<T> newNode = new Node<T>(data);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node<T> current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        // Método para buscar un dato y contar las ocurrencias en la lista.
        public int Search(T data)
        {
            Node<T> current = head;
            int count = 0;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    count++;
                }
                current = current.Next;
            }

            if (count == 0)
            {
                Console.WriteLine("El dato seleccionado no fue encontrado, selecciona un numero de la lista.");
            }

            return count;
        }

        // Método para imprimir los elementos de la lista.
        public void PrintList()
        {
            Node<T> current = head;
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
            LinkedList<int> list = new LinkedList<int>();

            // Agregando datos a la lista.
            list.Add(10);
            list.Add(20);
            list.Add(10);
            list.Add(30);
            list.Add(10);
            list.Add(40);
            list.Add(40);
            list.Add(10);

            Console.WriteLine("Lista original:");
            list.PrintList();

            while (true)
            {
                // Solicitar al usuario que ingrese el numero a buscar.
                Console.Write("Por Favor ingrese el numero que desea buscar o ( presione 'salir' para terminar): ");
                string input = Console.ReadLine();

                if (input.ToLower() == "salir")
                {
                    break;
                }

                // Intentar convertir la entrada a un numero entero.
                if (int.TryParse(input, out int numberToSearch))
                {
                    // Buscar el numero en la lista y mostrar el resultado.
                    int count = list.Search(numberToSearch);
                    if (count > 0)
                    {
                        Console.WriteLine($"El dato {numberToSearch} se encontró {count} veces.");
                    }
                }
                else
                {
                    Console.WriteLine("El numero seleccionado no es valido. Por favor, ingrese un nuevo número.");
                }
            }
        }
    }
}