﻿using System;
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
			get => Treatise.Authors.Aggregate("", (accum, name) => accum + name + "\n");
			set => OnPropertyChanged("AuthorList");
		}

		public ICommand AppendAuthorCommand { get; }

		public TreatiseFormViewModel(Treatise treatise)
		{
			Treatise = treatise;
			AuthorBuffer = string.Empty;
			AppendAuthorCommand = new AppendAuthorCommand(this);
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
