using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2HerenciaSimpleIES.Clases;

namespace _2HerenciaSimpleIES.Recursos
{
    public static class ExtensionClass
    {
        public static int WordCount(this string str)
        {
            return str.Split(new char[] { ' ', '.', '?' },
                StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static string Capitalize(this string word)
        {
            // Si la palabra es más larga que 1 caracter se agrega el substring desde el índice 1 al final
            // En caso contrario, se agrega una cadena vacía
            return word.Substring(0,1).ToUpper() + 
                (word.Length > 1 ? word.Substring(1).ToLower() : string.Empty);
        }

        public static bool SeekRemove(this List<Persona> lista, Persona personaABorrar)
        {
            foreach (Persona p in lista)
            {
                if (p.Equals(personaABorrar))
                {
                    lista.Remove(p);
                    return true;
                }
            }

            return false;
        }
    }
}
