﻿using Foundation;
using QRScanner.Launcher;
using UIKit;

namespace QRScanner.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {       
        private readonly CaliburnAppDelegate appDelegate = new CaliburnAppDelegate();

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Xamarin.Forms.Forms.Init();

            // Code for starting up the Xamarin Test Cloud Agent
#if DEBUG
            Xamarin.Calabash.Start();
#endif
            LoadApplication(ContainerContext.Resolver.Resolve<FormsApp>());

            return base.FinishedLaunching(app, options);
        }
    }
}


