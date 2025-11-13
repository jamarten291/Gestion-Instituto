using _2HerenciaSimpleIES.Clases;
using _2HerenciaSimpleIES.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGraficasIES.Recursos
{
    public class ClaseWPFAuxiliar
    {
        public static string RutaImagenes = "..\\..\\..\\Imagenes\\";

        public static Profesor.TipoFuncionario StringToFuncionario(string tipo)
        {
            return tipo.ToLower().Trim() switch
            {
                "en practicas" or "en prácticas" => Profesor.TipoFuncionario.EnPracticas,
                "de carrera" => Profesor.TipoFuncionario.DeCarrera,
                _ => throw new ArgumentException("Tipo de funcionario no válido")
            };
        }

        public static IEmpleadoPublico.TipoMedico StringToTipoMedico(string tipo)
        {
            return tipo.ToLower().Trim() switch
            {
                "ss" => IEmpleadoPublico.TipoMedico.SeguridadSocial,
                "muface" => IEmpleadoPublico.TipoMedico.Muface,
                _ => throw new ArgumentException("Tipo de médico no válido")
            };
        }
    }
}
