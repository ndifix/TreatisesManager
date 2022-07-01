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
	class EditItemCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter) => true;

		private readonly ObservableCollection<Treatise> treatises;

		public EditItemCommand(ObservableCollection<Treatise> treatises)
		{
			this.treatises = treatises;
		}

		public void Execute(object parameter)
		{
			Treatise editting = parameter as Treatise;
			var index = treatises.IndexOf(editting);
			var formWindow = new View.TreatiseForm(editting);
			formWindow.ShowDialog();

			treatises.RemoveAt(index);
			treatises.Insert(index, editting);
		}
	}
}
