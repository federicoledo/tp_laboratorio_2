using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtNum1.Text = "";
            this.txtNum2.Text = "";
            this.lblResultado.Text = "";
            this.cmbOperacion.Text = "";
        }

        private void btnResultado_Click(object sender, EventArgs e)
        {
            Numero num1 = new Numero(this.txtNum1.Text);
            Numero num2 = new Numero(this.txtNum2.Text);
            this.cmbOperacion.Text = Calculadora.validarOperador(this.cmbOperacion.Text);
            Numero resultado = new Numero(Calculadora.operar(num1, num2, this.cmbOperacion.Text));
            this.lblResultado.Text = resultado.getNumero().ToString("N3");
        }
    }
}
