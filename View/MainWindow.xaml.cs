using ATM_Simulator_WPF.ViewModel;
using System.Windows;

namespace ATM_Simulator_WPF.View
{
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
