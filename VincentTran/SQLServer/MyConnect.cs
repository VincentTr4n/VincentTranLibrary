using System;
using System.Data.SqlClient;
using System.Data;
using VincentTran.Helpers.Strings;

namespace VincentTran.SQLServer
{
	/// <summary>
	/// This class supports connection, execute query in database with C#
	/// 1) Connect to database
	/// 2) Get a DataTable from simple query
	/// 3) Execute quey
	/// </summary>
	public class MyConnect : IDisposable
	{
		#region Elements
		string _strCon = "";
		public string strCon { get { return _strCon; } set { _strCon = value; } }
		public IDbConnection connection { get; set; }
		#endregion

		#region Constructor
		public MyConnect(string strConnection) : this(strConnection, false) { }
		public MyConnect(string StrConnOrDBName,bool isDBName)
		{
			if (isDBName) _strCon = "Data Source=.;Initial Catalog=" + StrConnOrDBName + ";Integrated Security=True";
			else _strCon = StrConnOrDBName;
		}
		#endregion

		#region Connect/Disconnect 
		public void connect()
		{
			connection = new SqlConnection(_strCon);
			if (connection.State != ConnectionState.Open) connection.Open();
		}
		public void disconnect()
		{
			if (connection.State != ConnectionState.Closed)
			{
				connection.Close();
				connection.Dispose();
			}
		}
		#endregion

		#region Main
		/// <summary>
		/// Get a Table from Database by simple quey and collection paramenter
		/// Note: Should use a procedure for speed and ez to use
		/// </summary>
		/// <param name="query"></param>
		/// <param name="parameter"></param>
		/// <returns></returns>

		public DataTable getTable(string query, object[] parameter = null)
		{
			DataTable table = new DataTable();
			connect();
			SqlDataAdapter adapter = new SqlDataAdapter(query.CreateQuery(parameter), (SqlConnection)connection);
			adapter.Fill(table);
			adapter.Dispose();
			disconnect();
			return table;
		}

		/// <summary>
		/// Execute insert,update,delete or procedure
		/// Note: Should use a procedure for speed and ez to use
		/// </summary>
		/// <param name="query"></param>
		/// <param name="parameter"></param>
		/// <returns></returns>

		public bool Execute(string query, object[] parameter = null)
		{
			try
			{
				using (SqlCommand cmd = new SqlCommand(query.CreateQuery(parameter), (SqlConnection)connection))
				{
					connect();
					cmd.ExecuteNonQuery();
					disconnect();
				}
			}
			catch
			{
				return false;
			}
			return true;
		}
		#endregion

		#region IDisposable helper
		void IDisposable.Dispose()
		{
			disconnect();
		} 
		#endregion

	}
}
