using System.Collections.Generic;
using System.Data;
using Dapper;
using Microsoft.Extensions.Logging;
using SuperSimpleStudySample.App.Commons.Dbs.Entity;

namespace SuperSimpleStudySample.App.Commons.Dbs.Dao
{
  public class DeptDao
  {
    private ILogger<DeptDao> _logger;

    public DeptDao(ILogger<DeptDao> logger)
    {
      _logger = logger;
    }

    public int Insert(IDbConnection con, IDbTransaction tx, Dept entity)
    {
      string sql = @"
insert into DEPT (
   DEPT_CODE
  ,DEPT_NAME
  ,ADDRESS
) values (
   @DeptCode
  ,@DeptName
  ,@Address
)
            ";

      _logger.LogInformation("{0}{1}", sql, entity.ToString());

      return con.Execute(sql, entity, tx);
    }

    public List<Dept> FindAll(IDbConnection con, IDbTransaction tx)
    {
      string sql = @"
select
   DEPT_CODE as DeptCode
  ,DEPT_NAME as DeptName
  ,ADDRESS   as Address
from
  DEPT
order by
  DEPT_CODE
";

      _logger.LogInformation("{0}", sql);
      return con.Query<Dept>(sql, null, tx).AsList();
    }
  }
}