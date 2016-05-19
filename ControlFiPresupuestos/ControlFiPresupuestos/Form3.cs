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
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bindingSource1;
            GetData("select * from datosorigen");
        }
    }
}
