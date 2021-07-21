using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using Microsoft.Extensions.Logging;
using SuperSimpleStudySample.App.Pages.EmpSearch.Spec;

namespace SuperSimpleStudySample.App.Pages.EmpSearch
{
  public class EmpSearchDao
  {

    private ILogger<EmpSearchDao> _logger;

    public EmpSearchDao(ILogger<EmpSearchDao> logger)
    {
      _logger = logger;
    }

    //本当はここまでreqなんか持ってきちゃイカンけど最小サンプルで
    public List<EmpSearchResponseRow> Search(IDbConnection con, IDbTransaction tx, EmpSearchRequest req)
    {
      StringBuilder sql = new StringBuilder();
      sql.Append(@"
select
   E.EMP_CODE    as EmpCode
  ,E.FIRST_NAME  as FirstName
  ,E.FAMILY_NAME as FamilyName
  ,E.AGE         as Age
  ,D.DEPT_NAME   as DeptName
  ,D.ADDRESS     as Address
from
  EMP  E
left outer join
  DEPT D
on (E.DEPT_CODE = D.DEPT_CODE)
where
  1=1
");
      if (!string.IsNullOrEmpty(req.EmpName))
      {
        sql.Append(@"
and (  E.FIRST_NAME like @empName
    or E.FAMILY_NAME like @empName)");
      }
      
      if (!string.IsNullOrEmpty(req.DeptName))
      {
        sql.Append(@"
and (  D.DEPT_NAME like @deptName
    or D.ADDRESS like @deptName)");
      }

      sql.Append(@"
order by
  E.EMP_CODE
");
        var param = new {
            empName = $"%{req.EmpName}%",
            deptName = $"%{req.DeptName}%"
        };

            string sql2 = sql.ToString();
            _logger.LogInformation(sql2);
            _logger.LogInformation(param.ToString());

            return con.Query<EmpSearchResponseRow>(sql2, param, tx).AsList();
        }
  }
}