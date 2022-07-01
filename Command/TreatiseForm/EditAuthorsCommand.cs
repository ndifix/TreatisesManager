using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using TreatisesManager.View;
using TreatisesManager.ViewModel;

namespace TreatisesManager.Command.TreatiseForm
{
	public partial class EditAuthorsCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter) => true;

		private readonly List<string> authors;

		public EditAuthorsCommand(List<string> authors)
		{
			this.authors = authors;
		}

		public void Execute(object parameter)
		{
			Window editor = new AuthorEditor(authors);
			editor.ShowDialog();
		}
	}
}
