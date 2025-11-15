using _2HerenciaSimpleIES.Clases;
using _2HerenciaSimpleIES.Interfaces;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace IGraficasIES.Recursos
{
    public class ClaseWPFAuxiliar
    {
        public const string RUTA_IMG = "..\\..\\..\\Imagenes\\";

        public static ImageSource RutaImagen(Profesor p)
        {
            return (new ImageSourceConverter()).ConvertFromString(RUTA_IMG + p.RutaFoto) as ImageSource;
        }

        public static ImageSource RutaImagen(string rutaFoto)
        {
            return (new ImageSourceConverter()).ConvertFromString(RUTA_IMG + rutaFoto) as ImageSource;
        }

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

        public static string ConsultaFormateada<T>(IEnumerable<T> lista)
        {
            StringBuilder sb = new();

            foreach (var persona in lista)
            {
                System.Reflection.PropertyInfo[] props = persona.GetType().GetProperties();
                foreach (var prop in props)
                {
                    sb.Append($"{prop.Name}: {prop.GetValue(persona)?.ToString()}\n");
                }
                sb.Append("\n----------------------\n");
            }

            return sb.ToString();
        }

        public static string ConsultaGroupByFormateada<T>(IEnumerable<T> listaAgrupada)
        {
            var sb = new StringBuilder();

            foreach (var grupo in listaAgrupada)
            {
                var tipoGrupo = grupo.GetType();

                // Obtener propiedad Estado
                var propEstado = tipoGrupo.GetProperty("Estado");
                var estadoVal = propEstado?.GetValue(grupo)?.ToString() ?? "(null)";

                sb.AppendLine($"Estado: {estadoVal}");
                sb.AppendLine(new string('-', 30));

                // Obtener propiedad Valores (enumerable)
                var propValores = tipoGrupo.GetProperty("Valores");
                if (propValores == null)
                {
                    sb.AppendLine("Valores: (propiedad no encontrada)");
                    sb.AppendLine();
                    continue;
                }

                System.Collections.IEnumerable? valoresObj = propValores.GetValue(grupo) as System.Collections.IEnumerable;
                if (valoresObj == null)
                {
                    sb.AppendLine("Valores: (no enumerable)");
                    sb.AppendLine();
                    continue;
                }

                foreach (var elemento in valoresObj)
                {
                    var propsElemento = elemento.GetType().GetProperties();
                    foreach (var p in propsElemento)
                    {
                        var val = p.GetValue(elemento);
                        sb.AppendLine($"{p.Name}: {val}");
                    }
                    sb.AppendLine();
                }

                sb.AppendLine(new string('-', 30));
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
