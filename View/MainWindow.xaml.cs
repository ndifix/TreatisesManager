using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TreatisesManager.ViewModel;

namespace TreatisesManager.View
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly MainWindowViewModel viewModel = new MainWindowViewModel();

		public MainWindow()
		{
			InitializeComponent();
			DataContext = viewModel;
		}

		private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			viewModel.WindowClosing();
		}
	}
}
