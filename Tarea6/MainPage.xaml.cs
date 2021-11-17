using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Tarea6
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.1.7/moviles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Tarea6.Ws.Datos> _post;

        public MainPage()
        {
            InitializeComponent();
            get();
            //llenarDatos();
        }

        public async void get()
        {
            try
            {
                var content = await client.GetStringAsync(Url);
                List<Tarea6.Ws.Datos> posts = JsonConvert.DeserializeObject<List<Tarea6.Ws.Datos>>(content);
                _post = new ObservableCollection<Ws.Datos>(posts);

                MyListView.ItemsSource = _post;
            }
            catch(Exception ex)
            {
                DisplayAlert("Error", "Error" + ex.Message, "OK");
            }
        }

        //BOTON PARA MOSTRAR LOS REGISTROS DE LA TABLA ESTUDIANTES
        private async void btnGet_Clicked(object sender, EventArgs e)
        {
            
        }

        //BOTON PARA INSERTAR UN REGISTRO DE LA TABLA ESTUDIANTES
        private async void btnPost_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new vistaInsertar());
        }

        //BOTON PARA ACTUALIZAR UN REGISTRO DE LA TABLA ESTUDIANTES
        private async void btnPut_Clicked(object sender, EventArgs e)
        {
            try
            {
                var obj = (Ws.Datos)MyListView.SelectedItem;
                var item = obj.codigo.ToString();
                var itemN = obj.nombre.ToString();
                var itemP = obj.apellido.ToString();
                var itemE = obj.edad.ToString();
                int cod = Convert.ToInt32(item);
                string nom = Convert.ToString(itemN);
                string ape = Convert.ToString(itemP);
                int edad = Convert.ToInt32(itemE);

                MyListView.ItemsSource = _post;
                await Navigation.PushAsync(new vistaActualizar(cod, nom, ape, edad));
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "Debe seleccionar un registro ha Actualizar", "OK");
            }
        }

        //BOTON PARA ELIMINAR UN REGISTRO DE LA TABLA ESTUDIANTES
        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            try
            {
                var obj = (Ws.Datos)MyListView.SelectedItem;
                var item = obj.codigo.ToString();
                int cod = Convert.ToInt32(item);

                MyListView.ItemsSource = _post;
                await Navigation.PushAsync(new vistaEliminar(cod));
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "Debe seleccionar un registro a Eliminar", "OK");
            }
        }

        private void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
        }
    }
}
