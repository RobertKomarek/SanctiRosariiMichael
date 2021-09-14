using System;
using System.Collections.Generic;
using System.Linq;
using ErzengelMichael.iOS;
using Foundation;
using Syncfusion.XForms.iOS.Expander;
//using Lottie.Forms.Platforms.Ios;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

//[assembly: ExportRenderer(typeof(Button), typeof(MyButtonRenderer))]
//[assembly: ExportRenderer(typeof(Label), typeof(MyLabelRenderer))]
namespace ErzengelMichael.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application. 
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            //Register Syncfusion License
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDcxMTY0QDMxMzkyZTMyMmUzMFdZbk40aU9xZTFUQ1d4K1Q0dWdleUxVaWxKNUYzeHJldWVuMXpYbWo1TTg9");
            
            //global::Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
            //MediaElement_Experimental
            Forms.SetFlags(new string[]
              {
                    "Brush_Experimental", "CarouselView_Experimental", "CollectionView_Experimental", 
                    "DragAndDrop_Experimental", "Expander_Experimental",
                    "Markup_Experimental", "RadioButton_Experimental",
                    "SwipeView_Experimental", "Shapes_Experimental", "Shell_UWP_Experimental", "SwipeView_Experimental"
              });

            global::Xamarin.Forms.Forms.Init();
            SfExpanderRenderer.Init();
            LoadApplication(new App());
            return base.FinishedLaunching(app, options);
        }
    }

}
