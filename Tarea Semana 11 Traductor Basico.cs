using System;
using System.Collections.Generic;

class Program
{
    // Diccionario con palabras en inglés y sus traducciones en español
    static Dictionary<string, string> diccionario = new Dictionary<string, string>()
    {
        {"time", "tiempo"},
        {"person", "persona"},
        {"year", "año"},
        {"way", "camino/forma"},
        {"day", "día"},
        {"thing", "cosa"},
        {"man", "hombre"},
        {"world", "mundo"},
        {"life", "vida"},
        {"hand", "mano"},
        {"part", "parte"},
        {"child", "niño/a"},
        {"eye", "ojo"},
        {"woman", "mujer"},
        {"place", "lugar"},
        {"work", "trabajo"},
        {"week", "semana"},
        {"case", "caso"},
        {"point", "punto/tema"},
        {"government", "gobierno"},
        {"company", "empresa/compañía"},
        {"house", "casa"},
        {"car", "coche"},
        {"food", "comida"},
        {"water", "agua"},
        {"school", "escuela"},
        {"friend", "amigo"}
    };

    static void Main()
    {
        while (true)
        {
            // Mostrar menú de opciones
            Console.WriteLine("\nMENU");
            Console.WriteLine("=======================================================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Ingresar más palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese la frase: ");
                    string frase = Console.ReadLine();
                    Console.WriteLine("Su frase traducida es: " + Traducir(frase.ToLower(), CrearDiccionarioInverso(diccionario)));
                    break;
                case "2":
                    Console.Write("Ingrese la palabra en español: ");
                    string palabraEspanol = Console.ReadLine().ToLower();
                    Console.Write("Ingrese la traducción en inglés: ");
                    string palabraIngles = Console.ReadLine().ToLower();
                    AgregarPalabra(palabraEspanol, palabraIngles);
                    break;
                case "0":
                    Console.WriteLine("Saliendo...");
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    // Función para traducir frases
    static string Traducir(string frase, Dictionary<string, string> diccionario)
    {
        string[] palabras = frase.Split(' ');
        List<string> traduccion = new List<string>();

        foreach (string palabra in palabras)
        {
            if (diccionario.TryGetValue(palabra, out string traduccionPalabra))
            {
                traduccion.Add(traduccionPalabra);
            }
            else
            {
                traduccion.Add(palabra);  // Mantiene la palabra original si no está en el diccionario
            }
        }

        return string.Join(" ", traduccion);
    }

    // Función para crear un diccionario inverso (español-inglés)
    static Dictionary<string, string> CrearDiccionarioInverso(Dictionary<string, string> diccionario)
    {
        Dictionary<string, string> diccionarioInverso = new Dictionary<string, string>();
        foreach (var item in diccionario)
        {
            diccionarioInverso[item.Value] = item.Key;
        }
        return diccionarioInverso;
    }

    // Función para agregar nuevas palabras al diccionario
    static void AgregarPalabra(string espanol, string ingles)
    {
        if (!diccionario.ContainsKey(ingles))
        {
            diccionario[ingles] = espanol;
            Console.WriteLine($"Palabra '{espanol}' agregada con traducción '{ingles}'.");
        }
        else
        {
            Console.WriteLine($"La palabra '{espanol}' ya existe en el diccionario.");
        }
    }
}
