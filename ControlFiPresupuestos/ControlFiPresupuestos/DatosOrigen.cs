using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlFiPresupuestos
{
    public class DatosOrigen
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

        public string consultarOrigenes()
        {

            string cadena = @"select * from datosorigen";
            return cadena;
        }

        public string guardarOrigen() {

            string cadena = @"insert into datosorigen values('"+this.identificacion+"','"+this.nombre+"','"+this.contrato+"','"+this.feccontrato+"','"+this.covenio+"')";
            return cadena;
        }
       


    }
}