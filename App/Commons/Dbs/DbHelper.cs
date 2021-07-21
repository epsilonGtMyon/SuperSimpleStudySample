using System.Data;
using Microsoft.Data.Sqlite;

namespace SuperSimpleStudySample.App.Commons.Dbs
{
  public class DbHelper
  {

    public IDbConnection GetConnection()
    {
      IDbConnection con = new SqliteConnection("Data Source=Application.db");
      con.Open();
      return con;
    }
  }
}