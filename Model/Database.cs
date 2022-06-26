using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreatisesManager.Model
{
	public static class Database
	{
		private static string connectionString;

		static Database()
		{
			connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
		}

        /// <summary>
        /// データベースから全てを取得します。
        /// </summary>
        /// <param name="treatises">格納する変数。</param>
		public static void SelectAll(ObservableCollection<Treatise> treatises)
		{
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                try
                {
                    // データベースの接続開始
                    connection.Open();

                    // SQLの設定
                    command.CommandText = @"SELECT * FROM Treatise";

                    // SQLの実行
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var treatise = new Treatise()
                            {
                                Id = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                Authors = reader.GetString(2),
                                FilePath = reader.GetString(3),
                            };
                            treatises.Add(treatise);
                        }
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static void Insert(Treatise treatise)
		{
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                try
                {
                    // データベースの接続開始
                    connection.Open();

                    // SQLの準備
                    command.CommandText = @"INSERT INTO Treatise (Id, Title, Author, Path) VALUES (@Id, @Title, @Author, @Path)";
                    command.Parameters.Add(new SqlParameter("@Id", treatise.Id));
                    command.Parameters.Add(new SqlParameter("@Title", treatise.Title));
                    command.Parameters.Add(new SqlParameter("@Author", treatise.Authors));
                    command.Parameters.Add(new SqlParameter("@Path", treatise.FilePath));

                    // SQLの実行
                    command.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
	}
}
