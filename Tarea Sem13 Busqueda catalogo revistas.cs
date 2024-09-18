using System;

class Node
{
    // Clase que representa un nodo en un árbol binario, con un título de revista y referencias a hijos
    public string title;  // Título de la revista almacenado en el nodo
    public Node leftChild, rightChild;  // Referencias al hijo izquierdo y derecho

    // Constructor del nodo que inicializa el título y los hijos como nulos
    public Node(string title)
    {
        this.title = title;  // Asigna el título pasado como parámetro
        leftChild = rightChild = null;  // Inicializa ambos hijos como nulos (nodo hoja)
    }
}

class MagazineCatalog
{
    private Node root;  // Nodo raíz del árbol binario, que representa el catálogo

    // Constructor que inicializa el árbol vacío
    public MagazineCatalog()
    {
        root = null;  // La raíz se inicializa como nula (catálogo vacío)
    }

    // Función para insertar un título en el catálogo
    public void Insert(string title)
    {
        // Si el árbol está vacío, el nuevo título se convierte en la raíz
        if (root == null)
            root = new Node(title);  // Crea un nuevo nodo raíz con el título dado
        else
            InsertHelper(root, title);  // Llama a la función recursiva para insertar en la posición correcta
    }

    // Función recursiva para insertar un nuevo nodo en el árbol
    private void InsertHelper(Node node, string title)
    {
        // Compara el título a insertar con el título del nodo actual, ignorando mayúsculas/minúsculas
        if (string.Compare(title, node.title, StringComparison.OrdinalIgnoreCase) < 0)
        {
            // Si el nuevo título es menor, debe ir al subárbol izquierdo
            if (node.leftChild == null)
                node.leftChild = new Node(title);  // Si no hay hijo izquierdo, crea un nuevo nodo allí
            else
                InsertHelper(node.leftChild, title);  // Si ya hay hijo izquierdo, sigue buscando recursivamente
        }
        else
        {
            // Si el nuevo título es mayor o igual, debe ir al subárbol derecho
            if (node.rightChild == null)
                node.rightChild = new Node(title);  // Si no hay hijo derecho, crea un nuevo nodo allí
            else
                InsertHelper(node.rightChild, title);  // Si ya hay hijo derecho, sigue buscando recursivamente
        }
    }

    // Función para buscar un título en el catálogo de manera iterativa
    public bool Search(string title)
    {
        Node current = root;  // Comienza la búsqueda desde la raíz
        while (current != null)
        {
            // Compara el título buscado con el título del nodo actual
            int comparison = string.Compare(title, current.title, StringComparison.OrdinalIgnoreCase);
            if (comparison == 0)
                return true;  // Si los títulos coinciden, el título fue encontrado
            else if (comparison < 0)
                current = current.leftChild;  // Si el título buscado es menor, busca en el subárbol izquierdo
            else
                current = current.rightChild;  // Si el título buscado es mayor, busca en el subárbol derecho
        }
        return false;  // Si llega a un nodo nulo, el título no está en el catálogo
    }

    // Función para mostrar el menú de opciones al usuario
    public void DisplayMenu()
    {
        Console.WriteLine("Menú del Catálogo de Revistas:");
        Console.WriteLine("1. Buscar un título");
        Console.WriteLine("2. Salir");
        Console.WriteLine("\nElaborado por Mauricio Torres");
    }

    // Función principal del programa
    public static void Main(string[] args)
    {
        // Crear una instancia del catálogo de revistas
        MagazineCatalog catalog = new MagazineCatalog();
        
        // Insertar 10 títulos de revistas en el catálogo
        string[] titles = {
            "Tecnologia del Color", "El Conocimiento de lo Invisible", "El Mundo de las Tics",
            "El Internet de las cosas", "Informatica y Tecnologia", "Marketing Directo",
            "Mundo de la Robotica", "Ciencia y Futuro", "El mundo del Internet", "Macworld"
        };

        // Insertar cada título en el catálogo
        foreach (string title in titles)
        {
            catalog.Insert(title);  // Llama a la función Insert para cada título
        }

        // Ciclo de interacción con el usuario para buscar títulos
        while (true)
        {
            catalog.DisplayMenu();  // Muestra el menú de opciones
            Console.Write("Seleccione una opción: ");
            int option = Convert.ToInt32(Console.ReadLine());  // Lee la opción ingresada por el usuario

            if (option == 2) break;  // Si elige 2, termina el programa

            if (option == 1)
            {
                // Si elige 1, solicita un título para buscar
                Console.Write("Ingrese el título que desea buscar: ");
                string searchTitle = Console.ReadLine();

                // Realiza la búsqueda del título en el catálogo
                if (catalog.Search(searchTitle))
                    Console.WriteLine("Encontrado");  // Si lo encuentra, muestra "Encontrado"
                else
                    Console.WriteLine("No encontrado");  // Si no lo encuentra, muestra "No encontrado"
            }
            else
            {
                Console.WriteLine("Opción no válida. Intente de nuevo.");  // Si la opción es inválida, lo notifica
            }
        }
    }
}
