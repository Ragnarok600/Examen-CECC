using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExamenCECC
{
    public partial class Menu_Inicio : Form
    {
        public Menu_Inicio()
        {
            InitializeComponent();
        }

        private void Menu_Inicio_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Maestro_Registro form2 = new Maestro_Registro();
            
            // Show Form2
            form2.Show();
            this.Hide();
            form2.FormClosed += (s, args) => Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Alumno_Registro form2 = new Alumno_Registro();

            // Show Form2
            form2.Show();
            this.Hide();
            form2.FormClosed += (s, args) => Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Materia_Registro form2 = new Materia_Registro();

            // Show Form2
            form2.Show();
            this.Hide();
            form2.FormClosed += (s, args) => Application.Exit();
        }
    }
}
