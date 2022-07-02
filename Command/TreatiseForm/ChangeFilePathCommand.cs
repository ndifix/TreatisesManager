using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TreatisesManager.ViewModel;

namespace TreatisesManager.Command.TreatiseForm
{
	class ChangeFilePathCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter) => true;

		private readonly TreatiseFormViewModel viewModel;

		public ChangeFilePathCommand(TreatiseFormViewModel vm)
		{
			viewModel = vm;
		}

		public void Execute(object parameter)
		{
			var dialog = new OpenFileDialog();
			if (dialog.ShowDialog() == true)
			{
				if (!string.IsNullOrEmpty(dialog.FileName))
				{
					viewModel.Treatise.FilePath = dialog.FileName;

					// 通知のための代入。
					viewModel.Treatise = null;
				}
			}
		}
	}
}
