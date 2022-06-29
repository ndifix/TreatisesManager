using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace TreatisesManager.Model
{
	internal class TreatiseCache
	{
		private readonly string filePath = @"treatises.cache";

		public async Task GetTreatisesAsync(ObservableCollection<Treatise> treatises)
		{
			if (!File.Exists(filePath))
			{
				File.Create(filePath);
				File.SetAttributes(filePath, FileAttributes.Hidden);
				return;
			}

			using (var fs = File.OpenRead(filePath))
			using (var sr = new StreamReader(fs))
			{
				try
				{
					string jsonText = await sr.ReadToEndAsync();

					JsonSerializerOptions option = new JsonSerializerOptions()
					{
						Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
					};

					var treatisesBuf = JsonSerializer.Deserialize<ObservableCollection<Treatise>>(jsonText, option);
					foreach (var treatise in treatisesBuf)
					{
						treatises.Add(treatise);
					}
				}
				catch (TaskCanceledException)
				{ }
				catch (Exception e)
				{
					MessageBox.Show($"Failed to read saved treatises list: {e.Message}");
				}
			}
		}

		public async Task SaveTreatisesAsync(ObservableCollection<Treatise> treatises)
		{
			using (var fs = File.OpenWrite(filePath))
			using (var sw = new StreamWriter(fs))
			{
				try
				{
					string text = JsonSerializer.Serialize(treatises);
					await sw.WriteAsync(text);
				}
				catch (TaskCanceledException)
				{ }
				catch (Exception e)
				{
					MessageBox.Show($"Failed to save treatises list: {e.Message}");
					throw;
				}
			}
		}
	}
}
