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
using System.Windows.Shapes;
using TreatisesManager.Model;
using TreatisesManager.ViewModel;

namespace TreatisesManager.View
{
	/// <summary>
	/// TreatiseForm.xaml の相互作用ロジック
	/// </summary>
	public partial class TreatiseForm : Window
	{
		public TreatiseFormViewModel ViewModel { get; private set; }

		public TreatiseForm(Treatise treatise)
		{
			InitializeComponent();
			ViewModel = new TreatiseFormViewModel(treatise);
			DataContext = ViewModel;
		}

		private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			ViewModel.ClosingWindow();
		}
	}
}
