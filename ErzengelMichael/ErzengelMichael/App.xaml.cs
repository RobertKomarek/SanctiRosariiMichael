using ErzengelMichael.Services;
using ErzengelMichael.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ErzengelMichael
{
    public partial class App : Application
    {

        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDI4MjExQDMxMzkyZTMxMmUzME1JK0lrT0VkMDF2d2F3eUk5UmUvWTg3dWtTR2grd0MzdXZabkFKdVY3YUE9");

            InitializeComponent();

            DependencyService.Register<MockDataStore>();

            MainPage = new AppShell();
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
