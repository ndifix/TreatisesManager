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
using TreatisesManager.ViewModel;

namespace TreatisesManager.View
{
	/// <summary>
	/// TagEditor.xaml の相互作用ロジック
	/// </summary>
	public partial class TagEditor : Window
	{
		private TagEditorViewModel viewModel;

		public TagEditor(List<string> tags)
		{
			InitializeComponent();
			viewModel = new TagEditorViewModel(tags);
			DataContext = viewModel;
		}

		private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			viewModel.WindowClosing();
		}
	}
}
