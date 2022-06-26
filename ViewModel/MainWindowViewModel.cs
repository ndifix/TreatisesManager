using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TreatisesManager.Command.MainWindow;
using TreatisesManager.Model;

namespace TreatisesManager.ViewModel
{
	class MainWindowViewModel
	{
		public ObservableCollection<Treatise> Treatises { get; }

		public ICommand OpenFileCommand { get; }

		public MainWindowViewModel()
		{
			Treatises = new ObservableCollection<Treatise>();
			OpenFileCommand = new OpenFileCommand(Treatises);
		}
	}
}
