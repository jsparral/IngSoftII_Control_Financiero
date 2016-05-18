using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlFiPresupuestos
{
    public class DetalleCategoria:CategoriaGastos
    {
        private string descripcion;
        private int valor;



        public string Descripcion1
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

        public int Valor1
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

        public string  guardarDetalleCategoria()
        {

            string cadena = @"INSERT INTO deta_categoria VALUES(2,'" + this.descripcion + "'," + this.valor + ",1)";

            return cadena;
            throw new System.NotImplementedException();
        }
    }
}