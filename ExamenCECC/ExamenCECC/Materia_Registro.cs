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
    public partial class Materia_Registro : Form
    {
        public Materia_Registro()
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

            string query = "INSERT INTO tb_Materia (nombre_materia) " +
                            "VALUES (@Value1)";

            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@Value1", textBox1.Text);
                

                command.ExecuteNonQuery();
                MessageBox.Show("Exito");
            }

            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lista.Multiline = true;
            lista.Text = "";
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9ME3U4J\\SQLEXPRESS2008;Initial Catalog=CECC Examen;Integrated Security=True");
            con.Open();
            SqlCommand command = new SqlCommand("select * from tb_materia", con);
            command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        
                            int materiaId = reader.GetInt32(reader.GetOrdinal("pk_materia"));
                            string nombreMateria = reader.GetString(reader.GetOrdinal("nombre_materia"));
                            lista.Text += String.Format
                            ("ID: {0}, Nombre de la materia: {1} " + Environment.NewLine
                               , materiaId, nombreMateria);
                        
                    }
                }
            }
            con.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9ME3U4J\\SQLEXPRESS2008;Initial Catalog=CECC Examen;Integrated Security=True");
            con.Open();
            int valor;
            if (int.TryParse(eliminarBuscar.Text, out valor))
            {
                SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM tb_materia WHERE pk_materia=@valor", con);
                checkCommand.Parameters.AddWithValue("@valor", valor);
                int count = (int)checkCommand.ExecuteScalar();
                if (count > 0)
                {
                    // If exists, delete the record
                    SqlCommand deleteCommand = new SqlCommand("DELETE FROM tb_materia WHERE pk_materia=@valor", con);
                    deleteCommand.Parameters.AddWithValue("@valor", valor);
                    deleteCommand.ExecuteNonQuery();
                    MessageBox.Show("Eliminado con exito");
                }
                else
                {
                    MessageBox.Show("No se encontró el id");
                }

            }
            con.Close(); 
        }
    }
}
