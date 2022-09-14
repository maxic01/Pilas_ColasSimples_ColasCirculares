using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pilas_ColasSimples_ColasCirculares
{
    public partial class FormColaCircular : Form
    {
        //Una cola circular o anillo es una estructura de datos  en la que los elementos están de forma circular y cada elemento
        //tiene un sucesor y un predecesor. Los elementos pueden consultarse, añadirse y eliminarse únicamente desde la cabeza
        //del anillo que es una posición distinguida.
        public FormColaCircular()
        {
            InitializeComponent();
            groupBox1.Enabled = false;
            btnEliminar.Enabled = false;
            btn_reiniciar_cola.Enabled = false;
        }

        int cantidadMax = 0;

        ColaCirular registro;
        private void btnSubmitCantidad_Click_1(object sender, EventArgs e)
        {
            if (txtClienteCant.Text != string.Empty)
            {
                cantidadMax = Convert.ToInt32(txtClienteCant.Text);

                registro = new ColaCirular(cantidadMax);

                groupBox2.Enabled = false;

                groupBox1.Enabled = true;

                btnEliminar.Enabled = true;

                btn_reiniciar_cola.Enabled = true;

                txtNombre.Focus();
            }
            else
            {
                MessageBox.Show("debe ingresar una cantidad", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btn_reiniciar_cola_Click(object sender, EventArgs e)
        {
            cantidadMax = 0;
            txtClienteCant.Clear();
            txtNombre.Clear();
            txtHoras.Clear();
            txtApellido.Clear();
            txtPrecio.Clear();
            dataGridView1.Rows.Clear();
            groupBox2.Enabled = true;
            groupBox1.Enabled = false;
            txtClienteCant.Focus();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            registro.Eliminar(dataGridView1);
        }

        private void btnSubmitDatos_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNombre.Text) || 
                    string.IsNullOrEmpty(txtApellido.Text)  || 
                    string.IsNullOrEmpty(txtPrecio.Text) ||
                    string.IsNullOrEmpty(txtHoras.Text)){}

                registro.Agregar(txtNombre.Text, txtApellido.Text, Convert.ToDouble(txtPrecio.Text),
                        Convert.ToDouble(txtPrecio.Text) * Convert.ToInt32(txtHoras.Text), 
                        Convert.ToInt32(txtHoras.Text), dataGridView1);


                    txtNombre.Clear();
                    txtHoras.Clear();
                    txtApellido.Clear();
                    txtPrecio.Clear();
                    txtNombre.Focus();
              
            }
            catch (Exception)
            {
                 MessageBox.Show("debe ingresar datos en todos los campos.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
}
        /*
         * Al presionar la Tecla ""Enter"" de nuestro teclado,
         * por cada campo, iran pasando en orden 
         * haciendo que se rellenen los campos mas rapidos, 
         * para esto se usaron los eventos de los textbox
         * el cual es el Keypress para obtener la tecla presionada.
         */
        #region Focus de Textbox para Pasar de uno a otro

       
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtApellido.Focus();
            }
        }

        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtPrecio.Focus();
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtHoras.Focus();
            }
        }

        private void txtHoras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnSubmitDatos.Focus();
            }
        }

        private void txtClienteCant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                 btnSubmitCantidad.Focus();
            }
        }

        #endregion

        //evento para poder mover la ventana donde nosotros queramos
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            int PosY = 0;
            int PosX = 0;

            if (e.Button != MouseButtons.Left)
            {
                _ = e.X;
                _ = e.Y;
            }
            else
            {
                Left = Left + (e.X - PosX);
                Top = Top + (e.Y - PosY);
            }
        }
    }
}
