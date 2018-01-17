using Caliburn.Micro;

namespace QRScanner.Presentation.Shell.ViewModels
{
    public class ShellViewModel : Conductor<Screen>.Collection.OneActive
    {
        protected override void OnInitialize()
        {
            base.OnInitialize();

            //TODO: Use View Model Factory
            var mainViewModel = new MainViewModel();
            Items.Add(mainViewModel);
            ActivateItem(mainViewModel);
        }
    }
}