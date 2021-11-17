using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tarea6.Ws;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tarea6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class vistaActualizar : ContentPage
    {
        public vistaActualizar(int codigo, string nombre, string apellido, int edad)
        {
            InitializeComponent();
            txtCodigo.Text = Convert.ToString(codigo);
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtedad.Text = Convert.ToString(edad);
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("nombre", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtedad.Text);

                cliente.UploadValues("http://192.168.1.7/moviles/post.php ? codigo= " + Int32.Parse(txtCodigo.Text) + "&" + "nombre=" + txtNombre.Text + "&" + "apellido=" + txtApellido.Text + "&" + "edad=" + Int32.Parse(txtedad.Text), "PUT", parametros);
                await DisplayAlert("Mensaje", "Elemento actualizado con exito", "OK");

                txtCodigo.Text = "";
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtedad.Text = "";
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Debe seleccionar un Registro", "OK");
            }
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}