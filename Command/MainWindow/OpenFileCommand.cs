﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Treatises.Command.MainWindow
{
	class OpenFileCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter) => true;

		public void Execute(object parameter)
		{
			MessageBox.Show("show");
		}
	}
}
