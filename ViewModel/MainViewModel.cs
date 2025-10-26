using ATM_Simulator_WPF.Model.DataAccess;
using ATM_Simulator_WPF.Model;
using ATM_Simulator_WPF.ViewModel.Base;
using System.Windows.Input;

namespace ATM_Simulator_WPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private CuentaModel _cuenta;
        private readonly SqlDataAccess _dataAccess = new();
        private decimal _montoTransaccion;
        private string _mensajeOperacion = "Bienvenido. Seleccione una operación.";

        public CuentaModel Cuenta
        {
            get => _cuenta;
            set => SetProperty(ref _cuenta, value);
        }

        public decimal Saldo
        {
            get => _cuenta.Saldo;
            set
            {
                _cuenta.Saldo = value;
                OnPropertyChanged(nameof(Saldo));
            }
        }

        public decimal MontoTransaccion
        {
            get => _montoTransaccion;
            set => SetProperty(ref _montoTransaccion, value);
        }

        public string MensajeOperacion
        {
            get => _mensajeOperacion;
            set => SetProperty(ref _mensajeOperacion, value);
        }

        public ICommand RetirarCommand { get; }
        public ICommand DepositarCommand { get; }
        public ICommand ConsultarSaldoCommand { get; }

        public MainViewModel(CuentaModel cuenta)
        {
            _cuenta = cuenta;
            RetirarCommand = new RelayCommand(ExecuteRetirar, CanExecuteTransaccion);
            DepositarCommand = new RelayCommand(ExecuteDepositar, CanExecuteTransaccion);
            ConsultarSaldoCommand = new RelayCommand(ExecuteConsultarSaldo);
        }

        private bool CanExecuteTransaccion(object? parameter)
        {
            return MontoTransaccion > 0;
        }

        private void ExecuteConsultarSaldo(object? parameter)
        {
            MensajeOperacion = $"Su saldo actual es: {Saldo:C}.";
        }

        private void ExecuteRetirar(object? parameter)
        {
            if (Saldo >= MontoTransaccion)
            {
                decimal nuevoSaldo = Saldo - MontoTransaccion;
                if (_dataAccess.ActualizarSaldo(Cuenta.ID, nuevoSaldo))
                {
                    Saldo = nuevoSaldo;
                    MensajeOperacion = $"Retiro de {MontoTransaccion:C} exitoso. Saldo actual: {Saldo:C}.";
                }
                else
                {
                    MensajeOperacion = "Error en la base de datos al realizar el retiro.";
                }
            }
            else
            {
                MensajeOperacion = "Saldo insuficiente para realizar esta transacción.";
            }
            MontoTransaccion = 0;
        }

        private void ExecuteDepositar(object? parameter)
        {
            decimal nuevoSaldo = Saldo + MontoTransaccion;
            if (_dataAccess.ActualizarSaldo(Cuenta.ID, nuevoSaldo))
            {
                Saldo = nuevoSaldo;
                MensajeOperacion = $"Depósito de {MontoTransaccion:C} exitoso. Saldo actual: {Saldo:C}.";
            }
            else
            {
                MensajeOperacion = "Error en la base de datos al realizar el depósito.";
            }
            MontoTransaccion = 0;
        }
    }
}
