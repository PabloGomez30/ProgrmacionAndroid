using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Xml.Serialization;
using System.IO;
using System.Data;

namespace EjercicioLogIN
{
    [Activity(Label = "Principal")]
    public class Principal : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.vistaprincipal);
            var lblDestino = FindViewById<TextView>(Resource.Id.lblUsuario);
            var btnGuardar = FindViewById<Button>(Resource.Id.btnGuardar);
            var btnBuscar = FindViewById<Button>(Resource.Id.btnBuscar);
            var txtNombre = FindViewById<EditText>(Resource.Id.txtNombre);
            var txtCorreo = FindViewById<EditText>(Resource.Id.txtCorreo);
            var txtEdad = FindViewById<EditText>(Resource.Id.txtEdad);
            var txtSaldo = FindViewById<EditText>(Resource.Id.txtSaldo);
            var txtFolio = FindViewById<EditText>(Resource.Id.txtFolio);
            var txtDomicilio = FindViewById<EditText>(Resource.Id.txtDomicilio);
            string usuario;
            usuario = Intent.GetStringExtra("Usuario");
            lblDestino.Text = usuario;
            
            btnGuardar.Click+=delegate
            {
                /*ip de servicio 192.168.56.1:82*/
                try
                {
                    var WS = new ServicioWeb.ServicioWeb();
                    if (WS.Guardar(txtNombre.Text, txtDomicilio.Text,
                        txtCorreo.Text, int.Parse(txtEdad.Text),
                        double.Parse(txtSaldo.Text)))
                    Toast.MakeText(this, "Archivo Guardado Correctamente",
                        ToastLength.Long).Show(); 
                    else
                        Toast.MakeText(this, "No Guardado",
                       ToastLength.Long).Show();
                }
                catch (System.Exception ex)
                {
                    Toast.MakeText(this, ex.Message,
                   ToastLength.Long).Show();
                }
            };

            btnBuscar.Click += delegate
            {
                var conjunto = new DataSet();
                DataRow Renglon;
                try
                {
                    var WS = new ServicioWeb.ServicioWeb();
                    conjunto = WS.Buscar(int.Parse(txtFolio.Text));
                    Renglon = conjunto.Tables["Datos"].Rows[0];
                    txtNombre.Text = Renglon["Nombre"].ToString();
                    txtDomicilio.Text = Renglon["Domicilio"].ToString();
                    txtCorreo.Text = Renglon["Correo"].ToString();
                    txtEdad.Text = Renglon["Edad"].ToString();
                    txtSaldo.Text = Renglon["Saldo"].ToString();
                }
                catch (System.Exception ex)
                {
                    Toast.MakeText(this, ex.Message,
                     ToastLength.Long).Show();
                }
            };

            /*
            btnGuardar.Click += delegate
            {
                var DC = new Datos();
                try
                {
                    DC.Nombre = txtNombre.Text;
                    DC.Domicilio = txtDomicilio.Text;
                    DC.Correo = txtCorreo.Text;
                    DC.Edad = int.Parse(txtEdad.Text);
                    DC.Saldo = double.Parse(txtSaldo.Text);
                    var serializador = new XmlSerializer(typeof(Datos));
                    var Escritura = new StreamWriter(Path.Combine(System.Environment.GetFolderPath
                        (System.Environment.SpecialFolder.Personal), txtFolio.Text + ".xml"));
                    serializador.Serialize(Escritura, DC);
                    Escritura.Close();
                    txtFolio.Text = "";
                    txtNombre.Text = "";
                    txtDomicilio.Text = "";
                    txtCorreo.Text = "";
                    txtEdad.Text = "";
                    txtSaldo.Text = "";
                    Toast.MakeText(this, "Archivo Guardado Correctamente", ToastLength.Long).Show();
                }
                catch (System.Exception ex)
                {
                    Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
                }
            };
            btnBuscar.Click += delegate
            {
                var DC = new Datos();
                try
                {
                    var serializador = new XmlSerializer(typeof(Datos));
                    var Lecutra = new StreamReader(Path.Combine(System.Environment.GetFolderPath
                        (System.Environment.SpecialFolder.Personal), txtFolio.Text + ".xml"));
                    var datos = (Datos)serializador.Deserialize(Lecutra);
                    Lecutra.Close();
                    txtNombre.Text = datos.Nombre;
                    txtDomicilio.Text = datos.Domicilio;
                    txtCorreo.Text = datos.Correo;
                    txtEdad.Text = datos.Edad.ToString();
                    txtSaldo.Text = datos.Saldo.ToString();
                //    Toast.MakeText(this, "Archivo Guardado Correctamente", ToastLength.Long).Show();
                }
                catch (System.Exception ex)
                {
                    Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
                }
            }; */
        }
    }

    public class Datos
    {
        public string Nombre;
        public string Domicilio;
        public string Correo;
        public int Edad;
        public double Saldo;
    }
}