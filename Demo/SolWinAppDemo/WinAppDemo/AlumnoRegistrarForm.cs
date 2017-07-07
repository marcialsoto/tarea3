using Demo.BE;
using Demo.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppDemo
{
    public partial class AlumnoRegistrarForm : Form
    {
        public AlumnoRegistrarForm()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                txtNombres.Text = "";
                txtApellidos.Text = "";
                txtPractica1.Text = "0";
                txtPractica2.Text = "0";
                txtPractica3.Text = "0";
                txtPractica4.Text = "0";
                txtParcial.Text = "0";
                txtFinal.Text = "0";
                lblPromedioPractica.Text = "0";
                lblP.Text = "0";
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void btnCalcularPromedio_Click(object sender, EventArgs e)
        {
            try
            {
                List<NotaBE> ListaNotas = new List<NotaBE>();
                NotaBE nota = new NotaBE();
                //agregando Practica 1
                nota.Nota = decimal.Parse(txtPractica1.Text);
                ListaNotas.Add(nota);

                //agregando Practica 2
                nota = new NotaBE();
                nota.Nota = decimal.Parse(txtPractica2.Text);
                ListaNotas.Add(nota);

                //agregando Practica 3
                nota = new NotaBE();
                nota.Nota = decimal.Parse(txtPractica3.Text);
                ListaNotas.Add(nota);

                //agregando Practica 4
                nota = new NotaBE();
                nota.Nota = decimal.Parse(txtPractica4.Text);
                ListaNotas.Add(nota);

                List<NotaBE> ListaOrdenada = ListaNotas.OrderByDescending(x => x.Nota).ToList();
                Decimal PromedioPracticas = PromedioPractica(ListaOrdenada);

                AlumnoBE alumno = new AlumnoBE();
                alumno.Nombres = txtNombres.Text.Trim();
                alumno.apellidos = txtApellidos.Text.Trim();
                alumno.Practica1 = decimal.Parse(txtPractica1.Text.Trim());
                alumno.Practica2 = decimal.Parse(txtPractica2.Text.Trim());
                alumno.Practica3 = decimal.Parse(txtPractica3.Text.Trim());
                alumno.Practica4 = decimal.Parse(txtPractica4.Text.Trim());
                alumno.MenorPractica = ListaOrdenada[3].Nota;
                alumno.ExamenParcial = decimal.Parse(txtParcial.Text.Trim());
                alumno.ExamenFinal = decimal.Parse(txtFinal.Text.Trim());
                alumno.PromedioPracticas = PromedioPracticas;
                alumno.PromedioFinal = (PromedioPracticas*0.4m) + (alumno.ExamenParcial*0.2m) + (alumno.ExamenFinal*0.4m);
                if (chkEstado.Checked)
                {
                    alumno.Estado = 1;
                }
                else {
                    alumno.Estado = 0;
                }
                CalculoBL objBL = new CalculoBL();
                int resultado = objBL.RegistrarDetalleCliente(alumno);
                if (resultado > 0)
                {
                    MessageBox.Show("Se guardaron los cambios correctamente!!!");
                }
                lblPromedioPractica.Text = PromedioPracticas.ToString();
                lblP.Text = alumno.PromedioFinal.ToString();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void txtPractica1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPractica1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtPractica1_KeyPress(object sender, KeyPressEventArgs e)
        {
            CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;
            if (char.IsNumber(e.KeyChar) || e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator || Convert.ToInt32(e.KeyChar) == 8)
            {
                //int coma = 0;
                //for (int i = 0; i < txtPractica1.Text.Trim().Length; i++)
                //{
                //    if (txtPractica1.Text.Substring(i,1) == ",")
                //    {
                //        coma++; 
                //    }
                //}
                //if (coma < 1)
                //{
                //    MessageBox.Show("Solo se puede ingresar una coma decimal!!!");
                //    e.Handled = false;
                //}
                //else {
                //    e.Handled = true;
                //}
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Debe ingresar solo Numeros!!!");
            }
        }

        private void txtPractica1_KeyUp_1(object sender, KeyEventArgs e)
        {
            try
            {
                if (txtPractica1.Text.Trim().Length > 0)
                {
                    if (decimal.Parse(txtPractica1.Text) < 0 || decimal.Parse(txtPractica1.Text) > 20)
                    {
                        MessageBox.Show("Debe ingresar Numeros entre 1 y 20 !!!");
                        txtPractica1.Text = txtPractica1.Text.Trim().Substring(0, txtPractica1.Text.Trim().Length - 1);
                    }    
                }
                
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private decimal PromedioPractica(List<NotaBE> ListaOrdenada)
        {
            try
            {
                decimal total = 0;
                for (int i = 0; i < ListaOrdenada.Count - 1; i++)
                {
                    total += ListaOrdenada[i].Nota;
                }
                return total / 3;
            }
            catch (Exception)
            {
                
                throw;
            }
        }



    
    }
}
