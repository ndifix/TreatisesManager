using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreatisesManager.Model;

namespace TreatisesManager.ViewModel
{
	public class TreatiseFormViewModel
	{
		public Treatise Treatise { get; }

		public string AuthorBuffer { get; set; }

		public TreatiseFormViewModel(Treatise treatise)
		{
			Treatise = treatise;
			AuthorBuffer = string.Empty;
		}

		internal void ClosingWindow()
		{
			if (!string.IsNullOrWhiteSpace(AuthorBuffer))
			{
				Treatise.Authors += AuthorBuffer.Trim() + ";";
			}
		}
	}
}
