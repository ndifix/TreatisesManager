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

namespace TreatisesManager.Command.MainWindow
{
	class OpenFileCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;

		private readonly ObservableCollection<Treatise> treatises;

		public OpenFileCommand(ObservableCollection<Treatise> treatises)
		{
			this.treatises = treatises;
		}

		public bool CanExecute(object parameter) => true;

		public void Execute(object parameter)
		{
			var dialog = new OpenFileDialog();
			var treatise = new Treatise()
			{
				Title = "",
				Authors = "",
			};

			if (dialog.ShowDialog() == true)
			{
				treatise.FilePath = dialog.FileName;
			}

			treatises.Add(treatise);
		}
	}
}
