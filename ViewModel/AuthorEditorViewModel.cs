using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreatisesManager.ViewModel
{
	internal class AuthorEditorViewModel
	{
		private readonly List<string> authors;

		public List<Item> Items { get; }

		public AuthorEditorViewModel(List<string> authors)
		{
			this.authors = authors;
			Items = authors.Select(a => new Item { Checked = false, Name = a })
				.ToList();
		}

		internal class Item
		{
			public bool Checked { get; set; }

			public string Name { get; set; }
		}
	}
}
