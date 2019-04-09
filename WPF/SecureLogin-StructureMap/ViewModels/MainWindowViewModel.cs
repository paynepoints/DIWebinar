using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SecureLogin.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private IAppState _appState;
        private Services.IThingService _thingService;
        private Services.ILoginService _loginService;

        private string _doThingResult = string.Empty;

        public MainWindowViewModel(IAppState appState, Services.IThingService thingService, Services.ILoginService loginService)
        {
            _appState = appState;
            _thingService = thingService;
            _loginService = loginService;

            loginService.LoggedIn += LoginService_LoggedIn;

            DoThingCommand = new DelegateCommand(ExecuteDoThingCommand, CanExecuteDoThingCommand);
        }

        

        public IAppState AppState
        {
            get
            {
                return _appState;
            }
        }

        public string DoThingResult
        {
            get
            {
                return _doThingResult;
            }
            set
            {
                SetProperty(ref _doThingResult, value);
            }
        }

        public ICommand DoThingCommand { get; set; }

        private void LoginService_LoggedIn(object sender, EventArgs e)
        {
            ((DelegateCommand)DoThingCommand).RaiseCanExecuteChanged();
        }

        public bool CanExecuteDoThingCommand()
        {
            return _appState.IsUserLoggedIn && _thingService != null;
        }

        public void ExecuteDoThingCommand()
        {
            DoThingResult = _thingService.DoTheThing();
        }

    }
}
