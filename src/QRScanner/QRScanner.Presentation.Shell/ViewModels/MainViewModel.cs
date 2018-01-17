using System.Windows.Input;
using Caliburn.Micro;
using LogoFX.Client.Mvvm.Commanding;

namespace QRScanner.Presentation.Shell.ViewModels
{
    public class MainViewModel : Screen
    {
        public MainViewModel()
        {
        }

        private ICommand _scanCommand;

        public ICommand ScanCommand
        {
            get
            {
                return _scanCommand ??
                       (_scanCommand = ActionCommand
                           .When(() => !AutoScanEnabled)
                           .Do(() => { })
                           .RequeryOnPropertyChanged(this, () => AutoScanEnabled));
            }
        }

        private bool _autoScanEnabled;

        public bool AutoScanEnabled
        {
            get { return _autoScanEnabled; }
            set
            {
                if (value == _autoScanEnabled)
                {
                    return;
                }

                _autoScanEnabled = value;
                NotifyOfPropertyChange();
            }
        }
    }
}