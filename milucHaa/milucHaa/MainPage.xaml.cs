using milucHaa.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace milucHaa
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            llenarDatos();
            
        }

        private async void btnRegistro_Clicked(object sender, EventArgs e)
        {
            
            if (validarDatos())
            {
                Emociones emocion = new Emociones
                {
                    Toques = int.Parse(txtToques.Text),
                    Emocion = txtEmocion.Text,
                    Imagen = EntryIMG.Text,
                };
                
                await App.SQLiteDB.SaveEmocionAsync(emocion);
                llenarDatos();
                limpiarEntrys();
                btnRegistro.IsVisible = false;
                txtToques.IsVisible = false;
                txtEmocion.IsVisible = false;

                Dudando.IsVisible = false;
                Drinks.IsVisible = false;
                Enamorada.IsVisible = false;
                Feliz.IsVisible = false;
                Harta.IsVisible = false;
                SientoFea.IsVisible = false;
                SientoLinda.IsVisible = false;
                Neutra.IsVisible = false;
                Nonii.IsVisible = false;
                Pensativa.IsVisible = false;
                PorMatarme.IsVisible = false;
                Triste.IsVisible = false;
                listaEmocion.IsVisible = true;
                NuevaEmocion.IsVisible = true;

            }
            else
            {
                await DisplayAlert("Selecciona una emoción", "No seas paja", "Ok");
            }
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty(txtID.Text))
            {
                Emociones emocion = new Emociones()
                {
                    Imagen = EntryIMG.Text,
                    IdEmocion = Convert.ToInt32(txtID.Text),
                    Emocion = txtEmocion.Text,
                    Toques = Convert.ToInt32(txtToques.Text), 
                };
                await App.SQLiteDB.SaveEmocionAsync(emocion);
                llenarDatos();
                limpiarEntrys();
                
                btnActualizar.IsVisible = false;
                btnEliminar.IsVisible = false;
                txtToques.IsVisible = false;
                btnRestar.IsVisible = false;
                btnAgregar.IsVisible = false;
                NuevaEmocion.IsVisible = true;
            }
        }
        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            var emocion = await App.SQLiteDB.GetEmocionesByIdAsync(Convert.ToInt32(txtID.Text));
            if (emocion != null)
            {
                await App.SQLiteDB.DeleteEmocionesAsync(emocion);
            }
        }

        private async void listaEmocion_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            btnActualizar.IsVisible = true;
            btnEliminar.IsVisible = true;
            btnRegistro.IsVisible = false;
            txtEmocion.IsVisible = false;
            txtToques.IsVisible = true;
            NuevaEmocion.IsVisible = false;
            btnAgregar.IsVisible = true;
            btnRestar.IsVisible = true;
            var obj = (Emociones)e.SelectedItem;

            if (!string.IsNullOrEmpty(obj.IdEmocion.ToString()) )
            {
                var emocion = await App.SQLiteDB.GetEmocionesByIdAsync(obj.IdEmocion);
                if(emocion != null)
                {
                    EntryIMG.Text = emocion.Imagen.ToString();
                    txtID.Text = emocion.IdEmocion.ToString();
                    txtEmocion.Text = emocion.Emocion.ToString();
                    txtToques.Text = emocion.Toques.ToString();
                }
                
            }
        }

        public async void llenarDatos()
        {
            var emocionList = await App.SQLiteDB.GetEmocionAsync();
            if (emocionList != null)
            {
                listaEmocion.ItemsSource = emocionList;
            }
        }
        public bool validarDatos()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(txtToques.Text))
            {
                respuesta = false;
            }
            if (string.IsNullOrEmpty(txtEmocion.Text))
            {
                respuesta = false;
            }
            else
            {
                respuesta = true;
            }

            return respuesta;
        }

        public void limpiarEntrys()
        {
            txtEmocion.Text = "";
            txtToques.Text = "";
        }

        private void NuevaEmocion_Clicked(object sender, EventArgs e)
        {
            NuevaEmocion.IsVisible = false;
            txtEmocion.IsVisible = true;
            btnRegistro.IsVisible = true;
            txtToques.Text = "0";
            Drinks.IsVisible = true;
            Dudando.IsVisible = true;
            Enamorada.IsVisible = true;
            Feliz.IsVisible = true;
            Harta.IsVisible = true;
            SientoFea.IsVisible = true;
            SientoLinda.IsVisible = true;   
            Neutra.IsVisible = true;
            Nonii.IsVisible = true;
            Pensativa.IsVisible = true;
            PorMatarme.IsVisible = true;
            Triste.IsVisible = true;
            listaEmocion.IsVisible = false;
        }

        private void Drinks_Clicked(object sender, EventArgs e)
        {
            EntryIMG.Text = "drinks.jpeg";
            txtEmocion.Text = "Tomando unas drinks";
        }

        private void Dudando_Clicked(object sender, EventArgs e)
        {
            EntryIMG.Text = "dudando.jpeg";
            txtEmocion.Text = "Dudando";
        }

        private void btnAgregar_Clicked(object sender, EventArgs e)
        {
            int suma = Convert.ToInt32(txtToques.Text);
            suma += 1;
            txtToques.Text = Convert.ToString(suma);
        }

        private void btnRestar_Clicked(object sender, EventArgs e)
        {
            int resta = Convert.ToInt32(txtToques.Text);
            resta -= 1;
            txtToques.Text = Convert.ToString(resta);
        }

        private void Enamorada_Clicked(object sender, EventArgs e)
        {
            EntryIMG.Text = "enamorada.jpeg";
            txtEmocion.Text = "In Love";
        }

        private void Feliz_Clicked(object sender, EventArgs e)
        {
            EntryIMG.Text = "feliz.jpeg";
            txtEmocion.Text = "Es el mejor día de mi vida";
        }

        private void Harta_Clicked(object sender, EventArgs e)
        {
            EntryIMG.Text = "harta.jpeg";
            txtEmocion.Text = "Me quieren ver mal";
        }

        private void SientoFea_Clicked(object sender, EventArgs e)
        {
            EntryIMG.Text = "mesientofea.jpeg";
            txtEmocion.Text = "Hoy soy becky la fea";

        }

        private void SientoLinda_Clicked(object sender, EventArgs e)
        {
            EntryIMG.Text = "mesientolinda.jpeg";
            txtEmocion.Text = "Soy la mas diva";
        }

        private void Neutra_Clicked(object sender, EventArgs e)
        {
            EntryIMG.Text = "neutra.jpeg";
            txtEmocion.Text = "Estoy -_-";
        }

        private void Nonii_Clicked(object sender, EventArgs e)
        {
            EntryIMG.Text = "nonii.jpeg";
            txtEmocion.Text = "Que sueño zZzZz";
        }

        private void Pensativa_Clicked(object sender, EventArgs e)
        {
            EntryIMG.Text = "pensativa.jpeg";
            txtEmocion.Text = "Soy aristoteles for real";
        }

        private void PorMatarme_Clicked(object sender, EventArgs e)
        {
            EntryIMG.Text = "pormatarme.jpeg";
            txtEmocion.Text = "Odio mi vida";
        }

        private void Triste_Clicked(object sender, EventArgs e)
        {
            EntryIMG.Text = "triste.jpeg";
            txtEmocion.Text = "Estoy re triste chicos:(";
        }
    }
}
