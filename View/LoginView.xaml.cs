using ATM_Simulator_WPF.ViewModel;
using System.Windows;

namespace ATM_Simulator_WPF.View
{
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            if (DataContext is LoginViewModel viewModel)
            {
                viewModel.LoginSuccess += OnLoginSuccess;
            }
        }

        private void OnLoginSuccess()
        {
            MainViewModel mainVM = new((DataContext as LoginViewModel)!.CuentaAutenticada!);
            MainWindow mainWindow = new(mainVM);

            mainWindow.Show();
            this.Close();
        }
    }
}
