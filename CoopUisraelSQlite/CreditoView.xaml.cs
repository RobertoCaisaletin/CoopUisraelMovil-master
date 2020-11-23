using System;
using System.Collections.Generic;
using System.IO;
using CoopUisraelSQlite.Models;
using SQLite;
using Xamarin.Forms;

namespace CoopUisraelSQlite
{
    public partial class CreditoView : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        public CreditoView()
        {
            InitializeComponent();
            _conn = DependencyService.Get<DataBase>().GetConnection(); // inicializo la variable
        }

        void btn_CrearCredito_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
               
                var DatosRegistro = new Credito { Nombres = txtNombres.Text, Apellidos = txtApellidos.Text,Direccion=txtDireccion.Text, Monto = txtMonto.Text, Plazo=txtPlazo.Text };
                _conn.InsertAsync(DatosRegistro);
                //Console.WriteLine("datos registrados "+ DatosRegistro.Apellidos);
                limpiarFormulario();
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "OK");  // try  captura las exceciones
            }
        }
        void limpiarFormulario()
        {
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtDireccion.Text = "";
            txtMonto.Text = "";
            txtPlazo.Text = "";
            DisplayAlert("Alerta", "Se agrego correctamente", "OK");
        }
    }
}
