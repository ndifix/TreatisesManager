using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreatisesManager.Model;

namespace TreatisesManager.ViewModel
{
	class MainWindowViewModel
	{
		public List<Treatise> Treatises { get; }

		public MainWindowViewModel()
		{
			Treatises = new List<Treatise>();
		}
	}
}
