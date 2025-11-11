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
            get 
            {
                return _estadoCivil;
            }
            set 
            {
                switch (value.ToString().ToLower())
                {
                    case "casado":
                        _estadoCivil = EstadoCivil.Casado;
                        break;
                    case "divorciado":
                        _estadoCivil = EstadoCivil.Divorciado;
                        break;
                    case "viudo":
                        _estadoCivil = EstadoCivil.Viudo;
                        break;
                    default:
                        _estadoCivil = EstadoCivil.Soltero;
                        break;
                }
            }
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

        public List<ProfesorExtendido> GetProfesE()
        {
            return new List<ProfesorExtendido>
            { 
                // TODO meter datos de profesores
            };
        }
    }
}
