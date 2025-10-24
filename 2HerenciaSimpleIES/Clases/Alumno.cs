using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2HerenciaSimpleIES.Clases
{
    public class Alumno : Persona
    {
        private long numExpediente;

        public long NumeroExpediente
        {
            get => numExpediente;
            set => numExpediente = value > 0 ? value : 0;
        }

        public Alumno() 
        {
            
        }

        public Alumno(string nombre, string apellido, uint edad, int padding) : base(nombre, apellido, edad, padding)
        {

        }

        public Alumno(string nombre, string apellido, uint edad, long numExpediente, int padding) : base(nombre, apellido, edad, padding)
        {
            NumeroExpediente = numExpediente;
            Email = GenerateEmail();
        }

        public override string GenerateEmail()
        {
            return "a" + base.GenerateEmail() + $"{DateTime.Now.Year}" + "trass.com";
        }

        public override string ToString()
        {
            return base.ToString() + NumeroExpediente;
        }
    }
}
