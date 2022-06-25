using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreatisesManager.Model
{
	public class Treatise
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Authors { get; set; }

		public string FilePath { get; set; }
	}
}
