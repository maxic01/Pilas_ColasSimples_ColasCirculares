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
    public partial class FormPila : Form
    {
        //LIFO Last in first out, el último en entrar es el primero en salir.
        //Push: Apila un elemento a la pila, es decir agrega un item como si añadiéramos un plato a una pila de platos en una cocina.
        //Pop: Desapila un elemento, y como hablamos de pilas, será el último elemento apilado
        //Peek: Nos da el primer elemento de la pila pero no lo desapila, es decir sigue siendo parte de la pila.

        public FormPila()
        {
            InitializeComponent();
            groupBox1.Enabled = false;
            btnEliminar.Enabled = false;
        }
        int cantidadMax = 0;

        Pila pila;
        private void btnSubmitCantidad_Click(object sender, EventArgs e)
        {
            if (txtClienteCant.Text != string.Empty && txtClienteCant.Text != "0")
            {
                cantidadMax = Convert.ToInt32(txtClienteCant.Text);

                pila = new Pila(cantidadMax);

                groupBox1.Enabled = true;

                groupBox2.Enabled = false;

                btnEliminar.Enabled = true;

                txtNombre.Focus();
            }
            else
            {
                MessageBox.Show("Debe de agregar un valor numerico mayor que cero", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSubmitDatos_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != string.Empty && txtApellido.Text != string.Empty && txtPrecio.Text != string.Empty && txtHoras.Text != string.Empty)
            {
                pila.Agregar(txtNombre.Text, txtApellido.Text, Convert.ToDouble(txtPrecio.Text), 
                    Convert.ToDouble(txtPrecio.Text) * Convert.ToInt32(txtHoras.Text), Convert.ToInt32(txtHoras.Text), dataGridView1);

                txtNombre.Clear();

                txtApellido.Clear();

                txtPrecio.Clear();

                txtHoras.Clear();

                txtNombre.Focus();
            }
            else
            {
                MessageBox.Show("Los campos no pueden estar vacios", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            pila.Eliminar(dataGridView1);
        }

        private void btnReiniciarPila_Click(object sender, EventArgs e)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
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
