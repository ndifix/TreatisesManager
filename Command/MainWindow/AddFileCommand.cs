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
using TreatisesManager.View;

namespace TreatisesManager.Command.MainWindow
{
	class AddFileCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;

		private readonly ObservableCollection<Treatise> treatises;

		public AddFileCommand(ObservableCollection<Treatise> treatises)
		{
			this.treatises = treatises;
		}

		public bool CanExecute(object parameter) => true;

		public void Execute(object parameter)
		{
			var dialog = new OpenFileDialog();
			var treatise = new Treatise()
			{
				Id = treatises.Select(t => t.Id).DefaultIfEmpty().Max() + 1,
				Title = "",
				Authors = new List<string>(),
			};

			if (dialog.ShowDialog() == true)
			{
				treatise.FilePath = dialog.FileName;
			}

			if (string.IsNullOrEmpty(treatise.FilePath))
			{
				return;
			}
			if (treatises.Any(t => t.FilePath == treatise.FilePath))
			{
				MessageBox.Show($"Failed to add the treatise. {treatise.FilePath} is already added.");
				return;
			}

			var formWindow = new View.TreatiseForm(treatise);
			formWindow.ShowDialog();

			treatises.Add(treatise);
		}
	}
}
