﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Pilas_ColasSimples_ColasCirculares
{
    class ColaCirular
    {

        int final = -1, frente = -1, Cantidadmax;
        struct Clientes
        {
            public string nombre, apellido;
            public double precio, total;
            public int horas;
        }
        Clientes[] cliente;

        public ColaCirular(int cantidadMax)
        {
            this.Cantidadmax = cantidadMax;
            cliente = new Clientes[cantidadMax];
        }

        public void Agregar(string nombre, string apellido, double precio, double total, int horas, DataGridView dgv)
        {
            if ((final == Cantidadmax - 1 && frente == 0) || (final + 1 == frente))
            {
                MessageBox.Show("cola llena.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (final == Cantidadmax - 1)
                {
                    final = 0;
                }
                else
                {
                    final++;
                }

                cliente[final].nombre = nombre;
                cliente[final].apellido = apellido;
                cliente[final].precio = precio;
                cliente[final].total = total;
                cliente[final].horas = horas;

                dgv.Rows.Add(cliente[final].nombre, cliente[final].apellido,
                  cliente[final].precio, cliente[final].horas, cliente[final].total);

                if (frente == -1)
                {
                    frente = 0;
                }
            }
        }

        public void Eliminar(DataGridView dgv)
        {

            if (frente == -1)
            {
                MessageBox.Show("cola vacia.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dgv.Rows.RemoveAt(0);

                if (frente == final)
                {
                    frente = -1;
                    final = -1;
                }
                else
                {
                    if (frente == Cantidadmax - 1)
                    {
                        frente = 0;
                    }
                    else
                    {
                        frente++;
                    }
                }
            }
        }
    }
}
