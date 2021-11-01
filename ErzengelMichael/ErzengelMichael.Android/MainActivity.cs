using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace ErzengelMichael.Droid
{
    [Activity(Label = "Sancti Rosarii Michael", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = false, ScreenOrientation = ScreenOrientation.Portrait, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTE4MjQyQDMxMzkyZTMzMmUzMGx5cmIwbzUrb3NJZVFMRmt3ZFhEUkJtOFI0MFBSKzVobkFkZzFZaHVWcWc9");

            //StatusBarColor ändern
            this.SetStatusBarColor(Color.FromHex("#730073").ToAndroid());

            //MediaElement_Experimental
            Forms.SetFlags(new string[] 
            {
                "Brush_Experimental", "CarouselView_Experimental", "DragAndDrop_Experimental", "Expander_Experimental",
                "Markup_Experimental", "RadioButton_Experimental",
                 "SwipeView_Experimental", "Shapes_Experimental", "Shell_UWP_Experimental", "SwipeView_Experimental"
            });

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}