using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola2
{
    public static class Balanceo2
    {
        public static void Run()
        {
            Console.WriteLine($"Ingrese una ecuacion:ejemplo:{{7+(8*5)-[(9-7)+(4+1)]}}");
            string formula = Console.ReadLine();
            //string formula = "{7+(8*5)-[(9-7)+(4+1)]}";

            // Llamada al método IsBalanced para verificar si la fórmula está balanceada
            bool isBalanced = IsBalanced(formula);

            // Muestra el resultado de la verificación
            Console.WriteLine($"La fórmula '{formula}' está balanceada: {isBalanced}");
            Console.ReadKey();
        }

        public static bool IsBalanced(string formula)
        {
            // Utiliza una pila para llevar el control de los caracteres de apertura
            Stack<char> stack = new Stack<char>();

            foreach (char c in formula)
            {
                // Si se encuentra un paréntesis, corchete o llave de apertura, se agrega a la pila
                if (c == '{' || c == '[' || c == '(')
                {
                    stack.Push(c);
                }
                // Si se encuentra un paréntesis, corchete o llave de cierre, se verifica si corresponde al de apertura
                else if (c == '}' || c == ']' || c == ')')
                {
                    // Si la pila está vacía, significa que hay un cierre sin apertura correspondiente
                    if (stack.Count == 0)
                    {
                        return false;
                    }

                    // Se obtiene el último elemento de apertura de la pila
                    char top = stack.Pop();

                    // Verifica si el último elemento de apertura corresponde con el de cierre actual
                    if ((c == '}' && top != '{') || (c == ']' && top != '[') || (c == ')' && top != '('))
                    {
                        return false;
                    }
                }
            }

            // Si la pila está vacía al finalizar, significa que todos los paréntesis, corchetes y llaves están balanceados
            return stack.Count == 0;
        }

    }
    
}
