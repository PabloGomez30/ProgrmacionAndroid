using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace EjercicioLogIN
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        string usuario, password;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            var btnIngresa = FindViewById<Button>(Resource.Id.btnIngresar);
            var txtUser = FindViewById<EditText>(Resource.Id.txtUsuario);
            var txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);
            var Imagen = FindViewById<ImageView>(Resource.Id.imageView);
            Imagen.SetImageResource(Resource.Drawable.thecity);
            btnIngresa.Click += delegate
            {
                try
                {
                    usuario = txtUser.Text;
                    password = txtPassword.Text;
                    if (usuario == "PabloG")
                        if (password == "123")
                        {
                            Cargar();
                        }
                        else
                            Toast.MakeText(this, "Error en Password", ToastLength.Long).Show();
                    else
                        Toast.MakeText(this, "Error de Usuario", ToastLength.Long).Show();
                }
                catch(System.Exception ex)
                {
                    Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
                }
                
            };
        }
        public void Cargar()
        {
            var vistaPrincipal = new Intent(this, typeof(Principal));
            vistaPrincipal.PutExtra("Usuario", usuario);
            StartActivity(vistaPrincipal);
        }
    }
    
}