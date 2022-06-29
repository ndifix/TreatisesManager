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
		private readonly string filePath = @"treatises.json.gz";

		public async Task GetTreatisesAsync(ObservableCollection<Treatise> treatises)
		{
			if (!File.Exists(filePath))
			{
				File.Create(filePath);
				File.SetAttributes(filePath, FileAttributes.Hidden);
				return;
			}

			using (var fs = File.OpenRead(filePath))
			using (var gzs = new GZipStream(fs, CompressionMode.Decompress))
			{
				try
				{
					using (var ms = new MemoryStream())
					{
						await gzs.CopyToAsync(ms);
						string jsonText = Encoding.UTF8.GetString(ms.ToArray());
						var treatisesBuf = JsonSerializer.Deserialize<ObservableCollection<Treatise>>(jsonText);
						foreach (var treatise in treatisesBuf)
						{
							treatises.Add(treatise);
						}
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
			using (var gzs = new GZipStream(fs, CompressionMode.Compress))
			{
				try
				{
					string text = JsonSerializer.Serialize(treatises);
					byte[] jsonBytes = Encoding.UTF8.GetBytes(text);
					await gzs.WriteAsync(jsonBytes, 0, jsonBytes.Length);
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
