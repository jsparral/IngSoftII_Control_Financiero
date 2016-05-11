using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presupuesto
{
    public class Proyecto
    {
        private string descripcion;
        private string origen;
        private double valor;

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

        public string Origen
        {
            get
            {
                return origen;
            }

            set
            {
                origen = value;
            }
        }

        public double Valor
        {
            get
            {
                return valor;
            }

            set
            {
                valor = value;
            }
        }








        /// <summary></summary>
        public string crearProyecto()
        {

            string cadena=@"INSERT INTO proyecto VALUES(1,'"+ this.descripcion + "','"+ this.origen + "',"+ this.valor + ",1,1)";

            return cadena;
            //throw new System.NotImplementedException();
        }

        public void consultarProyecto()
        {
            throw new System.NotImplementedException();
        }

        public void modificarProyecto()
        {
            throw new System.NotImplementedException();
        }

        public void eliminarProyecto()
        {
            throw new System.NotImplementedException();
        }
    }
}