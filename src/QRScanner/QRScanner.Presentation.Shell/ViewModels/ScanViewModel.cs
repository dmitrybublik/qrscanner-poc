using System;
using System.Windows.Input;
using Caliburn.Micro;
using LogoFX.Client.Mvvm.Commanding;
using ZXing;

namespace QRScanner.Presentation.Shell.ViewModels
{
    public class ScanViewModel : Screen
    {
        private readonly Action<Result> _resultAction;

        public ScanViewModel(Action<Result> resultAction)
        {
            _resultAction = resultAction;
        }

        private ICommand _scanCommand;

        public ICommand ScanCommand
        {
            get
            {
                return _scanCommand ??
                       (_scanCommand = ActionCommand
                           .When(() => !IsScanning)
                           .Do(() =>
                           {
                               _isScanning = true;
                               NotifyOfPropertyChange(() => IsScanning);
                           })
                           .RequeryOnPropertyChanged(this, () => IsScanning));
            }
        }

        private ICommand _scanResultCommand;

        public ICommand ScanResultCommand
        {
            get
            {
                return _scanResultCommand ??
                       (_scanResultCommand = ActionCommand<Result>
                           .When(r => true)
                           .Do(r =>
                           {
                               TryClose();
                               _isScanning = false;
                               NotifyOfPropertyChange(() => IsScanning);
                               
                               _resultAction(r);
                           }));
            }
        }

        private bool _isScanning;
        public bool IsScanning
        {
            get { return (AutoScanEnabled || _isScanning) && IsActive; }
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
                NotifyOfPropertyChange(() => IsScanning);
                NotifyOfPropertyChange(() => BottomText);
            }
        }

        public string TopText
        {
            get { return "Hold your phone up to the barcode"; }
        }

        public string BottomText
        {
            get
            {
                return AutoScanEnabled
                    ? "Scanning will happen automatically"
                    : "Press SCAN button for scanning";
            }
        }
    }
}