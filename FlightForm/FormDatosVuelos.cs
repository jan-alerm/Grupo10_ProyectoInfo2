using FlightLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightForm
{
    public partial class FormDatosVuelos : Form
    {
        public FlightPlan Plan1 { get; private set; }
        public FlightPlan Plan2 { get; private set; }

        public FormDatosVuelos()
        {
            InitializeComponent();
        }

        private void txtboxID1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            string id1 = textBoxID1.Text;
            double OrigenX1 = Convert.ToDouble(textBoxOrigenX1.Text)
                , terigenY1, destinoX1, destinoY1, vel1;
            FlightPlan p1 = new FlightPlan();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
