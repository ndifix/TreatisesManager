using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TreatisesManager.ViewModel;

namespace TreatisesManager.Command.TagEditor
{
	class RemoveTagCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;

		private readonly ObservableCollection<TagEditorViewModel.Item> items;

		public RemoveTagCommand(ObservableCollection<TagEditorViewModel.Item> items)
		{
			this.items = items;
		}

		public bool CanExecute(object parameter) => true;

		public void Execute(object parameter)
		{
			while (items.Any(item => item.Checked))
			{
				items.Remove(items.First(item => item.Checked));
			}
		}
	}
}
