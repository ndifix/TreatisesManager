using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using TreatisesManager.ViewModel;

namespace TreatisesManager.View
{
	/// <summary>
	/// AuthorEditor.xaml の相互作用ロジック
	/// </summary>
	public partial class AuthorEditor : Window
	{
		private readonly AuthorEditorViewModel viewModel;

		public AuthorEditor(List<string> authors)
		{
			InitializeComponent();
			viewModel = new AuthorEditorViewModel(authors);
			DataContext = viewModel;
		}

		private void WindowClosing(object sender, CancelEventArgs e)
		{
			viewModel.WindowClosing();
		}
	}
}
