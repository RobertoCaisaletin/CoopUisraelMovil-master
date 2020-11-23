using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CoopUisraelSQlite
{
    public partial class Simular : ContentPage
    {
        public Simular()
        {
            InitializeComponent();
        }
        void btn_SimularCredito_Clicked(System.Object sender, System.EventArgs e)
        {
            double valorTotal;
            double monto = Convert.ToDouble(txtMonto.Text);
            valorTotal = monto * 0.15;
            valorTotal = monto + valorTotal;
            lbpagoTotal.Text = valorTotal.ToString();
            int iCount = Convert.ToInt32(txtPlazo.Text);
            double pago= valorTotal / iCount;
            lbpagoMensual.Text = pago.ToString();

        }
    }
}
