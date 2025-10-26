using ATM_Simulator_WPF.Model.DataAccess;
using ATM_Simulator_WPF.Model;
using ATM_Simulator_WPF.ViewModel.Base;
using System.Windows.Input;

namespace ATM_Simulator_WPF.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private string _numeroCuenta = string.Empty;
        private string _pin = string.Empty;
        private string _mensajeError = string.Empty;
        private readonly SqlDataAccess _dataAccess = new();

        public CuentaModel? CuentaAutenticada { get; private set; }

        public string NumeroCuenta
        {
            get => _numeroCuenta;
            set => SetProperty(ref _numeroCuenta, value);
        }

        public string PIN
        {
            get => _pin;
            set => SetProperty(ref _pin, value);
        }

        public string MensajeError
        {
            get => _mensajeError;
            set => SetProperty(ref _mensajeError, value);
        }

        public ICommand LoginCommand { get; }

        public event Action? LoginSuccess;

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(ExecuteLogin, CanExecuteLogin);
        }

        private bool CanExecuteLogin(object? parameter)
        {
            return !string.IsNullOrEmpty(NumeroCuenta) && !string.IsNullOrEmpty(PIN) && PIN.Length == 4;
        }

        private void ExecuteLogin(object? parameter)
        {
            MensajeError = string.Empty;

            CuentaAutenticada = _dataAccess.AutenticarCuenta(NumeroCuenta, PIN);

            if (CuentaAutenticada != null)
            {
                LoginSuccess?.Invoke();
            }
            else
            {
                MensajeError = "Credenciales incorrectas. Verifique la cuenta y el PIN.";
            }
        }
    }
}
