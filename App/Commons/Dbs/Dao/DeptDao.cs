using System.Data;
using Dapper;
using Microsoft.Extensions.Logging;
using SuperSimpleStudySample.App.Commons.Dbs.Entity;

namespace SuperSimpleStudySample.App.Commons.Dbs.Dao
{
    public class DeptDao
    {
        private ILogger<DeptDao> _logger;

        public DeptDao(ILogger<DeptDao> logger){
            _logger = logger;
        }

        public int Insert(IDbConnection con, IDbTransaction tx, Dept entity){
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

            _logger.LogInformation(sql);
            _logger.LogInformation(entity.ToString());

            return con.Execute(sql, entity, tx);
        }
    }
}