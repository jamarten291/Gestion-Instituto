using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2HerenciaSimpleIES.Interfaces;

namespace _2HerenciaSimpleIES.Clases
{
    public class ProfesorFuncionario : Profesor , IEmpleadoPublico
    {
        private uint yearIngreso;
        private bool destinoDefinitivo;
        private DateTime fechaIngreso;
        private IEmpleadoPublico.TipoMedico tipoMedico;

        public ProfesorFuncionario(string nombre, string apellidos, uint edad, int padding) :
            base(nombre, apellidos, edad, padding) {
            FechaIngreso = new DateTime(1970, 9, 1);
        }

        public ProfesorFuncionario(string nombre, string apellidos, uint edad, string materia, 
            TipoFuncionario tipoProfesor, bool definitivo, uint yearIngreso, IEmpleadoPublico.TipoMedico tipoMedico, int padding) :
            base(nombre, apellidos, edad, padding)
        {
            Materia = materia;
            TipoProfesor = tipoProfesor;
            YearIngreso = yearIngreso;
            DestinoDefinitivo = definitivo;
            FechaIngreso = new DateTime((int) yearIngreso, 9, 1);
            Medico = tipoMedico;
        }

        public uint YearIngreso
        {
            get { return yearIngreso; }
            set { yearIngreso = value > 0 ? value : 0; }
        }

        public bool DestinoDefinitivo
        {
            get { return destinoDefinitivo; }
            set {  destinoDefinitivo = value; }
        }

        public DateTime FechaIngreso
        {
            get { return fechaIngreso; }
            set { fechaIngreso = value; }
        }

        public IEmpleadoPublico.TipoMedico Medico {
            get => tipoMedico;
            set => tipoMedico = value;
        }

        public (int anios, int meses, int dias) 
            TiempoServicio()
        {
            // Calcular el número de años
            int anios = DateTime.Now.Year - fechaIngreso.Year;
            int meses = DateTime.Now.Month - fechaIngreso.Month;
            int dias = DateTime.Now.Day - fechaIngreso.Day;

            // Ajustar si el día del mes del inicio es mayor que el día del mes final
            if (dias < 0)
            {
                meses--;
                dias += DateTime.DaysInMonth(
                    DateTime.Now.Year, DateTime.Now.Month - 1
                );
            }

            // Ajustar si el mes  es negativo
            if (meses < 0)
            {
                anios--;
                meses += 12;
            }

            return (anios, meses, dias);
        }

        public override string ToString()
        {
            return base.ToStringProfesor() + $"{YearIngreso}".PadRight(base.Padding) +
                $"{(DestinoDefinitivo ? "SI" : "NO")}".PadRight(base.Padding);
        }

        public int GetSexenios()
        {
            return (DateTime.Now.Year - FechaIngreso.Year) / 6;
        }

        public int GetTrienios()
        {
            return (DateTime.Now.Year - FechaIngreso.Year) / 3;
        }
    }
}
