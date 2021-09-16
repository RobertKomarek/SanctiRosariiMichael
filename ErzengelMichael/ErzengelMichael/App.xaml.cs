using ErzengelMichael.Services;
using ErzengelMichael.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;


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
            AppCenter.Start("ios=31120fea-4912-431c-915e-843ac9cdb609;" +
                  "uwp={Your UWP App secret here};" +
                  "android={Your Android App secret here}",
                  typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
