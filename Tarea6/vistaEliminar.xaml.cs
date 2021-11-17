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
    public partial class vistaEliminar : ContentPage
    {
        public vistaEliminar(int codigo)
        {
            InitializeComponent();
            txtCodigo.Text = Convert.ToString(codigo);
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {

                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();

                parametros.Add("codigo", txtCodigo.Text);


                cliente.UploadValues("http://192.168.1.7/moviles/post.php/codigo ? codigo= " + Int32.Parse(txtCodigo.Text), "DELETE", parametros);
                await DisplayAlert("alerta", "Datos Eliminados Correctamente", "ok");

                txtCodigo.Text = "";
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Error" + ex.Message, "OK");
            }
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}