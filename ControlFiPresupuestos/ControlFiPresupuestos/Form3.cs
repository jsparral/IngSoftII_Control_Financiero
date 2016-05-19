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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //button2.Enabled = false;
            //button3.Enabled = false;
            //button4.Enabled = false;
            //button5.Enabled = false;
            textBox1.Focus();

            //Carga consulta en grilla

            dataGridView1.DataSource = bindingSource1;
            GetData("select * from datosorigen");



            


        }

        //funcion carga datos en grilla
        private void GetData(string selectCommand)
        {
            try
            {
               
                String cad = "Server=localhost;Port=5432;Database=presupuesto;User Id=postgres;Password=postgres";
                
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(selectCommand,cad);

               
                NpgsqlCommandBuilder commandBuilder = new NpgsqlCommandBuilder(dataAdapter);

                
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                bindingSource1.DataSource = table;

                
                dataGridView1.AutoResizeColumns(
                    DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            }
            catch (NpgsqlException)
            {
                MessageBox.Show("Error de consulta");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
           
            //validar casillas
            if ((string.IsNullOrEmpty(textBox1.Text)) || (string.IsNullOrEmpty(textBox2.Text)) || (string.IsNullOrEmpty(textBox3.Text)) ||(string.IsNullOrEmpty(textBox5.Text)))
            {
                MessageBox.Show("Verifique todos los campos");
            }
            else {






                //inserta registros de entidades
                DatosOrigen dataor = new DatosOrigen();
                dataor.Identificacion = textBox1.Text;
                    dataor.Nombre = textBox2.Text;
                    dataor.Contrato = textBox3.Text;
                    dataor.Feccontrato = dateTimePicker1.Value.ToShortDateString();
                    dataor.Convenio = textBox5.Text;

                    ConectarPostgres conn = new ConectarPostgres();

                    conn.GestCadena = dataor.InsertarOrigen();
                    toolStripLabel1.Text = conn.EjecutarSQL();

                
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
            }

            ////Activar casillas
            //textBox1.Enabled = true;
            //textBox2.Enabled = true;
            //textBox3.Enabled = true;
            ////textBox4.Enabled = true;
            //textBox5.Enabled = true;
            //dateTimePicker1.Enabled = true;
            //textBox1.Focus();

            //insertar un registro en la bbdd
           



        }

        private void button2_Click(object sender, EventArgs e)
        {

          


            
            //actualiza la grilla

            dataGridView1.DataSource = bindingSource1;
            DatosOrigen dataor = new DatosOrigen();
            GetData(dataor.consultarOrigenes());
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //inactivar botones que no necesito
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            textBox1.Focus();
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox5.Enabled=true;
            dateTimePicker1.Enabled = true;

            //
            if ((string.IsNullOrEmpty(textBox1.Text)))
            {
                MessageBox.Show("Verifique el número");
            }
            else { 
                string msg = "";
                try
                {
                    DatosOrigen dataor = new DatosOrigen();
                    dataor.Identificacion = textBox1.Text;
                    ConectarPostgres conn = new ConectarPostgres();
                    NpgsqlDataReader ds;
                    conn.GestCadena = dataor.ConsultarUnDatosOrigen();
                    ds = conn.Consulta(out msg);
                    toolStripLabel1.Text = msg;
                    if (ds.Read())
                    {
                        textBox2.Text = ds.GetString(1);
                        textBox3.Text = ds.GetString(2);
                        textBox5.Text = ds.GetString(4);
                        

                    }
                    conn.CerrarBase(out msg);
                }
                catch (Exception ex)
                {
                    toolStripLabel1.Text = msg + ex.Message;
                }

            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {

            //modifica  registros de entidades
            DatosOrigen dataor = new DatosOrigen();
            dataor.Identificacion = textBox1.Text;
            dataor.Nombre = textBox2.Text;
            dataor.Contrato = textBox3.Text;
            dataor.Feccontrato = dateTimePicker1.Value.ToShortDateString();
            dataor.Convenio = textBox5.Text;

            ConectarPostgres conn = new ConectarPostgres();

            conn.GestCadena = dataor.ModificarOrigen();
            toolStripLabel1.Text = conn.EjecutarSQL();


        }

        private void button3_Click(object sender, EventArgs e)
        {

            //modifica  registros de entidades
            DatosOrigen dataor = new DatosOrigen();
            dataor.Identificacion = textBox1.Text;
           
            ConectarPostgres conn = new ConectarPostgres();

            conn.GestCadena = dataor.EliminarDatosOrigen();
            toolStripLabel1.Text = conn.EjecutarSQL();


        }
    }
}
