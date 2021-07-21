using System.Data;
using Dapper;
using Microsoft.Extensions.Logging;

namespace SuperSimpleStudySample.App.Pages.Home
{
    
    public class HomeDao
    {
        private ILogger<HomeDao> _logger;

        public HomeDao(ILogger<HomeDao> logger){
            _logger = logger;
        }
        
        public void CreateEmp(IDbConnection con, IDbTransaction tx){
            string sql = @"
create table EMP (
    EMP_CODE    text
   ,FIRST_NAME  text
   ,FAMILY_NAME text
   ,AGE         integer
   ,DEPT_CODE   text
   ,constraint PK_EMP primary key(
       EMP_CODE
   )
)
            ";

            _logger.LogInformation(sql);
            con.Execute(sql, null, tx);
        }
        
        public void DropEmp(IDbConnection con, IDbTransaction tx){
            string sql = @"
drop table if exists EMP;
            ";

            _logger.LogInformation(sql);
            con.Execute(sql, null, tx);
        }

        
        public void CreateDept(IDbConnection con, IDbTransaction tx){
            string sql = @"
create table DEPT (
    DEPT_CODE   text
   ,DEPT_NAME   text
   ,ADDRESS text
   ,constraint PK_DEPT primary key(
       DEPT_CODE
   )
)
            ";

            _logger.LogInformation(sql);
            con.Execute(sql, null, tx);
        }
        
        public void DropDept(IDbConnection con, IDbTransaction tx){
            string sql = @"
drop table if exists DEPT;
            ";

            _logger.LogInformation(sql);
            con.Execute(sql, null, tx);
        }

    }
}