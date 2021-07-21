using System.Data;
using Dapper;
using Microsoft.Extensions.Logging;
using SuperSimpleStudySample.App.Commons.Dbs.Entity;

namespace SuperSimpleStudySample.App.Commons.Dbs.Dao
{
    public class EmpDao
    {
        private ILogger<EmpDao> _logger;

        public EmpDao(ILogger<EmpDao> logger){
            _logger = logger;
        }

        public int Insert(IDbConnection con, IDbTransaction tx, Emp entity){
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

            _logger.LogInformation(sql);
            _logger.LogInformation(entity.ToString());

            return con.Execute(sql, entity, tx);
        }
    }
}