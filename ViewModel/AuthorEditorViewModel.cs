using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TreatisesManager.Command.AuthorEditor;

namespace TreatisesManager.ViewModel
{
	internal class AuthorEditorViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private readonly List<string> authors;

		public ObservableCollection<Item> Items { get; }

		public string Author
		{
			get => authorBuffer;
			set
			{
				authorBuffer = value;
				OnPropertyChanged("Author");
			}
		}
		private string authorBuffer;

		public ICommand AppendAuthorCommand { get; }

		public AuthorEditorViewModel(List<string> authors)
		{
			authorBuffer = string.Empty;
			this.authors = authors;
			Items = new ObservableCollection<Item>(
				authors.Select(a => new Item() { Checked = false, Name = a })
			);
			AppendAuthorCommand = new AppendAuthorCommand(this);
		}

		internal class Item
		{
			public bool Checked { get; set; }

			public string Name { get; set; }
		}

		public void WindowClosing()
		{
			authors.Clear();
			foreach (var item in Items)
			{
				authors.Add(item.Name);
			}
		}

		protected void OnPropertyChanged([CallerMemberName] string name = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}
}
