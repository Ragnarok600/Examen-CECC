using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ExamenCECC
{
    public partial class Alumno_Registro : Form
    {
        public Alumno_Registro()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menu_Inicio form2 = new Menu_Inicio();
            this.Hide();
            // Show Form2
            form2.Show();
            form2.FormClosed += (s, args) => Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9ME3U4J\\SQLEXPRESS2008;Initial Catalog=CECC Examen;Integrated Security=True");
            
            con.Open();

            string query = "INSERT INTO tb_Alumno (nombre, ap_paterno, ap_materno, matricula_alumno, fecha_ingreso, email, telefono) " +
                            "VALUES (@Value1, @Value2, @Value3, @Value4, GETDATE(), @Value5, @Value6)";

            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@Value1", textBox1.Text);
                command.Parameters.AddWithValue("@Value2", textBox2.Text);
                command.Parameters.AddWithValue("@Value3", textBox3.Text);
                command.Parameters.AddWithValue("@Value4", textBox4.Text);
                command.Parameters.AddWithValue("@Value5", textBox5.Text);
                command.Parameters.AddWithValue("@Value6", textBox6.Text);

                command.ExecuteNonQuery();
                MessageBox.Show("Exito");
            }
            
            con.Close();
        }
    }
}
