using _2HerenciaSimpleIES.Clases;
using _2HerenciaSimpleIES.Recursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace _2HerenciaSimpleIES
{
    public class Program
    {
        private const int PADDING = 20;
        static void Main(string[] args)
        {
            List<Persona> listaPersonas = new List<Persona>();
            int opt;
            
            do
            {
                do
                {
                    Console.Clear();
                    Console.Write(
                    @"********** MENU **********
1. Añadir personas
2. Visualizar personas
3. Borrar una persona
4. Datos de un empleado público
5. Obtener el mayor de 2 personas
6. Salir
===========================
=> OPCION (1,2,3,4,5,6): ");
                }
                while (!Int32.TryParse(Console.ReadLine(), out opt) ||
                    opt < 1 || opt > 6);

                switch (opt)
                {
                    case 1:
                        listaPersonas.Add(
                            ClaseAuxiliar.GenerateSpecificPerson(PADDING)
                        );
                        break;
                    case 2:
                        ClaseAuxiliar.ListarPersonas(listaPersonas, PADDING);
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    default:
                        break;
                }
            }
            while (opt != 6);
        }
    }
}
