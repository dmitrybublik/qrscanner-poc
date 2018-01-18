using System;
using System.Windows.Input;
using LogoFX.Client.Mvvm.Commanding;
using LogoFX.Client.Mvvm.ViewModel;
using ZXing;

namespace QRScanner.Presentation.Shell.ViewModels
{
    public class ResultViewModel : ObjectViewModel<Result>
    {
        private readonly Action _rescanAction;

        public ResultViewModel(Result model, Action rescanAction)
            : base(model)
        {
            _rescanAction = rescanAction;
        }

        private ICommand _rescanCommand;

        public ICommand RescanCommand
        {
            get
            {
                return _rescanCommand ??
                       (_rescanCommand = ActionCommand
                           .When(() => true)
                           .Do(() => { _rescanAction(); }));
            }
        }

        public string ResultText
        {
            get { return Model.Text; }
        }
    }
}