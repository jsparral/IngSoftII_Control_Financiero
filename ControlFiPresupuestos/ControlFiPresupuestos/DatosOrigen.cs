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
        private string feccontrato;
        private string convenio;

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

        public string Feccontrato
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

        public string Convenio
        {
            get
            {
                return convenio;
            }

            set
            {
                convenio = value;
            }
        }

        public string consultarOrigenes()
        {

            string cadena = @"select * from datosorigen";
            return cadena;
        }

        public string InsertarOrigen() {

            string cadena = @"insert into datosorigen values('" + this.identificacion + "','" + this.nombre + "','" + this.contrato + "','" + this.feccontrato + "','" + this.convenio + "')";

            return cadena;
        }



        public string EliminarDatosOrigen()

        {

            string cadena = @"delete from datosorigen where(identificacion= '" + this.identificacion + "')";

            return cadena;

        }



        public string ModificarOrigen()

        {

            string cadena = @"update datosorigen set nombre='" + this.nombre + "', contrato='" + this.contrato + "', fecha_contrato='" + this.feccontrato + "', convenio='" + this.convenio + "' where(identificacion= '" + this.identificacion + "')";

            return cadena;

        }

        public string ConsultarUnDatosOrigen()

        {

            string cadena = @"select * from datosorigen where(identificacion= '" + this.identificacion + "')";

            return cadena;

        }

    }
}