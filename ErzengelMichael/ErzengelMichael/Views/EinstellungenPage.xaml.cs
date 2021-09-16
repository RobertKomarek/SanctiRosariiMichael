using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ErzengelMichael.Views
{
    public partial class EinstellungenPage : ContentPage
    {
        public List<string> MeineAdresse { get; set; }

        public EinstellungenPage()
        {
            InitializeComponent();

            MeineAdresse = new List<string>
            {
                "robert.komarek98@gmail.com"
            };
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            try
            {
                var message = new EmailMessage
                {
                    Subject = "Sancti Rosarii Michael",
                    To = MeineAdresse

                };
                Email.ComposeAsync(message);

            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Info", "Bitte installieren Sie eine Mail-Applikation aus dem Play- bzw. App Store zum Verwenden dieser Funktion!"
                    + Environment.NewLine + Environment.NewLine + "Please install a Mail-App from Play- or App Store to use this function!", "OK");
            }
          
        }

        async void OpenCreativeCommonsEventHandler(System.Object sender, System.EventArgs e)
        {
            await Browser.OpenAsync("https://creativecommons.org/licenses/by-sa/4.0/");
        }
    }
}

