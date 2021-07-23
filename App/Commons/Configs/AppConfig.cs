using Microsoft.Extensions.Configuration;

namespace SuperSimpleStudySample.App.Commons.Configs
{
  public class AppConfig
  {

    private IConfiguration _configuration;

    public AppConfig(
        IConfiguration configuration
    )
    {
      _configuration = configuration;
    }

    public string ConnectionString
    {
      get
      {
        return _configuration.GetSection("Dbs")["ConnectionString"];
      }
    }
  }
}