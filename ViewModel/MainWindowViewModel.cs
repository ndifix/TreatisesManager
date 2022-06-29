using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using TreatisesManager.Command.MainWindow;
using TreatisesManager.Model;

namespace TreatisesManager.ViewModel
{
	class MainWindowViewModel
	{
		public ObservableCollection<Treatise> Treatises { get; }

		public ICommand LoadedCommand { get; }

		public ICommand OpenFileCommand { get; }

		public TreatiseCache TreatiseCache { get; }

		public MainWindowViewModel()
		{
			Treatises = new ObservableCollection<Treatise>();
			LoadedCommand = new LoadedCommand(this);
			OpenFileCommand = new OpenFileCommand(Treatises);
			TreatiseCache = new TreatiseCache();
		}

		public async void WindowClosing()
		{
			try
			{
				await TreatiseCache.SaveTreatisesAsync(Treatises);
			}
			catch
			{ }
		}
	}
}
