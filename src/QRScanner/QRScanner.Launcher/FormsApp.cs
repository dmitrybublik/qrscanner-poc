using Caliburn.Micro.Xamarin.Forms;
using QRScanner.Presentation.Shell.ViewModels;
using Solid.Practices.IoC;
using Xamarin.Forms;

namespace QRScanner.Launcher
{
    public class FormsApp : FormsApplication
    {
        private readonly IDependencyRegistrator _dependencyRegistrator;

        public FormsApp(IDependencyRegistrator dependencyRegistrator)
        {
            Initialize();

            _dependencyRegistrator = dependencyRegistrator;

            //TODO: Move all registrations to modules
            _dependencyRegistrator.RegisterTransient<ShellViewModel>();
            _dependencyRegistrator.RegisterTransient<MainViewModel>();

            DisplayRootViewFor<ShellViewModel>();
        }             

        protected override void PrepareViewFirst(NavigationPage navigationPage)
        {
            _dependencyRegistrator.RegisterInstance<INavigationService>(new NavigationPageAdapter(navigationPage));
        }
    }
}