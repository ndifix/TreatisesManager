using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TreatisesManager.Model;

namespace TreatisesManager.Command.MainWindow
{
	class DeleteItemCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;

		bool ICommand.CanExecute(object parameter) => true;

		private readonly ObservableCollection<Treatise> treatises;

		public DeleteItemCommand(ObservableCollection<Treatise> treatises)
		{
			this.treatises = treatises;
		}

		void ICommand.Execute(object parameter)
		{
			var treatise = parameter as Treatise;

			string title = treatise.Title;
			if(string.IsNullOrWhiteSpace(title))
			{
				title = "\"\"";
			}

			bool confirm = ConfirmForm.ConfirmYesNo(
				$"Are you sure you want to delete the following one from this list?\n" +
				$"{title} at {treatise.FilePath}"
			);

			if (confirm)
			{
				treatises.Remove(parameter as Treatise);
			}
		}
	}
}
