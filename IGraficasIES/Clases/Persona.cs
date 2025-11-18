using _2HerenciaSimpleIES.Recursos;
using System.Text;

namespace _2HerenciaSimpleIES.Clases
{
    public class Persona
    {
        private string nombre;
        private string apellidos;
        private uint edad;
        private string email;
        private string rutaFoto;

        public Persona()
        {
        }

        public string Nombre 
        {
            get => nombre;
            set => nombre = CapitalizeAndClean(value);
        }
        public string Apellidos 
        { 
            get => apellidos;
            set => apellidos = CapitalizeAndClean(value);
        }
        public uint Edad 
        { 
            get => edad;
            set => edad = value >= 0 && value <= 120 ? value : 0;
        }
        public string Email 
        { 
            get => email;
            set => email = value;
        }

        public string RutaFoto
        {
            get => rutaFoto;
            set => rutaFoto = value;
        }

        public Persona(string nombre, string apellido, uint edad, string email, string rutaFoto)
        {
            Nombre = nombre;
            Apellidos = apellido;
            Edad = edad;
            Email = email;
            RutaFoto = rutaFoto;
        }

        public static String CapitalizeAndClean(string s)
        {
            // Split por si hay dos nombres
            string[] nombreLimpio = s.Trim().Split(' ');
            StringBuilder resultado = new StringBuilder();

            foreach (string nombre in nombreLimpio)
            {
                // Upper al primer carácter, después si hay más caracteres,
                // substring desde el índice 1 hasta el final en lowercase
                resultado.Append(nombre.Capitalize()).Append(' ');
            }

            return resultado.ToString();
        }

        public virtual string GenerateEmail()
        {
            string[] apellidosStr = Apellidos.ToLower().Split(' ');

            // Primeros dos caracteres del primer apellido
            // Primeros dos caracteres del segundo apellido si lo hubiese, sino se repite lo anterior
            // Primera letra del nombre
            string newEmail = apellidosStr[0].Substring(0,2) 
                // Para comprobar que hay dos apellidos, compruebo si el segundo apellido es una cadena vacía
                + (apellidosStr[1] == "" ? apellidosStr[0] : apellidosStr[1]).Substring(0,2)
                + Nombre.ToLower().Substring(0,1);

            return newEmail;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre} {Apellidos}, Edad: {Edad}, Email: {Email}";
        }

        public override bool Equals(object? obj)
        {
            Persona? persona = obj as Persona;
            if (persona != null)
            {
                return Nombre == persona.Nombre &&
                    Apellidos == persona.Apellidos &&
                    Edad == persona.Edad;
            }
            return false;
        }

        public static bool operator > (Persona p1, Persona p2) => p1.Edad > p2.Edad;
        public static bool operator < (Persona p1, Persona p2) => p1.Edad < p2.Edad;

        public static bool operator == (Persona p1, Persona p2) => p1.Edad == p2.Edad;
        public static bool operator != (Persona p1, Persona p2) => p1.Edad != p2.Edad;
    }
}
