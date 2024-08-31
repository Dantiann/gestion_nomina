using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_nomina
{
    public partial class frmGestionnomina : Form
    {
        public frmGestionnomina()
        {
            InitializeComponent();
        }

        private void lblnomina_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // DECLARACIÓN DE VARIABLES
            string nombre, identificacion;
            float diasLaborados, sueldoBasico, horasExtras;
            const float auxilioTransporte = 140606;
            const float dosSalarios = 2320000;
            var salarioDevengado = 0.0f; var totalDevengado = 0.0f;
            var totalDeducciones = 0.0f; var netoPagado = 0.0f;
            var salarioDia = 0.0f;
            var bonificaciones = 0.01f;
            var salud = 0.04f;
            var pension = 0.04f;
            var arl = 0.0522f;
            var sindicato = 0.01f;
            var libranzas = 0.05f;

            // VINCULAR VARIABLES (LABEL) CON CAJAS DE TEXTO (TEXBOX)
            nombre = txtNombre.Text;
            identificacion = txtIdentificacion.Text;
            sueldoBasico = float.Parse(txtSueldobasico.Text);
            diasLaborados = float.Parse(txtDiaslaborados.Text);
            horasExtras = float.Parse(txtHorasextras.Text);
                        
            //SAlARIO DEVENGADO
            salarioDia = sueldoBasico / 30;
            salarioDevengado = salarioDia * diasLaborados;
            horasExtras = (sueldoBasico/240) * (horasExtras*1.25f);

            // Bonificación
            if (chkBonificaciones.Checked)
            {
                bonificaciones *= salarioDevengado;
            }
            else
            {
                bonificaciones = 0.0f;
            }
            
            // Auxilio de Transporte
            var auxilio = 0.0f;
            if (salarioDevengado > 0 && salarioDevengado <= dosSalarios)
            {
                auxilio = auxilioTransporte;
            }
            else
            {
                auxilio = 0.0f;
            }
            
            // Total devengado
            totalDevengado = salarioDevengado + (horasExtras + bonificaciones + auxilio);

            
            // DEDUCCIONES
            salud *= (totalDevengado - auxilio);
            pension *= (totalDevengado - auxilio);
            arl *= (totalDevengado - auxilio);

            // Sindicato
            if (chkSindicato.Checked)
            {
                sindicato *= (totalDevengado - auxilio);
            }
            else 
            {
                sindicato = 0.0f;
            }

            // Libranzas
            if (chkLibranzas.Checked)
            {
                libranzas *= (totalDevengado - auxilio);
            }
            else
            {
                libranzas = 0.0f;
            }

            // Total deducciones
            totalDeducciones = salud + pension + arl + sindicato + libranzas;

            // NETO PAGADO
            netoPagado = totalDevengado - totalDeducciones;


            // Adición al formulario DataGridView en orden a como se encuentra registrada cada columna con su nombre respectivo
            dgvGestionNomina.Rows.Add(nombre, identificacion, sueldoBasico, Convert.ToString(diasLaborados),
                salarioDevengado, horasExtras, bonificaciones, auxilio, totalDevengado, salud, pension,
                arl, sindicato, libranzas, totalDeducciones, netoPagado);

            // Limpiar el formulario
            txtNombre.Text = "";
            txtIdentificacion.Text = "";
            txtSueldobasico.Text = "";
            txtDiaslaborados.Text = "";
            txtHorasextras.Text = "";
            chkBonificaciones.Text = "";
            chkLibranzas.Text = "";
            chkSindicato.Text = "";          
           
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            dgvGestionNomina.Rows.Clear();
        }

        private void dgvGestionNomina_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
