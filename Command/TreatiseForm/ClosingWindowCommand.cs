using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TreatisesManager.Model;

namespace TreatisesManager.Command.TreatiseForm
{
	class ClosingWindowCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;

		private readonly View.TreatiseForm window;

		public ClosingWindowCommand(View.TreatiseForm window)
		{
			this.window = window;
		}

		public bool CanExecute(object parameter) => true;

		public void Execute(object parameter) => window.Close();
	}
}
