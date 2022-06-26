using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TreatisesManager.Model;

namespace TreatisesManager.Command.MainWindow
{
	class LoadedCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;

		private readonly ObservableCollection<Treatise> treatises;

		public LoadedCommand(ObservableCollection<Treatise> treatises)
		{
			this.treatises = treatises;
		}

		public bool CanExecute(object parameter) => true;

		public void Execute(object parameter)
		{
			try
			{
				Database.SelectAll(treatises);
			}
			catch(Exception e)
			{
				MessageBox.Show($"Failed to read database: {e.Message}");
			}
		}
	}
}
