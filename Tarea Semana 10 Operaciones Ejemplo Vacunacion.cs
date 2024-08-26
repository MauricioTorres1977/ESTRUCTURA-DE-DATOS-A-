using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Crear un conjunto ficticio de 500 ciudadanos
        // Usamos un HashSet para garantizar que todos los ciudadanos sean únicos.
        HashSet<string> ciudadanos = new HashSet<string>();
        for (int i = 1; i <= 500; i++)
        {
            ciudadanos.Add("Ciudadano" + i);
        }

        // Crear un conjunto ficticio de 75 ciudadanos vacunados con Pfizer
        HashSet<string> vacunadosPfizer = new HashSet<string>();
        for (int i = 1; i <= 75; i++)
        {
            vacunadosPfizer.Add("Ciudadano" + i);
        }

        // Crear un conjunto ficticio de 75 ciudadanos vacunados con AstraZeneca
        HashSet<string> vacunadosAstraZeneca = new HashSet<string>();
        for (int i = 76; i <= 150; i++)
        {
            vacunadosAstraZeneca.Add("Ciudadano" + i);
        }

        // Obtener el listado de ciudadanos que no se han vacunado
        HashSet<string> noVacunados = new HashSet<string>(ciudadanos);
        noVacunados.ExceptWith(vacunadosPfizer); // Eliminar los vacunados con Pfizer
        noVacunados.ExceptWith(vacunadosAstraZeneca); // Eliminar los vacunados con AstraZeneca
        
        Console.WriteLine("Ciudadanos no vacunados:");
        foreach (var ciudadano in noVacunados)
        {
            Console.WriteLine(ciudadano);
        }

        // Obtener el listado de ciudadanos que han recibido las dos vacunas
        HashSet<string> vacunadosDosVeces = new HashSet<string>(vacunadosPfizer);
        vacunadosDosVeces.IntersectWith(vacunadosAstraZeneca); // Retener solo los que están en ambos conjuntos
        
        Console.WriteLine("\nCiudadanos vacunados con las dos vacunas:");
        foreach (var ciudadano in vacunadosDosVeces)
        {
            Console.WriteLine(ciudadano);
        }

        // Obtener el listado de ciudadanos que solamente han recibido la vacuna de Pfizer
        HashSet<string> soloPfizer = new HashSet<string>(vacunadosPfizer);
        soloPfizer.ExceptWith(vacunadosAstraZeneca); // Eliminar los que también están vacunados con AstraZeneca
        
        Console.WriteLine("\nCiudadanos vacunados solamente con Pfizer:");
        foreach (var ciudadano in soloPfizer)
        {
            Console.WriteLine(ciudadano);
        }

        // Obtener el listado de ciudadanos que solamente han recibido la vacuna de AstraZeneca
        HashSet<string> soloAstraZeneca = new HashSet<string>(vacunadosAstraZeneca);
        soloAstraZeneca.ExceptWith(vacunadosPfizer); // Eliminar los que también están vacunados con Pfizer
        
        Console.WriteLine("\nCiudadanos vacunados solamente con AstraZeneca:");
        foreach (var ciudadano in soloAstraZeneca)
        {
            Console.WriteLine(ciudadano);
        }

        // Imprimir el nombre del autor
        Console.WriteLine("\nElaborado por Mauricio Torres Diaz");
    }
}

