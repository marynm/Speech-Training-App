using System;
using System.Linq;
using System.Collections.Generic;

using Mono.Data.Sqlite;
using System.IO;
using System.Data;

namespace Project01
{
	/// <summary>
	/// WordDatabase uses ADO.NET to create the [Items] table and create,read,update,delete data
	/// </summary>
	public class WordDatabase 
	{
		static object locker = new object ();

		public SqliteConnection connection;

		public string path;

		/// <summary>
		/// Initializes a new instance of the <see cref="Project01.DL.WordDatabase"/> WordDatabase. 
		/// if the database doesn't exist, it will create the database and all the tables.
		/// </summary>
		public WordDatabase (string dbPath) 
		{
			var output = "";
			path = dbPath;
			// create the tables
			bool exists = File.Exists (dbPath);

			if (!exists) {
				connection = new SqliteConnection ("Data Source=" + dbPath);

				connection.Open ();
				var commands = new[] {
					"CREATE TABLE [Items] (_id INTEGER PRIMARY KEY ASC, Tone INTEGER, Word NTEXT, Translation NTEXT, Score INTEGER, Sound INTEGER, Character NTEXT);"
				};
				foreach (var command in commands) {
					using (var c = connection.CreateCommand ()) {
						c.CommandText = command;
						var i = c.ExecuteNonQuery ();
					}
				}
			} else {
				// already exists, do nothing. 
			}
			Console.WriteLine (output);
		}

		/// <summary>Convert from DataReader to word object</summary>
		word FromReader (SqliteDataReader r) {
			var t = new word ();
			t.ID = Convert.ToInt32 (r ["_id"]);
			t.Word = r ["Word"].ToString ();
			t.Translation = r ["Translation"].ToString ();
			//t.currentScore.Total = Convert.ToInt32( r ["Score"]); //Convert.ToInt32 (r ["Score"]) == 1 ? true : false;
			return t;
		}

		public IEnumerable<word> GetItems ()
		{
			var tl = new List<word> ();

			lock (locker) {
				connection = new SqliteConnection ("Data Source=" + path);
				connection.Open ();
				using (var contents = connection.CreateCommand ()) {
					contents.CommandText = "SELECT [_id], [Word], [Translation], [Tone], [Character] from [Items]";
					var r = contents.ExecuteReader ();
					while (r.Read ()) {
						tl.Add (FromReader(r));
					}
				}
				connection.Close ();
			}
			return tl;
		}

		public word GetItem (int id) 
		{
			var t = new word ();
			lock (locker) {
				connection = new SqliteConnection ("Data Source=" + path);
				connection.Open ();
				using (var command = connection.CreateCommand ()) {
					command.CommandText = "SELECT [_id], [Word], [Translation], [Tone], [Sound], [Score] from [Items] WHERE [_id] = ?";
					command.Parameters.Add (new SqliteParameter (DbType.Int32) { Value = id });
					var r = command.ExecuteReader ();
					while (r.Read ()) {
						t = FromReader (r);
						break;
					}
				}
				connection.Close ();
			}
			return t;
		}

		public int SaveItem (word item) 
		{
			int r;
			lock (locker) {
				if (item.ID != 0) {
					connection = new SqliteConnection ("Data Source=" + path);
					connection.Open ();
					using (var command = connection.CreateCommand ()) {
						command.CommandText = "UPDATE [Items] SET [Word] = ?, [Tone] = ?, [Character] = ?, [Translation] = ?, [Sound] = ?, [Score] = ? WHERE [_id] = ?;";
						command.Parameters.Add (new SqliteParameter (DbType.String) { Value = item.Word });
						command.Parameters.Add (new SqliteParameter (DbType.Int32) { Value = item.Tone });
						command.Parameters.Add (new SqliteParameter (DbType.String) { Value = item.Chatacter });
						command.Parameters.Add (new SqliteParameter (DbType.String) { Value = item.Translation });
						command.Parameters.Add (new SqliteParameter (DbType.Int32) { Value = item.Sound });
						command.Parameters.Add (new SqliteParameter (DbType.Int32) { Value = item.Score });
						command.Parameters.Add (new SqliteParameter (DbType.Int32) { Value = item.ID });
						r = command.ExecuteNonQuery ();
					}
					connection.Close ();
					return r;
				} else {
					connection = new SqliteConnection ("Data Source=" + path);
					connection.Open ();
					using (var command = connection.CreateCommand ()) {
						command.CommandText = "INSERT INTO [Items] ([Word], [Tone], [Character], [Translation], [Sound]) VALUES (? ,?, ?, ?, ?)";
						command.Parameters.Add (new SqliteParameter (DbType.String) { Value = item.Word });
						command.Parameters.Add (new SqliteParameter (DbType.Int32) { Value = item.Tone });
						command.Parameters.Add (new SqliteParameter (DbType.String) { Value = item.Chatacter });
						command.Parameters.Add (new SqliteParameter (DbType.String) { Value = item.Translation });
						command.Parameters.Add (new SqliteParameter (DbType.Int32) { Value = item.Sound });
						r = command.ExecuteNonQuery ();
					}
					connection.Close ();
					return r;
				}

			}
		}

		public int DeleteItem(int id) 
		{
			lock (locker) {
				int r;
				connection = new SqliteConnection ("Data Source=" + path);
				connection.Open ();
				using (var command = connection.CreateCommand ()) {
					command.CommandText = "DELETE FROM [Items] WHERE [_id] = ?;";
					command.Parameters.Add (new SqliteParameter (DbType.Int32) { Value = id});
					r = command.ExecuteNonQuery ();
				}
				connection.Close ();
				return r;
			}
		}

	}
}