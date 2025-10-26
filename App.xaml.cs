using ATM_Simulator_WPF.View;
using System.Windows;

namespace ATM_Simulator_WPF
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            LoginView loginWindow = new();
            loginWindow.Show();
        }
    }
}
