using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pilas_ColasSimples_ColasCirculares
{
    class Pila
    {
        int tope = -1, maximo;

        public struct Clientes
        {
            public string nombre, apellido;
            public double precio, total;
            public int horas;
        }
        Clientes[] cliente;

        public Pila(int max)
        {
            maximo = max;
            cliente = new Clientes[maximo];
        }

        public bool pilaLlena()
        {
            if (tope == maximo -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool PilaVacia()
        {
            if (tope == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Agregar(string nombre, string apellido, double precio, double total, int horas, DataGridView dgv)
        {
            if (pilaLlena() == false)
            {
                tope++;

                cliente[tope].nombre = nombre;
                cliente[tope].apellido = apellido;
                cliente[tope].precio = precio;
                cliente[tope].horas = horas;
                cliente[tope].total = total;

                dgv.Rows.Add(cliente[tope].nombre, cliente[tope].apellido, cliente[tope].precio,
                    cliente[tope].horas, cliente[tope].total);
            }
            else
            {
                MessageBox.Show("la pila esta llena", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void Eliminar(DataGridView dgv)
        {
            if (PilaVacia() == false)
            {
                tope--;

                dgv.Rows.Clear();
                for (int i = 0; i <= tope; i++)
                {
                    if (tope != -1)
                    {
                        dgv.Rows.Add(cliente[i].nombre, cliente[i].apellido, cliente[i].precio,
                            cliente[i].horas, cliente[i].total);
                    }
                }
            }
            else
            {
                MessageBox.Show("la pila esta vacia.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
