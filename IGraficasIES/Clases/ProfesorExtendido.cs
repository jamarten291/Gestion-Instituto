using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGraficasIES.Clases
{
    public class ProfesorExtendido
    {
        public enum EstadoCivil
        {
            Soltero,
            Casado,
            Divorciado,
            Viudo
        }

        private EstadoCivil _estadoCivil;
        private string _email;
        private int _peso;
        private int _estatura;

        public EstadoCivil Estado
        {
            get => _estadoCivil;
            set => _estadoCivil = value;
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public int Peso
        {
            get { return _peso; }
            set { _peso = value >= 0 ? value : 0; }
        }

        public int Estatura
        {
            get { return _estatura; }
            set { _estatura = value >= 0 ? value : 0; }
        }

        public static List<ProfesorExtendido> GetProfesE()
        {
            // Lista de correos electrónicos de ejemplo que se enlazan con los datos del .txt
            List<string> emails =
            [
                "juan.perez@gmail.com",
                "maria.garcia@gmail.com",
                "luis.martinez@gmail.com",
                "ana.sanchez@gmail.com",
                "carmen.fernandez@gmail.com",
                "jose.ramirez@gmail.com",
                "lucia.moreno@gmail.com",
                "david.cruz@gmail.com",
                "sofia.rivas@gmail.com",
                "miguel.vega@gmail.com"
            ];

            Random rand = new();
            EstadoCivil[] estados = Enum.GetValues<EstadoCivil>(); // Obtener todos los valores del enum
            List<ProfesorExtendido> lista = [];

            foreach (var email in emails)
            {
                // Crear un nuevo ProfesorExtendido con datos aleatorios y agregarlo a la lista
                lista.Add(new ProfesorExtendido
                {
                    Email = email,
                    Estado = estados[rand.Next(estados.Length)],
                    Peso = rand.Next(55, 111),      // 55..110 kg
                    Estatura = rand.Next(150, 201)  // 150..200 cm
                });
            }

            return lista;
        }
    }
}
