using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using TreatisesManager.View;
using TreatisesManager.ViewModel;

namespace TreatisesManager.Command.TreatiseForm
{
	public partial class EditTagsCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter) => true;

		private readonly TreatiseFormViewModel viewModel;

		public EditTagsCommand(TreatiseFormViewModel vm)
		{
			viewModel = vm;
		}

		public void Execute(object parameter)
		{
			Window editor = new View.TagEditor(viewModel.Treatise.Tags);
			editor.ShowDialog();

			// 通知のための代入
			viewModel.TagList = null;
		}
	}
}
