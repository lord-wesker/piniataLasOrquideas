using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibOrquideas;

namespace appPractica1
{
    public partial class frmAlmacen : Form
    {
        public frmAlmacen()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            try
            {
                clsFacturar factura = new clsFacturar();

                factura.VrDocena = float.Parse(txtValorDocena.Text);
                factura.Cantidad = int.Parse(txtCantidad.Text);
                factura.PorcIVA = float.Parse(txtIVA.Text);

                if ( ! factura.Facturar() )
                    MessageBox.Show("Por favor verifique la validez de los datos ingresados. \n" + factura.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    lblSubTotal.Text = "$ " + factura.SubTotal.ToString();
                    lblDescuento.Text = "$ " + factura.VrDscto.ToString();
                    lblValorIVA.Text = "$ " + factura.VrIVA.ToString();
                    lblTotalAPagar.Text = "$ " + factura.TotalAPagar.ToString();
                    grbAPagar.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Por favor verifique la validez de los datos ingresados. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            grbAPagar.Visible = false;
            txtValorDocena.Clear();
            txtCantidad.Clear();
            txtIVA.Clear();
        }
    }
}
