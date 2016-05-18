using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlFiPresupuestos
{
    private class DatosOrigen
    {
        private string identificacion;
        private string nombre;
        private string contrato;
        private DateTime feccontrato;
        private string covenio;

        public string Identificacion
        {
            get
            {
                return identificacion;
            }

            set
            {
                identificacion = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Contrato
        {
            get
            {
                return contrato;
            }

            set
            {
                contrato = value;
            }
        }

        public DateTime Feccontrato
        {
            get
            {
                return feccontrato;
            }

            set
            {
                feccontrato = value;
            }
        }

        public string Covenio
        {
            get
            {
                return covenio;
            }

            set
            {
                covenio = value;
            }
        }

        public void consultarOrigen()
        {
            throw new System.NotImplementedException();
        }

        public string guardarOrigen() {

            string cadena = @"insert into datosorigen values('"this.identificacion"','"this.Nombre"','"this.Contrato"','"this."')";
            return cadena;
        }
    }
}