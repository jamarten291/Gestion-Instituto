using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _2HerenciaSimpleIES.Clases
{
    public abstract class Profesor : Persona
    {
        private string materia;

        public string Materia { 
            get => materia; 
            set => materia = value; 
        }

        public enum TipoFuncionario : uint
        {
            //Tienen asignados los valores de constante por defecto
            Interino = 1,
            EnPracticas = 2,
            DeCarrera = 3
        }

        public TipoFuncionario TipoProfesor { get; set; }

        public Profesor(string nombre, string apellido, uint edad, int padding) : 
            base(nombre, apellido, edad, padding) 
        {
            Email = GenerateEmail();
        }

        protected Profesor()
        {
        }

        protected Profesor(string nombre, string apellido, uint edad, string email, string rutaFoto) : 
            base(nombre, apellido, edad, email, rutaFoto)
        {
        }

        public override string GenerateEmail()
        {
            return base.GenerateEmail() + "@trass.com";
        }

        public abstract override string ToString();

        public string ToStringProfesor()
        {
            return base.ToString() + 
                Materia.PadRight(base.Padding) + 
                $"{TipoProfesor}".PadRight(base.Padding);
        }
    }
}
