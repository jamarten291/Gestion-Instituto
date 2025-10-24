using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2HerenciaSimpleIES.Clases
{
    public class ProfesorInterino : Profesor
    {
        public ProfesorInterino(string nombre, string apellidos, uint edad, int padding) : 
            base(nombre, apellidos, edad, padding) {
        }

        public ProfesorInterino(string nombre, string apellidos, uint edad, string materia, Profesor.TipoFuncionario tipoProfesor, int padding) : 
            base(nombre, apellidos, edad, padding)
        {
            Materia = materia;
            TipoProfesor = tipoProfesor;
        }

        public override string ToString()
        {
            return base.ToStringProfesor();
        }
    }
}
