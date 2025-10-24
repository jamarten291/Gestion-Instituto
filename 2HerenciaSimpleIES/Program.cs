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

                Console.Clear();

                switch (opt)
                {
                    case 1:
                        Console.WriteLine("----- INSERTAR UNA PERSONA A LA LISTA DE USUARIOS -----");
                        listaPersonas.Add(
                            ClaseAuxiliar.GenerarPersonaEspecifica(PADDING)
                        );
                        break;
                    case 2:
                        ClaseAuxiliar.ListarPersonas(listaPersonas, PADDING);
                        break;
                    case 3:
                        Console.WriteLine("----- MENÚ DE BORRADO -----");
                        Console.WriteLine(ClaseAuxiliar.EliminarPersona(listaPersonas) ?
                            "Persona borrada" : "Persona no encontrada");
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine("----- MENÚ DE BÚSQUEDA -----");
                        Console.WriteLine(ClaseAuxiliar.MostrarDatosFuncionario(listaPersonas));
                        Console.ReadKey();
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
