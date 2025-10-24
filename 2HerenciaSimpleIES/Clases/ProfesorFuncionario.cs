using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2HerenciaSimpleIES.Interfaces;
using Microsoft.VisualBasic;

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
            int anios = (int) DateAndTime.DateDiff(
                DateInterval.Year, fechaIngreso, DateTime.Now
            );
            int meses = (int) DateAndTime.DateDiff(
                DateInterval.Month, fechaIngreso, DateTime.Now
            // Se divide entre 12 y se saca el resto para obtener los meses restantes
            ) % 12;
            int dias = (int) DateAndTime.DateDiff(
                // Se le agregan los años y meses de servicio a la fecha de ingreso para obtener
                // los días restantes
                DateInterval.Day, fechaIngreso.AddYears(anios).AddMonths(meses), DateTime.Now
            );

            return (anios, meses, dias);
        }

        public string DatosFuncionario()
        {
            var (anios, meses, dias) = TiempoServicio();
            return $"Tiempo de SERVICIO: {anios} años, {meses} meses, {dias} días\n" +
                $"Nº de SEXENIOS: {GetSexenios()}\n" +
                $"Nº de TRIENIOS: {GetTrienios()}";
        }

        public override string ToString()
        {
            return base.ToStringProfesor() + $"{YearIngreso}".PadRight(base.Padding) +
                $"{(DestinoDefinitivo ? "SI" : "NO")}".PadRight(base.Padding) +
                Medico;
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
