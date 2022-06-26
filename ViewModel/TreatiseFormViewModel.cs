using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreatisesManager.Model;
using TreatisesManager.Command.TreatiseForm;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TreatisesManager.ViewModel
{
	public class TreatiseFormViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public Treatise Treatise { get; }

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
			get => authorListString;
			set
			{
				authorListString = value;
				OnPropertyChanged("AuthorList");
			}
		}
		private string authorListString;

		public ICommand AppendAuthorCommand { get; }

		public TreatiseFormViewModel(Treatise treatise)
		{
			Treatise = treatise;
			AuthorBuffer = string.Empty;
			AuthorList = string.Empty;
			AppendAuthorCommand = new AppendAuthorCommand(this);
		}

		internal void ClosingWindow()
		{
			if (!string.IsNullOrWhiteSpace(AuthorBuffer))
			{
				Treatise.Authors += AuthorBuffer.Trim() + ";";
			}
		}
		protected void OnPropertyChanged([CallerMemberName] string name = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}
}
