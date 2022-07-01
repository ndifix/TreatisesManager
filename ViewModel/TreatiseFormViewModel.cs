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

		public string AuthorBuffer
		{
			get => authorBufferString;
			set
			{
				authorBufferString = value;
				OnPropertyChanged("AuthorBuffer");
			}
		}
		private string authorBufferString;

		public string AuthorList
		{
			get => Treatise.Authors.Aggregate("", (accum, name) => accum + name + "\n");
			set => OnPropertyChanged("AuthorList");
		}

		public ICommand AppendAuthorCommand { get; }

		public ICommand ClosingWindowCommand { get; }

		public ICommand ChangeFilePathCommand { get; }

		public ICommand EditAuthorsCommand { get; }

		public TreatiseFormViewModel(Treatise treatise, TreatiseForm form)
		{
			treatiseBuffer = treatise;
			AuthorBuffer = string.Empty;
			AppendAuthorCommand = new AppendAuthorCommand(this);
			ClosingWindowCommand = new ClosingWindowCommand(form);
			ChangeFilePathCommand = new ChangeFilePathCommand(this);
			EditAuthorsCommand = new EditAuthorsCommand(this);
		}

		internal void ClosingWindow()
		{
			if (!string.IsNullOrWhiteSpace(AuthorBuffer))
			{
				Treatise.Authors.Add(AuthorBuffer.Trim());
			}
		}

		protected void OnPropertyChanged([CallerMemberName] string name = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}
}
