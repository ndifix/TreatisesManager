using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using TreatisesManager.Command.MainWindow;
using TreatisesManager.Model;

namespace TreatisesManager.ViewModel
{
	class MainWindowViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public ObservableCollection<Treatise> Treatises { get; }

		public Treatise SelectedItem { get; set; }

		public IEnumerable<string> AllTags
		{
			get => Treatises.SelectMany(t => t.Tags).Distinct();
			set => OnPropertyChanged("AllTags");
		}

		public ICommand LoadedCommand { get; }

		public ICommand AddFileCommand { get; }

		public ICommand EditItemCommand { get; }

		public ICommand DeleteItemCommand { get; }

		public ICommand OpenFileCommand { get; }

		public TreatiseCache TreatiseCache { get; }

		public MainWindowViewModel()
		{
			Treatises = new ObservableCollection<Treatise>();
			LoadedCommand = new LoadedCommand(this);
			AddFileCommand = new AddFileCommand(Treatises);
			EditItemCommand = new EditItemCommand(Treatises);
			DeleteItemCommand = new DeleteItemCommand(Treatises);
			OpenFileCommand = new OpenFileCommand();
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

		protected void OnPropertyChanged([CallerMemberName] string name = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}
}
