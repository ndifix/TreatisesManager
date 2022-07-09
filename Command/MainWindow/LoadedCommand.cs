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

namespace TreatisesManager.Command.MainWindow
{
	class LoadedCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;

		private readonly MainWindowViewModel viewModel;

		public LoadedCommand(MainWindowViewModel vm)
		{
			viewModel = vm;
		}

		public bool CanExecute(object parameter) => true;

		public async void Execute(object parameter)
		{
			await viewModel.TreatiseCache.GetTreatisesAsync(viewModel.Treatises);

			// 通知のための代入
			viewModel.AllTags = null;
		}
	}
}
