using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
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

		public bool CanExecute(object parameter) => true;

		public void Execute(object parameter)
		{
			var treatise = parameter as Treatise;

			if (!File.Exists(treatise.FilePath))
			{
				MessageBox.Show($"File not fonud: {treatise.FilePath}");
				return;
			}

			Process.Start(treatise.FilePath);
		}
	}
}
