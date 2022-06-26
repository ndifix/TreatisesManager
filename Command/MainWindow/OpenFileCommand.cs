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
				Id = treatises.Max(t => t.Id) + 1,
				Title = "",
				Authors = "",
			};

			if (dialog.ShowDialog() == true)
			{
				treatise.FilePath = dialog.FileName;
			}

			if (string.IsNullOrEmpty(treatise.FilePath))
			{
				return;
			}

			var formWindow = new View.TreatiseForm(treatise);
			formWindow.ShowDialog();

			try
			{
				Database.Insert(treatise);
			}
			catch (Exception e)
			{
				MessageBox.Show($"Failed to save into database: {e.Message}");
			}

			treatises.Add(treatise);
		}
	}
}
