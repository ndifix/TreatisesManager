using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TreatisesManager.Model
{
	public class Treatise
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public List<string> Authors { get; set; }

		[JsonIgnore]
		public string DisplayAuthorString => Authors.Aggregate("", (accum, name) => accum + name + "; ");

		public string FilePath { get; set; }
	}
}
