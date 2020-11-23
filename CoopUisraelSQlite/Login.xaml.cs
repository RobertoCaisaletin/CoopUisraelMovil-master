using CoopUisraelSQlite.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoopUisraelSQlite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection _conn;

        public Login()
        {
            InitializeComponent();
            _conn = DependencyService.Get<DataBase>().GetConnection();
        }

        private void btn_login_Clicked(object sender, EventArgs e)
        {
            try
            {
                // cre mi variable que accede a mi base 
                var DataBasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(DataBasePath); // variable de conexion

                db.CreateTable<Estudiante>(); // crea la tabla estudiante  mapeo los campos 
                IEnumerable<Estudiante> resultado = SELECT_WHERE(db, usuario.Text, contra.Text); // accedo a esa tabla o campos
                
                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new ConsultaRegistro(usuario.Text));
                }
                else
                {
                    DisplayAlert("Alerta", "Verifique su usuario y constraseña", "OK");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "OK");  // try  captura las exceciones
            }
        }

        public static IEnumerable<Estudiante> SELECT_WHERE(SQLiteConnection db, string usuario, string contra)
        {
            return db.Query<Estudiante>("SELECT * FROM Estudiante where Usuario = ? and Contrasenia = ?", usuario, contra);
        }

        private async void btn_registrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registro());
        }
    }
}