using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;

namespace ControlFiPresupuestos
{
    class ConectarPostgres
    {
        private NpgsqlConnection conn = null;
        private String cadena;

        //constructor de la clase 
        public ConectarPostgres() {

            String cad = "Server=localhost;Port=5432;Database=presupuesto;User Id=postgres;Password=postgres";
            conn = new NpgsqlConnection(cad);

        }

        public String GestCadena {

            set { cadena = value; }
            get { return cadena; }

        }


        //ejecuta transacciones insert,update,delete,select

        public string EjecutarSQL() {


            string rta = "";

            try
            {
                conn.Open();
                NpgsqlCommand query = new NpgsqlCommand(cadena, conn);
                rta = query.ExecuteNonQuery().ToString();
                return "OK";


            }
            catch (Exception ex)

            {
                rta = ex.Message;
                           }
            finally {

                conn.Close();

            }

            return rta;
        }


        public NpgsqlDataReader Consulta(out string msg) {


            NpgsqlDataReader ds = null;
            msg = "";

            try
            {
                conn.Open();

                NpgsqlCommand query = new NpgsqlCommand(cadena,conn);
                ds = query.ExecuteReader();
                msg = "Consulta Satisfactoria";

            }
            catch (Exception ex)
            {

                msg= ex.Message;
                
            }
            return ds;
        }

        public string ObtenerReporte(DataSet ds)

        {

            string msg = "";

            try

            {

                conn.Open();

                NpgsqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = cadena;

                NpgsqlDataAdapter adap = new NpgsqlDataAdapter();

                adap.SelectCommand = cmd;

                adap.Fill(ds, "temporal");

                msg = "Consulta exitosa";

            }

            catch (Exception ex)

            {

                msg = ex.Message;

            }

            return msg;

        }




        public void CerrarBase(out string msg) {

            msg = "";
            try
            {
                conn.Close();
                msg = "Base de Datos Desconectada";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

        }



    }
}
