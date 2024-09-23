using System;

// Clase Nodo que representa un nodo en el árbol binario
public class Nodo
{
    public int Valor; // Almacena el valor del nodo
    public Nodo Izquierdo, Derecho; // Referencias a los hijos izquierdo y derecho del nodo

    // Constructor que inicializa el nodo con un valor
    public Nodo(int valor)
    {
        Valor = valor; // Asigna el valor proporcionado
        Izquierdo = Derecho = null; // Inicializa los hijos como nulos
    }
}

// Clase que representa un Árbol Binario de Búsqueda
public class ArbolBinarioBusqueda
{
    private Nodo raiz; // Raíz del árbol

    // Constructor que inicializa el árbol vacío
    public ArbolBinarioBusqueda()
    {
        raiz = null; // Inicializa la raíz como nula
    }

    // Método para insertar un valor en el árbol
    public void Insertar(int valor)
    {
        // Llama a la función recursiva para insertar el valor en el árbol
        raiz = InsertarRecursivo(raiz, valor);
    }

    // Método recursivo para insertar un valor en la ubicación correcta
    private Nodo InsertarRecursivo(Nodo nodo, int valor)
    {
        // Si el nodo es nulo, crea un nuevo nodo con el valor dado
        if (nodo == null)
        {
            nodo = new Nodo(valor);
            return nodo;
        }

        // Si el valor es menor, inserta en el subárbol izquierdo
        if (valor < nodo.Valor)
            nodo.Izquierdo = InsertarRecursivo(nodo.Izquierdo, valor);
        // Si el valor es mayor, inserta en el subárbol derecho
        else if (valor > nodo.Valor)
            nodo.Derecho = InsertarRecursivo(nodo.Derecho, valor);

        return nodo; // Retorna el nodo (posiblemente modificado)
    }

    // Método para imprimir el árbol en In-Orden (Izquierda, Raíz, Derecha)
    public void InOrden()
    {
        InOrdenRecursivo(raiz);
        Console.WriteLine(); // Salto de línea después de la impresión
    }

    // Método recursivo para recorrer en In-Orden
    private void InOrdenRecursivo(Nodo nodo)
    {
        if (nodo != null)
        {
            InOrdenRecursivo(nodo.Izquierdo); // Recorre el subárbol izquierdo
            Console.Write(nodo.Valor + " "); // Imprime el valor del nodo
            InOrdenRecursivo(nodo.Derecho); // Recorre el subárbol derecho
        }
    }

    // Método para imprimir el árbol en Pre-Orden (Raíz, Izquierda, Derecha)
    public void PreOrden()
    {
        PreOrdenRecursivo(raiz);
        Console.WriteLine(); // Salto de línea después de la impresión
    }

    // Método recursivo para recorrer en Pre-Orden
    private void PreOrdenRecursivo(Nodo nodo)
    {
        if (nodo != null)
        {
            Console.Write(nodo.Valor + " "); // Imprime el valor del nodo
            PreOrdenRecursivo(nodo.Izquierdo); // Recorre el subárbol izquierdo
            PreOrdenRecursivo(nodo.Derecho); // Recorre el subárbol derecho
        }
    }

    // Método para imprimir el árbol en Post-Orden (Izquierda, Derecha, Raíz)
    public void PostOrden()
    {
        PostOrdenRecursivo(raiz);
        Console.WriteLine(); // Salto de línea después de la impresión
    }

    // Método recursivo para recorrer en Post-Orden
    private void PostOrdenRecursivo(Nodo nodo)
    {
        if (nodo != null)
        {
            PostOrdenRecursivo(nodo.Izquierdo); // Recorre el subárbol izquierdo
            PostOrdenRecursivo(nodo.Derecho); // Recorre el subárbol derecho
            Console.Write(nodo.Valor + " "); // Imprime el valor del nodo
        }
    }

    // Método para buscar un valor en el árbol
    public Nodo Buscar(int valor)
    {
        return BuscarRecursivo(raiz, valor); // Llama a la función recursiva para buscar
    }

    // Método recursivo para buscar un valor en el árbol
    private Nodo BuscarRecursivo(Nodo nodo, int valor)
    {
        // Si el nodo es nulo o el valor es igual al valor del nodo actual, retorna el nodo
        if (nodo == null || nodo.Valor == valor)
            return nodo;

        // Si el valor es menor, busca en el subárbol izquierdo
        if (valor < nodo.Valor)
            return BuscarRecursivo(nodo.Izquierdo, valor);

        // Si el valor es mayor, busca en el subárbol derecho
        return BuscarRecursivo(nodo.Derecho, valor);
    }

    // Método para encontrar el valor mínimo en el árbol
    public int Minimo()
    {
        Nodo actual = raiz;
        // Se mueve siempre hacia la izquierda hasta encontrar el valor mínimo
        while (actual.Izquierdo != null)
        {
            actual = actual.Izquierdo;
        }
        return actual.Valor; // Retorna el valor mínimo
    }

    // Método para encontrar el valor máximo en el árbol
    public int Maximo()
    {
        Nodo actual = raiz;
        // Se mueve siempre hacia la derecha hasta encontrar el valor máximo
        while (actual.Derecho != null)
        {
            actual = actual.Derecho;
        }
        return actual.Valor; // Retorna el valor máximo
    }

    // Método para eliminar un valor del árbol
    public void Eliminar(int valor)
    {
        raiz = EliminarRecursivo(raiz, valor); // Llama a la función recursiva para eliminar
    }

