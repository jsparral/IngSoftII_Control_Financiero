using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
namespace ControlFiPresupuestos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ControlContrasena();


         



        }

        private void ControlContrasena() {

            textBox2.Text = "";
            textBox2.PasswordChar = '*';
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msg = "";
            try
            {
                Usuario usu=new Usuario();
               


                ConectarPostgres conn = new ConectarPostgres();

                NpgsqlDataReader ds;
                conn.GestCadena=usu.consultarUsuario();
                ds=conn.Consulta(out msg);

                //Revisar 
                while (ds.Read())

                {

                    usu.Id = ds.GetString(0);

                    usu.Password = ds.GetString(1);


                    if ((usu.Id == textBox1.Text) && (usu.Password == textBox2.Text))
                    {

                        toolStripStatusLabel1.Text = "Datos correctos";
                        textBox1.Text = "";
                        textBox2.Text = "";
                        MDIParent1 f2 = new MDIParent1();
                        f2.Show();


                    }
                    else
                    {

                        toolStripStatusLabel1.Text = "Usuario o contraseña Incorrectos";

                    }


                }


            }
            catch (Exception ex)
            {

                toolStripStatusLabel1.Text = ex.Message;

                
            }


        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
