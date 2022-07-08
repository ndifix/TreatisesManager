using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreatisesManager.Model;
using TreatisesManager.Command.TreatiseForm;
using TreatisesManager.View;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TreatisesManager.ViewModel
{
	public class TreatiseFormViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public Treatise Treatise
		{
			get => treatiseBuffer;
			set => OnPropertyChanged("Treatise");
		}
		private readonly Treatise treatiseBuffer;

		public string AuthorList
		{
			get => Treatise.Authors.Aggregate("", (accum, name) => accum + name + "\n");
			set => OnPropertyChanged("AuthorList");
		}

		public string TagList
		{
			get => Treatise.Tags.Aggregate("", (accum, tag) => accum + tag + "\n");
			set => OnPropertyChanged("TagList");
		}

		public ICommand ClosingWindowCommand { get; }

		public ICommand ChangeFilePathCommand { get; }

		public ICommand EditAuthorsCommand { get; }

		public TreatiseFormViewModel(Treatise treatise, TreatiseForm form)
		{
			treatiseBuffer = treatise;
			ClosingWindowCommand = new ClosingWindowCommand(form);
			ChangeFilePathCommand = new ChangeFilePathCommand(this);
			EditAuthorsCommand = new EditAuthorsCommand(this);
		}

		protected void OnPropertyChanged([CallerMemberName] string name = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}
}