    // Método recursivo para eliminar un nodo con el valor dado
    private Nodo EliminarRecursivo(Nodo raiz, int valor)
    {
        // Caso base: Si el nodo es nulo, retorna null
        if (raiz == null) return raiz;

        // Si el valor es menor que el nodo actual, busca en el subárbol izquierdo
        if (valor < raiz.Valor)
            raiz.Izquierdo = EliminarRecursivo(raiz.Izquierdo, valor);
        // Si el valor es mayor, busca en el subárbol derecho
        else if (valor > raiz.Valor)
            raiz.Derecho = EliminarRecursivo(raiz.Derecho, valor);
        // Si encuentra el valor, este es el nodo a eliminar
        else
        {
            // Si el nodo tiene solo un hijo o ninguno
            if (raiz.Izquierdo == null)
                return raiz.Derecho;
            else if (raiz.Derecho == null)
                return raiz.Izquierdo;

            // Si el nodo tiene dos hijos, se reemplaza con el mínimo del subárbol derecho
            raiz.Valor = MinimoValor(raiz.Derecho);

            // Elimina el valor mínimo del subárbol derecho
            raiz.Derecho = EliminarRecursivo(raiz.Derecho, raiz.Valor);
        }

        return raiz; // Retorna la nueva raíz
    }

    // Método auxiliar para encontrar el valor mínimo en un subárbol
    private int MinimoValor(Nodo nodo)
    {
        int minv = nodo.Valor;
        // Se mueve hacia la izquierda para encontrar el menor valor
        while (nodo.Izquierdo != null)
        {
            minv = nodo.Izquierdo.Valor;
            nodo = nodo.Izquierdo;
        }
        return minv; // Retorna el valor mínimo encontrado
    }

    // Método para imprimir el árbol de manera jerárquica
    public void ImprimirJerarquico()
    {
        ImprimirJerarquicoRecursivo(raiz, 0); // Llama a la función recursiva
    }

    // Método recursivo para imprimir el árbol en niveles
    private void ImprimirJerarquicoRecursivo(Nodo nodo, int nivel)
    {
        if (nodo != null)
        {
            // Primero imprime el subárbol derecho
            ImprimirJerarquicoRecursivo(nodo.Derecho, nivel + 1);
            // Imprime el nodo actual con indentación correspondiente al nivel
            Console.WriteLine(new String(' ', nivel * 4) + nodo.Valor);
            // Luego imprime el subárbol izquierdo
            ImprimirJerarquicoRecursivo(nodo.Izquierdo, nivel + 1);
        }
    }
}

// Clase principal para manejar el menú e interactuar con el árbol
class Program
{
    static void Main(string[] args)
    {
        ArbolBinarioBusqueda arbol = new ArbolBinarioBusqueda(); // Crea un nuevo árbol binario de búsqueda
        int opcion, valor;

        do
        {
            // Título y presentación del menú
            Console.WriteLine("\n--- Elaborado por Mauricio Torres ---");
            Console.WriteLine("--- Menu Arbol Binario de Busqueda ---");
            Console.WriteLine("Seleccione una opcion por favor");
            Console.WriteLine("1. Insertar");
            Console.WriteLine("2. Buscar");
            Console.WriteLine("3. Eliminar");
            Console.WriteLine("4. Mostrar In-Orden");
            Console.WriteLine("5. Mostrar Pre-Orden");
            Console.WriteLine("6. Mostrar Post-Orden");
            Console.WriteLine("7. Mostrar Jerarquico");
            Console.WriteLine("8. Salir");
            Console.Write("Ingrese su opción: ");
            opcion = int.Parse(Console.ReadLine()); // Lee la opción ingresada por el usuario

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese el valor a insertar: ");
                    valor = int.Parse(Console.ReadLine());
                    arbol.Insertar(valor); // Inserta el valor en el árbol
                    Console.WriteLine("Valor insertado correctamente.");
                    Console.WriteLine("--- Elaborado por Mauricio Torres ---");
                    break;

                case 2:
                    Console.Write("Ingrese el valor a buscar: ");
                    valor = int.Parse(Console.ReadLine());
                    Nodo encontrado = arbol.Buscar(valor); // Busca el valor en el árbol
                    if (encontrado != null)
                        Console.WriteLine("Valor encontrado: " + encontrado.Valor);
                    else
                        Console.WriteLine("Valor no encontrado.");
                    break;

                case 3:
                    Console.Write("Ingrese el valor a eliminar: ");
                    valor = int.Parse(Console.ReadLine());
                    arbol.Eliminar(valor); // Elimina el valor del árbol
                    Console.WriteLine("Valor eliminado correctamente.");
                    break;

                case 4:
                    Console.WriteLine("Recorrido In-Orden:");
                    arbol.InOrden(); // Muestra el árbol en In-Orden
                    break;

                case 5:
                    Console.WriteLine("Recorrido Pre-Orden:");
                    arbol.PreOrden(); // Muestra el árbol en Pre-Orden
                    break;

                case 6:
                    Console.WriteLine("Recorrido Post-Orden:");
                    arbol.PostOrden(); // Muestra el árbol en Post-Orden
                    break;

                case 7:
                    Console.WriteLine("Árbol Binario de Búsqueda Jerárquico:");
                    arbol.ImprimirJerarquico(); // Imprime el árbol de manera jerárquica
                    break;

                case 8:
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        } while (opcion != 8); // El ciclo continúa hasta que se elija la opción de salir
    }
}
