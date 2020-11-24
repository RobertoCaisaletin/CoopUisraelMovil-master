using CoopUisraelSQlite.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoopUisraelSQlite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection _conn;

        public Registro()
        {
            InitializeComponent();
            _conn = DependencyService.Get<DataBase>().GetConnection(); // inicializo la variable
        }

        private void btn_agregar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var DatosRegistro = new Estudiante { Nombre = Nombre.Text, Usuario = Usuario.Text, Contrasenia = Contrasenia.Text, Direccion = Direccion.Text};
                _conn.InsertAsync(DatosRegistro);
                limpiarFormulario();
            }
            catch(Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "OK");  // try  captura las exceciones
            }
        }

        void limpiarFormulario() 
        {
            Nombre.Text = "";
            Usuario.Text = "";
            Contrasenia.Text = "";
            Direccion.Text = "";
            DisplayAlert("Alerta", "Se agrego correctamente", "OK");
        }

        private async void btn_Mapa_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Mapa());
        }
    }
}