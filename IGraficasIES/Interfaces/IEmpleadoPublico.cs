using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2HerenciaSimpleIES.Interfaces
{
    public interface IEmpleadoPublico
    {
        public enum TipoMedico : uint
        {
            SeguridadSocial = 1,
            Muface = 2
        }

        public TipoMedico Medico { get; set; }

        public (int anios, int meses, int dias) TiempoServicio();
        public int GetSexenios();
        public int GetTrienios();
    }
}
