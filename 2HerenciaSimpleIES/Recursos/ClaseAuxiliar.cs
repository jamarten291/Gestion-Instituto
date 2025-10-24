using _2HerenciaSimpleIES.Clases;
using _2HerenciaSimpleIES.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _2HerenciaSimpleIES.Recursos
{
    public static class ClaseAuxiliar
    {
        //public static Persona[] ListadoPersonas(int padding)
        //{
        //    return new[] {
        //        new Persona
        //        {
        //            Nombre = "JUAN",
        //            Apellidos = "LOPEZ CRUZ",
        //            Edad = 34,
        //            Padding = padding
        //        },
        //        new Persona
        //        {
        //            Nombre = "JAIME",
        //            Apellidos = "LUQUE DE LOS RIOS",
        //            Edad = 16,
        //            Padding = padding
        //        },
        //        new Persona
        //        {
        //            Nombre = "MARIA",
        //            Apellidos = "GARCIA MARTINEZ",
        //            Edad = 22,
        //            Padding = padding
        //        },
        //        new Persona
        //        {
        //            Nombre = "CARLOS",
        //            Apellidos = "HERNANDEZ PEREZ",
        //            Edad = 26,
        //            Padding = padding
        //        },
        //        new Persona
        //        {
        //            Nombre = "SOFIA",
        //            Apellidos = "MORENO GUTIERREZ",
        //            Edad = 19,
        //            Padding = padding
        //        },
        //        new Persona
        //        {
        //            Nombre = "ANDRES",
        //            Apellidos = "REYES VEGA",
        //            Edad = 20,
        //            Padding = padding
        //        }
        //    };
        //}

        public static void ListarPersonas(List<Persona> lista, int padding)
        {
            PrintHeaderBasico(padding, true);
            foreach (Persona p in lista)
            {
                if (p is Alumno alumno)
                {
                    Console.WriteLine(alumno.ToString());
                }
            }

            Console.WriteLine();

            PrintHeaderProfesor(padding);
            foreach (Persona p in lista)
            {
                if (p is Profesor profesor)
                {
                    Console.WriteLine(profesor.ToString());
                }
            }

            Console.ReadKey();
        }

        public static void PrintHeaderBasico(int padding, bool alumno)
        {
            Console.WriteLine(alumno ? "----- LISTADO DE ALUMNOS -----" : "----- LISTADO DE PROFESORES -----");
            Console.Write("NOMBRE".PadRight(padding) +
                "APELLIDOS".PadRight(padding) +
                "EMAIL".PadRight(padding) +
                "EDAD".PadRight(padding) +
                (alumno ? "EXPEDIENTE\n" : "MATERIA".PadRight(padding)));
        }

        public static void PrintHeaderProfesor(int padding)
        {
            PrintHeaderBasico(padding, false);
            Console.Write("FUNCIONARIO".PadRight(padding) + 
                "AÑO".PadRight(padding) +
                "DEFINITIVO".PadRight(padding) +
                "S. MÉDICO\n");
        }

        public static bool AlumnoExiste(Persona p, List<Persona> personas)
        {
            // Devuelve true si cualquier persona que ya exista tiene la misma edad y el mismo email
            if (personas.Any(persona => persona.Email.Equals(p.Email) && persona.Edad == p.Edad))
            {
                Console.WriteLine("Ese alumno ya existe, debes introducir uno nuevo");
                return true;
            }

            return false;
        }

        // Tupla que devuelve el nombre, apellidos y la edad
        public static (string nombre, string apellidos, uint edad) GenerarPersona(int padding = 20)
        {
            string nombre, apellidos;
            uint edad;
            do
            {
                Console.Write("NOMBRE: ");
                nombre = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(nombre) || nombre.Length < 2);

            do
            {
                Console.Write("APELLIDOS: ");
                apellidos = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(apellidos) || apellidos.Length < 2);

            do
            {
                Console.Write("EDAD (entre 0-120): ");
            } while (!uint.TryParse(Console.ReadLine().Trim(), out edad) ||
                        edad > 120);

            return (nombre, apellidos, edad);
        }

        public static bool EliminarPersona(List<Persona> personas)
        {
            // Busca y elimina una persona que coincida con la instancia de Persona generada en este método
            // Esta instancia es creada pasándole una tupla con el nombre, apellido y edad de la persona que queremos borrar
            return personas.SeekRemove(new Persona(GenerarPersona()));
        }

        public static Persona GenerarPersonaEspecifica(int padding)
        {
            int opt;
            var (nombre, apellidos, edad) = GenerarPersona(padding);
            do
            {
                Console.Write($"Elige una opción:\n" +
                    $"1. Alumno\n" +
                    $"2. Profesor    =>OPCION (1,2): ");
            } while (!int.TryParse(Console.ReadLine().Trim(), out opt) ||
                opt > 2 || opt < 1);

            if (opt == 1)
            {
                return CrearAlumno(padding, nombre, apellidos, edad);
            }
            else if (opt == 2)
            {
                return CrearMaestro(padding, nombre, apellidos, edad);
            }
            return new Persona();
        }

        private static Persona CrearMaestro(int padding, string nombre, string apellidos, uint edad)
        {
            string materia;
            int tipoProfesor;

            do
            {
                Console.Write("MATERIA QUE IMPARTE: ");
                materia = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(materia));

            do
            {
                Console.Write("Elige el TIPO DE PROFESOR:\n" +
                    "1. Interino\n" +
                    "2. En Prácticas\n" +
                    "3. De Carrera    =>OPCION (1,2):");
            }
            while (!int.TryParse(Console.ReadLine(), out tipoProfesor) ||
                tipoProfesor < 1 || tipoProfesor > 3);

            switch (tipoProfesor)
            {
                case 1:
                    return new ProfesorInterino(
                        nombre,
                        apellidos,
                        edad,
                        materia,
                        IntToTipoFuncionario(tipoProfesor),
                        padding
                    );
                case 2:
                // Salta directamente al caso 3 ya que solo cambia el tipo de funcionario
                case 3:
                    uint anioIngreso;
                    string destinoDefinitivo;
                    int tipoMedico;

                    do
                    {
                        Console.Write("AÑO DE INGRESO al cuerpo: ");
                    }
                    while (!UInt32.TryParse(Console.ReadLine(), out anioIngreso) ||
                        // Compruebo que no sea menor que la edad mínima de ingreso (22 años)
                        DateTime.Now.Year - anioIngreso > edad - 22 ||
                        // Compruebo que no sea mayor que 50 años de antigüedad ni que supere el año actual
                        anioIngreso < (DateTime.Now.Year - 50) || anioIngreso > DateTime.Now.Year);

                    string[] opcionesDestino = {"si", "no"};
                    do
                    {
                        Console.Write("DESTINO DEFINITIVO (SI,NO): ");
                        destinoDefinitivo = Console.ReadLine().ToLower();
                    }
                    while (string.IsNullOrWhiteSpace(destinoDefinitivo) ||
                        !opcionesDestino.Contains(destinoDefinitivo));

                    bool definitivo = destinoDefinitivo.Equals("si");

                    do
                    {
                        Console.Write("Elige el TIPO DE SEGURO MÉDICO\n" +
                            "1. Seguridad Social\n" +
                            "2. MUFACE\n" +
                            "       =>OPCION (1,2):");
                    } while (!Int32.TryParse(Console.ReadLine(), out tipoMedico) ||
                        tipoMedico < 1 || tipoMedico > 2 || IntToMedic(tipoMedico) == 0);

                    return new ProfesorFuncionario(
                        nombre,
                        apellidos,
                        edad,
                        materia,
                        IntToTipoFuncionario(tipoProfesor), // Uso un método que convierte el int a TipoFuncionario
                        definitivo,
                        anioIngreso,
                        IntToMedic(tipoMedico),
                        padding
                    );
            };

            return new Persona();
        }

        private static Alumno CrearAlumno(int padding, string nombre, string apellidos, uint edad)
        {
            long numExp;
            do
            {
                Console.Write("Nº DE EXPEDIENTE: ");
            }
            while (!long.TryParse(Console.ReadLine().Trim(), out numExp));

            return new Alumno
            (
                nombre,
                apellidos,
                edad,
                numExp,
                padding
            );
        }

        public static void PrintPersonasAge(List<Persona> personas, bool condicion)
        {
            foreach (Persona persona in personas)
            {
                // Condicion comprueba si se quiere imprimir alumnos mayores o menores de edad
                if (persona.MayorEdad == condicion)
                {
                    Console.WriteLine(persona);
                }
            }
        }

        public static void PrintPersonasInstance(List<Persona> personas, bool mostrarAlumnos)
        {
            foreach (Persona persona in personas)
            {
                // Si el bool recibido por parámetros es true, devuelve solo alumnos
                // De otro modo, devuelve solo profesores
                if (persona is Alumno == mostrarAlumnos)
                {
                    Console.WriteLine(persona);
                }
            }
        }

        public static IEmpleadoPublico.TipoMedico IntToMedic(int input)
        {
            switch (input)
            {
                case 1:
                    return IEmpleadoPublico.TipoMedico.SeguridadSocial;
                case 2:
                    return IEmpleadoPublico.TipoMedico.Muface;
                default:
                    return 0;
            }
        }

        public static Profesor.TipoFuncionario IntToTipoFuncionario(int input)
        {
            switch (input)
            {
                case 1:
                    return Profesor.TipoFuncionario.Interino;
                case 2:
                    return Profesor.TipoFuncionario.EnPracticas;
                case 3:
                    return Profesor.TipoFuncionario.DeCarrera;
                default:
                    return 0;
            }
        }
    }
}
