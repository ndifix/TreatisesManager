using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TreatisesManager.Command.TagEditor;

namespace TreatisesManager.ViewModel
{
	internal class TagEditorViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private readonly List<string> tags;

		public ObservableCollection<Item> Items { get; }

		public string Tag
		{
			get => tagBuffer;
			set
			{
				tagBuffer = value;
				OnPropertyChanged("Tag");
			}
		}
		private string tagBuffer;

		public ICommand AppendTagCommand { get; }

		public ICommand RemoveTagCommand { get; }

		internal class Item
		{
			public bool Checked { get; set; }

			public string Tag { get; set; }
		}

		public TagEditorViewModel(List<string> tags)
		{
			tagBuffer = string.Empty;
			this.tags = tags;
			Items = new ObservableCollection<Item>(
				tags.Select(t => new Item() { Checked = false, Tag = t })
			);
			AppendTagCommand = new AppendTagCommand(this);
			RemoveTagCommand = new RemoveTagCommand(Items);
		}

		public void WindowClosing()
		{
			tags.Clear();
			tags.AddRange(Items.Select(item => item.Tag));
		}

		protected void OnPropertyChanged([CallerMemberName] string name = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}
}
