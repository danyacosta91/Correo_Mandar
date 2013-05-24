using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Correo
{
    public partial class Form1 : Form
    {
        Correo_Mandar correo = new Correo_Mandar();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            try
            {
                correo.Establecer_Iniciales(this.user.Text, this.password.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(null,"Error de Ingreso","Error",MessageBoxButtons.RetryCancel);
            }
            */

            try
            {
                correo.Establecer_Iniciales(this.user.Text, this.password.Text);
                correo.Enviar_Correo("acosta_g_885@hotmail.com;jos_ant032@hotmail.com;", "Quiero ver si se envio este correo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
