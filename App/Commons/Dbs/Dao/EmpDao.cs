using System.Data;
using Dapper;
using Microsoft.Extensions.Logging;
using SuperSimpleStudySample.App.Commons.Dbs.Entity;

namespace SuperSimpleStudySample.App.Commons.Dbs.Dao
{
  public class EmpDao
  {
    private ILogger<EmpDao> _logger;

    public EmpDao(ILogger<EmpDao> logger)
    {
      _logger = logger;
    }

    public int Insert(IDbConnection con, IDbTransaction tx, Emp entity)
    {
      string sql = @"
insert into EMP (
   EMP_CODE
  ,FIRST_NAME
  ,FAMILY_NAME
  ,AGE
  ,DEPT_CODE
) values (
   @EmpCode
  ,@FirstName
  ,@FamilyName
  ,@Age
  ,@DeptCode
)";

      _logger.LogInformation("{0}{1}", sql, entity);

      return con.Execute(sql, entity, tx);
    }

    public Emp FindById(IDbConnection con, IDbTransaction tx, string empCode)
    {
      string sql = @"
select
   EMP_CODE     as EmpCode
  ,FIRST_NAME   as FirstName
  ,FAMILY_NAME  as FamilyName
  ,AGE          as Age
  ,DEPT_CODE    as DeptCode
from
  EMP
where
  EMP_CODE = @empCode
";
      var param = new
      {
        empCode
      };

      return con.QuerySingleOrDefault<Emp>(sql, param, tx);
    }
  }

}