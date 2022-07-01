using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TreatisesManager.Model;
using TreatisesManager.ViewModel;

namespace TreatisesManager.Command.AuthorEditor
{
	class AppendAuthorCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;

		private readonly AuthorEditorViewModel viewModel;

		public AppendAuthorCommand(AuthorEditorViewModel vm)
		{
			viewModel = vm;
		}

		public bool CanExecute(object parameter) => true;

		public void Execute(object parameter)
		{
			if (string.IsNullOrWhiteSpace(viewModel.Author))
			{
				return;
			}

			var item = new AuthorEditorViewModel.Item()
			{
				Checked = false,
				Name = viewModel.Author,
			};

			viewModel.Items.Add(item);
			viewModel.Author = string.Empty;
		}
	}
}
