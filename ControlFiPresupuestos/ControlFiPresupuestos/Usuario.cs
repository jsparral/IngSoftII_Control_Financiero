using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlFiPresupuestos
{
    public class Usuario
    {
        private string id;
        private string password;

        public Usuario() {


        }

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value; ;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string crearUsuario()
        {
            string cadena = @"INSERT INTO usuario VALUES('" + this.Id + "'," + this.Password + "')";

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

        public string consultarUsuario()
        {
            string cadena = @"select * from usuario";

            return cadena;
        }
    }
}
