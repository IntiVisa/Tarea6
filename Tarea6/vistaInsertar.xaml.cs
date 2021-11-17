using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tarea6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class vistaInsertar : ContentPage
    {
        public vistaInsertar()
        {
            InitializeComponent();
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();

                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtcodigo.Text);
                parametros.Add("nombre", txtnombre.Text);
                parametros.Add("apellido", txtapellido.Text);
                parametros.Add("edad", txtedad.Text);

                cliente.UploadValues("http://192.168.1.7/moviles/post.php","POST",parametros);
                await DisplayAlert("Mensaje", "Elemento ingresado con exito", "OK");

                txtcodigo.Text = "";
                txtnombre.Text = "";
                txtapellido.Text = "";
                txtedad.Text = "";
            }
            catch(Exception ex)
            {
                await DisplayAlert("Alerta", "Error"+ex.Message, "OK");
            }
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}