﻿using Microsoft.Win32;
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

namespace TreatisesManager.Command.TreatiseForm
{
	class AppendAuthorCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;

		private readonly TreatiseFormViewModel viewModel;

		public AppendAuthorCommand(TreatiseFormViewModel vm)
		{
			viewModel = vm;
		}

		public bool CanExecute(object parameter) => true;

		public void Execute(object parameter)
		{
			if(string.IsNullOrWhiteSpace(viewModel.AuthorBuffer))
			{
				return;
			}
			viewModel.AuthorList += viewModel.AuthorBuffer.Trim() + "\n";
			viewModel.Treatise.Authors += viewModel.AuthorBuffer.Trim() + ";";
			viewModel.AuthorBuffer = string.Empty;
		}
	}
}