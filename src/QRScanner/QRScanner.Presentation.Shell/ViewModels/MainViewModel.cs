using Caliburn.Micro;
using ZXing;

namespace QRScanner.Presentation.Shell.ViewModels
{
    public class MainViewModel : Conductor<object>
    {
        private ScanViewModel _scanViewModel;

        public MainViewModel()
        {
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            _scanViewModel = new ScanViewModel(OnScanResult);
            OnRescan();
        }

        private void OnScanResult(Result result)
        {
            ActivateItem(new ResultViewModel(result, OnRescan));
        }

        private void OnRescan()
        {
            ActivateItem(_scanViewModel);
        }
    }
}