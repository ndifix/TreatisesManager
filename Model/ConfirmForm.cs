using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TreatisesManager.Model
{
	static class ConfirmForm
	{
		public static bool ConfirmYesNo(string message)
		{
			var result = MessageBox.Show(
				message, "",
				MessageBoxButton.YesNo,
				MessageBoxImage.Exclamation);
			return result == MessageBoxResult.Yes;
		}
	}
}
