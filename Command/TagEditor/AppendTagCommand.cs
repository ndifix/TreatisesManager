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

namespace TreatisesManager.Command.TagEditor
{
	class AppendTagCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;

		private readonly TagEditorViewModel viewModel;

		public AppendTagCommand(TagEditorViewModel vm)
		{
			viewModel = vm;
		}

		public bool CanExecute(object parameter) => true;

		public void Execute(object parameter)
		{
			if (string.IsNullOrWhiteSpace(viewModel.Tag))
			{
				return;
			}

			var item = new TagEditorViewModel.Item()
			{
				Checked = false,
				Tag = viewModel.Tag,
			};

			viewModel.Items.Add(item);
			viewModel.Tag = string.Empty;
		}
	}
}
