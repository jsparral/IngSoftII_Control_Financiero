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
            if ((string.IsNullOrEmpty(textBox1.Text)) && (string.IsNullOrEmpty(textBox2.Text)) && (string.IsNullOrEmpty(textBox3.Text)) && (string.IsNullOrEmpty( textBox5.Text)))
            {
                MessageBox.Show("Verifique todos los campos");
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
            DatosOrigen dataor = new DatosOrigen();
            dataor.Identificacion = textBox1.Text;
            dataor.Nombre = textBox2.Text;
            dataor.Contrato = textBox3.Text;
            dataor.Feccontrato = dateTimePicker1.Value.ToShortDateString();
            dataor.Convenio = textBox5.Text;

            ConectarPostgres conn = new ConectarPostgres();

            conn.GestCadena = dataor.InsertarOrigen();
            toolStripLabel1.Text = conn.EjecutarSQL();



        }

        private void button2_Click(object sender, EventArgs e)
        {

          



            //actualiza la grilla

            dataGridView1.DataSource = bindingSource1;
            GetData("select * from datosorigen");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
