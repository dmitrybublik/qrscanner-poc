using Android.App;
using Android.Content.PM;
using Android.Widget;
using Android.OS;
using QRScanner.Launcher;
using Xamarin.Forms.Platform.Android;

namespace QRScanner.Android
{
    [Activity(Label = "QRScanner.Android", MainLauncher = true)]
    public class MainActivity : FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(ContainerContext.Resolver.Resolve<FormsApp>());
        }
    }
}

