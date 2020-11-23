using CoopUisraelSQlite.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoopUisraelSQlite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        private ObservableCollection<Credito> _Tablaestudiante;  //contenedor de datos 
      

        public ConsultaRegistro(string usuario)
        {
            InitializeComponent();
            _conn = DependencyService.Get<DataBase>().GetConnection(); 
            NavigationPage.SetHasBackButton(this, false);
            lbUsuario.Text = usuario;
            
        }

        protected async override void OnAppearing()
        {
            var DataBasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
            var db = new SQLiteConnection(DataBasePath); // variable de conexion

            db.CreateTable<Credito>();
            var ResulRegistros = await _conn.Table<Credito>().ToListAsync(); // creo una variable de regitros
            _Tablaestudiante = new ObservableCollection<Credito>(ResulRegistros);
            ListaUsuarios.ItemsSource = _Tablaestudiante;
            base.OnAppearing();
        }


        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (Credito)e.SelectedItem;
            var item = Obj.Id.ToString();
            int ID = Convert.ToInt32(item);
            try
            {
                Navigation.PushAsync(new CreditoSeleccion(ID,lbUsuario.Text ,Obj.Nombres.ToString(), Obj.Apellidos.ToString(),Obj.Direccion.ToString(),Obj.Monto.ToString(),Obj.Plazo.ToString())); // abre una nueva ventana de ese campo elemento
            }
            catch (Exception)
            {
                throw;
            }
        }

        void btn_CrearCredito_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new CreditoView());
        }

        void btn_InformacionCredito_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Info());
        }
      
    }
}