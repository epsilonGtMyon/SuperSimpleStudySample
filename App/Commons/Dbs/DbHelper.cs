using System.Data;
using Microsoft.Data.Sqlite;
using SuperSimpleStudySample.App.Commons.Configs;

namespace SuperSimpleStudySample.App.Commons.Dbs
{
  public class DbHelper
  {
    private AppConfig _appConfig;

    public DbHelper(
      AppConfig appConfig
    )
    {
      _appConfig = appConfig;
    }

    public IDbConnection GetConnection()
    {
      IDbConnection con = new SqliteConnection(_appConfig.ConnectionString);
      con.Open();
      return con;
    }
  }
}