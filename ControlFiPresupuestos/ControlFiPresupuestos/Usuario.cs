using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presupuesto
{
    public class Usuario
    {
        private string id;
        private string password;

        public void crearUsuario()
        {
            string cadena = @"INSERT INTO usuario VALUES('" + this.id + "'," + this.password + "')";

            return cadena;
        }

        public void modificarUsuario()
        {
            throw new System.NotImplementedException();
        }

        public void eliminarUsuario()
        {
            throw new System.NotImplementedException();
        }

        public void consultarUsuario()
        {
            throw new System.NotImplementedException();
        }
    }
}
